using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

namespace Tanagra
{
    public class TextureLoader : IDisposable
    {
        PhysicalDevice physicalDevice;
        PhysicalDeviceMemoryProperties physicalDeviceMemoryProperties;
        Device device;
        Queue queue;
        CommandPool cmdPool;
        CommandBuffer cmdBuffer;

        public TextureLoader(PhysicalDevice physicalDevice, Device device, Queue queue, CommandPool cmdPool)
        {
            this.physicalDevice = physicalDevice;
            this.device = device;
            this.queue = queue;
            this.cmdPool = cmdPool;
            physicalDeviceMemoryProperties = physicalDevice.GetMemoryProperties();

            var cmdBufferCreate = new CommandBufferAllocateInfo(cmdPool, CommandBufferLevel.Primary, 1);
            cmdBuffer = device.AllocateCommandBuffers(cmdBufferCreate).First();
            cmdBufferCreate.Dispose();
        }

        public void Dispose()
        {
            device.FreeCommandBuffers(cmdPool, new List<CommandBuffer> { cmdBuffer });
        }
    }
}
