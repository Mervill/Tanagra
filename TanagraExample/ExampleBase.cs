using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

using ImageLayout = Vulkan.ImageLayout;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    public class ExampleBase
    {
        public class DepthStencil
        {
            public Image image;
            public DeviceMemory mem;
            public ImageView view;
        }

        uint width = 800;
        uint height = 600;

        Instance instance;
        PhysicalDevice physicalDevice;
        PhysicalDeviceProperties deviceProperties;
        PhysicalDeviceFeatures deviceFeatures;
        PhysicalDeviceMemoryProperties deviceMemoryProperties;
        Device device;
        Queue queue;
        Format colorFormat = Format.B8g8r8a8Unorm;
        Format depthFormat;
        CommandPool cmdPool;
        CommandBuffer setupCmdBuffer;
        CommandBuffer postPresentCmdBuffer;
        CommandBuffer prePresentCmdBuffer;
        PipelineStageFlags submitPipelineStages;
        SubmitInfo submitInfo;
        List<CommandBuffer> drawCmdBuffers;
        RenderPass renderPass;
        List<Framebuffer> frameBuffers;
        uint currentBuffer;
        DescriptorPool descriptorPool;
        List<ShaderModule> shaderModules;
        PipelineCache pipelineCache;
        Swapchain swapchain;

        DepthStencil depthStencil;

        List<Semaphore> presentComplete;
        List<Semaphore> renderComplete;
        List<Semaphore> textOverlayComplete;

        bool enableValidation;
        bool enableDebugMarkers;
        float fpsTimer;
        float frameTimer;

        public ExampleBase()
        {
            presentComplete = new List<Semaphore>();
            renderComplete = new List<Semaphore>();
            textOverlayComplete = new List<Semaphore>();
        }

        public void initVulkan()
        {
            // Vulkan instance
            createInstance();
            // Physical device
            uint gpuCount = 0;
            var physicalDevices = instance.EnumeratePhysicalDevices();
            physicalDevice = physicalDevices[0];
            
            var queueNodeIndex = (uint)physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0)
                .Select((properties, index) => index)
                .First();

            var queueCreateInfo = new DeviceQueueCreateInfo(queueNodeIndex, new[] { 0f });
            createDevice(queueCreateInfo);
            queueCreateInfo.Dispose();

            // Store properties (including limits) and features of the phyiscal device
            // So examples can check against them and see if a feature is actually supported
            deviceProperties = physicalDevice.GetProperties();
            deviceFeatures = physicalDevice.GetFeatures();
            // Gather physical device memory properties
            deviceMemoryProperties = physicalDevice.GetMemoryProperties();

            // Get the graphics queue
            queue = device.GetQueue(queueNodeIndex, 0);
            depthFormat = Utils.getSupportedDepthFormat(physicalDevice);

            swapchain = new Swapchain(instance, physicalDevice, device);

            var semCreateInfo = new SemaphoreCreateInfo();
            // Create a semaphore used to synchronize image presentation
            // Ensures that the image is displayed before we start submitting new commands to the queue
            presentComplete.Add(device.CreateSemaphore(semCreateInfo));
            // Create a semaphore used to synchronize command submission
            // Ensures that the image is not presented until all commands have been sumbitted and executed
            renderComplete.Add(device.CreateSemaphore(semCreateInfo));
            // Create a semaphore used to synchronize command submission
	        // Ensures that the image is not presented until all commands for the text overlay have been sumbitted and executed
	        // Will be inserted after the render complete semaphore if the text overlay is enabled
            textOverlayComplete.Add(device.CreateSemaphore(semCreateInfo));
            semCreateInfo.Dispose();

            // Set up submit info structure
            // Semaphores will stay the same during application lifetime
            // Command buffer submission info is set by each example
            submitInfo = new SubmitInfo();
            //submitInfo.WaitDstStageMask = // todo
            submitInfo.WaitSemaphores = presentComplete.ToArray();
            submitInfo.SignalSemaphores = renderComplete.ToArray();
        }

        void createInstance()
        {
            var instanceEnabledExtensions = new[]
            {
                VulkanConstant.KhrSurfaceExtensionName,
                VulkanConstant.KhrWin32SurfaceExtensionName,
            };

            var instanceCreateInfo = new InstanceCreateInfo(null, instanceEnabledExtensions);
            instance = Vk.CreateInstance(instanceCreateInfo);
            instanceCreateInfo.Dispose();
        }

        void createDevice(DeviceQueueCreateInfo requestedQueues)
        {
            var deviceCreateInfo = new DeviceCreateInfo(new[] { requestedQueues }, null, null);
            device = physicalDevice.CreateDevice(deviceCreateInfo);
            deviceCreateInfo.Dispose();
        }

        public virtual void prepare()
        {
            CreateCommandPool();
            createSetupCommandBuffer();
            setupSwapChain();
            createCommandBuffers();
            setupDepthStencil();
            setupRenderPass();
            createPipelineCache();
            setupFrameBuffer();
            flushSetupCommandBuffer();
            createSetupCommandBuffer();
        }

        void CreateCommandPool()
        {
            var createInfo = new CommandPoolCreateInfo();
            createInfo.QueueFamilyIndex = (uint)swapchain.queueNodeIndex;
            createInfo.Flags = CommandPoolCreateFlags.ResetCommandBuffer;
            cmdPool = device.CreateCommandPool(createInfo);
            createInfo.Dispose();
        }

        void createSetupCommandBuffer()
        {
            if(setupCmdBuffer != null)
            {
                device.FreeCommandBuffers(cmdPool, new List<CommandBuffer> { setupCmdBuffer });
                device = null;
            }

            var cmdBufAllocateInfo = new CommandBufferAllocateInfo();
            cmdBufAllocateInfo.CommandPool = cmdPool;
            cmdBufAllocateInfo.Level = CommandBufferLevel.Primary;
            cmdBufAllocateInfo.CommandBufferCount = 1;
            setupCmdBuffer = device.AllocateCommandBuffers(cmdBufAllocateInfo).First();
            cmdBufAllocateInfo.Dispose();

            var beginInfo = new CommandBufferBeginInfo();
            setupCmdBuffer.Begin(beginInfo);
            beginInfo.Dispose();
        }

        void createCommandBuffers()
        {
            var cmdBufAllocateInfo = new CommandBufferAllocateInfo();
            cmdBufAllocateInfo.CommandPool = cmdPool;
            cmdBufAllocateInfo.Level = CommandBufferLevel.Primary;
            cmdBufAllocateInfo.CommandBufferCount = (uint)swapchain.images.Count;
            drawCmdBuffers = device.AllocateCommandBuffers(cmdBufAllocateInfo);
            cmdBufAllocateInfo.CommandBufferCount = 1;
            prePresentCmdBuffer = device.AllocateCommandBuffers(cmdBufAllocateInfo)[0];
            postPresentCmdBuffer = device.AllocateCommandBuffers(cmdBufAllocateInfo)[0];
            cmdBufAllocateInfo.Dispose();
        }

        void setupDepthStencil()
        {
            var createInfo = new ImageCreateInfo();
            //createInfo.QueueFamilyIndices = new uint[] { 0 };
            createInfo.ImageType = ImageType.ImageType2d;
            createInfo.Format = depthFormat;
            createInfo.Extent = new Extent3D(width, height, 1);
            createInfo.MipLevels = 1;
            createInfo.ArrayLayers = 1;
            createInfo.Samples = SampleCountFlags.SampleCountFlags1;
            createInfo.Tiling = ImageTiling.Optimal;
            createInfo.Usage = ImageUsageFlags.DepthStencilAttachment | ImageUsageFlags.TransferSrc;
            //createInfo.InitialLayout = ImageLayout.Preinitialized;

            var depthStencilView = new ImageViewCreateInfo();
            depthStencilView.ViewType = ImageViewType.ImageViewType2d;
            depthStencilView.Format = depthFormat;
            depthStencilView.SubresourceRange = new ImageSubresourceRange(ImageAspectFlags.Depth | ImageAspectFlags.Stencil, 0, 1, 0, 1);

            depthStencil = new DepthStencil();

            var image = device.CreateImage(createInfo);
            var memReqs = device.GetImageMemoryRequirements(image);
            var memAlloc = new MemoryAllocateInfo();
            memAlloc.AllocationSize = memReqs.Size;
            memAlloc.MemoryTypeIndex = getMemoryType(memReqs.MemoryTypeBits, MemoryPropertyFlags.DeviceLocal);

            depthStencil.image = image;
            depthStencil.mem = device.AllocateMemory(memAlloc);

            device.BindImageMemory(depthStencil.image, depthStencil.mem, 0);
            Utils.setImageLayout(setupCmdBuffer, depthStencil.image, ImageAspectFlags.Depth | ImageAspectFlags.Stencil, ImageLayout.Undefined, ImageLayout.DepthStencilAttachmentOptimal);

            depthStencilView.Image = depthStencil.image;
            depthStencil.view = device.CreateImageView(depthStencilView);
            depthStencilView.Dispose();
        }
        
        void setupRenderPass()
        {
            var attachments = new AttachmentDescription[2];
            attachments[0].Format = colorFormat;
            attachments[0].Samples = SampleCountFlags.SampleCountFlags1;
            attachments[0].LoadOp = AttachmentLoadOp.Clear;
            attachments[0].StoreOp = AttachmentStoreOp.Store;
            attachments[0].StencilLoadOp = AttachmentLoadOp.DontCare;
            attachments[0].StencilStoreOp = AttachmentStoreOp.DontCare;
            attachments[0].InitialLayout = ImageLayout.ColorAttachmentOptimal;
            attachments[0].FinalLayout = ImageLayout.ColorAttachmentOptimal;

            attachments[1].Format = colorFormat;
            attachments[1].Samples = SampleCountFlags.SampleCountFlags1;
            attachments[1].LoadOp = AttachmentLoadOp.Clear;
            attachments[1].StoreOp = AttachmentStoreOp.Store;
            attachments[1].StencilLoadOp = AttachmentLoadOp.DontCare;
            attachments[1].StencilStoreOp = AttachmentStoreOp.DontCare;
            attachments[1].InitialLayout = ImageLayout.DepthStencilAttachmentOptimal;
            attachments[1].FinalLayout = ImageLayout.DepthStencilAttachmentOptimal;

            var colorRefrence = new AttachmentReference(0, ImageLayout.ColorAttachmentOptimal);
            var depthReference = new AttachmentReference(1, ImageLayout.DepthStencilAttachmentOptimal);

            var subpass = new SubpassDescription();
            subpass.PipelineBindPoint = PipelineBindPoint.Graphics;
            subpass.ColorAttachments = new[] { colorRefrence };
            subpass.DepthStencilAttachment = depthReference;

            var createInfo = new RenderPassCreateInfo();
            createInfo.Attachments = attachments;
            createInfo.Subpasses = new[] { subpass };
            renderPass = device.CreateRenderPass(createInfo);
            subpass.Dispose();
            createInfo.Dispose();
        }

        void createPipelineCache()
        {
            var createInfo = new PipelineCacheCreateInfo();
            pipelineCache = device.CreatePipelineCache(createInfo);
            createInfo.Dispose();
        }

        void setupFrameBuffer()
        {
            var attachments = new ImageView[2];
            attachments[1] = depthStencil.view;
            
            var createInfo = new FramebufferCreateInfo();
            createInfo.RenderPass = renderPass;
            createInfo.Width = width;
            createInfo.Height = height;
            createInfo.Layers = 1;

            frameBuffers = new List<Framebuffer>();
            for (var x = 0; x < swapchain.images.Count; x++)
            {
                attachments[0] = swapchain.buffers[x].view;
                createInfo.Attachments = null; // todo: realloc is broken
                createInfo.Attachments = attachments;
                frameBuffers.Add(device.CreateFramebuffer(createInfo));
            }
            createInfo.Dispose();
        }

        void flushSetupCommandBuffer()
        {
            if(setupCmdBuffer == null)
                return;

            setupCmdBuffer.End();

            var subInfo = new SubmitInfo();
            subInfo.CommandBuffers = new[] { setupCmdBuffer };
            queue.Submit(new List<SubmitInfo> { subInfo });
            subInfo.Dispose();

            queue.WaitIdle();

            device.FreeCommandBuffers(cmdPool, new List<CommandBuffer> { setupCmdBuffer });
            setupCmdBuffer = null;
        }
        
        public void initSwapchain(Form form)
        {
            width = (uint)form.ClientSize.Width;
            height = (uint)form.ClientSize.Height;
            swapchain.initSurface(form);
        }

        public void setupSwapChain()
        {
            swapchain.create(setupCmdBuffer, width, height);
        }

        public uint getMemoryType(uint typeBits, MemoryPropertyFlags propertyFlags)
        {
            for(uint x = 0; x < 32; x++)
            {
                if((typeBits & 1) == 1)
                {
                    if((deviceMemoryProperties.MemoryTypes[x].PropertyFlags & propertyFlags) == propertyFlags)
                    {
                        return x;
                    }
                }
                typeBits >>= 1;
            }

            throw new InvalidOperationException();
        }
    }
}
