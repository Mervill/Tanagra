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

        public Dictionary<string, string> files;

        const string NativeHandle = "NativeHandle";

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
            };
        }

        public string Generate(VkSpec spec)
        {
            //
            // Ideally `CSharpCodeGenerator` transforms the data as little as possible. It
            // should only transform data if doing so in the rewrite step is awkward or impossible.
            //

            foreach(var vkEnum in spec.Enums.Where(vkEnum => vkEnum.Name != "API Constants"))
                files.Add($"./Enum/{vkEnum.Name}.cs", GenerateEnum(vkEnum));
            
            foreach(var vkSpec in spec.Handles)
                files.Add($"./Handle/{vkSpec.Name}.cs", GenerateHandle(vkSpec));

            files.Add("./Interop/Structs.cs", GenerateInteropStructs(spec.Structs));
            files.Add("./Interop/VK.cs", GenerateCommandBindings(spec.Commands));

            foreach (var vkStruct in spec.Structs.Where(vkStruct => !platformStructTypes.Contains(vkStruct.Name)))
                files.Add($"./Wrapper/{vkStruct.Name}.cs", GenerateWrapperClass(vkStruct));

            files.Add("./Wrapper/VK.cs", GenerateCommandWrapper(spec.Commands));

            files.Add("./ObjectModel.cs", GenerateHandleExtensions(spec.Handles, spec.Commands));
            
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
            WriteLine($"internal IntPtr {NativeHandle};");
            WriteLine("");
            WriteLine($"public override string ToString() => {NativeHandle}.ToString();");
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

        string GenerateCommandBindings(VkCommand[] commands)
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
                        var pointer = new string('*', param.PointerRank);
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
            WriteLine($"internal Interop.{vkStruct.Name}* {NativeHandle};");
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
            WriteLine($"{NativeHandle} = (Interop.{vkStruct.Name}*)Interop.Structure.Allocate(typeof(Interop.{vkStruct.Name}));");
            if (generateStructureType)
                WriteLine($"//{NativeHandle}->SType = StructureType.{vkStruct.Name};");
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
            WriteLine($"get {{ return {NativeHandle}->{vkMember.Name}; }}");
            WriteLine($"set {{ {NativeHandle}->{vkMember.Name} = value; }}");
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
            WriteLine($"set {{ _{vkMember.Name} = value; {NativeHandle}->{vkMember.Name} = (IntPtr)value.{NativeHandle}; }}");
            _tabs--;
            WriteLine("}");
        }

        void WriteMemberString(VkMember vkMember)
        {
            WriteLine($"public string {vkMember.Name}");
            WriteLine("{");
            _tabs++;
            WriteLine($"get {{ return Marshal.PtrToStringAnsi({NativeHandle}->{vkMember.Name}); }}");
            WriteLine($"set {{ {NativeHandle}->{vkMember.Name} = Marshal.StringToHGlobalAnsi(value); }}");
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

            WriteLine($"var strings = new String[{NativeHandle}->{countName}];");
            WriteLine($"void** ptr = (void**){NativeHandle}->{vkMember.Name};");
            WriteLine($"for(int x = 0; x < {NativeHandle}->{countName}; x++)");
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
            WriteLine($"{NativeHandle}->{countName} = (uint)value.Length;");
            WriteLine($"{NativeHandle}->{vkMember.Name} = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*{NativeHandle}->{countName}));");
            WriteLine($"void** ptr = (void**){NativeHandle}->{vkMember.Name};");
            WriteLine($"for(int x = 0; x < {NativeHandle}->{countName}; x++)");
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

                var numOut = vkCommand.Parameters.Count(x => x.IsOut);
                var numFixed = vkCommand.Parameters.Count(x => x.IsFixed);

                bool returnsList = false;
                VkParam returnParam = null;
                VkParam listLengthParam = null;
                
                var lastParam = vkCommand.Parameters.Last();
                if(lastParam != null)
                {
                    if(!string.IsNullOrEmpty(lastParam.Len))
                    {
                        var countParam = vkCommand.Parameters.ToList().FirstOrDefault(x => x.Name == lastParam.Len);
                        if(countParam != null && countParam.IsOut)
                        {
                            // IsFixed, IsOut, IsPointer
                            returnsList = true;

                            returnParam = lastParam;
                            returnType = $"List<{returnParam.Type.Name}>";
                            listLengthParam = countParam;

                            excludeFromArguments.Add(returnParam);
                            excludeFromArguments.Add(countParam);
                        }
                    }
                    else if(lastParam.Type is VkHandle && lastParam.IsOut)
                    {
                        // IsFixed, IsOut, IsPointer
                        returnParam = lastParam;
                        returnType = returnParam.Type.Name;
                        excludeFromArguments.Add(returnParam);
                    }
                }

                // --- function params
                WriteTabs();
                Write("public static ");
                Write($"{returnType} {vkCommand.Name}");
                Write("(");

                var cmdParams = vkCommand.Parameters.Except(excludeFromArguments).ToList();
                for(var x = 0; x < cmdParams.Count; x++)
                {
                    var param = cmdParams[x];
                    var paramType = param.Type.Name;

                    if(paramType == "Char")
                    {
                        Write($"String {param.Name}");
                    }
                    else
                    {
                        Write($"{paramType} {param.Name}");
                    }
                    
                    if(x + 1 < cmdParams.Count)
                        Write(", ");
                }

                Write(")");
                Write(Environment.NewLine);
                // ---

                WriteLine("{");
                _tabs++;

                if(returnParam != null)
                {
                    if(returnsList)
                    {
                        WriteLine($"{listLengthParam.Type} {listLengthParam.Name};");
                    }
                    else
                    {
                        WriteLine($"{returnParam.Type} {returnParam.Name} = new {returnParam.Type}();");

                        var type = (returnParam.Type is VkHandle) ? "IntPtr" : $"{returnParam.Type}";
                        var handle = (returnParam.Type is VkHandle) ? $".{NativeHandle}" : string.Empty;
                        WriteLine($"fixed({type}* ptr{returnParam.Type} = &{returnParam.Name}{handle})");
                        WriteLine("{");
                        _tabs++;
                    }
                }
                
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
                        Write((returnsList) ? "null" : $"ptr{vkParam.Type}");
                    }
                    else if(returnsList && vkParam == listLengthParam)
                    {
                        Write($"&{vkParam.Name}");
                    }
                    else if((vkParam.Type is VkStruct && !platformStructTypes.Contains(paramType)) || vkParam.Type is VkHandle)
                    {
                        Write($"{vkParam.Name}.{NativeHandle}");
                    }
                    else
                    {
                        Write($"{vkParam.Name}");
                    }

                    if(x + 1 < vkCommand.Parameters.Length)
                        Write(", ");
                }

                Write(")");
                Write(";");
                Write(Environment.NewLine);
                
                if(internalReturnsResult)
                {
                    WriteLine("if(result != Result.SUCCESS)");
                    _tabs++;
                    WriteLine($"throw new VulkanCommandException(nameof({vkCommand.SpecName}), result);");
                    _tabs--;
                }
                // ---
                
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
                            if(returnParam.Type is VkHandle)
                            {
                                Write($"(IntPtr*)ptr{returnParam.Type}");
                            }
                            else
                            {
                                Write($"(Interop.{returnParam.Type}*)ptr{returnParam.Type}");
                            }
                        }
                        else if(returnsList && vkParam == listLengthParam)
                        {
                            Write($"&{vkParam.Name}");
                        }
                        else if((vkParam.Type is VkStruct && !platformStructTypes.Contains(paramType)) || vkParam.Type is VkHandle)
                        {
                            Write($"{vkParam.Name}.{NativeHandle}");
                        }
                        else
                        {
                            Write($"{vkParam.Name}");
                        }

                        if(x + 1 < vkCommand.Parameters.Length)
                            Write(", ");
                    }

                    Write(")");
                    Write(";");
                    Write(Environment.NewLine);

                    if(internalReturnsResult)
                    {
                        WriteLine("if(result != Result.SUCCESS)");
                        _tabs++;
                        WriteLine($"throw new VulkanCommandException(nameof({vkCommand.SpecName}), result);");
                        _tabs--;
                    }
                    // ---
                }

                if(returnParam != null && !returnsList)
                {
                    _tabs--;
                    WriteLine("}");
                }
                
                if(returnsList)
                {
                    WriteLine("");
                    WriteLine($"var list = new {returnType}();");
                    WriteLine($"for(var x = 0; x < {listLengthParam.Name}; x++)");
                    WriteLine("{");
                    _tabs++;
                    WriteLine($"var item = new {returnParam.Type}();");
                    
                    if(returnParam.Type is VkHandle)
                    {
                        WriteLine($"item.{NativeHandle} = ((IntPtr*)ptr{returnParam.Type})[x];");
                    }
                    else
                    {
                        WriteLine($"item.{NativeHandle} = &((Interop.{returnParam.Type}*)ptr{returnParam.Type})[x];");
                    }
                    
                    WriteLine($"list.Add(item);");
                    _tabs--;
                    WriteLine("}");
                    WriteLine("");
                    WriteLine($"return list;");
                }
                else
                {
                    if(returnParam != null)
                    {
                        WriteLine($"return {returnParam.Name};");
                    }
                    else
                    {
                        if(returnType != "void")
                            WriteLine("throw new NotImplementedException();");
                    }
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
                    WriteTabs();
                    Write("public static ");

                    var returnType = (vkCommand.ReturnType != null) ? vkCommand.ReturnType.Name : "void";
                    var returnsResult = returnType == "Result";
                    if(returnsResult)
                        returnType = "void";

                    Write($"{returnType} {vkCommand.Name}");
                    Write("(");

                    for(var x = 0; x < vkCommand.Parameters.Length; x++)
                    {
                        var param = vkCommand.Parameters[x];
                        var paramType = param.Type.Name;
                        var thisKeyword = (x == 0) ? "this " : string.Empty;
                        Write($"{thisKeyword}{paramType} {param.Name}");
                        if(x + 1 < vkCommand.Parameters.Length)
                            Write(", ");
                    }

                    Write(")");
                    Write(Environment.NewLine);

                    WriteLine("{");
                    _tabs++;
                    WriteTabs();
                    if(vkCommand.ReturnType != null && !returnsResult)
                        Write("return ");
                    Write($"VK.{vkCommand.Name}");
                    Write("(");

                    for(var x = 0; x < vkCommand.Parameters.Length; x++)
                    {
                        var param = vkCommand.Parameters[x];
                        Write($"{param.Name}");
                        if(x + 1 < vkCommand.Parameters.Length)
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
