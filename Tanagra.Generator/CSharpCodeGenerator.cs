using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanagra.Generator
{
    // Notes:
    //  - By default, structures use "copy" behaviour on assignment ie; the struct's data is copied
    //    to a new struct instance and then assigned. So using a simmilar copy method in the interop
    //    layer actually maintains expected functionality
    public class CSharpCodeGenerator
    {
        class GeneratedObjectInfo
        {
            public string Name;
            public string Contents;

            public GeneratedObjectInfo(string name, string contents)
            {
                Name = name;
                Contents = contents;
            }
        }

        class CommandInfo
        {
            public bool ReturnsList;
            public VkParam ReturnParam;
            public VkParam ReturnListCountParam;
            public VkMember ReturnListCountMember;
            public bool ReturnListHasKnownLength;
            public List<VkParam> InternalParams;
            public Dictionary<VkParam, VkParam> ParamListCountMap;
            public string ReturnType;
            public bool InternalReturnsVkResult;
            public VkParam LastParam;
            public bool HasReturnValue;
            public IEnumerable<VkParam> ParamArrays;
            public bool HasArrayParams;

            public CommandInfo()
            {
                InternalParams = new List<VkParam>();
                ParamListCountMap = new Dictionary<VkParam, VkParam>();
            }

        }

        StringBuilder _sb;
        int _tabs;

        public string DllName = "vulkan-1-1-0-8-0.dll";
        readonly List<string> platformStructTypes;
        readonly List<string> disabledStructs;
        readonly List<string> disabledCommands;
        readonly List<string> isFixedRange;
        readonly List<string> isFixedVector;
        readonly List<string> isFixedColor;

        public Dictionary<string, string> files;

        const string NativePointer           = "NativePointer";
        const string CallingConvention       = "Winapi";
        const string VulkanResultException   = "VulkanCommandException";
        const string AllocateFnName          = "MemUtil.Alloc";
        const string FreeFnName              = "MemUtil.Free";
        const string FixedSizeStringFnName   = "MemUtil.MarshalFixedSizeString";
        const string ManagedNS               = "Managed";
        const string ManagedFunctionsClass   = "Vk";
        const string UnmanagedNS             = "Unmanaged";
        const string UnmanagedFunctionsClass = "VulkanBinding";
        const string ObjectModelNS           = "ObjectModel";
        const string LineEnding              = "\n";

        bool CombineFiles;

        public CSharpCodeGenerator()
        {
            _sb = new StringBuilder();
            files = new Dictionary<string, string>();

            platformStructTypes = new List<string>
            {
                "IntPtr",
                "String",
                "Single",
                "Byte",
                "Int32",
                "UInt32",
                "UInt64",
                //"UIntPtr",
                "Boolean",
                "Bool32",
                "DeviceSize",
            };

            disabledStructs = new List<string> 
            {
                "ClearValue",
                "ClearColorValue"
            };

            disabledCommands = new List<string>
            {
            };

            isFixedRange = new List<string>
            {
                "ViewportBoundsRange",
                "PointSizeRange",
                "LineWidthRange",
            };

            isFixedVector = new List<string>
            {
                "MaxComputeWorkGroupCount",
                "MaxComputeWorkGroupSize",
                "MaxViewportDimensions" // vec2
            };

            isFixedColor = new List<string>
            {
                "BlendConstants",
                "Color",
            };
        }

        public void Generate(VkSpec spec)
        {
            //
            // Ideally `CSharpCodeGenerator` transforms the data as little as possible. It
            // should only transform data if doing so in the rewrite step is awkward or impossible.
            //

            var commands = spec.Commands.Where(x => !disabledCommands.Contains(x.Name)).ToList();
            var commandInfoMap = commands.ToDictionary(vkCommand => vkCommand, CreateCommandInfo);

            var apiConstants = spec.Enums.First(x => x.Name == "API Constants");
            files.Add("./VulkanConstant.cs", GenerateConstants(apiConstants));

            foreach(var vkEnum in spec.Enums.Where(vkEnum => vkEnum.Name != "API Constants"))
                files.Add($"./Enum/{vkEnum.Name}.cs", GenerateEnum(vkEnum));
            
            foreach(var vkSpec in spec.Handles)
                files.Add($"./Handle/{vkSpec.Name}.cs", GenerateHandle(vkSpec));

            // -- struct
            
            var needsInteropStruct = spec.Structs.Where(IsManagedStruct);
            files.Add($"./{UnmanagedNS}/Structs.cs", GenerateStructs(needsInteropStruct, false));

            var regularStruct = spec.Structs.Except(needsInteropStruct).Where(x => !disabledStructs.Contains(x.Name));
            files.Add("./Structs.cs", GenerateStructs(regularStruct, true));

            // -- vk
            files.Add($"./{UnmanagedNS}/{UnmanagedFunctionsClass}.cs", GenerateCommandBindings(commands));

            var generateWrapper = needsInteropStruct.Where(vkStruct => !IsPlatformStruct(vkStruct) && !disabledStructs.Contains(vkStruct.Name));
            foreach (var vkStruct in generateWrapper)
                files.Add($"./{ManagedNS}/Class/{vkStruct.Name}.cs", GenerateManagedClass(vkStruct));

            files.Add($"./{ManagedNS}/{ManagedFunctionsClass}.cs", GenerateManagedCommand(commands, commandInfoMap));

            files.Add($"./{ManagedNS}/ObjectModel.cs", GenerateHandleExtensions("HandleExtensions", spec.Handles, commands, commandInfoMap));
        }
        
        string GenerateConstants(VkEnum apiConstants)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteBeginBlock();
            WriteLine("public static class VulkanConstant");
            WriteBeginBlock();
            foreach(var vkEnumValue in apiConstants.Values.Where(x => x.Name != "True" && x.Name != "False"))
            {
                var constType = "String";
                var constValue = $"\"{vkEnumValue.Value}\"";
                var integerValue = 0;
                if (Int32.TryParse(vkEnumValue.Value, out integerValue))
                {
                    constType = "Int32";
                    constValue = integerValue.ToString();
                }
                WriteLine($"public const {constType} {vkEnumValue.Name} = {constValue};");
            }
            WriteEndBlock();
            WriteEndBlock();

            return _sb.ToString();
        }

        string GenerateEnum(VkEnum vkEnum)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteBeginBlock();
            if (!string.IsNullOrEmpty(vkEnum.Comment))
            {
                WriteLine("/// <summary>");
                WriteLine($"/// {vkEnum.Comment}");
                WriteLine("/// </summary>");
            }

            if (vkEnum.IsBitmask)
                WriteLine("[Flags]");

            WriteLine($"public enum {vkEnum.Name}"); // : int
            WriteBeginBlock();

            if(vkEnum.IsBitmask || vkEnum.Values.Any(x => x.Name == "None"))
                WriteLine("None = 0,");

            foreach(var vkEnumValue in vkEnum.Values.Where(x => x.Name != "None"))
            {
                var comment = vkEnumValue.Comment;
                if(!string.IsNullOrEmpty(comment))
                {
                    WriteLine("/// <summary>");
                    WriteLine($"/// {comment}");
                    WriteLine("/// </summary>");
                }
                var mask = (vkEnum.IsBitmask) ? "1 << " : string.Empty;
                WriteLine($"{vkEnumValue.Name} = {mask}{vkEnumValue.Value},");
            }
            WriteEndBlock();
            WriteEndBlock();

            return _sb.ToString();
        }
        
        string GenerateHandle(VkHandle vkHandle)
        {
            var name = vkHandle.Name;
            var type = GetHandleType(vkHandle);
            var strDispatch = (vkHandle.IsDispatchable) ? "Dispatchable" : "Nondispatchable";
            var parent = !string.IsNullOrEmpty(vkHandle.Parent) ? $" Child of <see cref=\"{vkHandle.Parent.Remove(0,2)}\"/>." : string.Empty;

            Clear();

            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteBeginBlock();
            WriteLine("/// <summary>");
            WriteLine($"/// Vulkan handle. {strDispatch}.{parent}");
            WriteLine("/// </summary>");
            WriteLine($"public class {name}");
            WriteBeginBlock();
            WriteLine($"internal {type} {NativePointer};");
            WriteLine("");
            WriteLine($"public override string ToString() => \"{name} 0x\" + {NativePointer}.ToString(\"X8\");");
            WriteEndBlock();
            WriteEndBlock();

            return _sb.ToString();
        }
        
        string GenerateStructs(IEnumerable<VkStruct> vkStructs, bool isPublic)
        {
            var structs = vkStructs
                .Where(x => !IsPlatformStruct(x))
                .Select(x => new GeneratedObjectInfo(x.Name, GenerateStruct(x, isPublic)))
                .ToArray();
            
            var structNamespace = $"Vulkan{((!isPublic) ? $".{UnmanagedNS}" : string.Empty)}";
            var structUsing = new[] { "System" };

            if(CombineFiles)
            {

            }
            else
            {
                var files = structs.Select(x => CreateFile($"{x.Name}.cs", structNamespace, structUsing, x));
            }

            return CreateFile("Structs.cs", structNamespace, structUsing, structs).Contents;
        }

        string GenerateStruct(VkStruct vkStruct, bool isPublic)
        {
            Clear();

            var vis = "public";//isPublic ? "public" : "internal";

            if(vkStruct.ReturnedOnly)
            {
                WriteLine("/// <summary>");
                WriteLine("/// Returned Only - This object is never given as input to a Vulkan function");
                WriteLine("/// </summary>");
            }

            WriteLine($"{vis} struct {vkStruct.Name}");
            WriteBeginBlock();

            // Is this really the best workaround? ...
            #region Fixed
            var fixedTypes = vkStruct.Members.Where(x => x.IsFixedSize);
            if (fixedTypes.Any())
            {
                foreach (var vkFixedMember in fixedTypes)
                {
                    if (vkFixedMember.Type.Name == "String")
                        continue;
                    
                    WriteLine($"public struct {vkFixedMember.Name}Info");
                    WriteBeginBlock();
                    if (isFixedRange.Contains(vkFixedMember.Name))
                    {
                        WriteLine($"public {vkFixedMember.Type} Min;");
                        WriteLine($"public {vkFixedMember.Type} Max;");
                    }
                    else if (isFixedVector.Contains(vkFixedMember.Name))
                    {
                        WriteLine($"public {vkFixedMember.Type} X;");
                        WriteLine($"public {vkFixedMember.Type} Y;");
                        if (vkFixedMember.Name != "MaxViewportDimensions")
                            WriteLine($"public {vkFixedMember.Type} Z;");
                    }
                    else if (isFixedColor.Contains(vkFixedMember.Name))
                    {
                        WriteLine($"public {vkFixedMember.Type} R;");
                        WriteLine($"public {vkFixedMember.Type} G;");
                        WriteLine($"public {vkFixedMember.Type} B;");
                        WriteLine($"public {vkFixedMember.Type} A;");
                    }
                    else
                    {
                        var fixedSize = int.Parse(vkFixedMember.FixedSize);
                        WriteLine($"public const UInt32 Length = {fixedSize};");
                        WriteLine("");
                        for (var x = 0; x < fixedSize; x++)
                            WriteLine($"public {vkFixedMember.Type} Value{x.ToString("D2")};");
                        
                        WriteLine("");
                        WriteLine($"public {vkFixedMember.Type} this[uint key]");
                        WriteBeginBlock();
                        WriteLine("get");
                        WriteBeginBlock();
                        WriteLine("switch(key)");
                        WriteBeginBlock();
                        WriteLine("default: throw new IndexOutOfRangeException();");
                        for(var x = 0; x < fixedSize; x++)
                            WriteLine($"case {x}: return Value{x.ToString("D2")};");
                        
                        WriteEndBlock();
                        WriteEndBlock();
                        WriteEndBlock();
                    }
                    WriteEndBlock();
                }
            }
            #endregion

            foreach(var vkMember in vkStruct.Members)
            {
                WriteMemberComments(vkMember);

                if(vkMember.IsFixedSize)
                {
                    WriteLine(vkMember.Type.Name == "String"
                        ? $"public unsafe fixed Byte {vkMember.Name}[{vkMember.FixedSize}];"
                        : $"public {vkMember.Name}Info {vkMember.Name};");
                    continue;
                }

                if(vkMember.IsArray || vkMember.IsPointer || vkMember.Type.Name == "String")
                {
                    WriteLine($"public IntPtr {vkMember.Name};");
                    continue;
                }
                
                if (IsNondispatchableHandle(vkMember.Type))
                {
                    WriteLine($"public UInt64 {vkMember.Name};");
                    continue;
                }

                WriteLine($"public {vkMember.Type} {vkMember.Name};");
            }
            
            // For public structs that are not returned (only) and contain members
            // marked as 'mandatory' by the spec (the spec actually marks members as optional)
            // generate a constructor that takes all the mandatory members as arguments. 
            // This is actually pretty good at generating useful constructors.
            if(isPublic && !vkStruct.ReturnedOnly && vkStruct.Name != "PhysicalDeviceFeatures")
            {
                var mandatoryMembers = vkStruct.Members.Where(x => x.Optional != "true").ToArray();
                var optionalMembers  = vkStruct.Members.Except(mandatoryMembers).ToArray();

                if(mandatoryMembers.Any())
                {
                    var mandatoryMemberStrings = new List<string>();
                    foreach (var member in mandatoryMembers)
                    {
                        if (member.IsFixedSize)
                        {
                            mandatoryMemberStrings.Add($"{member.Name}Info {member.Name}");
                            continue;
                        }
                        mandatoryMemberStrings.Add($"{member.Type} {member.Name}");
                    }

                    WriteLine("");
                    WriteLine($"public {vkStruct.Name}({string.Join(", ", mandatoryMemberStrings)})");
                    WriteBeginBlock();

                    foreach(var vkMember in mandatoryMembers)
                        WriteLine($"this.{vkMember.Name} = {vkMember.Name};");

                    // Assign default values to the optional members
                    foreach(var vkMember in optionalMembers)
                        WriteLine($"{vkMember.Name} = default({vkMember.Type});");

                    WriteEndBlock();
                }
            }

            WriteEndBlock();
            
            return _sb.ToString();
        }
        
        string GenerateCommandBindings(IEnumerable<VkCommand> commands)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine($"namespace Vulkan.{UnmanagedNS}");
            WriteBeginBlock();
            WriteLine($"public unsafe static class {UnmanagedFunctionsClass}");
            WriteBeginBlock();
            WriteLine($"const string DllName = \"{DllName}\";");
            WriteLine($"const CallingConvention callingConvention = CallingConvention.{CallingConvention};");
            WriteLine("");
            foreach(var vkCommand in commands)
            {
                var returnType = (vkCommand.ReturnType != null) ? vkCommand.ReturnType.Name : "void";

                WriteCommandComment(vkCommand, vkCommand.Parameters);
                WriteLine($"[DllImport(DllName, EntryPoint = \"{vkCommand.SpecName}\", CallingConvention = callingConvention)]");
                WriteTabs();
                Write("public static ");
                Write($"extern {returnType} {vkCommand.SpecName}");
                Write("(");
                for(var x = 0; x < vkCommand.Parameters.Length; x++)
                {
                    var param = vkCommand.Parameters[x];
                    var paramType = param.Type.Name;
                    if (param.Type is VkHandle)
                        paramType = GetHandleType((VkHandle)param.Type);
                    
                    var pointer = (param.IsPointer && paramType != "String") ? "*" : string.Empty;
                    Write($"{paramType}{pointer} {param.Name}");
                    
                    if(x + 1 < vkCommand.Parameters.Length)
                        Write(", ");
                }
                Write(");");
                Write(LineEnding);
                WriteLine("");
            }
            WriteEndBlock();
            WriteEndBlock();

            return _sb.ToString();
        }

        #region Generate Managed Class

        string GenerateManagedClass(VkStruct vkStruct)
        {
            var hiddenMembers = new HashSet<string>();
            foreach (var vkMember in vkStruct.Members)
            {
                if (vkMember.Len.Length == 0)
                    continue;

                var memberCountName = vkMember.Len[0];
                var isCountMember = vkStruct.Members.Any(x => x.Name == memberCountName);
                if(isCountMember && !hiddenMembers.Contains(vkStruct.Name))
                    hiddenMembers.Add(memberCountName);
            }

            if (vkStruct.IsExtensible)
            {
                hiddenMembers.Add("Next");
                hiddenMembers.Add("SType");
            }

            Clear();
            
            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine($"namespace Vulkan.{ManagedNS}");
            WriteBeginBlock();
            if(vkStruct.ReturnedOnly)
            {
                WriteLine("/// <summary>");
                WriteLine("/// Returned Only - This object is never given as input to a Vulkan function");
                WriteLine("/// </summary>");
            }
            WriteLine($"unsafe public class {vkStruct.Name} : IDisposable");
            WriteBeginBlock();
            WriteLine($"internal {UnmanagedNS}.{vkStruct.Name}* {NativePointer};");
            WriteLine("");

            #region Write Members
            foreach(var vkMember in vkStruct.Members.Where(x => !hiddenMembers.Contains(x.Name)))
            {
                if (vkMember.Type.Name == "String")
                {
                    if (vkMember.Len.Length > 1)
                    {
                        WriteMemberStringArray(vkMember, vkStruct.ReturnedOnly);
                    }
                    else
                    {
                        WriteMemberString(vkMember, vkStruct.ReturnedOnly);
                    }
                    WriteLine("");
                    continue;
                }

                if(vkMember.IsArray)
                {
                    if (vkMember.IsFixedSize)
                    {
                        WriteMemberComments(vkMember);
                        var prefix = string.Empty;
                        if (IsManagedStruct(vkStruct))
                            prefix = $"{UnmanagedNS}.{vkStruct.Name}.";
                        WriteLine($"public {prefix}{vkMember.Name}Info {vkMember.Name}");
                        WriteBeginBlock();
                        WriteLine($"get {{ return {NativePointer}->{vkMember.Name}; }}");
                        if (!vkStruct.ReturnedOnly)
                            WriteLine($"set {{ {NativePointer}->{vkMember.Name} = value; }}");
                        WriteEndBlock();
                        WriteLine("");
                        continue;
                    }

                    WriteMemeberArray(vkMember, vkStruct.ReturnedOnly);
                    WriteLine("");
                    continue;
                }

                // If the member is a value type or an enum
                if (IsPlatformStruct(vkMember.Type) || vkMember.Type is VkEnum)
                {
                    WriteMember(vkMember, vkStruct.ReturnedOnly);
                    WriteLine("");
                    continue;
                }
                
                WriteMemberStruct(vkMember, vkStruct.ReturnedOnly);
                WriteLine("");
            }
            #endregion

            #region Write constructors
            // Give returned-only wrapper classes an internal constructor, meaning that
            // only internal assembly can create new instances of it (neat!)
            var cotorVis = (vkStruct.ReturnedOnly) ? "internal" : "public";
            WriteLine($"{cotorVis} {vkStruct.Name}()");
            WriteBeginBlock();
            WriteLine($"{NativePointer} = ({UnmanagedNS}.{vkStruct.Name}*){AllocateFnName}(typeof({UnmanagedNS}.{vkStruct.Name}));");
            if (vkStruct.IsExtensible)
                WriteLine($"{NativePointer}->SType = StructureType.{vkStruct.Name};");
            WriteEndBlock();
            
            // internal constructor for clone operation
            /*WriteLine("");
            WriteLine($"internal {vkStruct.Name}({UnmanagedNS}.{vkStruct.Name}* ptr)");
            WriteBeginBlock();
            WriteLine($"{NativePointer} = ptr;");
            WriteEndBlock();*/

            // Unless the underlying struct is returned-only, generate
            // a constructor by omitting any members that are marked as
            // 'optional' in the spec and using the remaning 'mandatory'
            // members as the constructor arguments. These generated
            // constructors arent as good as the ones generated for the
            // simpler public strcuts.
            if(!vkStruct.ReturnedOnly)
            {
                var cotorParams = new Dictionary<string, string>();
                foreach (var vkMember in vkStruct.Members.Where(x => !hiddenMembers.Contains(x.Name) && x.Optional != "true"))
                {                    
                    var memberTypeName = vkMember.Type.Name;
                    var memberName = vkMember.Name;

                    if (memberTypeName == "String")
                    {
                        memberTypeName = vkMember.Len.Length > 1 ? "String[]" : "String";
                        cotorParams.Add(memberName, memberTypeName);
                        continue;
                    }

                    if (vkMember.IsFixedSize)
                    {
                        var prefix = string.Empty;
                        if (IsManagedStruct(vkStruct))
                            prefix = $"{UnmanagedNS}.{vkStruct.Name}.";
                        memberTypeName = $"{prefix}{memberName}Info";
                        cotorParams.Add(memberName, memberTypeName);
                        continue;
                    }

                    if (vkMember.IsArray)
                    {
                        memberTypeName += "[]";
                        cotorParams.Add(memberName, memberTypeName);
                        continue;
                    }
                    
                    cotorParams.Add(memberName, memberTypeName);
                }

                if (cotorParams.Count() != 0)
                {
                    var mandatoryMemberString = string.Join(", ", cotorParams.Select(x => $"{x.Value} {x.Key}"));
                    WriteLine("");
                    WriteLine($"public {vkStruct.Name}({mandatoryMemberString}) : this()");
                    WriteBeginBlock();
                    foreach (var kvp in cotorParams)
                        WriteLine($"this.{kvp.Key} = {kvp.Key};");

                    WriteEndBlock();
                }
            }

            // IDisposable and Finalizer
            WriteLine("");
            WriteLine("public void Dispose()");
            WriteBeginBlock();
            WriteManagedCleanup(vkStruct);
            WriteLine("GC.SuppressFinalize(this);");
            WriteEndBlock();
            WriteLine("");
            WriteLine($"~{vkStruct.Name}()");
            WriteBeginBlock();
            WriteLine($"if({NativePointer} != null)");
            WriteBeginBlock();
            WriteManagedCleanup(vkStruct);
            WriteEndBlock();
            WriteEndBlock();
            #endregion

            WriteEndBlock();
            WriteEndBlock();

            return _sb.ToString();
        }

        void WriteManagedCleanup(VkStruct vkStruct)
        {
            // TODO: arrays are not the only kind of pointer...
            foreach (var vkMember in vkStruct.Members.Where(vkMember => vkMember.IsArray && !vkMember.IsFixedSize))
                WriteLine($"Marshal.FreeHGlobal({NativePointer}->{vkMember.Name});");

            WriteLine($"{FreeFnName}((IntPtr){NativePointer});");
            WriteLine($"{NativePointer} = null;");
        }

        void WriteMember(VkMember vkMember, bool readOnly)
        {
            // Value types are simply passed to/from the underlying struct
            WriteMemberComments(vkMember);
            WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
            WriteBeginBlock();
            WriteLine($"get {{ return {NativePointer}->{vkMember.Name}; }}");
            if(!readOnly)
                WriteLine($"set {{ {NativePointer}->{vkMember.Name} = value; }}");
            WriteEndBlock();
        }

        void WriteMemberStruct(VkMember vkMember, bool readOnly)
        {
            if(vkMember.Type is VkStruct)
            {
                var isPointer = vkMember.IsPointer;
                var isManaged = IsManagedStruct(vkMember.Type);
                // If this is a managed struct or if 
                // the member itself is a pointer...
                if(isManaged || isPointer)
                {
                    if(isPointer && !isManaged)
                    {
                        WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                        WriteBeginBlock();
                        WriteLine("get");
                        WriteBeginBlock();
                        WriteLine($"var val = new {vkMember.Type.Name}();");
                        WriteLine($"Marshal.PtrToStructure({NativePointer}->{vkMember.Name}, val);");
                        WriteLine("return val;");
                        WriteEndBlock();
                        WriteLine("set");
                        WriteBeginBlock();
                        // todo: this will leak memory :(
                        WriteLine($"{NativePointer}->{vkMember.Name} = Marshal.AllocHGlobal(Marshal.SizeOf(typeof({vkMember.Type.Name})));");
                        WriteLine($"Marshal.StructureToPtr(value, {NativePointer}->{vkMember.Name}, false);");
                        WriteEndBlock();
                        WriteEndBlock();
                    }
                    else
                    {
                        // If this is a pointer to a struct that is unmanaged (no wrapper is generated), take
                        // the address of the struct directily
                        var valueCast = (isPointer && !isManaged) ? "(&value)" : $"value.{NativePointer}";

                        WriteLine($"{vkMember.Type.Name} _{vkMember.Name};");
                        WriteMemberComments(vkMember);
                        WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                        WriteBeginBlock();
                        // get
                        WriteLine($"get {{ return _{vkMember.Name}; }}");
                        // set
                        if(isPointer)
                        {
                            if(!readOnly)
                                WriteLine($"set {{ _{vkMember.Name} = value; {NativePointer}->{vkMember.Name} = (IntPtr){valueCast}; }}");
                        }
                        else
                        {
                            if(!readOnly)
                                WriteLine($"set {{ _{vkMember.Name} = value; {NativePointer}->{vkMember.Name} = *value.{NativePointer}; }}");
                        }
                        WriteEndBlock();
                    }
                }
                else
                {
                    WriteMemberComments(vkMember);
                    WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                    WriteBeginBlock();
                    WriteLine($"get {{ return {NativePointer}->{vkMember.Name}; }}");
                    if(!readOnly)
                        WriteLine($"set {{ {NativePointer}->{vkMember.Name} = value; }}");
                    WriteEndBlock();
                }
            }
            else
            {
                var castTo = "(IntPtr)";
                if (IsNondispatchableHandle(vkMember.Type))
                    castTo = string.Empty;
                
                WriteLine($"{vkMember.Type.Name} _{vkMember.Name};");
                WriteMemberComments(vkMember);
                WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                WriteBeginBlock();
                WriteLine($"get {{ return _{vkMember.Name}; }}");
                WriteLine($"set {{ _{vkMember.Name} = value; {NativePointer}->{vkMember.Name} = {castTo}value.{NativePointer}; }}");
                WriteEndBlock();
            }
        }

        void WriteMemberString(VkMember vkMember, bool readOnly)
        {
            if (vkMember.IsFixedSize)
            {
                WriteMemberComments(vkMember);
                WriteLine($"public String {vkMember.Name}");
                WriteBeginBlock();
                WriteLine($"get {{ return Marshal.PtrToStringAnsi((IntPtr){NativePointer}->{vkMember.Name}); }}");
                if(!readOnly)
                    WriteLine($"set {{ {FixedSizeStringFnName}({NativePointer}->{vkMember.Name}, value, {vkMember.FixedSize}); }}");
                WriteEndBlock();
            }
            else
            {
                WriteMemberComments(vkMember);
                WriteLine($"public String {vkMember.Name}");
                WriteBeginBlock();
                WriteLine($"get {{ return Marshal.PtrToStringAnsi({NativePointer}->{vkMember.Name}); }}");
                if(!readOnly)
                    WriteLine($"set {{ {NativePointer}->{vkMember.Name} = Marshal.StringToHGlobalAnsi(value); }}");
                WriteEndBlock();
            }
        }

        #region Member Array

        void WriteMemberStringArray(VkMember vkMember, bool readOnly)
        {
            var countName = vkMember.Name.Substring(0, vkMember.Name.Length - 5) + "Count";
            var get = "valueArray[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);";
            var set = "ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);";
            WriteArray(vkMember, countName, readOnly, "void*", "IntPtr", "void*", get, set);
        }

        void WriteMemeberArray(VkMember vkMember, bool readOnly)
        {
            var countName = vkMember.Len[0];
            if(countName.StartsWith("Latexmath"))
            {
                WriteNotImplementedArray(vkMember, "Latexmath", readOnly);
                return;
            }

            if(vkMember.Type is VkHandle)
            {
                var structType = GetHandleType((VkHandle)vkMember.Type);
                var get = $"valueArray[x] = new {vkMember.Type} {{ {NativePointer} = ptr[x] }};";
                var set = $"ptr[x] = value[x].{NativePointer};";
                WriteArray(vkMember, countName, readOnly, structType, get, set);
                return;
            }

            if(vkMember.Type is VkEnum)
            {
                var get = $"valueArray[x] = ({vkMember.Type})ptr[x];";
                var set = "ptr[x] = (UInt32)value[x];";
                var typeName = "UInt32";
                WriteArray(vkMember, countName, readOnly, typeName, get, set);
                return;
            }

            if(IsPlatformStruct(vkMember.Type))
            {
                var get = "valueArray[x] = ptr[x];";
                var set = "ptr[x] = value[x];";
                var typeName = vkMember.Type.Name;
                WriteArray(vkMember, countName, readOnly, typeName, get, set);
                return;
            }

            // struct
            {
                var vkStruct = vkMember.Type as VkStruct;
                var structType = vkStruct.Name;
                if (IsManagedStruct(vkStruct))
                    structType = $"{UnmanagedNS}." + structType;

                var getValueCast = IsManagedStruct(vkStruct) ? $"new {vkMember.Type} {{ {NativePointer} = &ptr[x] }}" : "ptr[x]";
                var get = $"valueArray[x] = {getValueCast};";

                var setValueCast = IsManagedStruct(vkStruct) ? $"*value[x].{NativePointer}" : "value[x]";
                var set = $"ptr[x] = {setValueCast};";

                var typeName = structType;
                WriteArray(vkMember, countName, readOnly, typeName, get, set);
            }
        }

        void WriteArray(VkMember vkMember, string countName, bool readOnly, string structType, string get, string set)
        {
            WriteArray(vkMember, countName, readOnly, structType, structType, structType, get, set);
        }

        void WriteArray(VkMember vkMember, string countName, bool readOnly, string structType, string sizeType, string pointerType, string get, string set)
        {
            WriteMemberComments(vkMember);
            WriteLine($"public {vkMember.Type}[] {vkMember.Name}");
            WriteBeginBlock();
            // get
            WriteLine("get");
            WriteBeginBlock();
            WriteLine($"if({NativePointer}->{vkMember.Name} == IntPtr.Zero)");
            _tabs++;
            WriteLine($"return null;");
            _tabs--;
            WriteLine($"var valueCount = {NativePointer}->{countName};");
            WriteLine($"var valueArray = new {vkMember.Type}[valueCount];");
            WriteLine($"var ptr = ({structType}*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            WriteLine(get);
            _tabs--;
            WriteLine("");
            WriteLine("return valueArray;");
            WriteEndBlock();
            if (!readOnly)
            {
                // set
                WriteLine("set");
                WriteBeginBlock();
                WriteLine("if(value != null)");
                WriteBeginBlock();
                WriteLine("var valueCount = value.Length;");
                WriteLine($"var typeSize = Marshal.SizeOf(typeof({sizeType})) * valueCount;");
                WriteLine($"if({NativePointer}->{vkMember.Name} != IntPtr.Zero)");
                _tabs++;
                WriteLine($"Marshal.ReAllocHGlobal({NativePointer}->{vkMember.Name}, (IntPtr)typeSize);");
                _tabs--;
                WriteLine("");
                WriteLine($"if({NativePointer}->{vkMember.Name} == IntPtr.Zero)");
                _tabs++;
                WriteLine($"{NativePointer}->{vkMember.Name} = Marshal.AllocHGlobal(typeSize);");
                _tabs--;
                WriteLine("");
                WriteLine($"{NativePointer}->{countName} = (UInt32)valueCount;");
                WriteLine($"var ptr = ({pointerType}*){NativePointer}->{vkMember.Name};");
                WriteLine("for(var x = 0; x < valueCount; x++)");
                _tabs++;
                WriteLine(set);
                _tabs--;
                WriteEndBlock();
                WriteLine("else");
                WriteBeginBlock();
                WriteLine($"if({NativePointer}->{vkMember.Name} != IntPtr.Zero)");
                _tabs++;
                WriteLine($"Marshal.FreeHGlobal({NativePointer}->{vkMember.Name});");
                _tabs--;
                WriteLine("");
                WriteLine($"{NativePointer}->{vkMember.Name} = IntPtr.Zero;");
                WriteLine($"{NativePointer}->{countName} = 0;");
                WriteEndBlock();
                WriteEndBlock();
            }
            WriteEndBlock();
        }
        
        void WriteNotImplementedArray(VkMember vkMember, string why, bool readOnly)
        {
            WriteMemberComments(vkMember);
            WriteLine($"public {vkMember.Type}[] {vkMember.Name}");
            WriteBeginBlock();
            // get
            WriteLine("get");
            WriteBeginBlock();
            WriteLine($"throw new NotImplementedException(\"{why}\");");
            WriteEndBlock();
            if (!readOnly)
            {
                // set
                WriteLine("set");
                WriteBeginBlock();
                WriteLine($"throw new NotImplementedException(\"{why}\");");
                WriteEndBlock();
            }
            WriteEndBlock();
        }

        #endregion
        #endregion

        void WriteMemberComments(VkMember vkMember)
        {
            var commentLines = new List<string>();

            /*if((vkMember.IsPointer || vkMember.IsArray) && vkMember.Type.Name != "IntPtr")
            {
                var array = vkMember.IsArray ? "[]" : string.Empty;
                commentLines.Add($"/// <para>Pointer to <see cref=\"{vkMember.Type}\"/>{array}</para>");
            }*/

            if(!string.IsNullOrEmpty(vkMember.XMLComment))
            {
                var desc = $"{vkMember.XMLComment}";
                if(vkMember.Optional == "true")
                    desc += " (Optional)";
                commentLines.Add(desc);
            }

            if(commentLines.Count != 0)
            {
                WriteLine("/// <summary>");
                WriteLine($"/// {commentLines[0]}");
                for(int x = 1; x < commentLines.Count - 1; x++)
                    WriteLine($"/// <para>{commentLines[x]}</para>");
                WriteLine("/// </summary>");
            }
        }

        string GenerateManagedCommand(IEnumerable<VkCommand> vkCommands, Dictionary<VkCommand, CommandInfo> commandInfoMap)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine($"namespace Vulkan.{ManagedNS}");
            WriteBeginBlock();
            WriteLine($"using static {UnmanagedNS}.{UnmanagedFunctionsClass};");
            WriteLine("");
            WriteLine($"public unsafe static class {ManagedFunctionsClass}");
            WriteBeginBlock();

            foreach(var vkCommand in vkCommands)
            {
                var commandInfo = commandInfoMap[vkCommand];
                
                var cmdParams = vkCommand.Parameters.Except(commandInfo.InternalParams).ToList();

                var optionalArgs = new List<string>();
                for(var x = cmdParams.Count - 1; x > 0; x--)
                {
                    if(!cmdParams[x].IsOptional)
                        break;

                    optionalArgs.Add(cmdParams[x].Name);
                }

                WriteCommandComment(vkCommand, cmdParams.ToArray());
                
                #region Declaration
                WriteTabs();
                Write($"public static {commandInfo.ReturnType} {vkCommand.Name}(");
                for(var x = 0; x < cmdParams.Count; x++)
                {
                    var vkParam = cmdParams[x];
                    var paramName = vkParam.Name;
                    var paramType = vkParam.Type.Name;
                    
                    if(commandInfo.ParamArrays.Contains(vkParam))
                        paramType = $"List<{paramType}>";
                    
                    Write($"{paramType} {paramName}");

                    if(optionalArgs.Contains(paramName))
                        Write($" = default({paramType})");
                    
                    if(x + 1 < cmdParams.Count)
                        Write(", ");
                }
                Write(")");
                Write(LineEnding);
                #endregion

                WriteBeginBlock();

                #region Single Return Prologue
                if(commandInfo.ReturnParam != null && !commandInfo.ReturnsList)
                {
                    WriteLine($"var {commandInfo.ReturnParam.Name} = new {commandInfo.ReturnParam.Type}();");

                    if(commandInfo.ReturnParam.IsFixed)
                    {
                        var type = IsPlatformStruct(commandInfo.ReturnParam.Type) ? $"{commandInfo.ReturnParam.Type}" : "IntPtr";
                        if (commandInfo.ReturnParam.Type is VkHandle)
                            type = GetHandleType((VkHandle)commandInfo.ReturnParam.Type);

                        var handle = (commandInfo.ReturnParam.Type is VkHandle) ? $".{NativePointer}" : string.Empty;
                        WriteLine($"fixed({type}* ptr{commandInfo.ReturnParam.Type} = &{commandInfo.ReturnParam.Name}{handle})");
                        WriteBeginBlock();
                    }
                }
                #endregion
                
                #region Array Parameters Prologue
                if(commandInfo.HasArrayParams)
                {
                    List<string> existingCounts = new List<string>();

                    // Emit a prologue block for each array param
                    foreach (var kv in commandInfo.ParamListCountMap)
                    {
                        var paramName     = kv.Key.Name;
                        var paramType     = kv.Key.Type;
                        var paramTypeName = kv.Key.Type.Name;
                        var countName     = kv.Value.Name;
                        var sizeVar       = $"_{paramName}Size";
                        var ptrVar        = $"_{paramName}Ptr";

                        var paramIsIntPtr       = (paramTypeName == "IntPtr");
                        var paramIsHandle       = paramType is VkHandle;
                        var paramIsDispatchable = (paramIsHandle) && (paramType as VkHandle).IsDispatchable;
                        var paramIsStruct       = paramType is VkStruct;
                        var paramIsInterop      = paramIsStruct && IsManagedStruct(paramType);
                        
                        var sizeType = (paramIsHandle) ? "IntPtr" : paramTypeName;
                        if(paramIsInterop)
                            sizeType = $"{UnmanagedNS}.{sizeType}";
                        
                        var pointerRefrence = (paramIsStruct && paramIsInterop) ? "*" : string.Empty;
                        var nativePtr = (paramIsHandle || paramIsInterop) ? $".{NativePointer}" : string.Empty;

                        var arrayPointerType = string.Empty;
                        if(paramIsHandle)
                            arrayPointerType = (paramIsDispatchable) ? "IntPtr*" : "UInt64*";

                        if(paramIsStruct)
                            arrayPointerType = (paramIsInterop) ? $"{UnmanagedNS}.{paramType}*" : $"{paramType}*";

                        if(paramIsIntPtr)
                            arrayPointerType = "IntPtr*";

                        if(!existingCounts.Contains(countName))
                        {
                            WriteLine($"var {countName} = ({paramName} != null) ? (UInt32){paramName}.Count : 0;");
                            existingCounts.Add(countName);
                        }

                        WriteLine($"var {ptrVar} = ({arrayPointerType})IntPtr.Zero;");
                        WriteLine($"if({countName} != 0)");
                        WriteBeginBlock();
                        WriteLine($"var {sizeVar} = Marshal.SizeOf(typeof({sizeType}));");
                        WriteLine($"{ptrVar} = ({arrayPointerType})Marshal.AllocHGlobal((int)({sizeVar} * {countName}));");
                        WriteLine($"for(var x = 0; x < {countName}; x++)");
                        _tabs++;
                        WriteLine($"{ptrVar}[x] = {pointerRefrence}{paramName}[x]{nativePtr};");
                        _tabs--;
                        WriteEndBlock();
                        WriteLine("");
                    }
                }
                #endregion

                const string returnListLength = "listLength";

                #region List Return Prologue
                if(commandInfo.ReturnsList && commandInfo.ReturnListCountParam != null)
                {
                    if(!commandInfo.ReturnListHasKnownLength)
                    {
                        WriteLine(commandInfo.ReturnListCountMember == null
                            ? $"{commandInfo.ReturnListCountParam.Type} {returnListLength};"
                            : $"var {returnListLength} = {commandInfo.ReturnListCountParam.Name}.{commandInfo.ReturnListCountMember.Name};");
                    }
                    else
                    {
                        WriteLine(commandInfo.ReturnListCountMember == null
                            ? $"var {returnListLength} = {commandInfo.ReturnListCountParam.Name};"
                            : $"var {returnListLength} = {commandInfo.ReturnListCountParam.Name}.{NativePointer}->{commandInfo.ReturnListCountMember.Name};");
                    }
                }
                #endregion

                #region Internal Function Call
                if(!commandInfo.ReturnsList || (commandInfo.ReturnsList && !commandInfo.ReturnListHasKnownLength))
                {
                    WriteTabs();
                    if(commandInfo.InternalReturnsVkResult || commandInfo.HasReturnValue)
                        Write("var result = ");

                    var commandParams = CreateCommandCallParams(vkCommand.Parameters.ToList(), commandInfo, false);
                    Write($"{vkCommand.SpecName}({commandParams});");
                    Write(LineEnding);

                    if(commandInfo.InternalReturnsVkResult)
                    {
                        WriteLine("if(result != Result.Success)");
                        _tabs++;
                        WriteLine($"throw new {VulkanResultException}(nameof({vkCommand.SpecName}), result);");
                        _tabs--;
                    }
                }
                else
                {
                    WriteLine("Result result;");
                }
                #endregion

                #region Single Return Epilogue
                if(commandInfo.ReturnParam != null && commandInfo.ReturnParam.IsFixed && !commandInfo.ReturnsList)
                    WriteEndBlock();
                #endregion

                #region List Return 2nd Function Call
                if(commandInfo.ReturnsList)
                {
                    WriteLine("");

                    var isNotManaged = !IsManagedStruct(commandInfo.ReturnParam.Type);
                    var interop = (isNotManaged || commandInfo.ReturnParam.Type is VkHandle || commandInfo.ReturnParam.Type is VkEnum) ? "" : $"{UnmanagedNS}.";
                    var sizeType = commandInfo.ReturnParam.Type.Name;
                    if(commandInfo.ReturnParam.Type is VkHandle)
                        sizeType = GetHandleType((VkHandle)commandInfo.ReturnParam.Type);
                    
                    WriteLine($"var array{commandInfo.ReturnParam.Type} = new {interop}{sizeType}[{returnListLength}];");
                    WriteLine($"fixed({interop}{sizeType}* resultPtr = &array{commandInfo.ReturnParam.Type}[0])");

                    #region Internal Function Call 2
                    _tabs++;
                    WriteTabs();
                    if(commandInfo.InternalReturnsVkResult)
                        Write("result = ");

                    var commandParams2 = CreateCommandCallParams(vkCommand.Parameters.ToList(), commandInfo, true);
                    Write($"{vkCommand.SpecName}({commandParams2});");
                    Write(LineEnding);
                    _tabs--;
                    #endregion

                    if(commandInfo.InternalReturnsVkResult)
                    {
                        WriteLine("if(result != Result.Success)");
                        _tabs++;
                        WriteLine($"throw new {VulkanResultException}(nameof({vkCommand.SpecName}), result);");
                        _tabs--;
                    }
                }
                #endregion

                #region Array Parameters Prologue
                if (commandInfo.HasArrayParams)
                {
                    // Emit a prologue block for each array param
                    foreach (var kv in commandInfo.ParamListCountMap)
                    {
                        var paramName = kv.Key.Name;
                        var ptrVar = $"_{paramName}Ptr";
                        WriteLine($"Marshal.FreeHGlobal((IntPtr){ptrVar});");
                    }
                }
                #endregion

                #region Epilogue
                if (commandInfo.ReturnParam != null)
                {
                    if (commandInfo.ReturnsList)
                    {
                        const string returnListName = "list";

                        WriteLine("");
                        WriteLine($"var {returnListName} = new {commandInfo.ReturnType}();");
                        WriteLine($"for(var x = 0; x < {returnListLength}; x++)");
                        WriteBeginBlock();

                        var isInteropType = false;
                        if(commandInfo.ReturnParam.Type is VkStruct)
                        {
                            var vkStruct = commandInfo.ReturnParam.Type as VkStruct;
                            isInteropType = !IsManagedStruct(vkStruct);
                        }

                        if(isInteropType || commandInfo.ReturnParam.Type is VkEnum)
                        {
                            WriteLine($"{returnListName}.Add(array{commandInfo.ReturnParam.Type}[x]);");
                        }
                        else
                        {
                            WriteLine($"var item = new {commandInfo.ReturnParam.Type}();");

                            if(commandInfo.ReturnParam.Type is VkHandle)
                            {
                                WriteLine($"item.{NativePointer} = array{commandInfo.ReturnParam.Type}[x];");
                            }
                            else
                            {
                                WriteLine($"fixed({UnmanagedNS}.{commandInfo.ReturnParam.Type}* itemPtr = &array{commandInfo.ReturnParam.Type}[x])");
                                _tabs++;
                                WriteLine($"item.{NativePointer} = itemPtr;");
                                _tabs--;
                            }

                            WriteLine($"{returnListName}.Add(item);");
                        }
                        WriteEndBlock();
                        WriteLine("");
                        WriteLine($"return {returnListName};");
                    }
                    else
                    {
                        WriteLine($"return {commandInfo.ReturnParam.Name};");
                    }
                }
                else if(commandInfo.ReturnType != "void")
                {
                    if(commandInfo.HasReturnValue && !commandInfo.HasArrayParams)
                    {
                        WriteLine("return result;");
                    }
                    else
                    {
                        WriteLine("throw new NotImplementedException(\"Appears to return a value but could not determine the type\");");
                    }
                }
                #endregion

                WriteEndBlock();
                WriteLine("");
            }

            WriteEndBlock();
            WriteEndBlock();

            return _sb.ToString();
        }

        string CreateCommandCallParams(List<VkParam> vkCmdParams, CommandInfo commandInfo, bool isSecondArrayCall)
        {
            var internalCallParams = new List<string>();
            foreach(var vkParam in vkCmdParams)
            {
                var paramName = vkParam.Name;
                var paramType = vkParam.Type;

                #region Return Param
                if(vkParam == commandInfo.ReturnParam && commandInfo.ReturnsList)
                {
                    // if the return value is a list and this is the kind of
                    // function we need to call twice (todo)
                    internalCallParams.Add(isSecondArrayCall ? "resultPtr" : "null");
                    continue;
                }

                if(vkParam == commandInfo.ReturnParam && vkParam.IsFixed)
                {
                    internalCallParams.Add($"ptr{commandInfo.ReturnParam.Type}");
                    continue;
                }

                if(vkParam == commandInfo.ReturnListCountParam && commandInfo.ReturnListCountMember == null)
                {
                    var listLen = "listLength";
                    if(!commandInfo.ReturnListHasKnownLength)
                        listLen = $"&{listLen}";
                    internalCallParams.Add(listLen);
                    continue;
                }

                if(commandInfo.ParamArrays.Contains(vkParam))
                {
                    internalCallParams.Add($"_{paramName}Ptr");
                    continue;
                }
                #endregion

                if(IsPlatformStruct(paramType) || paramType is VkEnum)
                {
                    var addressOf = string.Empty;
                    if(vkParam.IsPointer && paramType.Name != "String")
                        addressOf = "&";

                    internalCallParams.Add($"{addressOf}{paramName}");
                    continue;
                }
                
                if(vkParam.IsOptional)
                {
                    var nullValue = "null";
                    if(paramType is VkHandle)
                    {
                        nullValue = "0";
                        if(((VkHandle)paramType).IsDispatchable)
                            nullValue = "IntPtr.Zero";
                    }

                    internalCallParams.Add($"({paramName} != null) ? {paramName}.{NativePointer} : {nullValue}");
                    continue;
                }

                if(paramType is VkStruct)
                {
                    var vkStruct = paramType as VkStruct;
                    internalCallParams.Add(IsManagedStruct(vkStruct) ? $"{paramName}.{NativePointer}" : $"&{paramName}");
                    continue;
                }

                if(paramType is VkHandle)
                {
                    internalCallParams.Add($"{paramName}.{NativePointer}");
                    continue;
                }

                throw new InvalidOperationException();
            }

            return String.Join(", ", internalCallParams);
        }

        string GenerateHandleExtensions(string className, IEnumerable<VkHandle> vkHandles, IEnumerable<VkCommand> vkCommands, Dictionary<VkCommand, CommandInfo> commandInfoMap)
        {
            Clear();
            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            //WriteLine("using System.Diagnostics;");
            WriteLine("");
            WriteLine($"namespace Vulkan.{ManagedNS}.{ObjectModelNS}");
            WriteBeginBlock();
            WriteLine($"public static class {className}");
            WriteBeginBlock();

            foreach(var vkHandle in vkHandles)
            {
                var handleCommands = vkCommands.Where(x => x.Parameters.FirstOrDefault()?.Type.Name == vkHandle.Name).ToArray();
                if(!handleCommands.Any())
                    continue;

                WriteLine($"#region {vkHandle.Name}");
                WriteLine("");
                foreach(var vkCommand in handleCommands)
                {
                    var commandInfo = commandInfoMap[vkCommand];
                    var cmdParams = vkCommand.Parameters.Except(commandInfo.InternalParams).ToList();
                    
                    var commandName = vkCommand.Name;

                    if(commandName.StartsWith($"Get{vkHandle.Name}"))
                        commandName = commandName.Replace($"Get{vkHandle.Name}", "Get");

                    if(commandName.StartsWith(vkHandle.Name))
                        commandName = commandName.Replace(vkHandle.Name, string.Empty);

                    if(commandName.EndsWith(vkHandle.Name))
                        commandName = commandName.Replace(vkHandle.Name, string.Empty);

                    var optionalArgs = new List<string>();
                    for(var x = cmdParams.Count - 1; x > 0; x--)
                    {
                        if(!cmdParams[x].IsOptional)
                            break;

                        optionalArgs.Add(cmdParams[x].Name);
                    }

                    WriteCommandComment(vkCommand, cmdParams.ToArray());

                    //WriteLine("[DebuggerStepThrough]");

                    #region Declaration
                    WriteTabs();
                    Write($"public static {commandInfo.ReturnType} {commandName}(");
                    for(var x = 0; x < cmdParams.Count; x++)
                    {
                        var vkParam = cmdParams[x];
                        var paramName = vkParam.Name;
                        var paramType = vkParam.Type.Name;

                        if(x == 0)
                            Write($"this ");

                        if (commandInfo.ParamArrays.Contains(vkParam))
                            paramType = $"List<{paramType}>";
                        
                        Write($"{paramType} {paramName}");

                        if(optionalArgs.Contains(paramName))
                            Write($" = default({paramType})");

                        if(x + 1 < cmdParams.Count)
                            Write(", ");
                    }
                    Write(")");
                    Write(LineEnding);
                    #endregion
                    WriteBeginBlock();
                    #region Call into Vk
                    WriteTabs();
                    if(commandInfo.ReturnParam != null || commandInfo.HasReturnValue)
                        Write("return ");
                    Write($"{ManagedFunctionsClass}.{vkCommand.Name}");
                    Write("(");
                    for(var x = 0; x < cmdParams.Count; x++)
                    {
                        var param = cmdParams[x];
                        Write($"{param.Name}");
                        if(x + 1 < cmdParams.Count)
                            Write(", ");
                    }
                    Write(");");
                    Write(LineEnding);
                    #endregion
                    WriteEndBlock();
                    WriteLine("");
                }
                WriteLine("#endregion");
                WriteLine("");
            }

            WriteEndBlock();
            WriteEndBlock();

            return _sb.ToString();
        }
        
        CommandInfo CreateCommandInfo(VkCommand vkCommand)
        {
            var commandInfo = new CommandInfo();

            commandInfo.ReturnType = (vkCommand.ReturnType != null) ? vkCommand.ReturnType.Name : "void";
            commandInfo.InternalReturnsVkResult = commandInfo.ReturnType == "Result" && vkCommand.SuccessCodes.Length == 1 && vkCommand.SuccessCodes[0] == "VK_SUCCESS";
            if(commandInfo.InternalReturnsVkResult)
                commandInfo.ReturnType = "void";

            commandInfo.LastParam = vkCommand.Parameters.Last();

            #region Determine Return Type
            //
            // If the last param is a non-constant pointer, it's a return value
            //
            if(commandInfo.LastParam != null && commandInfo.LastParam.IsOut)
            {
                if(string.IsNullOrEmpty(commandInfo.LastParam.Len))
                {
                    // return value is a single object
                    commandInfo.ReturnParam = commandInfo.LastParam;
                    commandInfo.ReturnType = commandInfo.ReturnParam.Type.Name;
                    commandInfo.InternalParams.Add(commandInfo.ReturnParam);
                }
                else
                {
                    // The return value is an array, the count variable can either be
                    // a member of the current struct, or a member of another struct
                    // in the same scope, indicated by the value of `Len`
                    var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == commandInfo.LastParam.Len);
                    if(countParam != null)
                    {
                        commandInfo.ReturnsList = true;
                        commandInfo.ReturnParam = commandInfo.LastParam;
                        commandInfo.ReturnType = $"List<{commandInfo.ReturnParam.Type.Name}>";
                        commandInfo.InternalParams.Add(commandInfo.ReturnParam);
                        commandInfo.ReturnListCountParam = countParam;
                        commandInfo.InternalParams.Add(commandInfo.ReturnListCountParam);

                        // If countParam is a pointer, then we don't know the length
                        // of the array, so we have to call the function twice. Otherwise
                        // we provide the length as an argument
                        if (!countParam.IsPointer)
                            commandInfo.ReturnListHasKnownLength = true;
                    }
                    else
                    {
                        var splitLen = commandInfo.LastParam.Len.Split(new[] { "->" }, StringSplitOptions.None);
                        countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == splitLen[0]);
                        var countStruct = countParam?.Type as VkStruct;
                        var countMember = countStruct?.Members.ToList().FirstOrDefault(x => string.Equals(x.Name, splitLen[1], StringComparison.OrdinalIgnoreCase));
                        if(countMember != null)
                        {
                            commandInfo.ReturnsList = true;
                            commandInfo.ReturnParam = commandInfo.LastParam;
                            commandInfo.ReturnType = $"List<{commandInfo.ReturnParam.Type.Name}>";
                            commandInfo.ReturnListCountParam = countParam;
                            commandInfo.ReturnListCountMember = countMember;
                            commandInfo.ReturnListHasKnownLength = true;
                            commandInfo.InternalParams.Add(commandInfo.ReturnParam);
                        }
                    }
                }
            }
            #endregion

            commandInfo.HasReturnValue = (commandInfo.ReturnParam == null) && (commandInfo.ReturnType != "void");

            #region Determine if command has Array Parameters
            //
            // In C, arrays are passed using the (uint32_t objectCount, const Object* pObject).
            // We can combine the count and array pointer into one object, List<T>. Then we can
            // read the length of the list inside the function as needed.
            //
            commandInfo.ParamArrays = vkCommand.Parameters
                .Where(x => !string.IsNullOrEmpty(x.Len) && x.Type.Name != "String")
                .Except(new[] { commandInfo.ReturnParam });

            commandInfo.HasArrayParams = commandInfo.ParamArrays.Any();
            if(commandInfo.HasArrayParams)
            {
                foreach(var vkParam in commandInfo.ParamArrays)
                {
                    var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == vkParam.Len);
                    if(countParam != null)
                    {
                        commandInfo.ParamListCountMap.Add(vkParam, countParam);
                        commandInfo.InternalParams.Add(countParam);
                    }
                }
            }
            #endregion

            return commandInfo;
        }

        void WriteCommandComment(VkCommand vkCommand, VkParam[] vkParams)
        {
            var cmdProperties = string.Empty;
            
            // Command Buffer Levels
            if(vkCommand.CmdBufferLevel.Length != 0)
                cmdProperties += ($"[<see cref=\"CommandBufferLevel\"/>: {string.Join(", ", vkCommand.CmdBufferLevel)}] ");

            // Render Pass Scope
            if(!string.IsNullOrEmpty(vkCommand.RenderPass))
                cmdProperties += ($"[Render Pass: {vkCommand.RenderPass}] ");

            // Supported Queue Types
            if(vkCommand.Queues.Length != 0)
                cmdProperties += ($"[<see cref=\"QueueFlags\"/>: {string.Join(", ", vkCommand.Queues)}] ");
            
            if(!string.IsNullOrEmpty(cmdProperties))
            {
                WriteLine("/// <summary>");
                WriteLine($"/// {cmdProperties}");
                WriteLine("/// </summary>");
            }
            
            foreach(var vkParam in vkParams)
            {
                var comments = new List<string>();
                if(vkParam.ExternSync) comments.Add($"ExternSync");
                if(vkParam.IsOptional) comments.Add($"Optional");
                if(vkParam.NoAutoValidity) comments.Add("No Auto Validity");
                if(comments.Any())
                    WriteLine($"/// <param name=\"{vkParam.Name}\">{string.Join(", ", comments)}</param>");
            }
            //WriteLine("/// <returns></returns>");
        }

        string GetHandleType(VkHandle handle)
            => handle.IsDispatchable ? "IntPtr" : "UInt64";

        bool IsPlatformStruct(VkType type)
            => platformStructTypes.Contains(type.Name);

        bool IsDispatchableHandle(VkType vkType)
            => vkType is VkHandle && ((VkHandle)vkType).IsDispatchable;

        bool IsNondispatchableHandle(VkType vkType)
            => vkType is VkHandle && !((VkHandle)vkType).IsDispatchable;

        /// <summary>
        /// True if the struct contains any poiners, handles or special string objects
        /// </summary>
        bool IsManagedStruct(VkStruct vkStruct)
            => vkStruct.ContainsPointers
            || vkStruct.Members.Any(y => y.Type is VkHandle)
            || vkStruct.Members.Any(y => y.IsFixedSize && (y.Type.Name == "String"));

        bool IsManagedStruct(VkType vkType)
            => (vkType is VkStruct) && IsManagedStruct(vkType as VkStruct);

        GeneratedObjectInfo CreateFile(string fileName, string fileNamespace, string[] fileUsing, params GeneratedObjectInfo[] fileObjects)
        {
            Clear();
            
            foreach(var strUsing in fileUsing)
                WriteLine($"using {strUsing};");

            WriteLine("");
            WriteLine($"namespace {fileNamespace}");
            WriteBeginBlock();
            foreach(var obj in fileObjects)
            {
                var objLines = obj.Contents.Split(new[] { LineEnding }, StringSplitOptions.None);
                foreach(var line in objLines)
                    WriteLine(line);
            }
            WriteEndBlock();

            return new GeneratedObjectInfo(fileName, _sb.ToString());
        }

        void Clear()
        {
            _sb.Clear();
            _tabs = 0;
        }

        void WriteTabs()
        {
            _sb.Append($"{new string(' ', _tabs * 4)}");
        }

        void Write(string str)
        {
            _sb.Append($"{str}");
        }

        void WriteLine(string str)
        {
            _sb.Append($"{new string(' ', _tabs * 4)}{str}{LineEnding}");
        }

        void WriteBeginBlock()
        {
            WriteLine("{");
            _tabs++;
        }

        void WriteEndBlock()
        {
			_tabs--;
			WriteLine("}");
        }
    }
}
