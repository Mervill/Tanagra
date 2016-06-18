using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

using SharpDX.Windows;

using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // A managed interface to Vulkan
using Vulkan.Managed.ObjectModel; // Extentions to object handles

using Image  = Vulkan.Image;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    public class ExampleBase
    {
        public class VertexData
        {
            public Buffer Buffer;
            public DeviceMemory DeviceMemory;
            public VertexInputBindingDescription[] BindingDescriptions;
            public VertexInputAttributeDescription[] AttributeDescriptions;
            public int[] Indicies;
            public Buffer IndexBuffer;
            public DeviceMemory IndexDeviceMemory;
        }

        public class ImageData
        {
            public uint Width;
            public uint Height;
            public Image Image;
            public DeviceMemory Memory;
            public ImageView View;
            public Sampler Sampler;
        }

        public class SwapchainData
        {
            public SwapchainKHR Swapchain;
            public List<ImageData> Images;
            public List<Framebuffer> Framebuffers;
            public Format ImageFormat;
        }

        protected Device device;

        protected PhysicalDeviceMemoryProperties physDeviceMem;
        protected DebugReportCallbackEXT debugCallback;

        #region  Primary Initialization

        protected Instance CreateInstance()
        {
            String[] enabledLayers = new string[]
            {
                "VK_LAYER_LUNARG_standard_validation"
            };

            var enabledExtensions = new[]
            {
                VulkanConstant.KhrSurfaceExtensionName,
                VulkanConstant.KhrWin32SurfaceExtensionName,
                VulkanConstant.ExtDebugReportExtensionName,
            };

            var instanceCreateInfo = new InstanceCreateInfo(enabledLayers, enabledExtensions);
            var instance = Vk.CreateInstance(instanceCreateInfo);

            debugCallback = DebugUtils.CreateDebugReportCallback(instance, DebugReport);

            return instance;
        }

        protected PhysicalDevice[] EnumeratePhysicalDevices(Instance instance)
        {
            var physicalDevices = instance.EnumeratePhysicalDevices();

            if(physicalDevices.Length == 0)
                throw new InvalidOperationException("Didn't find any physical devices");

            return physicalDevices;
        }

        protected Device CreateDevice(PhysicalDevice physicalDevice, uint queueFamily)
        {
            String[] enabledLayers = new string[]
            {
                "VK_LAYER_LUNARG_standard_validation"
            };

            var enabledExtensions = new[]
            {
                VulkanConstant.KhrSwapchainExtensionName,
            };

            var features = new PhysicalDeviceFeatures();
            features.ShaderClipDistance = true;
            features.ShaderCullDistance = true;

            var queueCreateInfo = new DeviceQueueCreateInfo(queueFamily, new[]{ 0f });
            var deviceCreateInfo = new DeviceCreateInfo(new[]{ queueCreateInfo }, enabledLayers, enabledExtensions);
            deviceCreateInfo.EnabledFeatures = features;
            return physicalDevice.CreateDevice(deviceCreateInfo);
        }

        protected Queue GetQueue(PhysicalDevice physicalDevice, uint queueFamily)
        {
            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((p, i) => (p.QueueFlags & QueueFlags.Graphics) != 0)
                .Select((p, i) => i)
                .First();

            return device.GetQueue(queueFamily, (uint)queueNodeIndex);
        }

        protected CommandPool CreateCommandPool(uint queueFamily)
        {
            var commandPoolCreateInfo = new CommandPoolCreateInfo(queueFamily);
            commandPoolCreateInfo.Flags = CommandPoolCreateFlags.ResetCommandBuffer;
            return device.CreateCommandPool(commandPoolCreateInfo);
        }

        protected CommandBuffer[] AllocateCommandBuffers(CommandPool commandPool, uint buffersToAllocate)
        {
            var commandBufferAllocationInfo = new CommandBufferAllocateInfo(commandPool, CommandBufferLevel.Primary, buffersToAllocate);
            var commandBuffers = device.AllocateCommandBuffers(commandBufferAllocationInfo);

            if(commandBuffers.Length == 0)
                throw new InvalidOperationException("Couldn't allocate any command buffers");

            return commandBuffers;
        }

        #endregion

        #region Surface / Swapchain

        protected SurfaceKHR CreateWin32Surface(Instance instance, IntPtr formHandle)
        {
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR(Process.GetCurrentProcess().Handle, formHandle);
            return instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
        }

        protected SwapchainData CreateSwapchain(PhysicalDevice physicalDevice, SurfaceKHR surface, uint windowWidth, uint windowHeight)
        {
            var data = new SwapchainData();

            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            var surfaceFormat  = surfaceFormats[0].Format;

            var surfaceCapabilities = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            var desiredImageCount = Math.Min(surfaceCapabilities.MinImageCount + 1, surfaceCapabilities.MaxImageCount);

            SurfaceTransformFlagsKHR preTransform;
            if((surfaceCapabilities.SupportedTransforms & SurfaceTransformFlagsKHR.Identity) != 0)
            {
                preTransform = SurfaceTransformFlagsKHR.Identity;
            }
            else
            {
                preTransform = surfaceCapabilities.CurrentTransform;
            }

            var presentModes = physicalDevice.GetSurfacePresentModesKHR(surface);

            var swapChainPresentMode = PresentModeKHR.Fifo;
            if(presentModes.Contains(PresentModeKHR.Mailbox))
                swapChainPresentMode = PresentModeKHR.Mailbox;
            else if(presentModes.Contains(PresentModeKHR.Immediate))
                swapChainPresentMode = PresentModeKHR.Immediate;

            var imageExtent = new Extent2D(windowWidth, windowHeight);
            var swapchainCreateInfo = new SwapchainCreateInfoKHR
            {
                Surface            = surface,
                MinImageCount      = desiredImageCount,

                ImageFormat        = surfaceFormat,
                ImageExtent        = imageExtent,
                ImageArrayLayers   = 1,
                ImageUsage         = ImageUsageFlags.ColorAttachment,
                ImageSharingMode   = SharingMode.Exclusive,
                //ImageColorSpace    = ColorSpaceKHR.SrgbNonlinear,

                QueueFamilyIndices = null,
                PreTransform       = preTransform,
                CompositeAlpha     = CompositeAlphaFlagsKHR.Opaque,
                PresentMode        = swapChainPresentMode,
                Clipped            = true,
            };
            data.Swapchain = device.CreateSwapchainKHR(swapchainCreateInfo);
            data.ImageFormat = surfaceFormat;

            return data;
        }

        protected List<ImageData> InitializeSwapchainImages(Queue queue, CommandPool cmdPool, Image[] images, Format imageFormat, uint width, uint height)
        {
            var cmdBuffers = AllocateCommandBuffers(cmdPool, 1);
            var cmdBuffer  = cmdBuffers.First();

            var inheritanceInfo = new CommandBufferInheritanceInfo();
            var beginInfo = new CommandBufferBeginInfo { InheritanceInfo = inheritanceInfo };
            cmdBuffer.Begin(beginInfo);

            foreach(var img in images)
                PipelineBarrierSetLayout(cmdBuffer, img, ImageLayout.Undefined, ImageLayout.PresentSrcKHR, AccessFlags.None, AccessFlags.None);

            cmdBuffer.End();

            var submitInfo = new SubmitInfo(null, null, new[]{ cmdBuffer }, null);
            queue.Submit(new[] { submitInfo });
            queue.WaitIdle();

            device.FreeCommandBuffers(cmdPool, new[] { cmdBuffer });

            var imageDatas = new List<ImageData>();

            foreach(var img in images)
            {
                var imgData    = new ImageData();
                imgData.Image = img;
                imgData.Width = width;
                imgData.Height = height;
                imgData.View = CreateImageView(img, imageFormat);
                imageDatas.Add(imgData);
            }

            return imageDatas;
        }

        #endregion

        #region Dependencies

        protected Image CreateImage(Format imageFormat, uint width, uint height)
        {
            var size = new Extent3D(width, height, 1);
            var usage = ImageUsageFlags.ColorAttachment | ImageUsageFlags.TransferSrc | ImageUsageFlags.TransferDst;
            var createImageInfo = new ImageCreateInfo(ImageType.ImageType2d, imageFormat, size, 1, 1, SampleCountFlags.SampleCountFlags1, ImageTiling.Optimal, usage, SharingMode.Exclusive, null, ImageLayout.Preinitialized);
            return device.CreateImage(createImageInfo);
        }

        protected Image CreateTextureImage(Format imageFormat, uint width, uint height)
        {
            var size = new Extent3D(width, height, 1);
            var usage = ImageUsageFlags.TransferDst | ImageUsageFlags.Sampled;
            var createImageInfo = new ImageCreateInfo(ImageType.ImageType2d, imageFormat, size, 1, 1, SampleCountFlags.SampleCountFlags1, ImageTiling.Optimal, usage, SharingMode.Exclusive, null, ImageLayout.Preinitialized);
            return device.CreateImage(createImageInfo);
        }

        protected DeviceMemory BindImage(Image image)
        {
            var memRequirements = device.GetImageMemoryRequirements(image);
            var memTypeIndex = FindMemoryIndex(MemoryPropertyFlags.DeviceLocal);
            var memAlloc = new MemoryAllocateInfo(memRequirements.Size, memTypeIndex);
            var deviceMem = device.AllocateMemory(memAlloc);
            device.BindImageMemory(image, deviceMem, 0);
            return deviceMem;
        }

        protected ImageView CreateImageView(Image image, Format imageFormat)
        {
            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            var createInfo = new ImageViewCreateInfo(image, ImageViewType.ImageViewType2d, imageFormat, new ComponentMapping(), subresourceRange);
            return device.CreateImageView(createInfo);
        }

        protected RenderPass CreateRenderPass(Format imageFormat)
        {
            var imageLayout = ImageLayout.ColorAttachmentOptimal;

            var attachmentDescriptions = new[]
            {
                new AttachmentDescription
                {
                    Format         = imageFormat,
                    Samples        = SampleCountFlags.SampleCountFlags1,
                    StencilLoadOp  = AttachmentLoadOp.DontCare,
                    StencilStoreOp = AttachmentStoreOp.DontCare,
                    InitialLayout  = imageLayout,
                    FinalLayout    = imageLayout
                },
            };

            var colorAttachmentReferences = new[]
            {
                new AttachmentReference(0, imageLayout)
            };

            var subpassDescriptions = new[]
            {
                new SubpassDescription(PipelineBindPoint.Graphics, null, colorAttachmentReferences, null)
            };

            var createInfo = new RenderPassCreateInfo(attachmentDescriptions, subpassDescriptions, null);
            return device.CreateRenderPass(createInfo);
        }

        protected RenderPass CreateRenderPass(Format colorFormat, Format stencilFormat)
        {
            var attachmentDescriptions = new[]
            {
                new AttachmentDescription
                {
                    Format         = colorFormat,
                    Samples        = SampleCountFlags.SampleCountFlags1,
                    StencilLoadOp  = AttachmentLoadOp.DontCare,
                    StencilStoreOp = AttachmentStoreOp.DontCare,
                    InitialLayout  = ImageLayout.ColorAttachmentOptimal,
                    FinalLayout    = ImageLayout.ColorAttachmentOptimal
                },
                new AttachmentDescription
                {
                    Format         = stencilFormat,
                    Samples        = SampleCountFlags.SampleCountFlags1,
                    StencilLoadOp  = AttachmentLoadOp.DontCare,
                    StencilStoreOp = AttachmentStoreOp.DontCare,
                    InitialLayout  = ImageLayout.DepthStencilAttachmentOptimal,
                    FinalLayout    = ImageLayout.DepthStencilAttachmentOptimal
                },
            };

            var colorAttachmentReferences = new[]
            {
                new AttachmentReference(0, ImageLayout.ColorAttachmentOptimal)
            };
            
            var subpassDescriptions = new[]
            {
                new SubpassDescription(PipelineBindPoint.Graphics, null, colorAttachmentReferences, null)
                {
                    DepthStencilAttachment = new AttachmentReference(1, ImageLayout.DepthStencilAttachmentOptimal),
                }
            };

            var createInfo = new RenderPassCreateInfo(attachmentDescriptions, subpassDescriptions, null);
            return device.CreateRenderPass(createInfo);
        }

        protected PipelineShaderStageCreateInfo GetShaderStageCreateInfo(ShaderStageFlags stage, string filename, string entrypoint = "main")
        {
            var shaderBytes = File.ReadAllBytes(filename);
            return new PipelineShaderStageCreateInfo(stage, CreateShaderModule(shaderBytes), entrypoint);
        }

        protected ShaderModule CreateShaderModule(byte[] shaderCode)
        {
            var createInfo = new ShaderModuleCreateInfo(shaderCode);
            return device.CreateShaderModule(createInfo);
        }

        protected PipelineLayout CreatePipelineLayout(DescriptorSetLayout descriptorSetLayout)
        {
            var createInfo = new PipelineLayoutCreateInfo(new[]{ descriptorSetLayout }, null);
            return device.CreatePipelineLayout(createInfo);
        }

        protected Pipeline[] CreatePipelines(PipelineLayout pipelineLayout, RenderPass renderPass, PipelineShaderStageCreateInfo[] shaderStageCreateInfos, VertexData vertexData)
        {
            var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo(PrimitiveTopology.TriangleList, false);

            var vertexInputState = new PipelineVertexInputStateCreateInfo(vertexData.BindingDescriptions, vertexData.AttributeDescriptions);

            var rasterizationState = new PipelineRasterizationStateCreateInfo();
            rasterizationState.LineWidth = 1;

            //var blendState = new PipelineColorBlendStateCreateInfo();

            //var viewportState = new PipelineViewportStateCreateInfo();
            //viewportState.Viewports = 1;
            //viewportState.Scissors = 1;

            var depthStencilState = new PipelineDepthStencilStateCreateInfo();
            depthStencilState.DepthTestEnable = true;
            depthStencilState.DepthWriteEnable = true;
            depthStencilState.DepthCompareOp = CompareOp.LessOrEqual;
            depthStencilState.Back = new StencilOpState { CompareOp = CompareOp.Always };
            depthStencilState.Front = new StencilOpState { CompareOp = CompareOp.Always };

            var createInfos = new[]
            {
                new GraphicsPipelineCreateInfo(shaderStageCreateInfos, vertexInputState, inputAssemblyState, rasterizationState, pipelineLayout, renderPass, 0, 0)
                {
                    ViewportState = new PipelineViewportStateCreateInfo(),
                    MultisampleState = new PipelineMultisampleStateCreateInfo()
                    {
                        RasterizationSamples = SampleCountFlags.SampleCountFlags1
                    },
                    DepthStencilState = depthStencilState,
                }
            };

            return device.CreateGraphicsPipelines(null, createInfos);
        }

        protected Framebuffer CreateFramebuffer(RenderPass renderPass, params ImageData[] imageData)
        {
            var attachments = imageData.Select(x => x.View).ToArray();
            var createInfo = new FramebufferCreateInfo(renderPass, attachments, imageData[0].Width, imageData[0].Height, 1);
            return device.CreateFramebuffer(createInfo);
        }

        protected Buffer CreateBuffer(DeviceSize size, BufferUsageFlags flags)
        {
            var bufferCreateInfo = new BufferCreateInfo(size, flags, SharingMode.Exclusive, null);
            return device.CreateBuffer(bufferCreateInfo);
        }

        protected DeviceMemory BindBuffer(Buffer buffer, MemoryAllocateInfo allocInfo)
        {
            var bufferMem = device.AllocateMemory(allocInfo);
            device.BindBufferMemory(buffer, bufferMem, 0);
            return bufferMem;
        }

        #endregion

        protected void SubmitForExecution(Queue queue, Semaphore presentSemaphore, CommandBuffer cmdBuffer)
        {
            var submitInfo = new SubmitInfo(new[]{ presentSemaphore }, null, new[]{ cmdBuffer }, null);
            queue.Submit(new[] { submitInfo });
            submitInfo.Dispose();
        }

        protected void PipelineBarrierSetLayout(CommandBuffer cmdBuffer, Image image, ImageLayout oldLayout, ImageLayout newLayout, AccessFlags srcMask, AccessFlags dstMask)
        {
            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            var imageMemoryBarrier = new ImageMemoryBarrier(oldLayout, newLayout, 0, 0, image, subresourceRange);
            imageMemoryBarrier.SrcAccessMask = srcMask;
            imageMemoryBarrier.DstAccessMask = dstMask;
            var imageMemoryBarriers = new[]{ imageMemoryBarrier };
            cmdBuffer.PipelineBarrier(PipelineStageFlags.TopOfPipe, PipelineStageFlags.TopOfPipe, DependencyFlags.None, null, null, imageMemoryBarriers);
            imageMemoryBarrier.Dispose();
        }

        protected uint FindMemoryIndex(MemoryPropertyFlags propertyFlags)
        {
            for(uint x = 0; x < VulkanConstant.MaxMemoryTypes; x++)
                if((physDeviceMem.MemoryTypes[x].PropertyFlags & propertyFlags) == propertyFlags)
                    return x;

            throw new InvalidOperationException();
        }

        protected float DegreesToRadians(float degrees)
        {
            const float degToRad = (float)Math.PI / 180.0f;
            return degrees * degToRad;
        }

        private Bool32 DebugReport(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData)
        {
            if(messageCode != 0)
                Console.WriteLine($"[{messageCode,2}] {message}");
            return false;
        }
    }
}
