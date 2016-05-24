using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

using Buffer = Vulkan.Buffer;

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
        
        public void LoadTexture(Format format, bool forceLinear, ImageUsageFlags imageUsageFlags)
        {
            var texture = new Texture();
            UInt64 size = 0;

            // Get device properites for the requested texture format
            var formatProperties = physicalDevice.GetFormatProperties(format);

            // Only use linear tiling if requested (and supported by the device)
            // Support for linear tiling is mostly limited, so prefer to use
            // optimal tiling instead
            // On most implementations linear tiling will only support a very
            // limited amount of formats and features (mip maps, cubemaps, arrays, etc.)
            var useStaging = !forceLinear;

            var memAllocInfo = new MemoryAllocateInfo();
            var memReqs = new MemoryRequirements();

            // Use a separate command buffer for texture loading
            var cmdBufInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(cmdBufInfo);
            cmdBufInfo.Dispose();

            if (useStaging)
            {
                BufferCreateInfo bufferCreateInfo = new BufferCreateInfo(size, BufferUsageFlags.TransferSrc, SharingMode.Exclusive, null);
                Buffer stagingBuffer = device.CreateBuffer(bufferCreateInfo);
                memReqs = device.GetBufferMemoryRequirements(stagingBuffer);
                memAllocInfo.AllocationSize = memReqs.Size;
                //memAllocInfo.MemoryTypeIndex = // todo

                var stagingMemory = device.AllocateMemory(memAllocInfo);
                device.BindBufferMemory(stagingBuffer, stagingMemory, 0);

                //device.MapMemory()// todo: map memory
            }
        }

        public void Dispose()
        {
            device.FreeCommandBuffers(cmdPool, new List<CommandBuffer> { cmdBuffer });
        }
    }
}
