using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Vulkan;

namespace Example
{
    class Program
    {
        static Instance instance;
        static PhysicalDevice physicalDevice;
        static SurfaceKhr surface;
        static Device device;
        static Queue queue;
        static CommandPool commandPool;
        static CommandBuffer commandBuffer;
        static SwapchainKhr swapchain;

        static Format backBufferFormat;
        static List<Image> backBuffers;

        static void Main(string[] args)
        {
            CreateInstance();
            CreateSurface();
            CreateDevice();
            CreateCommandBuffer();

            CreateSwapchain();

            Console.WriteLine("Program Complete");
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

            instance = new Instance(instanceCreateInfo);
            Console.WriteLine("[ OK ] Instance");

            var physicalDevices = instance.EnumeratePhysicalDevices();
            Console.WriteLine($"Physical Devices: {physicalDevices.Count}");

            physicalDevice = physicalDevices[0];
            Console.WriteLine("[ OK ] Physical Device");
        }

        static void CreateSurface()
        {
            IntPtr HINSTANCE, HWND;
            GetProcessHandles(out HINSTANCE, out HWND);
            var surfaceCreateInfo = new Win32SurfaceCreateInfo
            {
                hinstance = HINSTANCE,
                hwnd = HWND,
            };
            surface = instance.CreateWin32Surface(surfaceCreateInfo);
            Console.WriteLine("[ OK ] Surface");
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

            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0) //&& physicalDevice.GetSurfaceSupport((uint)index, surface)
                .Select((properties, index) => index)
                .First();

            queue = device.GetQueue(0, (uint)queueNodeIndex);
            Console.WriteLine("[ OK ] Queue");
        }

        static void CreateCommandBuffer()
        {
            // Command pool
            var commandPoolCreateInfo = new CommandPoolCreateInfo
            {
                QueueFamilyIndex = 0,
                Flags = (uint)CommandPoolCreateFlags.ResetCommandBuffer,
            };
            commandPool = device.CreateCommandPool(commandPoolCreateInfo, null);
            Console.WriteLine("[ OK ] Command Pool");

            // Command Buffer
            var commandBufferAllocationInfo = new CommandBufferAllocateInfo
            {
                Level = CommandBufferLevel.Primary,
                CommandPool = commandPool,
                CommandBufferCount = 1,
            };
            commandBuffer = device.AllocateCommandBuffers(commandBufferAllocationInfo);
            Console.WriteLine("[ OK ] Command Buffer");
        }

        static void CreateSwapchain()
        {
            // surface format
            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            if(surfaceFormats.Count == 1 && surfaceFormats[0].Format == Format.Undefined)
            {
                backBufferFormat = Format.B8g8r8a8Unorm;
                Console.WriteLine($"using default backBufferFormat {backBufferFormat}");
            }
            else
            {
                backBufferFormat = surfaceFormats[0].Format;
                Console.WriteLine($"backBufferFormat {backBufferFormat}");
            }
            
            var surfaceCapabilities = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            // Buffer count
            var desiredImageCount = surfaceCapabilities.MinImageCount + 1;
            if(surfaceCapabilities.MaxImageCount > 0 && desiredImageCount > surfaceCapabilities.MaxImageCount)
            {
                desiredImageCount = surfaceCapabilities.MaxImageCount;
            }

            // Transform
            SurfaceTransformFlagsKhr preTransform;
            if((surfaceCapabilities.SupportedTransforms & SurfaceTransformFlagsKhr.Identity) != 0)
            {
                preTransform = SurfaceTransformFlagsKhr.Identity;
            }
            else
            {
                preTransform = surfaceCapabilities.CurrentTransform;
            }

            // Present mode
            var presentModes = physicalDevice.GetSurfacePresentModesKHR(surface);
            
            var swapChainPresentMode = PresentModeKhr.Fifo;
            if(presentModes.Contains(PresentModeKhr.Mailbox))
                swapChainPresentMode = PresentModeKhr.Mailbox;
            else if(presentModes.Contains(PresentModeKhr.Immediate))
                swapChainPresentMode = PresentModeKhr.Immediate;

            Console.WriteLine($"swapChainPresentMode {swapChainPresentMode}");

            // Create swapchain
            /*var swapchainCreateInfo = new SwapchainCreateInfoKhr
            {
                Surface = surface,
                ImageSharingMode = SharingMode.Exclusive,
                ImageExtent = new Extent2D { Width = 800, Height = 600 },
                ImageArrayLayers = 1,
                ImageFormat = backBufferFormat,
                ImageColorSpace = ColorSpaceKhr.SrgbNonlinear,
                ImageUsage = (uint)ImageUsageFlags.ColorAttachment,
                PresentMode = swapChainPresentMode,
                CompositeAlpha = CompositeAlphaFlagsKhr.Opaque,
                MinImageCount = desiredImageCount,
                PreTransform = preTransform,
                Clipped = true,
            };
            swapchain = device.CreateSwapchainKHR(swapchainCreateInfo, null);
            Console.WriteLine("[ OK ] Swapchain");

            backBuffers = device.GetSwapchainImagesKHR(swapchain);*/
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
