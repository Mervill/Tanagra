using System;

namespace TanagraExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var example = new ExampleRenderToDisk();
            //var example = new ExampleRenderToWindow();
            //var example = new ExampleDrawTexture();
            var example = new ExampleDrawCube();

            Console.WriteLine("program complete");
            Console.ReadKey();
        }
    }
}
