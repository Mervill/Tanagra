using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanagra.Generator
{
    public class CSharpCodeGenerator
    {
        StringBuilder _sb;
        int _tabs;

        public string DllName = "vulkan-1.dll";
        readonly List<string> platformStructTypes;
        readonly List<string> disabledStructs;
        readonly List<string> disabledCommands;

        public Dictionary<string, string> files;

        const string NativePointer = "NativePointer";

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
                "UInt32",
                "UInt64",
                "Int32",
                "UIntPtr",
                "Boolean",
                "DeviceSize",
            };

            disabledStructs = new List<string> 
            {
                //"DebugReportCallbackCreateInfoEXT",
            };

            disabledCommands = new List<string>
            {
                "GetPipelineCacheData",
                "GetPhysicalDeviceSurfacePresentModesKHR",
                "GetPhysicalDeviceXlibPresentationSupportKHR",
                "GetPhysicalDeviceWin32PresentationSupportKHR",
                "GetPhysicalDeviceXcbPresentationSupportKHR",
                "GetDeviceProcAddr",
                "GetInstanceProcAddr",
                "DebugReportMessageEXT",
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

            files.Add("./Interop/Structs.cs", GenerateInteropStructs(spec.Structs));
            files.Add("./Interop/VK.cs", GenerateCommandBindings(commands));

            var generateStructs = spec.Structs.Where(vkStruct => !platformStructTypes.Contains(vkStruct.Name) && !disabledStructs.Contains(vkStruct.Name));
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

            foreach(var vkEnumValue in vkEnum.Values)
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
            WriteLine($"internal IntPtr {NativePointer};");
            WriteLine("");
            WriteLine($"public override string ToString() => {NativePointer}.ToString();");
            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");

            return _sb.ToString();
        }

        string GenerateInteropStructs(IEnumerable<VkStruct> vkStructs)
        {
            Clear();

            WriteLine("// ReSharper disable BuiltInTypeReferenceStyle");
            WriteLine("// ReSharper disable InconsistentNaming");
            WriteLine("using System;");
            WriteLine("");
            WriteLine("namespace Vulkan.Interop");
            WriteLine("{");
            _tabs++;

            foreach (var vkStruct in vkStructs)
            {
                if (platformStructTypes.Contains(vkStruct.Name))
                    continue;

                WriteLine($"internal struct {vkStruct.Name}");
                WriteLine("{");
                _tabs++;

                if (vkStruct.IsImportedType)
                    WriteLine("// Imported type");

                foreach (var member in vkStruct.Members)
                {
                    if (member.Type is VkEnum || (platformStructTypes.Contains(member.Type.Name) && member.Type.Name != "Char"))
                    {
                        WriteLine($"internal {member.Type} {member.Name};");
                        continue;
                    }
                    // Eveything else is a pointer
                    // `Char` is a C-style string ... so it's a pointer
                    WriteLine($"internal IntPtr {member.Name};");
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
            WriteLine($"const CallingConvention callingConvention = CallingConvention.Winapi;");
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
                        paramType = "IntPtr";

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
                Write(Environment.NewLine);

                WriteLine("");
            }

            _tabs--;
            WriteLine("}");
            _tabs--;
            WriteLine("}");

            return _sb.ToString();
        }

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
            WriteLine($"{vkMember.Type.Name} _{vkMember.Name};");
            WriteLine($"public {vkMember.Type.Name} {vkMember.Name}");
            WriteLine("{");
            _tabs++;
            WriteLine($"get {{ return _{vkMember.Name}; }}");
            WriteLine($"set {{ _{vkMember.Name} = value; {NativePointer}->{vkMember.Name} = (IntPtr)value.{NativePointer}; }}");
            _tabs--;
            WriteLine("}");
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
            WriteLine($"for(int x = 0; x < {NativePointer}->{countName}; x++)");
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
            WriteLine($"for(int x = 0; x < {NativePointer}->{countName}; x++)");
            _tabs++;
            WriteLine("ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);");
            _tabs--;
            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
        }

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
                var internalReturnsResult = returnType == "Result";
                if(internalReturnsResult)
                    returnType = "void";

                List<VkParam> excludeFromArguments = new List<VkParam>();
                
                bool returnsList = false;
                VkParam returnParam = null;
                VkParam listLengthParam = null;
                
                var lastParam = vkCommand.Parameters.Last();
                if(lastParam != null)
                {
                    if(lastParam.IsOut && string.IsNullOrEmpty(lastParam.Len))
                    {
                        returnParam = lastParam;
                        returnType = returnParam.Type.Name;
                        excludeFromArguments.Add(returnParam);
                    }

                    if(!string.IsNullOrEmpty(lastParam.Len))
                    {
                        var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == lastParam.Len);
                        if(countParam != null && countParam.IsPointer)
                        {
                            returnsList = true;

                            returnParam = lastParam;
                            returnType = $"List<{returnParam.Type.Name}>";
                            listLengthParam = countParam;

                            excludeFromArguments.Add(returnParam);
                            excludeFromArguments.Add(countParam);
                        }
                    }
                }

                var paramArrays = vkCommand.Parameters.Where(x => !string.IsNullOrEmpty(x.Len) && x.Type.Name != "Char");
                var hasArrayArguments = paramArrays.Except(new[] { returnParam }).Any();

                // --- function params
                WriteTabs();
                Write("public static ");
                Write($"{returnType} {vkCommand.Name}");
                Write("(");

                var cmdParams = vkCommand.Parameters.Except(excludeFromArguments).ToList();
                for(var x = 0; x < cmdParams.Count; x++)
                {
                    var vkParam = cmdParams[x];
                    var paramType = vkParam.Type.Name;

                    if(paramType == "Char")
                    {
                        Write($"String {vkParam.Name}");
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
                Write(Environment.NewLine);
                // ---

                WriteLine("{");
                _tabs++;

                // debug
                /*foreach(var vkParam in vkCommand.Parameters)
                {
                    WriteLine($"// {vkParam.Name} ({vkParam.Type})[{vkParam.Type.GetType()}]");
                    WriteLine($"//     IsConst:   {vkParam.IsConst}");
                    WriteLine($"//     IsFixed:   {vkParam.IsFixed} (Type is VkHandle && !IsConst)");
                    WriteLine($"//     IsOut:     {vkParam.IsOut} (IsPointer && !IsConst)");
                    //WriteLine($"//     IsPointer: {vkParam.IsPointer}");
                }*/

                if(returnParam != null && !returnsList)
                {
                    WriteLine($"{returnParam.Type} {returnParam.Name} = new {returnParam.Type}();");

                    if(returnParam.IsFixed)
                    {
                        var type = platformStructTypes.Contains(returnParam.Type.Name) ? $"{returnParam.Type}" : "IntPtr";
                        var handle = (returnParam.Type is VkHandle) ? $".{NativePointer}" : string.Empty;
                        WriteLine($"fixed({type}* ptr{returnParam.Type} = &{returnParam.Name}{handle})");
                        WriteLine("{");
                        _tabs++;
                    }
                }

                if(returnsList)
                {
                    WriteLine($"{listLengthParam.Type} {listLengthParam.Name};");
                }

                if(!hasArrayArguments)
                {
                    // --- internal callback params
                    WriteTabs();
                    if(internalReturnsResult)
                        Write("var result = ");

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
                                Write("null");
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
                        else if(vkParam == listLengthParam)
                        {
                            Write($"&{vkParam.Name}");
                        }
                        else
                        {
                            if(platformStructTypes.Contains(vkParam.Type.Name) || vkParam.Type is VkEnum)
                            {
                                if(vkParam.IsPointer && vkParam.Type.Name != "Char")
                                {
                                    // If the platform type is a pointer, use the dref syntax
                                    Write($"&{vkParam.Name}");
                                }
                                else
                                {
                                    // Otherwise just pass it
                                    Write($"{vkParam.Name}");
                                }
                            }
                            else
                            {
                                // struct or handle, pass the native pointer
                                if(!(vkParam.Type is VkHandle) && vkParam.Optional.Length != 0 && vkParam.Optional[0] == "true")
                                {
                                    Write($"({vkParam.Name} != null) ? {vkParam.Name}.{NativePointer} : null");
                                }
                                else
                                {
                                    Write($"{vkParam.Name}.{NativePointer}");
                                }
                            }
                        }
                        
                        if(x + 1 < vkCommand.Parameters.Length)
                            Write(", ");
                    }

                    Write(")");
                    Write(";");
                    Write(Environment.NewLine);

                    if(internalReturnsResult)
                    {
                        WriteLine("if(result != Result.Success)");
                        _tabs++;
                        WriteLine($"throw new VulkanCommandException(nameof({vkCommand.SpecName}), result);");
                        _tabs--;
                    }
                    // ---
                }
                else
                {
                    WriteLine("// hasArrayArguments");
                    WriteLine("throw new NotImplementedException();");
                }
                
                if(returnParam != null && returnParam.IsFixed && !returnsList)
                {
                    _tabs--;
                    WriteLine("}");
                }

                if(returnsList)
                {
                    WriteLine("");

                    var interop = (returnParam.Type is VkHandle) ? "" : "Interop.";
                    var sizeType = (returnParam.Type is VkHandle) ? "IntPtr" : returnParam.Type.Name;
                    WriteLine($"int size = Marshal.SizeOf(typeof({interop}{sizeType}));");
                    WriteLine($"var ptr{returnParam.Type} = Marshal.AllocHGlobal((int)(size * {listLengthParam.Name}));");

                    // --- internal callback params
                    WriteTabs();
                    if(internalReturnsResult)
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
                                if(returnParam.Type is VkHandle)
                                {
                                    Write($"(IntPtr*)ptr{returnParam.Type}");
                                }
                                else
                                {
                                    Write($"(Interop.{returnParam.Type}*)ptr{returnParam.Type}");
                                }
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
                        else if(vkParam == listLengthParam)
                        {
                            Write($"&{vkParam.Name}");
                        }
                        else
                        {
                            if(platformStructTypes.Contains(vkParam.Type.Name) || vkParam.Type is VkEnum)
                            {
                                if(vkParam.IsPointer && vkParam.Type.Name != "Char")
                                {
                                    // If the platform type is a pointer, use the dref syntax
                                    Write($"&{vkParam.Name}");
                                }
                                else
                                {
                                    // Otherwise just pass it
                                    Write($"{vkParam.Name}");
                                }
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
                    Write(Environment.NewLine);

                    if(internalReturnsResult)
                    {
                        WriteLine("if(result != Result.Success)");
                        _tabs++;
                        WriteLine($"throw new VulkanCommandException(nameof({vkCommand.SpecName}), result);");
                        _tabs--;
                    }
                    // ---
                }

                if(returnParam != null)
                {
                    if(!returnsList)
                    {
                        WriteLine($"return {returnParam.Name};");
                    }
                    else
                    {
                        WriteLine("");
                        WriteLine($"var list = new {returnType}();");
                        WriteLine($"for(var x = 0; x < {listLengthParam.Name}; x++)");
                        WriteLine("{");
                        _tabs++;
                        WriteLine($"var item = new {returnParam.Type}();");

                        if(returnParam.Type is VkHandle)
                        {
                            WriteLine($"item.{NativePointer} = ((IntPtr*)ptr{returnParam.Type})[x];");
                        }
                        else
                        {
                            WriteLine($"item.{NativePointer} = &((Interop.{returnParam.Type}*)ptr{returnParam.Type})[x];");
                        }

                        WriteLine($"list.Add(item);");
                        _tabs--;
                        WriteLine("}");
                        WriteLine("");
                        WriteLine($"return list;");
                    }
                }
                else if(returnType != "void")
                {
                    WriteLine("throw new NotImplementedException();");
                }
                
                _tabs--;
                WriteLine("}");
                WriteLine("");
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
                    if(internalReturnsResult)
                        returnType = "void";

                    List<VkParam> excludeFromArguments = new List<VkParam>();

                    bool returnsList = false;
                    VkParam returnParam = null;
                    VkParam listLengthParam = null;

                    var lastParam = vkCommand.Parameters.Last();
                    if(lastParam != null)
                    {
                        if(lastParam.IsOut && string.IsNullOrEmpty(lastParam.Len))
                        {
                            returnParam = lastParam;
                            returnType = returnParam.Type.Name;
                            excludeFromArguments.Add(returnParam);
                        }

                        if(!string.IsNullOrEmpty(lastParam.Len))
                        {
                            var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == lastParam.Len);
                            if(countParam != null && countParam.IsPointer)
                            {
                                returnsList = true;

                                returnParam = lastParam;
                                returnType = $"List<{returnParam.Type.Name}>";
                                listLengthParam = countParam;

                                excludeFromArguments.Add(returnParam);
                                excludeFromArguments.Add(countParam);
                            }
                        }
                    }

                    var paramArrays = vkCommand.Parameters.Where(x => !string.IsNullOrEmpty(x.Len) && x.Type.Name != "Char");
                    var hasArrayArguments = paramArrays.Except(new[] { returnParam }).Any();

                    WriteTabs();
                    Write("public static ");
                    
                    Write($"{returnType} {vkCommand.Name}");
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
                    Write(Environment.NewLine);

                    WriteLine("{");
                    _tabs++;
                    WriteTabs();
                    if(returnParam != null)
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
                    Write(Environment.NewLine);
                    
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
            _sb.AppendLine($"{new string(' ', _tabs * 4)}{str}");
        }
    }
}
