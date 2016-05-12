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
        StringBuilder _sb;
        int _tabs;

        public string DllName = "vulkan-1-1-0-8-0.dll";
        readonly List<string> platformStructTypes;
        readonly List<string> disabledStructs;
        readonly List<string> disabledCommands;

        public Dictionary<string, string> files;

        const string NativePointer = "NativePointer";
        const string CallingConvention = "Winapi";
        const string LineEnding = "\n";

        public CSharpCodeGenerator()
        {
            _sb = new StringBuilder();
            files = new Dictionary<string, string>();

            platformStructTypes = new List<string>
            {
                "IntPtr",
                "Char",
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

            foreach(var vkEnum in spec.Enums.Where(vkEnum => vkEnum.Name != "API Constants"))
                files.Add($"./Enum/{vkEnum.Name}.cs", GenerateEnum(vkEnum));
            
            foreach(var vkSpec in spec.Handles)
                files.Add($"./Handle/{vkSpec.Name}.cs", GenerateHandle(vkSpec));

            // -- struct

            //var needsInteropStruct = spec.Structs.Where(x => x.Members.Any(y => y.IsPointer || y.Type.Name == "Char"));
            var needsInteropStruct = spec.Structs.Where(x => x.HasPointerMembers);
            files.Add("./Interop/Structs.cs", GenerateStructs(needsInteropStruct, false));

            var regularStruct = spec.Structs.Except(needsInteropStruct);
            files.Add("./Structs.cs", GenerateStructs(regularStruct, true));

            // -- vk
            files.Add("./Interop/VK.cs", GenerateCommandBindings(commands));

            var generateStructs = needsInteropStruct.Where(vkStruct => !platformStructTypes.Contains(vkStruct.Name) && !disabledStructs.Contains(vkStruct.Name));

            foreach (var vkStruct in generateStructs)
                files.Add($"./Wrapper/{vkStruct.Name}.cs", GenerateWrapperClass(vkStruct));

            files.Add("./Wrapper/VK.cs", GenerateCommandWrapper(commands));

            files.Add("./ObjectModel.cs", GenerateHandleExtensions(spec.Handles, commands));
            
            return _sb.ToString();
        }

        string GenerateEnum(VkEnum vkEnum)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteLine("{");
            _tabs++;
            if(vkEnum.IsBitmask)
                WriteLine("[Flags]");
            WriteLine($"public enum {vkEnum.Name}"); // : int
            WriteLine("{");
            _tabs++;

            if(vkEnum.IsBitmask || vkEnum.Values.Any(x => x.Name == "None"))
            {
                WriteLine($"None = 0,");
            }

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

            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");

            return _sb.ToString();
        }
        
        string GenerateHandle(VkHandle vkHandle)
        {
            var name = vkHandle.Name;

            Clear();

            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteLine("{");
            _tabs++;
            WriteLine($"public class {name}");
            WriteLine("{");
            _tabs++;
            var type = (vkHandle.IsDispatchable) ? "IntPtr" : "UInt64";
            WriteLine($"internal {type} {NativePointer};");
            WriteLine("");
            WriteLine($"public override string ToString() => \"{name} 0x\" + {NativePointer}.ToString(\"X8\");");
            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");

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
            WriteLine("{");
            _tabs++;

            foreach (var vkStruct in vkStructs)
            {
                if (platformStructTypes.Contains(vkStruct.Name))
                    continue;

                WriteLine($"{vis} struct {vkStruct.Name}");
                WriteLine("{");
                _tabs++;

                if (vkStruct.IsImportedType)
                    WriteLine("// Imported type");

                foreach (var member in vkStruct.Members)
                {
                    if (member.Type is VkEnum || (platformStructTypes.Contains(member.Type.Name) && member.Type.Name != "Char"))
                    {
                        if(!member.IsArray)
                        {
                            WriteLine($"{vis} {member.Type} {member.Name};");
                            continue;
                        }
                    }

                    if(member.Type is VkStruct && !member.IsArray && !member.IsPointer && member.Type.Name != "Char")
                    {
                        var memberType = member.Type as VkStruct;
                        if(!memberType.HasPointerMembers)
                        {
                            WriteLine($"{vis} {member.Type} {member.Name};");
                            continue;
                        }
                    }

                    if(member.Type is VkHandle && !member.IsArray)
                    {
                        var vkHandle = member.Type as VkHandle;
                        if(!vkHandle.IsDispatchable)
                        {
                            WriteLine($"{vis} UInt64 {member.Name};");
                            continue;
                        }
                    }

                    // Eveything else is a pointer
                    // `Char` is a C-style string ... so it's a pointer
                    WriteLine($"{vis} IntPtr {member.Name};");
                }

                _tabs--;
                WriteLine("}");
                _tabs--;
                WriteLine("");
                _tabs++;
            }

            _tabs--;
            WriteLine("}");

            return _sb.ToString();
        }

        string GenerateCommandBindings(IEnumerable<VkCommand> commands)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan.Interop");
            WriteLine("{");
            _tabs++;
            WriteLine("internal unsafe static class VK");
            WriteLine("{");
            _tabs++;
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

                    if(paramType == "Char")
                    {
                        Write($"String {param.Name}");
                    }
                    else
                    {
                        //var pointer = new string('*', param.PointerRank);
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

            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");

            return _sb.ToString();
        }

        #region GenerateWrapperClass

        string GenerateWrapperClass(VkStruct vkStruct)
        {
            Clear();
            
            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteLine("{");
            _tabs++;
            WriteLine($"unsafe public class {vkStruct.Name}");
            WriteLine("{");
            _tabs++;
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

                if (member.Type.Name == "Char")
                {
                    if (member.Len.Length > 1)
                    {
                        WriteMemberStringArray(member);
                    }
                    else
                    {
                        WriteMemberString(member);
                    }
                    WriteLine("");
                    continue;
                }

                if(member.IsArray)
                {
                    WriteMemeberArray(member);
                    WriteLine("");
                    continue;
                }

                if (member.Type is VkEnum || platformStructTypes.Contains(member.Type.Name))
                {
                    WriteMember(member);
                    WriteLine("");
                    continue;
                }
                
                WriteMemberStruct(member);
                WriteLine("");
            }

            WriteLine($"public {vkStruct.Name}()");
            WriteLine("{");
            _tabs++;
            WriteLine($"{NativePointer} = (Interop.{vkStruct.Name}*)Interop.Structure.Allocate(typeof(Interop.{vkStruct.Name}));");
            if (generateStructureType)
                WriteLine($"{NativePointer}->SType = StructureType.{vkStruct.Name};");
            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");
            
            return _sb.ToString();
        }

        void WriteMember(VkMember vkMember)
        {
            WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
            WriteLine("{");
            _tabs++;
            WriteLine($"get {{ return {NativePointer}->{vkMember.Name}; }}");
            WriteLine($"set {{ {NativePointer}->{vkMember.Name} = value; }}");
            _tabs--;
            WriteLine("}");
        }

        void WriteMemberStruct(VkMember vkMember)
        {
            if(vkMember.Type is VkStruct)
            {
                var vkStruct = vkMember.Type as VkStruct;
                if(vkMember.IsPointer || vkStruct.HasPointerMembers)
                {
                    // If this is a pointer to a struct that wont have a wrapper class generated 
                    // for it, take the address of the struct directily instead of the NativePointer
                    var valueCast = (vkMember.IsPointer && !vkStruct.HasPointerMembers) ? "(&value)" : $"value.{NativePointer}";

                    WriteLine($"{vkMember.Type.Name} _{vkMember.Name};");
                    WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                    WriteLine("{");
                    _tabs++;
                    WriteLine($"get {{ return _{vkMember.Name}; }}");
                    WriteLine($"set {{ _{vkMember.Name} = value; {NativePointer}->{vkMember.Name} = (IntPtr){valueCast}; }}");
                    _tabs--;
                    WriteLine("}");
                }
                else
                {
                    WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                    WriteLine("{");
                    _tabs++;
                    WriteLine($"get {{ return {NativePointer}->{vkMember.Name}; }}");
                    WriteLine($"set {{ {NativePointer}->{vkMember.Name} = value; }}");
                    _tabs--;
                    WriteLine("}");
                }
            }
            else
            {
                var castTo = "(IntPtr)";
                if(vkMember.Type is VkHandle)
                {
                    var vkHandle = vkMember.Type as VkHandle;
                    if(!vkHandle.IsDispatchable)
                        castTo = string.Empty;
                }

                WriteLine($"{vkMember.Type.Name} _{vkMember.Name};");
                WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
                WriteLine("{");
                _tabs++;
                WriteLine($"get {{ return _{vkMember.Name}; }}");
                WriteLine($"set {{ _{vkMember.Name} = value; {NativePointer}->{vkMember.Name} = {castTo}value.{NativePointer}; }}");
                _tabs--;
                WriteLine("}");
            }
        }

        void WriteMemberString(VkMember vkMember)
        {
            WriteLine($"public string {vkMember.Name}");
            WriteLine("{");
            _tabs++;
            WriteLine($"get {{ return Marshal.PtrToStringAnsi({NativePointer}->{vkMember.Name}); }}");
            WriteLine($"set {{ {NativePointer}->{vkMember.Name} = Marshal.StringToHGlobalAnsi(value); }}");
            _tabs--;
            WriteLine("}");
        }

        #region Member Array

        void WriteMemberStringArray(VkMember vkMember)
        {
            WriteLine($"public string[] {vkMember.Name}");
            WriteLine("{");
            _tabs++;

            // get
            WriteLine("get");
            WriteLine("{");
            _tabs++;

            if (!vkMember.Name.EndsWith("Names"))
                throw new Exception($"unable to handle member {vkMember.Name}");
            var countName = vkMember.Name.Substring(0, vkMember.Name.Length - 5) + "Count";

            WriteLine($"var strings = new String[{NativePointer}->{countName}];");
            WriteLine($"void** ptr = (void**){NativePointer}->{vkMember.Name};");
            WriteLine($"for(var x = 0; x < {NativePointer}->{countName}; x++)");
            _tabs++;
            WriteLine("strings[x] = Marshal.PtrToStringAnsi((IntPtr)ptr[x]);");
            _tabs--;
            WriteLine("");
            WriteLine("return strings;");
            _tabs--;
            WriteLine("}");

            // set
            WriteLine("set");
            WriteLine("{");
            _tabs++;
            WriteLine($"{NativePointer}->{countName} = (uint)value.Length;");
            WriteLine($"{NativePointer}->{vkMember.Name} = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*{NativePointer}->{countName}));");
            WriteLine($"void** ptr = (void**){NativePointer}->{vkMember.Name};");
            WriteLine($"for(var x = 0; x < {NativePointer}->{countName}; x++)");
            _tabs++;
            WriteLine("ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);");
            _tabs--;
            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
        }

        void WriteMemeberArray(VkMember vkMember)
        {
            var countName = vkMember.Len[0];
            countName = char.ToUpper(countName[0]) + countName.Substring(1, countName.Length - 1);

            if(countName.StartsWith("Latexmath"))
            {
                WriteNotImplementedArray(vkMember);
                return;
            }

            if(vkMember.Type is VkHandle)
            {
                WriteHandleArray(vkMember, countName);
                return;
            }

            if(vkMember.Type is VkEnum)
            {
                WriteEnumArray(vkMember, countName);
                return;
            }

            if(platformStructTypes.Contains(vkMember.Type.Name))
            {
                WritePlatformArray(vkMember, countName);
                return;
            }

            WriteStructArray(vkMember, countName);
        }

        void WriteStructArray(VkMember vkMember, string countName)
        {
            WriteLine($"public {vkMember.Type}[] {vkMember.Name}");
            WriteLine("{");
            _tabs++;

            // get
            WriteLine("get");
            WriteLine("{");
            _tabs++;
            
            var vkStruct = vkMember.Type as VkStruct;
            var structType = vkStruct.Name;
            if(vkStruct.HasPointerMembers)
                structType = "Interop." + structType;

            WriteLine($"var valueCount = {NativePointer}->{countName};");
            WriteLine($"var valueArray = new {vkMember.Type}[valueCount];");
            WriteLine($"var ptr = ({structType}*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            if(vkStruct.HasPointerMembers)
            {
                WriteLine($"valueArray[x] = new {vkMember.Type} {{ {NativePointer} = &ptr[x] }};");
            }
            else
            {
                WriteLine($"valueArray[x] = ptr[x];");
            }
            _tabs--;
            WriteLine("return valueArray;");

            _tabs--;
            WriteLine("}");

            // set
            WriteLine("set");
            WriteLine("{");
            _tabs++;

            WriteLine("var valueCount = value.Length;");
            WriteLine($"{NativePointer}->{countName} = (uint)valueCount;");
            
            WriteLine($"{NativePointer}->{vkMember.Name} = Marshal.AllocHGlobal(Marshal.SizeOf<{structType}>() * valueCount);");
            WriteLine($"var ptr = ({structType}*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            if(vkStruct.HasPointerMembers)
            {
                WriteLine("ptr[x] = *value[x].NativePointer;");
            }
            else
            {
                WriteLine("ptr[x] = value[x];");
            }
            _tabs--;

            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
        }

        void WriteHandleArray(VkMember vkMember, string countName)
        {
            WriteLine($"public {vkMember.Type}[] {vkMember.Name}");
            WriteLine("{");
            _tabs++;

            var structType = "UInt64";
            var vkHandle = vkMember.Type as VkHandle;
            if(vkHandle.IsDispatchable)
                structType = "IntPtr";

            // get
            WriteLine("get");
            WriteLine("{");
            _tabs++;

            WriteLine($"var valueCount = {NativePointer}->{countName};");
            WriteLine($"var valueArray = new {vkMember.Type}[valueCount];");
            WriteLine($"var ptr = ({structType}*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            WriteLine($"valueArray[x] = new {vkMember.Type} {{ {NativePointer} = ptr[x] }};");
            _tabs--;
            WriteLine("return valueArray;");

            _tabs--;
            WriteLine("}");

            // set
            WriteLine("set");
            WriteLine("{");
            _tabs++;

            WriteLine("var valueCount = value.Length;");
            WriteLine($"{NativePointer}->{countName} = (uint)valueCount;");

            WriteLine($"{NativePointer}->{vkMember.Name} = Marshal.AllocHGlobal(Marshal.SizeOf<IntPtr>() * valueCount);");
            WriteLine($"var ptr = (IntPtr*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            WriteLine("ptr[x] = (IntPtr)value[x].NativePointer;");
            _tabs--;

            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
        }

        void WritePlatformArray(VkMember vkMember, string countName)
        {
            WriteLine($"public {vkMember.Type}[] {vkMember.Name}");
            WriteLine("{");
            _tabs++;

            // get
            WriteLine("get");
            WriteLine("{");
            _tabs++;

            WriteLine($"var valueCount = {NativePointer}->{countName};");
            WriteLine($"var valueArray = new {vkMember.Type}[valueCount];");
            WriteLine($"var ptr = ({vkMember.Type}*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            WriteLine($"valueArray[x] = ptr[x];");
            _tabs--;
            WriteLine("return valueArray;");

            _tabs--;
            WriteLine("}");

            // set
            WriteLine("set");
            WriteLine("{");
            _tabs++;

            WriteLine("var valueCount = value.Length;");
            WriteLine($"{NativePointer}->{countName} = (uint)valueCount;");

            WriteLine($"{NativePointer}->{vkMember.Name} = Marshal.AllocHGlobal(Marshal.SizeOf<{vkMember.Type.Name}>() * valueCount);");
            WriteLine($"var ptr = ({vkMember.Type.Name}*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            WriteLine($"ptr[x] = value[x];");
            _tabs--;

            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
        }

        void WriteEnumArray(VkMember vkMember, string countName)
        {
            WriteLine($"public {vkMember.Type}[] {vkMember.Name}");
            WriteLine("{");
            _tabs++;

            // get
            WriteLine("get");
            WriteLine("{");
            _tabs++;

            WriteLine($"var valueCount = {NativePointer}->{countName};");
            WriteLine($"var valueArray = new {vkMember.Type}[valueCount];");
            WriteLine($"var ptr = (UInt32*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            WriteLine($"valueArray[x] = ({vkMember.Type})ptr[x];");
            _tabs--;
            WriteLine("return valueArray;");

            _tabs--;
            WriteLine("}");
            
            // set
            WriteLine("set");
            WriteLine("{");
            _tabs++;
            
            WriteLine("var valueCount = value.Length;");
            WriteLine($"{NativePointer}->{countName} = (uint)valueCount;");

            WriteLine($"{NativePointer}->{vkMember.Name} = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);");
            WriteLine($"var ptr = (UInt32*){NativePointer}->{vkMember.Name};");
            WriteLine("for(var x = 0; x < valueCount; x++)");
            _tabs++;
            WriteLine($"ptr[x] = (UInt32)value[x];");
            _tabs--;

            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
        }

        void WriteNotImplementedArray(VkMember vkMember)
        {
            WriteLine($"public {vkMember.Type}[] {vkMember.Name}");
            WriteLine("{");
            _tabs++;

            // get
            WriteLine("get");
            WriteLine("{");
            _tabs++;

            WriteLine("throw new System.NotImplementedException();");

            _tabs--;
            WriteLine("}");

            // set
            WriteLine("set");
            WriteLine("{");
            _tabs++;

            WriteLine("throw new System.NotImplementedException();");

            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
        }

        #endregion
        #endregion

        string GenerateCommandWrapper(IEnumerable<VkCommand> vkCommands)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteLine("{");
            _tabs++;
            WriteLine("using static Interop.VK;");
            WriteLine("");
            WriteLine("public unsafe static class VK");
            WriteLine("{");
            _tabs++;

            foreach(var vkCommand in vkCommands)
            {
                var returnType = (vkCommand.ReturnType != null) ? vkCommand.ReturnType.Name : "void";
                var internalReturnsVkResult = returnType == "Result";
                if(internalReturnsVkResult)
                    returnType = "void";
                
                bool returnsList = false;
                VkParam returnParam = null;
                VkParam returnListCountParam = null;
                VkMember returnListCountMember = null;
                bool returnListHasKnownLength = false;

                var internalParams = new List<VkParam>();

                #region Determine Return Type
                //
                // If the last param is a non-constant pointer, it's a return value
                //
                var lastParam = vkCommand.Parameters.Last();
                if(lastParam != null && lastParam.IsOut)
                {
                    if(string.IsNullOrEmpty(lastParam.Len))
                    {
                        // return value is a single object
                        returnParam = lastParam;
                        returnType = returnParam.Type.Name;
                        internalParams.Add(returnParam);
                    }
                    else
                    {
                        // The return value is an array, the count variable can either be
                        // a member of the current struct, or a member of another struct
                        // in the same scope, indicated by the value of `Len`
                        var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == lastParam.Len);
                        if (countParam != null)
                        {
                            returnsList = true;
                            returnParam = lastParam;
                            returnType = $"List<{returnParam.Type.Name}>";
                            internalParams.Add(returnParam);

                            // If countParam is a pointer, then we don't know the length
                            // of the array, so we have to call the function twice. Otherwise
                            // we provide the length as an argument
                            if (countParam.IsPointer)
                            {
                                returnListCountParam = countParam;
                                internalParams.Add(returnListCountParam);
                            }
                        }
                        else
                        {
                            var splitLen = lastParam.Len.Split(new[] { "->" }, StringSplitOptions.None);
                            countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == splitLen[0]);
                            var countStruct = countParam?.Type as VkStruct;
                            var countMember = countStruct?.Members.ToList().FirstOrDefault(x => string.Equals(x.Name, splitLen[1], StringComparison.OrdinalIgnoreCase));
                            if (countMember != null)
                            {
                                returnsList = true;
                                returnParam = lastParam;
                                returnType = $"List<{returnParam.Type.Name}>";
                                returnListCountParam = countParam;
                                returnListCountMember = countMember;
                                returnListHasKnownLength = true;
                                internalParams.Add(returnParam);
                            }
                        }
                    }
                }

                var hasReturnValue = (returnParam == null) && (returnType != "void");
                #endregion

                #region Determine if command has Array Parameters
                //
                // In C, arrays are passed using the (uint32_t objectCount, const Object* pObject).
                // We can combine the count and array pointer into one object, List<T>. Then we can
                // read the length of the list inside the function as needed.
                //
                var paramLists = vkCommand.Parameters
                    .Where(x => !string.IsNullOrEmpty(x.Len) && x.Type.Name != "Char")
                    .Except(new[] { returnParam });
                
                var paramListCountMap = new Dictionary<VkParam, VkParam>();
                var hasArrayParams = paramLists.Any();
                if (hasArrayParams)
                {
                    foreach (var param in paramLists)
                    {
                        var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == param.Len);
                        if (countParam != null)
                        {
                            paramListCountMap.Add(param, countParam);
                            internalParams.Add(countParam);
                        }
                    }
                }
                #endregion
                
                #region Command Header
                // --- function params
                WriteTabs();
                Write($"public static {returnType} {vkCommand.Name}(");

                var cmdParams = vkCommand.Parameters.Except(internalParams).ToList();
                //var paramList = new List<string>();
                for(var x = 0; x < cmdParams.Count; x++)
                {
                    var vkParam = cmdParams[x];
                    var paramName = vkParam.Name;
                    var paramType = vkParam.Type.Name;

                    if(paramType == "Char")
                        paramType = "String";

                    if(paramLists.Contains(vkParam))
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
                // ---

                WriteLine("{");
                _tabs++;
                #endregion

                #region Single Return Prologue
                if(returnParam != null && !returnsList)
                {
                    WriteLine($"var {returnParam.Name} = new {returnParam.Type}();");

                    if(returnParam.IsFixed)
                    {
                        var type = IsPlatformStruct(returnParam.Type) ? $"{returnParam.Type}" : "IntPtr";
                        if (returnParam.Type is VkHandle)
                            type = ((VkHandle)returnParam.Type).IsDispatchable ? "IntPtr" : "UInt64";

                        var handle = (returnParam.Type is VkHandle) ? $".{NativePointer}" : string.Empty;
                        WriteLine($"fixed({type}* ptr{returnParam.Type} = &{returnParam.Name}{handle})");
                        WriteLine("{");
                        _tabs++;
                    }
                }
                #endregion

                #region List Return Prologue
                if(returnsList && returnListCountParam != null)
                {
                    if (returnListCountMember == null)
                    {
                        WriteLine($"{returnListCountParam.Type} listLength;");
                    }
                    else
                    {
                        WriteLine($"var listLength = {returnListCountParam.Name}.{returnListCountMember.Name};");
                    }
                }
                #endregion

                #region Array Parameters Prologue
                if(hasArrayParams)
                {
                    WriteLine("// hasArrayArguments");
                    if(paramListCountMap.Count == 0)
                        WriteLine("// (no arrayLengthParams)");

                    // Emit a prologue block for each array param
                    foreach (var kv in paramListCountMap)
                    {
                        var paramName  = kv.Key.Name;
                        var paramType  = kv.Key.Type;
                        var paramTypeName = kv.Key.Type.Name;
                        var countName  = kv.Value.Name;
                        var sizeVar    = $"_{paramName}Size";
                        var ptrVar     = $"_{paramName}Ptr";
                        var paramIsHandle = kv.Key.Type is VkHandle;
                        var paramIsIntPtr = (paramTypeName == "IntPtr");
                        var paramIsInterop = (paramType is VkStruct) && (((VkStruct)paramType).HasPointerMembers);
                        var interop    = (paramIsInterop) ? "Interop." : string.Empty;
                        var countType  = (paramIsHandle) ? "IntPtr" : paramTypeName;
                        var intPtrCast = (paramIsHandle || paramIsIntPtr) ? "(IntPtr*)" : string.Empty;
                        var nativePtr  = (paramIsIntPtr) ? string.Empty : $".{NativePointer}";

                        WriteLine($"var {countName} = ({kv.Value.Type}){paramName}.Count;");
                        WriteLine($"var {sizeVar} = Marshal.SizeOf(typeof({interop}{countType}));");
                        WriteLine($"var {ptrVar} = (void**)Marshal.AllocHGlobal((int)({sizeVar} * {countName}));");
                        WriteLine($"for(var x = 0; x < {countName}; x++)");
                        _tabs++;
                        WriteLine($"{ptrVar}[x] = {intPtrCast}{paramName}[x]{nativePtr};");
                        _tabs--;
                        WriteLine("");
                    }
                }
                #endregion

                #region Internal Function Call
                WriteTabs();
                if(internalReturnsVkResult || hasReturnValue)
                    Write("var result = ");

                Write($"{vkCommand.SpecName}");
                Write("(");

                var internalCallParams = new List<string>();
                foreach(var vkParam in vkCommand.Parameters)
                {
                    var paramName = vkParam.Name;
                    var paramType = vkParam.Type;

                    #region Return Param
                    if(vkParam == returnParam && returnsList)
                    {
                        // if the return value is a list and this is the kind of
                        // function we need to call twice (todo)
                        internalCallParams.Add("null");
                        continue;
                    }

                    if(vkParam == returnParam && vkParam.IsFixed)
                    {
                        internalCallParams.Add($"ptr{returnParam.Type}");
                        continue;
                    }
                    
                    if(vkParam == returnListCountParam && returnListCountMember == null)
                    {
                        internalCallParams.Add($"&listLength");
                        continue;
                    }

                    if(paramLists.Contains(vkParam))
                    {
                        var castType = string.Empty;
                        if (paramType is VkHandle)
                        {
                            var type = ((VkHandle)paramType).IsDispatchable ? "IntPtr" : "UInt64";
                            castType = $"({type}*)";
                        }
                        else if (paramType.Name == "IntPtr")
                        {
                            castType = $"(IntPtr*)";
                        }
                        else
                        {
                            castType = $"(Interop.{paramType}*)";
                        }
                        
                        internalCallParams.Add($"{castType}_{paramName}Ptr");
                        continue;
                    }
                    #endregion

                    if(IsPlatformStruct(paramType) || paramType is VkEnum)
                    {
                        var addressOf = string.Empty;
                        if(vkParam.IsPointer && paramType.Name != "Char")
                            addressOf = $"&";
                        
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
                        if(vkStruct.HasPointerMembers)
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

                Write(String.Join(", ", internalCallParams));

                Write(")");
                Write(";");
                Write(LineEnding);

                if(internalReturnsVkResult)
                {
                    WriteLine("if(result != Result.Success)");
                    _tabs++;
                    WriteLine($"throw new VulkanCommandException(nameof({vkCommand.SpecName}), result);");
                    _tabs--;
                }
                // ---
                #endregion

                #region Single Return Epilogue
                if(returnParam != null && returnParam.IsFixed && !returnsList)
                {
                    _tabs--;
                    WriteLine("}");
                }
                #endregion

                #region List Return 2nd Function Call
                if(returnsList && !hasArrayParams)
                {
                    WriteLine("");

                    var isInteropType = false;
                    if(returnParam.Type is VkStruct)
                    {
                        var vkStruct = returnParam.Type as VkStruct;
                        isInteropType = !vkStruct.HasPointerMembers;
                    }

                    var interop = (isInteropType || returnParam.Type is VkHandle || returnParam.Type is VkEnum) ? "" : "Interop.";
                    var sizeType = returnParam.Type.Name;
                    if(returnParam.Type is VkHandle)
                    {
                        sizeType = "IntPtr";
                        var vkHandle = returnParam.Type as VkHandle;
                        if(!vkHandle.IsDispatchable)
                            sizeType = "UInt64";
                    }
                    
                    WriteLine($"var array{returnParam.Type} = new {interop}{sizeType}[listLength];");
                    WriteLine($"fixed({interop}{sizeType}* resultPtr = &array{returnParam.Type}[0])");
                    _tabs++;
                    
                    #region internal callback params
                    // --- internal callback params
                    WriteTabs();
                    if(internalReturnsVkResult)
                        Write("result = ");

                    Write($"{vkCommand.SpecName}");
                    Write("(");

                    for(var x = 0; x < vkCommand.Parameters.Length; x++)
                    {
                        var vkParam = vkCommand.Parameters[x];
                        var paramType = vkParam.Type.Name;

                        if(vkParam == returnParam)
                        {
                            if(returnsList)
                            {
                                Write("resultPtr");
                            }
                            else if(vkParam.IsFixed)
                            {
                                Write($"ptr{returnParam.Type}");
                            }
                            else
                            {
                                if(platformStructTypes.Contains(vkParam.Type.Name))
                                {
                                    // If the platform type is a pointer, use the dref syntax
                                    Write($"&{vkParam.Name}");
                                }
                                else
                                {
                                    // Otherwise it's a struct or a handle
                                    Write($"{vkParam.Name}.{NativePointer}");
                                }
                            }
                        }
                        else if(vkParam == returnListCountParam)
                        {
                            if (returnListCountMember == null)
                            {
                                Write($"&listLength");
                            }
                            else
                            {
                                Write($"{vkParam.Name}.{NativePointer}");
                            }
                        }
                        else
                        {
                            if(platformStructTypes.Contains(vkParam.Type.Name) || vkParam.Type is VkEnum)
                            {
                                // If the platform type is a pointer, use the dref syntax
                                if (vkParam.IsPointer && vkParam.Type.Name != "Char")
                                    Write("&");

                                // Otherwise just pass it
                                Write($"{vkParam.Name}");
                            }
                            else
                            {
                                // struct or handle, pass the native pointer
                                Write($"{vkParam.Name}.{NativePointer}");
                            }
                        }
                        
                        if(x + 1 < vkCommand.Parameters.Length)
                            Write(", ");
                    }

                    Write(")");
                    Write(";");
                    Write(LineEnding);

                    _tabs--;

                    if(internalReturnsVkResult)
                    {
                        WriteLine("if(result != Result.Success)");
                        _tabs++;
                        WriteLine($"throw new VulkanCommandException(nameof({vkCommand.SpecName}), result);");
                        _tabs--;
                    }
                    // ---
                    #endregion
                }
                #endregion

                #region Epilogue
                if(returnParam != null)
                {
                    if (returnsList && !hasArrayParams)
                    {
                        WriteLine("");
                        WriteLine($"var list = new {returnType}();");
                        WriteLine($"for(var x = 0; x < listLength; x++)");
                        WriteLine("{");
                        _tabs++;

                        var isInteropType = false;
                        if(returnParam.Type is VkStruct)
                        {
                            var vkStruct = returnParam.Type as VkStruct;
                            isInteropType = !vkStruct.HasPointerMembers;
                        }

                        if(isInteropType || returnParam.Type is VkEnum)
                        {
                            WriteLine($"list.Add(array{returnParam.Type}[x]);");
                        }
                        else
                        {
                            WriteLine($"var item = new {returnParam.Type}();");

                            if(returnParam.Type is VkHandle)
                            {
                                WriteLine($"item.{NativePointer} = array{returnParam.Type}[x];");
                            }
                            else
                            {
                                WriteLine($"fixed(Interop.{returnParam.Type}* itemPtr = &array{returnParam.Type}[x])");
                                _tabs++;
                                WriteLine($"item.{NativePointer} = itemPtr;");
                                _tabs--;
                            }

                            WriteLine($"list.Add(item);");
                        }
                        
                        _tabs--;
                        WriteLine("}");
                        WriteLine("");
                        WriteLine($"return list;");
                    }
                    else
                    {
                        if (!hasArrayParams)
                        {
                            WriteLine($"return {returnParam.Name};");
                        }
                        else
                        {
                            WriteLine("throw new NotImplementedException();");
                        }
                    }
                }
                else if(returnType != "void")
                {
                    if(hasReturnValue && !hasArrayParams)
                    {
                        WriteLine("return result;");
                    }
                    else
                    {
                        WriteLine("throw new NotImplementedException(\"Appears to return a value but could not determine the type\");");
                    }
                }
                
                _tabs--;
                WriteLine("}");
                WriteLine("");
                #endregion
            }

            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");

            return _sb.ToString();
        }

        string GenerateHandleExtensions(IEnumerable<VkHandle> vkHandles, IEnumerable<VkCommand> vkCommands)
        {
            Clear();
            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            //WriteLine("using System.Diagnostics;");
            WriteLine("");
            WriteLine("namespace Vulkan.ObjectModel");
            WriteLine("{");
            _tabs++;
            WriteLine("public static class HandleExtensions");
            WriteLine("{");
            _tabs++;

            foreach(var vkHandle in vkHandles)
            {
                var handleCommands = vkCommands.Where(x => x.Parameters.FirstOrDefault()?.Type.Name == vkHandle.Name);
                if(!handleCommands.Any())
                    continue;

                WriteLine($"#region {vkHandle.Name}");
                WriteLine("");
                foreach(var vkCommand in handleCommands)
                {
                    var returnType = (vkCommand.ReturnType != null) ? vkCommand.ReturnType.Name : "void";
                    var internalReturnsResult = returnType == "Result";
                    if (internalReturnsResult)
                        returnType = "void";

                    List<VkParam> excludeFromArguments = new List<VkParam>();

                    bool returnsList = false;
                    VkParam returnParam = null;
                    VkParam listLengthParam = null;

                    //
                    // If the last param is a non-constant pointer, it's a return value
                    //
                    var lastParam = vkCommand.Parameters.Last();
                    if (lastParam != null && lastParam.IsOut)
                    {
                        if (string.IsNullOrEmpty(lastParam.Len))
                        {
                            // return value is a single object
                            returnParam = lastParam;
                            returnType = returnParam.Type.Name;
                            excludeFromArguments.Add(returnParam);
                        }
                        else
                        {
                            // return value is an array of objects
                            var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == lastParam.Len);
                            if (countParam != null)
                            {
                                returnsList = true;

                                returnParam = lastParam;
                                returnType = $"List<{returnParam.Type.Name}>";

                                excludeFromArguments.Add(returnParam);

                                // If countParam is a pointer, then we don't know the length
                                // of the array, so we have to call the function twice. Otherwise
                                // we provide the length as an argument
                                if (countParam.IsPointer)
                                {
                                    listLengthParam = countParam;
                                    excludeFromArguments.Add(listLengthParam);
                                }
                            }
                            else
                            {
                                var splitLen = lastParam.Len.Split(new[] { "->" }, StringSplitOptions.None);
                                if (splitLen.Length > 1)
                                {
                                    //var argName = 
                                }
                            }
                        }
                    }

                    //
                    // In C, arrays are passed using the (uint32_t objectCount, const Object* pObject).
                    // We can combine the count and array pointer into once object, List<T>. Then we can
                    // read the length of the list inside the function when needed.
                    //
                    var arrayParams = vkCommand.Parameters
                        .Where(x => !string.IsNullOrEmpty(x.Len) && x.Type.Name != "Char")
                        .Except(new[] { returnParam });

                    var arrayLengthParams = new Dictionary<VkParam, VkParam>();
                    var hasArrayParams = arrayParams.Any();
                    if (hasArrayParams)
                    {
                        foreach (var param in arrayParams)
                        {
                            var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == param.Len);
                            if (countParam != null)
                            {
                                arrayLengthParams.Add(param, countParam);
                                excludeFromArguments.Add(countParam);
                            }
                        }
                    }

                    var hasReturnValue = (returnParam == null) && (returnType != "void");

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

                    Write($"{returnType} {commandName}");
                    Write("(");

                    var cmdParams = vkCommand.Parameters.Except(excludeFromArguments).ToList();
                    for(var x = 0; x < cmdParams.Count; x++)
                    {
                        var vkParam = cmdParams[x];
                        var paramType = vkParam.Type.Name;

                        if(x == 0)
                        {
                            Write($"this {paramType} {vkParam.Name}");
                        }
                        else if(paramType == "Char")
                        {
                            Write($"String {vkParam.Name}");
                        }
                        else if (arrayParams.Contains(vkParam))
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

                    WriteLine("{");
                    _tabs++;
                    WriteTabs();
                    if(returnParam != null || hasReturnValue)
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
                    
                    _tabs--;
                    WriteLine("}");

                    WriteLine("");
                }
                WriteLine("#endregion");
                WriteLine("");
            }

            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");

            return _sb.ToString();
        }

        bool IsPlatformStruct(VkType type)
            => platformStructTypes.Contains(type.Name);

        string GetStructArgument(VkStruct vkStruct)
        {
            if(vkStruct.HasPointerMembers)
            {
                return $"{vkStruct.Name}.{NativePointer}";
            }
            else
            {
                return $"&{vkStruct.Name}";
            }
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
            //_sb.AppendLine($"{new string(' ', _tabs * 4)}{str}");
            _sb.Append($"{new string(' ', _tabs * 4)}{str}{LineEnding}");
        }
    }
}
