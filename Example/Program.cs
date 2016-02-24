using System;
using System.Diagnostics;

using Vulkan;

namespace Example
{
    // http://stackoverflow.com/questions/21798986/marshal-a-c-struct-containing-a-variable-length-array
    // http://stackoverflow.com/questions/11968960/how-use-pinvoke-for-c-struct-array-pointer-to-c-sharp
    // http://stackoverflow.com/questions/1197181/how-to-marshal-a-variable-sized-array-of-structs-c-sharp-and-c-interop-help
    // http://stackoverflow.com/questions/5902103/how-do-i-marshal-a-struct-that-contains-a-variable-sized-array-to-c/5902264#5902264
    // Process.GetCurrentProcess().Handle; // HINSTANCE
    // Process.GetCurrentProcess().MainWindowHandle; // HWND
    class Program
    {
        const string title = "Vulkan Example";
        const string name = "vulkanExample";
        
        static unsafe void Main(string[] args)
        {
            IntPtr HINSTANCE, HWND;
            GetProcessHandles(out HINSTANCE, out HWND);
            Debug.Assert(HINSTANCE != IntPtr.Zero);
            Debug.Assert(HWND      != IntPtr.Zero);

            var instance = new Instance();
            var device = new Device();
            var queue = new Queue();
            var physicalDevice = new PhysicalDevice();

            var deviceMemoryProperties = new PhysicalDeviceMemoryProperties();
            //deviceMemoryProperties.memoryTypes = new MemoryType[32];
            //deviceMemoryProperties.memoryHeaps = new MemoryHeap[16];

            Result result;

            // <createInstance>
            {
                var appInfo = new ApplicationInfo();
                appInfo.sType = StructureType.APPLICATION_INFO;
                appInfo.ApplicationName = name;
                appInfo.EngineName = name;
                appInfo.apiVersion = MakeVersion(1, 0, 0);

                var instanceEnabledExtensions = new[]
                {
                    "VK_KHR_surface",       // VK_KHR_SURFACE_EXTENSION_NAME
                    "VK_KHR_win32_surface", // VK_KHR_WIN32_SURFACE_EXTENSION_NAME
                };

                var instanceCreateInfo = new InstanceCreateInfo();
                instanceCreateInfo.sType = StructureType.INSTANCE_CREATE_INFO;
                instanceCreateInfo.Next = IntPtr.Zero;
                instanceCreateInfo.ApplicationInfo = appInfo;
                if(instanceEnabledExtensions.Length > 0)
                {
                    //instanceCreateInfo.enabledExtensionCount = (uint)instanceEnabledExtensions.Length;
                    //instanceCreateInfo.ppEnabledExtensionNames
                }

                result = VK.vkCreateInstance(ref instanceCreateInfo, IntPtr.Zero, ref instance);
                Console.WriteLine(result);
                Console.WriteLine(instance);
            }
            // </createInstance>
            
            var gpuCount = 0U;
            result = VK.vkEnumeratePhysicalDevices(instance, &gpuCount, IntPtr.Zero);
            Console.WriteLine(result);
            Console.WriteLine("Devices {0}", gpuCount);

            result = VK.vkEnumeratePhysicalDevices(instance, &gpuCount, ref physicalDevice);
            Console.WriteLine(result);
            Console.WriteLine(physicalDevice);

            var queueCount = 0U;
            QueueFamilyProperties[] queueProps = null;
            VK.vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueCount, queueProps);
            Console.WriteLine("Assert {0}", queueCount >= 1);

            queueProps = new QueueFamilyProperties[queueCount];
            VK.vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice, &queueCount, queueProps);

            uint graphicsQueueIndex;
            for(graphicsQueueIndex = 0; graphicsQueueIndex < queueCount; graphicsQueueIndex++)
            {
                if((queueProps[graphicsQueueIndex].queueFlags & QueueFlags.QUEUE_GRAPHICS_BIT) == 0)
                    break;
            }
            Console.WriteLine("Assert {0}", graphicsQueueIndex < queueCount);

            // Vulkan device
            var queueCreateInfo = new DeviceQueueCreateInfo();
            queueCreateInfo.Next = IntPtr.Zero;
            queueCreateInfo.sType = StructureType.DEVICE_QUEUE_CREATE_INFO;
            //queueCreateInfo.flags = DeviceQueueCreateFlags.NONE;
            queueCreateInfo.queueFamilyIndex = graphicsQueueIndex;
            queueCreateInfo.queueCount = 1;

            float QueuePriorities = 0.0f;
            float[] QueuePriorities2 = new float[] { 0.0f };
            queueCreateInfo.QueuePriorities = &QueuePriorities; // new float[] { 0.0f }; //

            // <createDevice>
            {
                var deviceEnabledExtensions = new[]
                {
                    "VK_KHR_swapchain", // VK_KHR_SWAPCHAIN_EXTENSION_NAME
                };

                var deviceCreateInfo = new DeviceCreateInfo();
                deviceCreateInfo.sType = StructureType.DEVICE_CREATE_INFO;
                deviceCreateInfo.Next = IntPtr.Zero;
                //deviceCreateInfo.flags = DeviceCreateFlags.NONE
                deviceCreateInfo.queueCreateInfoCount = 1;
                deviceCreateInfo.QueueCreateInfos = &queueCreateInfo; // = new[] { queueCreateInfo }; // 
                //deviceCreateInfo.enabledLayerCount = 0;
                //deviceCreateInfo.ppEnabledLayerNames;
                deviceCreateInfo.EnabledFeatures = null;
                if(deviceEnabledExtensions.Length > 0)
                {
                    //deviceCreateInfo.enabledExtensionCount = (uint)deviceEnabledExtensions.Length;
                    //deviceCreateInfo.ppEnabledExtensionNames;
                }

                result = VK.vkCreateDevice(physicalDevice, ref deviceCreateInfo, IntPtr.Zero, ref device);
                Console.WriteLine(result);
            }
            // </createDevice>

            VK.vkGetPhysicalDeviceMemoryProperties(physicalDevice, ref deviceMemoryProperties);

            VK.vkGetDeviceQueue(device, graphicsQueueIndex, 0, ref queue);
            
            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static void initSwapChain()
        {
            uint queueCount;
            QueueFamilyProperties queueProps;
            Result result;

            //Win32SurfaceCreateInfoKHR surfaceCreateInfo;
            //VK.vkGetPhysicalDeviceQueueFamilyProperties
            //VK.vkGetPhysicalDeviceSurfaceSupportKHR
        }

        static void GetProcessHandles(out IntPtr HINSTANCE, out IntPtr HWND)
        {
            var process = Process.GetCurrentProcess();
            HINSTANCE = process.Handle;
            HWND = process.MainWindowHandle;
        }

        static uint MakeVersion(int major, int minor, int patch)
        {
            return (uint)(major << 22 | minor << 12 | patch);
        }
    }
}
