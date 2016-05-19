using System;

namespace TanagraExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            run();
            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static void run()
        {
            var tri = new VKTriangle();
            tri.Main(null);
        }
    }
}
