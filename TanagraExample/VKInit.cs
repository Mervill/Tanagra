using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // A managed interface to Vulkan
using Vulkan.Managed.ObjectModel; // Extentions to object handles

using ImageLayout = Vulkan.ImageLayout;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    public class VKInit
    {
        public VKInit()
        {
            var enabledExtensions = new[]
            {
                VulkanConstant.KhrSurfaceExtensionName,
                VulkanConstant.KhrWin32SurfaceExtensionName,
                VulkanConstant.ExtDebugReportExtensionName,
            };

            var instanceCreateInfo = new InstanceCreateInfo(null, enabledExtensions);

            var instance = Vk.CreateInstance(instanceCreateInfo, null);

            var physicalDevices = instance.EnumeratePhysicalDevices();
            var physicalDevice = physicalDevices[0];
        }
    }
}
