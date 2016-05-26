using System;
using System.Threading;
using System.Linq;
using System.IO;

namespace Tanagra.Generator
{
    class Program
    {
        // todo: realloc is broken
        // todo: union
        // todo: merge flag enums
        // todo: port member comments to constructor
        // todo: tanagra: handle wrapper, parent notify on destroy
        // todo: tanagra: nondispatchable extentions
        // todo: study more closely the lifecycle of vulkan objects, esp returned-only objects - when are they freed?
        // todo: typed pointers in structs?
        // todo: typed non-dispatchable?
        // todo: generate arrays instead of lists on commands?
        // todo: Fix edge cases in VulkanConstant
        // todo: MemoryPressure in extra areas
        // todo: There are still a few corner cases in memory allocation that will leak (pointer to nonmanaged struct)
        // todo: there is a common case where a command that takes arrays only takes a single entry
        // VK_SAMPLER_ADDRESS_MODE_MIRROR_CLAMP_TO_EDGE
        // VK_STENCIL_FRONT_AND_BACK
        //
        // Vulkan Docs:
        // https://www.khronos.org/registry/vulkan/specs/1.0/xhtml/vkspec.html
        //
        // Notes
        //
        // In most destroy commands (ie DestroyFence) the handle to be destroyed 
        // is an optional param ... why?
        //
        // Dispatchable handles use the platform word length so IntPtr is used to ensure 
        // that they are the correct size in structs on both platforms. Nondispatchable 
        // handles are always 64 bits in length. 
        //
        // Im not sure how I'd like to handle vendor suffixes. Most generators remove them, but the whole
        // point of the suffix is to prevent name collision, which while unlikely is still a thing that can
        // happen.
        //
        static void Main(string[] args)
        {
            var raw = File.ReadAllText("./spec/vk.xml");

            var reader = new VKSpecReader();
            var spec = reader.Read(raw);

            Console.WriteLine("Structs:    {0}", spec.Structs.Count());
            Console.WriteLine("Handles:    {0}", spec.Handles.Count());
            Console.WriteLine("Enums:      {0}", spec.Enums.Count());
            Console.WriteLine("Commands:   {0}", spec.Commands.Count());
            Console.WriteLine("Features:   {0}", spec.Features.Count());
            Console.WriteLine("Extensions: {0}", spec.Extensions.Count());
            Console.WriteLine("----------");
            
            var rewrite = new CSharpSpecRewriter();
            spec = rewrite.Rewrite(spec);

            var gen = new CSharpCodeGenerator();
            gen.Generate(spec);
            Console.WriteLine("Generated {0} files", gen.files.Count);
            
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
            
            const string rootPath = "../../../Vulkan";
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
