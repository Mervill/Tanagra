using System;
using Vulkan;

namespace Example
{
    // http://stackoverflow.com/questions/21798986/marshal-a-c-struct-containing-a-variable-length-array
    // http://stackoverflow.com/questions/11968960/how-use-pinvoke-for-c-struct-array-pointer-to-c-sharp
    class Program
    {
        const string title = "Vulkan Example";
        const string name = "vulkanExample";
        
        static unsafe void Main(string[] args)
        {
            var instance = new Instance();
            var device = new Device();
            var queue = new Queue();

            var deviceMemoryProperties = new PhysicalDeviceMemoryProperties();

            // <createInstance>

            var appInfo = new ApplicationInfo();
            appInfo.sType = StructureType.APPLICATION_INFO;
            appInfo.pApplicationName = name;
            appInfo.pEngineName = name;
            appInfo.apiVersion = MakeVersion(1, 0, 0);

            var instanceEnabledExtensions = new[] 
            {
                "VK_KHR_surface",
                "VK_KHR_WIN32_SURFACE_EXTENSION_NAME",
            };

            var instanceCreateInfo = new InstanceCreateInfo();
            instanceCreateInfo.sType = StructureType.INSTANCE_CREATE_INFO;
            instanceCreateInfo.pNext = IntPtr.Zero;
            instanceCreateInfo.pApplicationInfo = appInfo;

            //instanceCreateInfo.enabledExtensionCount = (uint)enabledExtensions.Length;
            //instanceCreateInfo.ppEnabledExtensionNames

            var result = VK.vkCreateInstance(ref instanceCreateInfo, IntPtr.Zero, ref instance);
            Console.WriteLine(result);
            Console.WriteLine(instance);

            // </createInstance>
            
            var physicalDevice = new PhysicalDevice();
            var gpuCount = 0U;
            result = VK.vkEnumeratePhysicalDevices(instance, &gpuCount, IntPtr.Zero);
            Console.WriteLine(result);
            Console.WriteLine("Devices {0}", gpuCount);
            
            result = VK.vkEnumeratePhysicalDevices(instance, &gpuCount, &physicalDevice);
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
            queueCreateInfo.pNext = IntPtr.Zero;
            queueCreateInfo.sType = StructureType.DEVICE_QUEUE_CREATE_INFO;
            //queueCreateInfo.flags = DeviceQueueCreateFlags.NONE;
            queueCreateInfo.queueFamilyIndex = graphicsQueueIndex;
            queueCreateInfo.queueCount = 1;
            float pQueuePriorities = 0.0f;
            queueCreateInfo.pQueuePriorities = &pQueuePriorities; //= new float[] { 0.0f };

            // <createDevice>

            var deviceEnabledExtensions = new[]
            {
                "VK_KHR_swapchain",
            };

            var deviceCreateInfo = new DeviceCreateInfo();
            deviceCreateInfo.sType = StructureType.DEVICE_CREATE_INFO;
            deviceCreateInfo.pNext = IntPtr.Zero;
            //deviceCreateInfo.flags = DeviceCreateFlags.NONE
            deviceCreateInfo.queueCreateInfoCount = 1;
            deviceCreateInfo.pQueueCreateInfos = &queueCreateInfo; //new[] { queueCreateInfo };
            //deviceCreateInfo.enabledLayerCount = 0;
            //deviceCreateInfo.ppEnabledLayerNames;
            //deviceCreateInfo.enabledExtensionCount = 0;
            //deviceCreateInfo.ppEnabledExtensionNames;
            deviceCreateInfo.pEnabledFeatures = null;
            
            result = VK.vkCreateDevice(physicalDevice, ref deviceCreateInfo, IntPtr.Zero, ref device);
            Console.WriteLine(result);

            // </createDevice>

            VK.vkGetPhysicalDeviceMemoryProperties(physicalDevice, &deviceMemoryProperties);

            VK.vkGetDeviceQueue(device, graphicsQueueIndex, 0, &queue);

            //SwapchainKHR

            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static uint MakeVersion(int major, int minor, int patch)
        {
            return (uint)(major << 22 | minor << 12 | patch);
        }
    }
}
