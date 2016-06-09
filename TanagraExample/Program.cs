using System;

namespace TanagraExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //run();
            //ExampleBaseTest();

            //run();
            //var example = new ExampleRenderToWindow();
            //var example = new ExampleRenderToDisk();
            //var example = new ExampleDrawTexture();
            var example = new ExampleRenderToWindow2();

            //var opt = new Tanagra.InstanceMgr.InitializeOptions();
            //opt.ForceUseDevice(x);
            // Indicate that we would like a graphics queue to be allocated
            //     This tells tanagra that it should look for a device that supports
            //     graphics rendering and allocate a single graphics queue
            //opt.AddQueue(QueueFlags.Graphics);

            //var mgr = new Tanagra.InstanceMgr();
            //mgr.Initialize(opt);

            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static void run()
        {
            var tri = new VKTriangle2();
            tri.Main(null);
        }
        
    }
}
