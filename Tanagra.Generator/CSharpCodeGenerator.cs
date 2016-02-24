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
        List<string> platformStructTypes;

        public Dictionary<string, string> files;
        
        public CSharpCodeGenerator()
        {
            _sb = new StringBuilder();
            files = new Dictionary<string, string>();

            platformStructTypes = new List<string>
            {
                "void",
                "Char",
                "Single",
                "Byte",
                "UInt32",
                "UInt64",
                "Int32",
                "Int64",
                "Boolean"
            };
        }

        public string Generate(VkSpec spec)
        {
            //
            // Ideally `CSharpCodeGenerator` transforms the data as little as possible. It
            // should only transform data if doing so in the rewrite step is awkward or impossible.
            //

            foreach(var vkSpec in spec.Handles)
                files.Add(vkSpec.Name + ".cs", GenerateHandle(vkSpec));

            foreach(var vkEnum in spec.Enums)
            {
                if(vkEnum.Name != "API Constants")
                {
                    files.Add("./enums/" + vkEnum.Name + ".cs", GenerateEnum(vkEnum));
                }
            }
            
            foreach(var vkStruct in spec.Structs)
            {
                if(!platformStructTypes.Contains(vkStruct.Name))
                {
                    files.Add("./structs/" + vkStruct.Name + ".cs", GenerateStruct(vkStruct));
                }
            }
            
            files.Add("VK.cs", GenerateCommandClass(spec.Commands));

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

            WriteLine("[StructLayout(LayoutKind.Sequential)]");
            WriteLine($"public struct {name}");
            WriteLine("{");

            _tabs++;
            
            WriteLine($"public readonly static {name} Null = new {name}();");
            WriteLine("");
            WriteLine("internal IntPtr NativeHandle;");
            WriteLine("");
            WriteLine("public override string ToString() => NativeHandle.ToString();");

            _tabs--;

            WriteLine("}");

            _tabs--;

            WriteLine("}");

            return _sb.ToString();
        }

        string GenerateStruct(VkStruct vkStruct)
        {
            Clear();
            
            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteLine("{");

            _tabs++;
            
            //WriteLine("[Serializable]");
            WriteLine("[StructLayout(LayoutKind.Sequential)]");
            WriteLine($"public struct {vkStruct.Name}");
            WriteLine("{");

            _tabs++;

            foreach(var member in vkStruct.Members)
            {
                if(member.Type.Name == "void")
                {
                    WriteLine($"public IntPtr {member.Name};");
                }
                else
                {
                    if(string.IsNullOrEmpty(member.Len))
                    {
                        WriteLine($"public {member.Type} {member.Name};");
                    }
                    else
                    {
                        WriteLine($"public {member.Type}[] {member.Name}; // len:{member.Len}");
                    }
                }
            }
            
            _tabs--;

            WriteLine("}");

            _tabs--;

            WriteLine("}");

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

            if(vkEnum.IsBitmask) WriteLine("[Flags]");
            WriteLine($"public enum {vkEnum.Name}");
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
                WriteLine($"{vkEnumValue.Name} = {vkEnumValue.Value},");
            }
            
            _tabs--;

            WriteLine("}");

            _tabs--;

            WriteLine("}");

            return _sb.ToString();
        }

        string GenerateCommandClass(VkCommand[] commands)
        {
            Clear();

            WriteLine("using System;");
            WriteLine("using System.Runtime.InteropServices;");
            WriteLine("");
            WriteLine("namespace Vulkan");
            WriteLine("{");

            _tabs++;

            WriteLine("public static class VK");
            WriteLine("{");

            _tabs++;

            WriteLine("");
            WriteLine("static VK()");
            WriteLine("{");
            WriteLine("}");
            WriteLine("");

            foreach (var cmd in commands)
            {
                var isUnsafe = cmd.Parameters.Any(x => x.PointerRank > 0);

                WriteLine($"// {cmd.ToDeclaration()}");
                WriteTabs();
                Write("public static ");
                if(isUnsafe) Write("unsafe ");
                Write(cmd.ReturnType.Name);
                Write(" ");
                Write(cmd.Name);
                Write("(");

                for (int x = 0; x < cmd.Parameters.Length; x++)
                {
                    var param = cmd.Parameters[x];
                    var paramType = param.Type.Name;
                    var pointer = new string('*', param.PointerRank);
                    if(paramType == "void") paramType = "IntPtr";
                    Write($"{paramType}{pointer} {param.Name}");
                    if (x + 1 < cmd.Parameters.Length)
                        Write(", ");
                }

                Write(")");
                Write(Environment.NewLine);

                WriteLine("{");
                _tabs++;
                
                WriteLine("throw new NotImplementedException();");
                
                _tabs--;
                WriteLine("}");

                WriteLine("");
            }

            foreach (var cmd in commands)
            {
                var isUnsafe = cmd.Parameters.Any(x => x.PointerRank > 0);

                WriteLine($"[DllImport(\"{DllName}\", EntryPoint = \"{cmd.SpecName}\", CallingConvention = CallingConvention.Winapi)]");
                
                WriteTabs();
                Write("public static ");
                if(isUnsafe) Write("unsafe ");
                Write($"extern {cmd.ReturnType} {cmd.SpecName}");
                Write("(");

                for (var x = 0; x < cmd.Parameters.Length; x++)
                {
                    var param = cmd.Parameters[x];
                    var paramType = param.Type.Name;
                    var pointer = new string('*', param.PointerRank);
                    if(paramType == "void") paramType = "IntPtr";
                    Write($"{paramType}{pointer} {param.Name}");
                    if (x + 1 < cmd.Parameters.Length)
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
