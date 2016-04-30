using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

using SharpDX;
using SharpDX.Text;
using SharpDX.Windows;

using Vulkan;
using Vulkan.ObjectModel;

namespace TanagraExample
{
    class Program
    {
        static Form form;

        static Instance instance;
        static PhysicalDevice physicalDevice;
        static SurfaceKHR surface;
        static Device device;
        static Queue queue;
        static CommandPool commandPool;
        static List<CommandBuffer> commandBuffer;
        static SwapchainKHR swapchain;

        static Format backBufferFormat;
        static List<Image> backBuffers;

        static void Main(string[] args)
        {
            form = new RenderForm("Tanagra - Vulkan Sample");

            CreateInstance();
            CreateSurface();
            CreateDevice();
            CreateCommandBuffer();

            CreateSwapchain();

            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static void CreateInstance()
        {
            var appInfo = new ApplicationInfo();
            appInfo.ApplicationName = "vulkanExample";
            appInfo.EngineName = "vulkanExample";
            appInfo.ApiVersion = MakeVersion(1, 0, 12);

            var instanceEnabledExtensions = new[]
            {
                "VK_KHR_surface",       // VK_KHR_SURFACE_EXTENSION_NAME
                "VK_KHR_win32_surface", // VK_KHR_WIN32_SURFACE_EXTENSION_NAME
            };

            var instanceCreateInfo = new InstanceCreateInfo();
            instanceCreateInfo.ApplicationInfo = appInfo;
            instanceCreateInfo.EnabledExtensionNames = instanceEnabledExtensions;
            
            instance = VK.CreateInstance(instanceCreateInfo);
            Console.WriteLine("[ OK ] Instance " + instance);
            
            var physicalDevices = instance.EnumeratePhysicalDevices();
            Console.WriteLine($"[INFO] Physical Devices: {physicalDevices.Count}");

            physicalDevice = physicalDevices[0];
            Console.WriteLine("[ OK ] Physical Device " + physicalDevice);
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

            device = physicalDevice.CreateDevice(deviceCreateInfo);
            Console.WriteLine("[ OK ] Device " + device);
            
            Console.WriteLine($"[INFO] Begin GetQueueFamilyProperties");
            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0 && physicalDevice.GetSurfaceSupportKHR((uint)index, surface))
                .Select((properties, index) => index)
                .First();
            
            queue = device.GetQueue(0, (uint)queueNodeIndex);
            Console.WriteLine("[ OK ] Queue " + queue);
        }

        static void CreateSurface()
        {
            IntPtr HINSTANCE, HWND;
            GetProcessHandles(out HINSTANCE, out HWND);
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR
            {
                Hinstance = HINSTANCE,
                Hwnd = form.Handle//HWND,
            };
            surface = instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
            Console.WriteLine("[ OK ] Surface " + surface);
        }

        static void CreateCommandBuffer()
        {
            // Command pool
            var commandPoolCreateInfo = new CommandPoolCreateInfo
            {
                QueueFamilyIndex = 0,
                Flags = CommandPoolCreateFlags.ResetCommandBuffer,
            };
            commandPool = device.CreateCommandPool(commandPoolCreateInfo);
            Console.WriteLine("[ OK ] Command Pool " + commandPool);

            // Command Buffer
            var commandBufferAllocationInfo = new CommandBufferAllocateInfo
            {
                Level = CommandBufferLevel.Primary,
                CommandPool = commandPool,
                CommandBufferCount = 1,
            };
            commandBuffer = device.AllocateCommandBuffers(commandBufferAllocationInfo);
            Console.WriteLine("[INFO] commandBuffers: " + commandBuffer.Count);
            Console.WriteLine("[ OK ] Command Buffer " + commandBuffer[0]);
            //if (!commandBuffer[0].IsValid) throw new Exception();
        }

        static void CreateSwapchain()
        {
            // surface format
            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            if (surfaceFormats.Count == 1 && surfaceFormats[0].Format == Format.Undefined)
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
            if (surfaceCapabilities.MaxImageCount > 0 && desiredImageCount > surfaceCapabilities.MaxImageCount)
            {
                desiredImageCount = surfaceCapabilities.MaxImageCount;
            }

            // Transform
            SurfaceTransformFlags preTransform;
            if ((surfaceCapabilities.SupportedTransforms & SurfaceTransformFlags.IdentityBitKhr) != 0)
            {
                preTransform = SurfaceTransformFlags.IdentityBitKhr;
            }
            else
            {
                preTransform = surfaceCapabilities.CurrentTransform;
            }
            
            // Present mode
            var presentModes = physicalDevice.GetSurfacePresentModesKHR(surface);
            
            var swapChainPresentMode = PresentMode.FifoKhr;
            if(presentModes.Contains(PresentMode.MailboxKhr))
                swapChainPresentMode = PresentMode.MailboxKhr;
            else if(presentModes.Contains(PresentMode.ImmediateKhr))
                swapChainPresentMode = PresentMode.ImmediateKhr;

            Console.WriteLine($"swapChainPresentMode {swapChainPresentMode}");

            var imageExtent = new Extent2D { Width = (uint)form.ClientSize.Width, Height = (uint)form.ClientSize.Height };
            // Create swapchain
            var swapchainCreateInfo = new SwapchainCreateInfoKHR
            {
                Surface = surface,
                ImageSharingMode = SharingMode.Exclusive,
                ImageExtent = imageExtent,
                ImageArrayLayers = 1,
                ImageFormat = backBufferFormat,
                ImageColorSpace = ColorSpace.ColorspaceSrgbNonlinearKhr,
                ImageUsage = (uint)ImageUsageFlags.ColorAttachment,
                PresentMode = swapChainPresentMode,
                CompositeAlpha = CompositeAlphaFlags.OpaqueBitKhr,
                MinImageCount = desiredImageCount,
                PreTransform = preTransform,
                Clipped = 1,
            };
            swapchain = device.CreateSwapchainKHR(swapchainCreateInfo);
            Console.WriteLine("[ OK ] Swapchain");

            backBuffers = device.GetSwapchainImagesKHR(swapchain);
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
