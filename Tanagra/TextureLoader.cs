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
        const long defaultFenceWaitTime = 100000000000;

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
            uint mipLevels = 1;
            uint texWidth = 32;
            uint texHeight = 32;

            // Get device properites for the requested texture format
            var formatProperties = physicalDevice.GetFormatProperties(format);

            // Only use linear tiling if requested (and supported by the device)
            // Support for linear tiling is mostly limited, so prefer to use
            // optimal tiling instead
            // On most implementations linear tiling will only support a very
            // limited amount of formats and features (mip maps, cubemaps, arrays, etc.)
            var useStaging = !forceLinear;

            var memAlloc = new MemoryAllocateInfo();
            var memReqs = new MemoryRequirements();

            // Use a separate command buffer for texture loading
            var cmdBuffInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(cmdBuffInfo);
            cmdBuffInfo.Dispose();

            if (useStaging)
            {
                // Create a host-visible staging buffer that contains the raw image data

                // This buffer is used as a transfer source for the buffer copy
                var bufferCreate = new BufferCreateInfo(size, BufferUsageFlags.TransferSrc, SharingMode.Exclusive, null);
                var stagingBuffer = device.CreateBuffer(bufferCreate);
                bufferCreate.Dispose();

                // Get memory requirements for the staging buffer (alignment, memory type bits)
                memReqs = device.GetBufferMemoryRequirements(stagingBuffer);
                memAlloc.AllocationSize = memReqs.Size;
                // Get memory type index for a host visible buffer
                memAlloc.MemoryTypeIndex = getMemoryType(memReqs.MemoryTypeBits, MemoryPropertyFlags.HostVisible);

                var stagingMemory = device.AllocateMemory(memAlloc);
                device.BindBufferMemory(stagingBuffer, stagingMemory, 0);

                // Copy texture data into staging buffer
                var data = device.MapMemory(stagingMemory, 0, memReqs.Size);
                // todo: copy
                device.UnmapMemory(stagingMemory);

                // Setup buffer copy regions for each mip level
                var bufferCopy = new List<BufferImageCopy>();
                var offset = 0U;
                for(uint x = 0; x < mipLevels; x++)
                {
                    var bufferCopyRegion = new BufferImageCopy();
                    var subresource = new ImageSubresourceLayers(ImageAspectFlags.Color, x, 0, 1);
                    bufferCopyRegion.ImageSubresource = subresource;
                    var imageExtent = new Extent3D(32, 32, 1); // todo
                    bufferCopyRegion.ImageExtent = imageExtent;

                    bufferCopy.Add(bufferCopyRegion);
                    // todo
                }

                var extent = new Extent3D(texWidth, texHeight, 1);
                var usage = ImageUsageFlags.Sampled | ImageUsageFlags.TransferDst;
                var imageCreate = new ImageCreateInfo(ImageType.ImageType2d, format, extent, mipLevels, 1, SampleCountFlags.SampleCountFlags1, ImageTiling.Optimal, usage, SharingMode.Exclusive, null, ImageLayout.Preinitialized);
                texture.image = device.CreateImage(imageCreate);
                imageCreate.Dispose();

                memReqs = device.GetImageMemoryRequirements(texture.image);
                memAlloc.AllocationSize = memReqs.Size;
                memAlloc.MemoryTypeIndex = getMemoryType(memReqs.MemoryTypeBits, MemoryPropertyFlags.DeviceLocal);

                texture.deviceMemory = device.AllocateMemory(memAlloc);
                device.BindImageMemory(texture.image, texture.deviceMemory, 0);

                var subRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, mipLevels, 0, 1);

                // Image barrier for optimal image (target)
                // Optimal image will be used as destination for the copy
                setImageLayout(cmdBuffer, texture.image, ImageAspectFlags.Color, ImageLayout.Preinitialized, ImageLayout.TransferDstOptimal, subRange);

                // Copy mip levels from staging buffer
                cmdBuffer.CmdCopyBufferToImage(stagingBuffer, texture.image, ImageLayout.TransferDstOptimal, bufferCopy);

                // Change texture image layout to shader read after all mip levels have been copied
                texture.imageLayout = ImageLayout.ShaderReadOnlyOptimal;
                setImageLayout(cmdBuffer, texture.image, ImageAspectFlags.Color, ImageLayout.TransferDstOptimal, texture.imageLayout, subRange);

                // Submit command buffer containing copy and image layout commands
                cmdBuffer.End();

                // Create a fence to make sure that the copies have finished before continuing
                var fenceCreate = new FenceCreateInfo();
                var copyFence = device.CreateFence(fenceCreate);
                fenceCreate.Dispose();

                var submitInfo = new SubmitInfo();
                submitInfo.CommandBuffers = new[] { cmdBuffer };
                queue.Submit(new List<SubmitInfo> { submitInfo }, copyFence);
                submitInfo.Dispose();
                device.WaitForFences(new List<Fence> { copyFence }, true, defaultFenceWaitTime);
                device.DestroyFence(copyFence);

                // Clean up staging resources
                device.FreeMemory(stagingMemory);
                device.DestroyBuffer(stagingBuffer);
            }
            else
            {
                //VK_FORMAT_FEATURE_SAMPLED_IMAGE_BIT

                // Load mip map level 0 to linear tiling image
                var extent = new Extent3D(texWidth, texHeight, 1);
                var imageCreate = new ImageCreateInfo(ImageType.ImageType2d, format, extent, 1, 1, SampleCountFlags.SampleCountFlags1, ImageTiling.Linear, ImageUsageFlags.Sampled, SharingMode.Exclusive, null, ImageLayout.Preinitialized);
                var mappableImage = device.CreateImage(imageCreate);
                imageCreate.Dispose();

                // Get memory requirements for this image 
                // like size and alignment
                memReqs = device.GetImageMemoryRequirements(mappableImage);
                // Set memory allocation size to required memory size
                memAlloc.AllocationSize = memReqs.Size;
                // Get memory type that can be mapped to host memory
                memAlloc.MemoryTypeIndex = getMemoryType(memReqs.MemoryTypeBits, MemoryPropertyFlags.HostVisible);

                // Allocate host memory
                var mappableMemory = device.AllocateMemory(memAlloc);
                // Bind allocated image for use
                device.BindImageMemory(mappableImage, mappableMemory, 0);

                // Get sub resource layout
                // Mip map count, array layer, etc.
                var subresource = new ImageSubresource(ImageAspectFlags.Color, 0, 0);
                var subresourceLayout = device.GetImageSubresourceLayout(mappableImage, subresource);

                var data = device.MapMemory(mappableMemory, 0, memReqs.Size, MemoryMapFlags.None);
                // todo: copy
                device.UnmapMemory(mappableMemory);

                // Linear tiled images don't need to be staged
                // and can be directly used as textures
                texture.image = mappableImage;
                texture.deviceMemory = mappableMemory;
                texture.imageLayout = ImageLayout.ShaderReadOnlyOptimal;

                // Setup image memory barrier
                setImageLayout(cmdBuffer, texture.image, ImageAspectFlags.Color, ImageLayout.Preinitialized, texture.imageLayout);

                cmdBuffer.End();

                var submitInfo = new SubmitInfo();
                submitInfo.CommandBuffers = new[] { cmdBuffer };
                queue.Submit(new List<SubmitInfo> { submitInfo });
                submitInfo.Dispose();
                queue.WaitIdle();
            }

            // Create sampler
            var samplerCreate = new SamplerCreateInfo();
            samplerCreate.MagFilter = Filter.Linear;
            samplerCreate.MinFilter = Filter.Linear;
            samplerCreate.MipmapMode = SamplerMipmapMode.Linear;
            //samplerCreate.AddressModeU = SamplerAddressMode.Repeat;
            //samplerCreate.AddressModeV = SamplerAddressMode.Repeat;
            //samplerCreate.AddressModeW = SamplerAddressMode.Repeat;
            //samplerCreate.MipLodBias = 0f;
            //samplerCreate.CompareOp = CompareOp.Never;
            //samplerCreate.MinLod = 0;
            // Max level-of-detail should match mip level count
            samplerCreate.MaxLod = (useStaging) ? (float)texture.MipLevels : 0;
            // Enable anisotropic filtering
            samplerCreate.MaxAnisotropy = 8;
            samplerCreate.AnisotropyEnable = true;
            samplerCreate.BorderColor = BorderColor.FloatOpaqueWhite;
            texture.sampler = device.CreateSampler(samplerCreate);
            samplerCreate.Dispose();

            var components = new ComponentMapping(ComponentSwizzle.R, ComponentSwizzle.G, ComponentSwizzle.B, ComponentSwizzle.A);
            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, (useStaging) ? mipLevels : 1, 0, 1);
            var imageViewCreate = new ImageViewCreateInfo(texture.image, ImageViewType.ImageViewType2d, format, components, subresourceRange);
            texture.view = device.CreateImageView(imageViewCreate);
            imageViewCreate.Dispose();
        }
        
        public void Dispose()
        {
            device.FreeCommandBuffers(cmdPool, new List<CommandBuffer> { cmdBuffer });
        }
        
        uint getMemoryType(uint typeBits, MemoryPropertyFlags propertyFlags)
        {
            for(uint x = 0; x < 32; x++)
            {
                if((typeBits & 1) == 1)
                {
                    if((physicalDeviceMemoryProperties.MemoryTypes[x].PropertyFlags & propertyFlags) == propertyFlags)
                    {
                        return x;
                    }
                }
                typeBits >>= 1;
            }

            throw new InvalidOperationException();
        }

        static void setImageLayout(CommandBuffer cmdBuffer, Image image, ImageAspectFlags aspectMask, ImageLayout oldLayout, ImageLayout newLayout)
        {
            var subresourceRange = new ImageSubresourceRange(aspectMask, 0, 1, 0, 1);
            setImageLayout(cmdBuffer, image, aspectMask, oldLayout, newLayout, subresourceRange);
        }

        static void setImageLayout(CommandBuffer cmdBuffer, Image image, ImageAspectFlags aspectMask, ImageLayout oldLayout, ImageLayout newLayout, ImageSubresourceRange subRange)
        {
            var imageMemoryBarrier = new ImageMemoryBarrier(oldLayout, newLayout, 0, 0, image, subRange);

            if(oldLayout == ImageLayout.Preinitialized)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.HostWrite | AccessFlags.TransferWrite;

            if(oldLayout == ImageLayout.ColorAttachmentOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.ColorAttachmentWrite;

            if(oldLayout == ImageLayout.DepthStencilAttachmentOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.DepthStencilAttachmentWrite;

            if(oldLayout == ImageLayout.TransferSrcOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.TransferRead;

            if(oldLayout == ImageLayout.ShaderReadOnlyOptimal)
                imageMemoryBarrier.SrcAccessMask = AccessFlags.ShaderRead;

            if(newLayout == ImageLayout.TransferDstOptimal)
                imageMemoryBarrier.DstAccessMask = AccessFlags.TransferWrite;

            if(newLayout == ImageLayout.TransferSrcOptimal)
            {
                imageMemoryBarrier.SrcAccessMask |= AccessFlags.TransferRead;
                imageMemoryBarrier.DstAccessMask = AccessFlags.TransferRead;
            }

            if(newLayout == ImageLayout.DepthStencilAttachmentOptimal)
                imageMemoryBarrier.DstAccessMask |= AccessFlags.DepthStencilAttachmentWrite;

            if(newLayout == ImageLayout.ShaderReadOnlyOptimal)
            {
                imageMemoryBarrier.SrcAccessMask = AccessFlags.HostWrite | AccessFlags.TransferWrite;
                imageMemoryBarrier.DstAccessMask = AccessFlags.ShaderRead;
            }

            var srcStageFlags = PipelineStageFlags.TopOfPipe;
            var destStageFlags = PipelineStageFlags.TopOfPipe;

            var imageMemoryBarriers = new List<ImageMemoryBarrier> { imageMemoryBarrier };
            cmdBuffer.CmdPipelineBarrier(srcStageFlags, destStageFlags, DependencyFlags.None, null, null, imageMemoryBarriers);
        }
    }
}
