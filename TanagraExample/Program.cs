using System;

namespace TanagraExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var example = new ExampleRenderToDisk();
            //var example = new ExampleRenderToWindow();
            var example = new ExampleDrawTexture();

            Console.WriteLine("program complete");
            Console.ReadKey();
        }
    }
}
