using System;
using System.Threading;
using System.Linq;
using System.IO;

namespace Tanagra.Generator
{
    class Program
    {
        // todo: spec extensions
        // todo: hasArrayArguments
        // todo: Create* commands that return arrays
        // todo: union
        // todo: x64 and VK_DEFINE_NON_DISPATCHABLE_HANDLE
        // todo: null input arrays
        // todo: arrays in structs
        // todo: Marshal.GetFunctionPointerForDelegate
        // XCB -> X protocol C-language Binding
        // https://msdn.microsoft.com/en-us/library/dn823273(v=vs.110).aspx
        static void Main(string[] args)
        {
            var raw = File.ReadAllText("./spec/vk.xml");

            var reader = new VKSpecReader();
            var spec = reader.Read(raw);

            Console.WriteLine("Structs:  {0}", spec.Structs.Count());
            Console.WriteLine("Handles:  {0}", spec.Handles.Count());
            Console.WriteLine("Enums:    {0}", spec.Enums.Count());
            Console.WriteLine("Commands: {0}", spec.Commands.Count());
            Console.WriteLine("Features: {0}", spec.Features.Count());
            Console.WriteLine("----------");
            
            var rewrite = new CSharpSpecRewriter();
            spec = rewrite.Rewrite(spec);

            var gen = new CSharpCodeGenerator();
            gen.Generate(spec);
            Console.WriteLine("Generated {0} files", gen.files.Count);
            
            var notHandleFn = spec.Commands.Where(x => !(x.Parameters.First().Type is VkHandle));

            //var codes = spec.Commands.SelectMany(x => x.ErrorCodes).Distinct().ToList();
            //codes.ForEach(Console.WriteLine);

            //var types = spec.AllTypes.Values.Where(x => x.Category == VkTypeCategory.None).Select(x => x.Name).ToList();
            //types.ForEach(Console.WriteLine);

            WriteCode(gen);

            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static void WriteCode(CSharpCodeGenerator gen)
        {
            Console.WriteLine("!!! Overwrite Generated Tanagra Files? [Y/n] !!!");
            string resp = Console.ReadLine();
            if(!resp.StartsWith("Y"))
            {
                Console.WriteLine("ABORT");
                return;
            }
            
            const string rootPath = "../../../Tanagra";
            try { Directory.Delete($"{rootPath}/Generated", true); } catch { }
            Console.WriteLine("Saving to disk...");
            foreach(var kv in gen.files)
            {
                var path = $"{rootPath}/Generated/{kv.Key}";
                new FileInfo(path).Directory.Create();
                File.WriteAllText(path, kv.Value);
            }
        }
    }
}
