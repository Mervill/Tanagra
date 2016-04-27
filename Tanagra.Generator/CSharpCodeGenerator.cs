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

            foreach(var vkSpec in spec.Handles)
                files.Add($"{vkSpec.Name}.cs", GenerateHandle(vkSpec));

            foreach (var vkEnum in spec.Enums.Where(vkEnum => vkEnum.Name != "API Constants"))
                files.Add($"./enums/{vkEnum.Name}.cs", GenerateEnum(vkEnum));
            
            foreach (var vkStruct in spec.Structs.Where(vkStruct => !platformStructTypes.Contains(vkStruct.Name)))
                files.Add($"./structs/{vkStruct.Name}.cs", GenerateWrapperClass(vkStruct));
            
            files.Add("VK.cs", GenerateCommandClass(spec.Commands));

            files.Add("VK.Interop.cs", GenerateInteropStructs(spec.Structs));

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
                        WriteMemberStringArray(member.Name);
                    }
                    else
                    {
                        WriteMemberString(member.Name);
                    }
                    WriteLine("");
                    continue;
                }

                if (member.Type is VkEnum || platformStructTypes.Contains(member.Type.Name))
                {
                    WriteMember(member.Name, member.Type.Name);
                    WriteLine("");
                    continue;
                }
                
                WriteMemberStruct(member.Name, member.Type.Name);
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

        void WriteMember(string memberName, string memberType)
        {
            WriteLine($"public {memberType} {memberName}");
            WriteLine("{");
            _tabs++;
            WriteLine($"get {{ return {NativeHandle}->{memberName}; }}");
            WriteLine($"set {{ {NativeHandle}->{memberName} = value; }}");
            _tabs--;
            WriteLine("}");
        }

        void WriteMemberStruct(string memberName, string memberType)
        {
            WriteLine($"{memberType} _{memberName};");
            WriteLine($"public {memberType} {memberName}");
            WriteLine("{");
            _tabs++;
            WriteLine($"get {{ return _{memberName}; }}");
            WriteLine($"set {{ _{memberName} = value; {NativeHandle}->{memberName} = (IntPtr)value.{NativeHandle}; }}");
            _tabs--;
            WriteLine("}");
        }

        void WriteMemberString(string memberName)
        {
            WriteLine($"public string {memberName}");
            WriteLine("{");
            _tabs++;
            WriteLine($"get {{ return Marshal.PtrToStringAnsi({NativeHandle}->{memberName}); }}");
            WriteLine($"set {{ {NativeHandle}->{memberName} = Marshal.StringToHGlobalAnsi(value); }}");
            _tabs--;
            WriteLine("}");
        }
        
        void WriteMemberStringArray(string memberName)
        {
            WriteLine($"public string[] {memberName}");
            WriteLine("{");
            _tabs++;

            // get
            WriteLine("get");
            WriteLine("{");
            _tabs++;

            if (!memberName.EndsWith("Names"))
                throw new Exception($"unable to handle member {memberName}");
            var countName = memberName.Substring(0, memberName.Length - 5) + "Count";

            WriteLine($"var strings = new String[{NativeHandle}->{countName}];");
            WriteLine($"void** ptr = (void**){NativeHandle}->{memberName};");
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
            WriteLine($"{NativeHandle}->{memberName} = Marshal.AllocHGlobal((int)(sizeof(IntPtr)*{NativeHandle}->{countName}));");
            WriteLine($"void** ptr = (void**){NativeHandle}->{memberName};");
            WriteLine($"for(int x = 0; x < {NativeHandle}->{countName}; x++)");
            _tabs++;
            WriteLine("ptr[x] = (void*)Marshal.StringToHGlobalAnsi(value[x]);");
            _tabs--;
            _tabs--;
            WriteLine("}");

            _tabs--;
            WriteLine("}");
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

        string GenerateCommandClass(VkCommand[] commands)
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
            WriteLine("");
            WriteLine("static VK()");
            WriteLine("{");
            WriteLine("}");
            WriteLine("");

            foreach (var cmd in commands)
            {
                WriteLine($"[DllImport(DllName, EntryPoint = \"{cmd.SpecName}\", CallingConvention = CallingConvention.Winapi)]");
                
                WriteTabs();
                Write("public static ");
                Write($"extern {cmd.ReturnType} {cmd.SpecName}");
                Write("(");

                for (var x = 0; x < cmd.Parameters.Length; x++)
                {
                    var param = cmd.Parameters[x];
                    var paramType = param.Type.Name;
                    if (param.Type is VkHandle)
                        paramType = "IntPtr";

                    var pointer = new string('*', param.PointerRank);
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
