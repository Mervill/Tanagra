using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanagra.Generator
{
    // There are a few species of objects we need to handle:
    //
    // - Terminal Structs
    //   - Contain only platform types and other Terminal Structs (also Bool32 and DeviceSize)
    //   - Cannot contain pointers
    //   - May contain other Terminal Structs so long as they are refrenced by value and not by pointer
    //
    // - Nonterminal Structs
    //   - May contain pointers to Terminal and Nonterminal structs
    //   - May refrence Terminal structs either by value or by pointer  
    //   - Must use pointers to refrence other Nonterminal structs
    //
    // Notes:
    //  - By default, structures use "copy" behaviour on assignment ie; the struct's data is copied
    //    to a new struct instance and then assigned. So using a simmilar copy method in the interop
    //    layer actually maintains expected functionality
    //
    // http://stackoverflow.com/questions/9302236/why-use-a-public-method-in-an-internal-class
    public class CSharpCodeGenerator
    {
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
        
        public Dictionary<string, string> files;

        const string NativePointer = "NativePointer";
        const string CallingConvention = "Winapi";
        const string VulkanCommandException = "VulkanCommandException";
        const string LineEnding = "\n";

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
        }

        public string Generate(VkSpec spec)
        {
            //
            // Ideally `CSharpCodeGenerator` transforms the data as little as possible. It
            // should only transform data if doing so in the rewrite step is awkward or impossible.
            //

            var commands = spec.Commands.Where(x => !disabledCommands.Contains(x.Name));
            var commandInfoMap = new Dictionary<VkCommand, CommandInfo>();
            foreach(var cmd in commands)
                commandInfoMap.Add(cmd, CreateCommandInfo(cmd));

            foreach(var vkEnum in spec.Enums.Where(vkEnum => vkEnum.Name != "API Constants"))
                files.Add($"./Enum/{vkEnum.Name}.cs", GenerateEnum(vkEnum));
            
            foreach(var vkSpec in spec.Handles)
                files.Add($"./Handle/{vkSpec.Name}.cs", GenerateHandle(vkSpec));

            // -- struct
            
            var needsInteropStruct = spec.Structs.Where(x => IsInteropStruct(x));
            files.Add("./Interop/Structs.cs", GenerateStructs(needsInteropStruct, false));

            var regularStruct = spec.Structs.Except(needsInteropStruct).Where(x => !disabledStructs.Contains(x.Name));
            files.Add("./Structs.cs", GenerateStructs(regularStruct, true));

            // -- vk
            files.Add("./Interop/VK.cs", GenerateCommandBindings(commands));

            var generateWrapper = needsInteropStruct.Where(vkStruct => !platformStructTypes.Contains(vkStruct.Name) && !disabledStructs.Contains(vkStruct.Name));
            foreach (var vkStruct in generateWrapper)
                files.Add($"./Wrapper/{vkStruct.Name}.cs", GenerateWrapperClass(vkStruct));

            files.Add("./Wrapper/VK.cs", GenerateCommandWrapper(commands, commandInfoMap));

            files.Add("./ObjectModel.cs", GenerateHandleExtensions(spec.Handles, commands, commandInfoMap));
            
            return _sb.ToString();
        }

        string GenerateEnum(VkEnum vkEnum)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteBeginBlock();
            if(vkEnum.IsBitmask)
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
            var type = (vkHandle.IsDispatchable) ? "IntPtr" : "UInt64";

            Clear();

            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteBeginBlock();
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
            Clear();

            var vis = isPublic ? "public" : "internal";

            WriteLine("// ReSharper disable BuiltInTypeReferenceStyle");
            WriteLine("// ReSharper disable InconsistentNaming");
            WriteLine("using System;");
            WriteLine("");
            WriteLine($"namespace Vulkan{((!isPublic) ? ".Interop" : string.Empty)}");
            WriteBeginBlock();
            foreach (var vkStruct in vkStructs)
            {
                if (platformStructTypes.Contains(vkStruct.Name))
                    continue;

                if(vkStruct.ReturnedOnly)
                {
                    WriteLine("/// <summary>");
                    WriteLine("/// Returned Only - This object is never given as input to a Vulkan function");
                    WriteLine("/// </summary>");
                }

                WriteLine($"{vis} struct {vkStruct.Name}");
                WriteBeginBlock();

                if (vkStruct.IsImportedType)
                    WriteLine("// Imported type");

                foreach (var member in vkStruct.Members)
                {
                    WriteMemberComments(member);

                    if (member.IsFixedSize)
                    {
                        if (!platformStructTypes.Contains(member.Type.Name))
                        {
                            WriteLine($"public {member.Type} {member.Name};");
                        }
                        else
                        {
                            var fixedType = member.Type.ToString();
                            if (fixedType == "String")
                                fixedType = "byte";

                            WriteLine($"public unsafe fixed {fixedType} {member.Name}[{member.FixedSize}];");
                        }
                        continue;
                    }

                    if (member.IsArray || member.IsPointer || member.Type.Name == "String")
                    {
                        WriteLine($"public IntPtr {member.Name};");
                        continue;
                    }

                    if (member.Type is VkHandle)
                    {
                        var vkHandle = (VkHandle)member.Type;
                        if (!vkHandle.IsDispatchable)
                        {
                            // should never be hit when isPublic == true
                            WriteLine($"public UInt64 {member.Name};");
                            continue;
                        }
                    }

                    WriteLine($"public {member.Type} {member.Name};");
                }

                // For public structs that are not returned (only) and contain members
                // marked as 'mandatory' by the spec (the spec actually marks members as optional)
                // generate a constructor that takes all the mandatory members as arguments. 
                // This is actually pretty good at generating useful constructors.
                if(isPublic && !vkStruct.ReturnedOnly && vkStruct.Name != "PhysicalDeviceFeatures")
                {
                    var mandatoryMembers = vkStruct.Members.Where(x => x.Optional != "true");
                    var optionalMembers  = vkStruct.Members.Except(mandatoryMembers);
                    
                    if(mandatoryMembers.Count() != 0)
                    {
                        mandatoryMembers.Select(x => $"{x.Type} {x.Name}");
                        var mandatoryMemberString = String.Join(", ", mandatoryMembers);

                        WriteLine("");
                        WriteLine($"public {vkStruct.Name}({mandatoryMemberString})");
                        WriteBeginBlock();

                        foreach(var member in mandatoryMembers)
                            WriteLine($"this.{member.Name} = {member.Name};");

                        // Assign default values to the optional members
                        foreach(var member in optionalMembers)
                            WriteLine($"{member.Name} = default({member.Type});");

                        WriteEndBlock();
                    }
                }
                WriteEndBlock();
                _tabs--;
                WriteLine("");
                _tabs++;
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
            WriteLine("namespace Vulkan.Interop");
            WriteBeginBlock();
            WriteLine("internal unsafe static class VK");
            WriteBeginBlock();
            WriteLine($"const string DllName = \"{DllName}\";");
            WriteLine($"const CallingConvention callingConvention = CallingConvention.{CallingConvention};");
            WriteLine("");
            foreach(var cmd in commands)
            {
                WriteLine($"[DllImport(DllName, EntryPoint = \"{cmd.SpecName}\", CallingConvention = callingConvention)]");
                WriteTabs();
                Write("internal static ");
                var returnType = (cmd.ReturnType != null) ? cmd.ReturnType.Name : "void";
                Write($"extern {returnType} {cmd.SpecName}");
                Write("(");
                for(var x = 0; x < cmd.Parameters.Length; x++)
                {
                    var param = cmd.Parameters[x];
                    var paramType = param.Type.Name;
                    if(param.Type is VkHandle)
                        paramType = ((VkHandle)param.Type).IsDispatchable ? "IntPtr" : "UInt64";

                    if(paramType == "String")
                    {
                        Write($"String {param.Name}");
                    }
                    else
                    {
                        var pointer = (param.IsPointer) ? "*" : string.Empty;
                        Write($"{paramType}{pointer} {param.Name}");
                    }
                    
                    if(x + 1 < cmd.Parameters.Length)
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

        #region GenerateWrapperClass

        string GenerateWrapperClass(VkStruct vkStruct)
        {
            var hiddenMembers = new HashSet<string>();
            foreach (var member in vkStruct.Members)
            {
                if (member.Len.Length == 0)
                    continue;

                var memberCountName = member.Len[0];
                memberCountName = char.ToUpper(memberCountName[0]) + memberCountName.Substring(1, memberCountName.Length - 1);
                var isCountMember = vkStruct.Members.Any(x => x.Name == memberCountName);
                if(isCountMember && !hiddenMembers.Contains(vkStruct.Name))
                    hiddenMembers.Add(memberCountName);
            }

            Clear();
            
            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteBeginBlock();
            if(vkStruct.ReturnedOnly)
            {
                WriteLine("/// <summary>");
                WriteLine("/// Returned Only - This object is never given as input to a Vulkan function");
                WriteLine("/// </summary>");
            }
            WriteLine($"unsafe public class {vkStruct.Name}");
            WriteBeginBlock();
            WriteLine($"internal Interop.{vkStruct.Name}* {NativePointer};");
            WriteLine("");

            var generateStructureType = false;
            foreach (var member in vkStruct.Members)
            {
                if (member.Name == "Next" && member.Type.Name == "IntPtr")
                    continue;

                if (member.Name == "SType" && member.Type.Name == "StructureType")
                {
                    generateStructureType = true;
                    continue;
                }

                if (hiddenMembers.Contains(member.Name))
                    continue;

                if (member.Type.Name == "String")
                {
                    if (member.Len.Length > 1)
                    {
                        WriteMemberStringArray(member, vkStruct.ReturnedOnly);
                    }
                    else
                    {
                        WriteMemberString(member, vkStruct.ReturnedOnly);
                    }
                    WriteLine("");
                    continue;
                }

                if(member.IsArray)
                {
                    WriteMemeberArray(member, vkStruct.ReturnedOnly);
                    WriteLine("");
                    continue;
                }

                if (member.Type is VkEnum || platformStructTypes.Contains(member.Type.Name))
                {
                    WriteMember(member, vkStruct.ReturnedOnly);
                    WriteLine("");
                    continue;
                }
                
                WriteMemberStruct(member, vkStruct.ReturnedOnly);
                WriteLine("");
            }

            // Give returned-only wrapper classes an internal constructor, meaning that
            // only internal assembly can create new instances of it (neat!)
            var cotorVis = (vkStruct.ReturnedOnly) ? "internal" : "public";
            WriteLine($"{cotorVis} {vkStruct.Name}()");
            WriteBeginBlock();
            WriteLine($"{NativePointer} = (Interop.{vkStruct.Name}*)Interop.Structure.Allocate(typeof(Interop.{vkStruct.Name}));");
            if (generateStructureType)
                WriteLine($"{NativePointer}->SType = StructureType.{vkStruct.Name};");
            WriteEndBlock();

            // Unless the underlying struct is returned-only, generate
            // a constructor by omitting any members that are marked as
            // 'optional' in the spec and using the remaning 'mandatory'
            // members as the constructor arguments. These generated
            // constructors arent as good as the ones generated for the
            // simpler public strcuts.
            if (!vkStruct.ReturnedOnly)
            {
                var cotorParams = new Dictionary<string, string>();
                foreach (var member in vkStruct.Members)
                {
                    if (member.Optional == "true")
                        continue;

                    if (member.Name == "Next" && member.Type.Name == "IntPtr")
                        continue;

                    if (member.Name == "SType" && member.Type.Name == "StructureType")
                        continue;

                    if (hiddenMembers.Contains(member.Name))
                        continue;

                    var memberTypeName = member.Type.Name;
                    var memberName = member.Name;

                    if (memberTypeName == "String")
                    {
                        memberTypeName = member.Len.Length > 1 ? "String[]" : "String";
                        cotorParams.Add(memberName, memberTypeName);
                        continue;
                    }

                    if (member.IsArray)
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

            // Implement IDisposable and deconstructor

            WriteEndBlock();
            WriteEndBlock();
            
            return _sb.ToString();
        }

        void WriteMember(VkMember vkMember, bool readOnly)
        {
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
                var vkStruct = (VkStruct)vkMember.Type;
                if(vkMember.IsPointer || IsInteropStruct(vkStruct))
                {
                    // If this is a pointer to a struct that wont have a wrapper class generated 
                    // for it, take the address of the struct directily instead of the NativePointer
                    var valueCast = (vkMember.IsPointer && !IsInteropStruct(vkStruct)) ? "(&value)" : $"value.{NativePointer}";
                    if(vkMember.IsPointer)
                        WriteLine($"{vkMember.Type.Name} _{vkMember.Name};");

                    WriteMemberComments(vkMember);
                    WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                    WriteBeginBlock();
                    // get
                    if(vkMember.IsPointer)
                    {
                        WriteLine($"get {{ return _{vkMember.Name}; }}");
                    }
                    else
                    {
                        WriteLine($"get {{ return new {vkMember.Type.Name} {{ {NativePointer} = &{NativePointer}->{vkMember.Name} }}; }}");
                    }
                    // set
                    if(vkMember.IsPointer)
                    {
                        if(!readOnly)
                            WriteLine($"set {{ _{vkMember.Name} = value; {NativePointer}->{vkMember.Name} = (IntPtr){valueCast}; }}");
                    }
                    else
                    {
                        if(!readOnly)
                            WriteLine($"set {{ {NativePointer}->{vkMember.Name} = *value.{NativePointer}; }}");
                    }
                    WriteEndBlock();
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
                if(vkMember.Type is VkHandle)
                {
                    var vkHandle = (VkHandle)vkMember.Type;
                    if(!vkHandle.IsDispatchable)
                        castTo = string.Empty;
                }

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
                WriteLine($"public string {vkMember.Name}");
                WriteBeginBlock();
                WriteLine($"get {{ return Marshal.PtrToStringAnsi((IntPtr){NativePointer}->{vkMember.Name}); }}");
                if(!readOnly)
                    WriteLine($"set {{ Interop.Structure.MarshalFixedSizeString({NativePointer}->{vkMember.Name}, value, {vkMember.FixedSize}); }}");
                WriteEndBlock();
            }
            else
            {
                WriteMemberComments(vkMember);
                WriteLine($"public string {vkMember.Name}");
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
            string get = "valueArray[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);";
            string set = "ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);";
            WriteArray(vkMember, countName, readOnly, "void*", "IntPtr", "void*", get, set);
        }

        void WriteMemeberArray(VkMember vkMember, bool readOnly)
        {
            if (vkMember.IsFixedSize)
            {
                WriteNotImplementedArray(vkMember, "IsFixedSize", readOnly);
                return;
            }

            var countName = vkMember.Len[0];
            countName = char.ToUpper(countName[0]) + countName.Substring(1, countName.Length - 1);

            if(countName.StartsWith("Latexmath"))
            {
                WriteNotImplementedArray(vkMember, "Latexmath", readOnly);
                return;
            }

            if(vkMember.Type is VkHandle)
            {
                var structType = "UInt64";
                var vkHandle = vkMember.Type as VkHandle;
                if (vkHandle.IsDispatchable)
                    structType = "IntPtr";

                var get = $"valueArray[x] = new {vkMember.Type} {{ {NativePointer} = ptr[x] }};";
                var set = "ptr[x] = (IntPtr)value[x].NativePointer;";
                WriteArray(vkMember, countName, readOnly, structType, "IntPtr", "IntPtr", get, set);
                return;
            }

            if(vkMember.Type is VkEnum)
            {
                string get = $"valueArray[x] = ({vkMember.Type})ptr[x];";
                string set = "ptr[x] = (UInt32)value[x];";
                WriteArray(vkMember, countName, readOnly, "UInt32", "UInt32", "UInt32", get, set);
                return;
            }

            if(platformStructTypes.Contains(vkMember.Type.Name))
            {
                string get = "valueArray[x] = ptr[x];";
                string set = "ptr[x] = value[x];";
                WriteArray(vkMember, countName, readOnly, vkMember.Type.Name, vkMember.Type.Name, vkMember.Type.Name, get, set);
                return;
            }

            // struct
            {
                var vkStruct = vkMember.Type as VkStruct;
                var structType = vkStruct.Name;
                if (IsInteropStruct(vkStruct))
                    structType = "Interop." + structType;

                var getValueCast = IsInteropStruct(vkStruct) ? $"new {vkMember.Type} {{ {NativePointer} = &ptr[x] }}" : "ptr[x]";
                string get = $"valueArray[x] = {getValueCast};";

                var setValueCast = IsInteropStruct(vkStruct) ? "*value[x].NativePointer" : "value[x]";
                string set = $"ptr[x] = {setValueCast};";

                WriteArray(vkMember, countName, readOnly, structType, structType, structType, get, set);
            }
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
                WriteLine($"var typeSize = Marshal.SizeOf<{sizeType}>() * valueCount;");
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
            WriteLine($"throw new System.NotImplementedException(\"{why}\");");
            WriteEndBlock();
            if (!readOnly)
            {
                // set
                WriteLine("set");
                WriteBeginBlock();
                WriteLine($"throw new System.NotImplementedException(\"{why}\");");
                WriteEndBlock();
            }
            WriteEndBlock();
        }

        #endregion
        #endregion

        void WriteMemberComments(VkMember vkMember)
        {
            if(!string.IsNullOrEmpty(vkMember.XMLComment))
            {
                WriteLine("/// <summary>");
                WriteTabs();
                Write($"/// {vkMember.XMLComment}");

                if(vkMember.Optional == "true")
                    Write(" (Optional)");

                Write(LineEnding);
                WriteLine("/// </summary>");
            }
        }
        
        string GenerateCommandWrapper(IEnumerable<VkCommand> vkCommands, Dictionary<VkCommand, CommandInfo> commandInfoMap)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteBeginBlock();
            WriteLine("using static Interop.VK;");
            WriteLine("");
            WriteLine("public unsafe static class VK");
            WriteBeginBlock();

            foreach(var vkCommand in vkCommands)
            {
                var commandInfo = commandInfoMap[vkCommand];
                
                #region Command Header
                WriteTabs();
                Write($"public static {commandInfo.ReturnType} {vkCommand.Name}(");
                var cmdParams = vkCommand.Parameters.Except(commandInfo.InternalParams).ToList();
                for(var x = 0; x < cmdParams.Count; x++)
                {
                    var vkParam = cmdParams[x];
                    var paramName = vkParam.Name;
                    var paramType = vkParam.Type.Name;
                    
                    if(commandInfo.ParamArrays.Contains(vkParam))
                        paramType = $"List<{paramType}>";
                    
                    Write($"{paramType} {paramName}");

                    // if the last argument is a struct and is marked as optional, we 
                    // can add `= null` to generate an overload without that argument
                    if((vkParam.Type is VkStruct) && !IsPlatformStruct(vkParam.Type) && vkParam.Optional.Length != 0 && vkParam.Optional[0] == "true" && x + 1 == cmdParams.Count)
                        Write(" = null");

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
                            type = ((VkHandle)commandInfo.ReturnParam.Type).IsDispatchable ? "IntPtr" : "UInt64";

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
                        var paramIsInterop      = paramIsStruct && IsInteropStruct((VkStruct)paramType);
                        
                        var sizeType = (paramIsHandle) ? "IntPtr" : paramTypeName;
                        if(paramIsInterop)
                            sizeType = $"Interop.{sizeType}";
                        
                        var pointerRefrence = (paramIsStruct && paramIsInterop) ? "*" : string.Empty;
                        var nativePtr = (paramIsHandle || paramIsInterop) ? $".{NativePointer}" : string.Empty;

                        var arrayPointerType = string.Empty;
                        if(paramIsHandle)
                            arrayPointerType = (paramIsDispatchable) ? "IntPtr*" : "UInt64*";

                        if(paramIsStruct)
                            arrayPointerType = (paramIsInterop) ? $"Interop.{paramType}*" : $"{paramType}*";

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
                        if(commandInfo.ReturnListCountMember == null)
                        {
                            WriteLine($"{commandInfo.ReturnListCountParam.Type} {returnListLength};");
                        }
                        else
                        {
                            WriteLine($"var {returnListLength} = {commandInfo.ReturnListCountParam.Name}.{commandInfo.ReturnListCountMember.Name};");
                        }
                    }
                    else
                    {
                        if(commandInfo.ReturnListCountMember == null)
                        {
                            WriteLine($"var {returnListLength} = {commandInfo.ReturnListCountParam.Name};");
                        }
                        else
                        {
                            WriteLine($"var {returnListLength} = {commandInfo.ReturnListCountParam.Name}.{NativePointer}->{commandInfo.ReturnListCountMember.Name};");
                        }
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
                        WriteLine($"throw new {VulkanCommandException}(nameof({vkCommand.SpecName}), result);");
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
                {
                    WriteEndBlock();
                }
                #endregion

                #region List Return 2nd Function Call
                if(commandInfo.ReturnsList)
                {
                    WriteLine("");

                    var isInteropType = false;
                    if(commandInfo.ReturnParam.Type is VkStruct)
                    {
                        var vkStruct = commandInfo.ReturnParam.Type as VkStruct;
                        isInteropType = !IsInteropStruct(vkStruct);
                    }

                    var interop = (isInteropType || commandInfo.ReturnParam.Type is VkHandle || commandInfo.ReturnParam.Type is VkEnum) ? "" : "Interop.";
                    var sizeType = commandInfo.ReturnParam.Type.Name;
                    if(commandInfo.ReturnParam.Type is VkHandle)
                    {
                        sizeType = "IntPtr";
                        var vkHandle = commandInfo.ReturnParam.Type as VkHandle;
                        if(!vkHandle.IsDispatchable)
                            sizeType = "UInt64";
                    }
                    
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
                        WriteLine($"throw new {VulkanCommandException}(nameof({vkCommand.SpecName}), result);");
                        _tabs--;
                    }
                }
                #endregion

                #region Array Parameters Prologue
                if (commandInfo.HasArrayParams)
                {
                    List<string> existingCounts = new List<string>();

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
                            isInteropType = !IsInteropStruct(vkStruct);
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
                                WriteLine($"fixed(Interop.{commandInfo.ReturnParam.Type}* itemPtr = &array{commandInfo.ReturnParam.Type}[x])");
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
                    if(isSecondArrayCall)
                    {
                        internalCallParams.Add("resultPtr");
                    }
                    else
                    {
                        internalCallParams.Add("null");
                    }
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

                // struct or handle, pass the native pointer
                if(vkParam.Optional.Length != 0 && vkParam.Optional[0] == "true")
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
                    if(IsInteropStruct(vkStruct))
                    {
                        internalCallParams.Add($"{paramName}.{NativePointer}");
                    }
                    else
                    {
                        internalCallParams.Add($"&{paramName}");
                    }
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

        string GenerateHandleExtensions(IEnumerable<VkHandle> vkHandles, IEnumerable<VkCommand> vkCommands, Dictionary<VkCommand, CommandInfo> commandInfoMap)
        {
            Clear();
            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            //WriteLine("using System.Diagnostics;");
            WriteLine("");
            WriteLine("namespace Vulkan.ObjectModel");
            WriteBeginBlock();
            WriteLine("public static class HandleExtensions");
            WriteBeginBlock();

            foreach(var vkHandle in vkHandles)
            {
                var handleCommands = vkCommands.Where(x => x.Parameters.FirstOrDefault()?.Type.Name == vkHandle.Name);
                if(!handleCommands.Any())
                    continue;

                WriteLine($"#region {vkHandle.Name}");
                WriteLine("");
                foreach(var vkCommand in handleCommands)
                {
                    var commandInfo = commandInfoMap[vkCommand];

                    #region Create Wrapper
                    WriteTabs();
                    //WriteLine("[DebuggerStepThrough]");
                    Write("public static ");

                    var commandName = vkCommand.Name;

                    if(commandName.StartsWith($"Get{vkHandle.Name}"))
                        commandName = commandName.Replace($"Get{vkHandle.Name}", "Get");

                    if(commandName.StartsWith(vkHandle.Name))
                        commandName = commandName.Replace(vkHandle.Name, string.Empty);

                    if(commandName.EndsWith(vkHandle.Name))
                        commandName = commandName.Replace(vkHandle.Name, string.Empty);

                    Write($"{commandInfo.ReturnType} {commandName}");
                    Write("(");

                    var cmdParams = vkCommand.Parameters.Except(commandInfo.InternalParams).ToList();
                    for(var x = 0; x < cmdParams.Count; x++)
                    {
                        var vkParam = cmdParams[x];
                        var paramType = vkParam.Type.Name;

                        if(x == 0)
                        {
                            Write($"this {paramType} {vkParam.Name}");
                        }
                        else if(paramType == "String")
                        {
                            Write($"String {vkParam.Name}");
                        }
                        else if (commandInfo.ParamArrays.Contains(vkParam))
                        {
                            Write($"List<{paramType}> {vkParam.Name}");
                        }
                        else
                        {
                            // if the last argument is a struct and is marked as optional, we can add `= null` to generate an overload without that argument
                            if((vkParam.Type is VkStruct) && !platformStructTypes.Contains(paramType) && vkParam.Optional.Length != 0 && vkParam.Optional[0] == "true" && x + 1 == cmdParams.Count)
                            {
                                Write($"{paramType} {vkParam.Name} = null");
                            }
                            else
                            {
                                Write($"{paramType} {vkParam.Name}");
                            }
                        }
                        
                        if(x + 1 < cmdParams.Count)
                            Write(", ");
                    }

                    Write(")");
                    Write(LineEnding);

                    WriteBeginBlock();
                    WriteTabs();
                    if(commandInfo.ReturnParam != null || commandInfo.HasReturnValue)
                        Write("return ");
                    Write($"VK.{vkCommand.Name}");
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
                    
                    WriteEndBlock();

                    WriteLine("");
                    #endregion
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

            commandInfo.ReturnsList = false;
            commandInfo.ReturnParam = null;
            commandInfo.ReturnListCountParam = null;
            commandInfo.ReturnListCountMember = null;
            commandInfo.ReturnListHasKnownLength = false;
            commandInfo.InternalParams = new List<VkParam>();
            commandInfo.ParamListCountMap = new Dictionary<VkParam, VkParam>();

            commandInfo.ReturnType = (vkCommand.ReturnType != null) ? vkCommand.ReturnType.Name : "void";
            commandInfo.InternalReturnsVkResult = commandInfo.ReturnType == "Result";
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

                        // If countParam is a pointer, then we don't know the length
                        // of the array, so we have to call the function twice. Otherwise
                        // we provide the length as an argument
                        if(countParam.IsPointer)
                        {
                            commandInfo.ReturnListCountParam = countParam;
                            commandInfo.InternalParams.Add(commandInfo.ReturnListCountParam);
                        }
                        else
                        {
                            commandInfo.ReturnListHasKnownLength = true;
                            commandInfo.ReturnListCountParam = countParam;
                            commandInfo.InternalParams.Add(commandInfo.ReturnListCountParam);
                        }
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
            if(commandInfo.ParamArrays.Any())
            {
                foreach(var param in commandInfo.ParamArrays)
                {
                    var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == param.Len);
                    if(countParam != null)
                    {
                        commandInfo.ParamListCountMap.Add(param, countParam);
                        commandInfo.InternalParams.Add(countParam);
                    }
                }
            }
            #endregion

            return commandInfo;
        }

        bool IsPlatformStruct(VkType type)
            => platformStructTypes.Contains(type.Name);

        bool IsInteropStruct(VkStruct vkStruct)
            => vkStruct.HasPointerMembers
            || vkStruct.Members.Any(y => y.Type is VkHandle)
            || vkStruct.Members.Any(y => y.IsFixedSize);

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
