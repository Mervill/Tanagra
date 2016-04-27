using System;
using System.Threading;
using System.Linq;
using System.IO;

namespace Tanagra.Generator
{
    // http://stackoverflow.com/questions/31702766/how-to-properly-pass-struct-pointer-from-c-sharp-to-c-dll
    // http://stackoverflow.com/questions/779444/p-invoke-c-function-that-returns-pointer-to-a-struct
    // http://stackoverflow.com/questions/16065110/porting-c-struct-to-c-sharp
    // http://stackoverflow.com/questions/15217406/passing-null-reference-for-a-ref-struct-parameter-in-interop-method
    // https://msdn.microsoft.com/en-us/library/system.runtime.interopservices.marshalasattribute(v=vs.110).aspx
    class Program
    {
        // todo: improve the generator so that WriteMember and simmilar take a vkType
        // todo: figure out what to do with imported types
        // todo: union (how?)
        // todo: detect when a pointer is really an array pointer (yeesh...)
        // XCB -> X protocol C-language Binding
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
            Directory.CreateDirectory($"{rootPath}/Generated");
            Thread.Sleep(1);
            Directory.CreateDirectory($"{rootPath}/Generated/enums");
            Thread.Sleep(1);
            Directory.CreateDirectory($"{rootPath}/Generated/structs");
            Thread.Sleep(1);
            Console.WriteLine("Saving to disk...");
            foreach(var kv in gen.files)
            {
                File.WriteAllText($"{rootPath}/Generated/{kv.Key}", kv.Value);
            }
        }
    }
}
