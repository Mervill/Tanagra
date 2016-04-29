using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.ObjectModel;

namespace TanagraExample
{
    class Program
    {
        static Instance instance;
        static PhysicalDevice physicalDevice;
        //static SurfaceKhr surface;
        static Device device;
        static Queue queue;
        static CommandPool commandPool;
        static CommandBuffer commandBuffer;
        //static SwapchainKhr swapchain;

        static void Main(string[] args)
        {
            CreateInstance();
            //CreateSurface();
            CreateDevice();

            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static void CreateInstance()
        {
            var appInfo = new ApplicationInfo();
            appInfo.ApplicationName = "vulkanExample";
            appInfo.EngineName = "vulkanExample";
            appInfo.ApiVersion = MakeVersion(1, 0, 0);

            var instanceEnabledExtensions = new[]
            {
                "VK_KHR_surface",       // VK_KHR_SURFACE_EXTENSION_NAME
                "VK_KHR_win32_surface", // VK_KHR_WIN32_SURFACE_EXTENSION_NAME
            };

            var instanceCreateInfo = new InstanceCreateInfo();
            instanceCreateInfo.ApplicationInfo = appInfo;
            instanceCreateInfo.EnabledExtensionNames = instanceEnabledExtensions;

            //instance = new Instance(instanceCreateInfo);
            instance = VK.CreateInstance(instanceCreateInfo, null);
            Console.WriteLine("[ OK ] Instance");

            var physicalDevices = instance.EnumeratePhysicalDevices();
            Console.WriteLine($"Physical Devices: {physicalDevices.Count}");

            physicalDevice = physicalDevices[0];
            Console.WriteLine("[ OK ] Physical Device");
        }

        static void CreateDevice()
        {
            var queueCreateInfo = new DeviceQueueCreateInfo
            {
                QueueFamilyIndex = 0,
                QueueCount = 1,
                QueuePriorities = 0,
            };

            var deviceEnabledExtensions = new[]
            {
                "VK_KHR_swapchain",
            };

            var deviceCreateInfo = new DeviceCreateInfo
            {
                QueueCreateInfoCount = 1,
                QueueCreateInfos = queueCreateInfo,
                EnabledExtensionNames = deviceEnabledExtensions,
            };

            device = physicalDevice.CreateDevice(deviceCreateInfo, null);
            Console.WriteLine("[ OK ] Device");
            
            var queueNodeIndex = physicalDevice.GetPhysicalDeviceQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.QUEUE_GRAPHICS_BIT) != 0) //&& physicalDevice.GetSurfaceSupport((uint)index, surface)
                .Select((properties, index) => index)
                .First();
            
            queue = device.GetDeviceQueue(0, (uint)queueNodeIndex);
            Console.WriteLine("[ OK ] Queue");
        }

        static uint MakeVersion(int major, int minor, int patch)
        {
            return (uint)(major << 22 | minor << 12 | patch);
        }
    }
}
