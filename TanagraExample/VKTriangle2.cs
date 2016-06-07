using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

using SharpDX.Windows;

using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // A managed interface to Vulkan
using Vulkan.Managed.ObjectModel; // Extentions to object handles

using ImageLayout = Vulkan.ImageLayout;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    class VKTriangle2
    {
        class VertexData
        {
            public Buffer Buffer;
            public DeviceMemory DeviceMemory;
            public VertexInputBindingDescription[] BindingDescriptions;
            public VertexInputAttributeDescription[] AttributeDescriptions;
        }

        Vulkan.Allocation.Allocator allocator;
        
        Device device;
        
        private Format backBufferFormat;
        
        private DebugReportCallbackEXT debugCallback;

        static List<ShaderModule> shaders = new List<ShaderModule>();
        static List<PipelineShaderStageCreateInfo> shaderInfos = new List<PipelineShaderStageCreateInfo>();

        Queue render_queue;
        CommandBuffer render_cmdBuffer;
        RenderPass render_renderPass;
        Pipeline render_pipeline;
        SwapchainKHR render_swapchain;
        List<Framebuffer> render_framebuffers;
        Image[] render_swapchainImages;
        List<ImageView> render_swapchainViews;
        VertexData render_vertexData;

        public void Main(string[] args)
        {
            var window = new RenderForm("Tanagra - Vulkan Sample");

            uint imageWidth  = 800;
            uint imageHeight = 600;

            var instance      = CreateInstance();
            var physDevices   = EnumeratePhysicalDevices(instance);
            var physDevice    = physDevices.First();
            var queueFamilies = physDevice.GetQueueFamilyProperties();
            var physDeviceMem = physDevice.GetMemoryProperties();

            var surface       = CreateWin32Surface(instance, window.Handle);
            physDevice.GetSurfaceSupportKHR(0, surface);

                device        = CreateDevice(physDevice);
            var queue         = GetQueue(physDevice, 0);
            var cmdPool       = CreateCommandPool(0);

            var vertexData    = CreateVertexData();
            
            var swapchain       = CreateSwapchain(cmdPool, physDevice, queue, surface, imageHeight, imageWidth);
            var swapchainImages = device.GetSwapchainImagesKHR(swapchain);
            var swapchainViews  = InitializeSwapchainImages(queue, cmdPool, swapchainImages, Format.B8g8r8a8Unorm);
            
            var renderPass     = CreateRenderPass();
            var pipelineLayout = CreatePipelineLayout();
            var pipelines      = CreatePipelines(pipelineLayout, renderPass, vertexData);
            var pipeline       = pipelines.First();

            var framebuffers = CreateFramebuffers(renderPass, swapchainImages, swapchainViews,  imageHeight, imageWidth);

            var cmdBuffers = AllocateCommandBuffers(cmdPool, 1);
            var cmdBuffer  = cmdBuffers.First();

            render_queue = queue;
            render_cmdBuffer = cmdBuffer;
            render_renderPass = renderPass;
            render_pipeline = pipeline;
            render_swapchain = swapchain;
            render_framebuffers = framebuffers;
            render_swapchainImages = swapchainImages;
            render_swapchainViews = swapchainViews;
            render_vertexData = vertexData;
            RenderLoop.Run(window, Draw);
            
            //Destroy();
        }

        #region  Primary Initialization

        Instance CreateInstance()
        {
            String[] enabledLayers = new string[]
            {
                //"VK_LAYER_LUNARG_standard_validation"
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

        PhysicalDevice[] EnumeratePhysicalDevices(Instance instance)
        {
            var physicalDevices = instance.EnumeratePhysicalDevices();

            if(physicalDevices.Length == 0)
                throw new InvalidOperationException("Didn't find any physical devices");

            return physicalDevices;
        }

        Device CreateDevice(PhysicalDevice physicalDevice)
        {
            String[] enabledLayers = new string[]
            {
                //"VK_LAYER_LUNARG_standard_validation"
            };

            var enabledExtensions = new[]
            {
                VulkanConstant.KhrSwapchainExtensionName,
            };

            var features = new PhysicalDeviceFeatures();
            features.ShaderClipDistance = true;

            var queueCreateInfo = new DeviceQueueCreateInfo(0, new[] { 0f });
            var deviceCreateInfo = new DeviceCreateInfo(new[] { queueCreateInfo }, enabledLayers, enabledExtensions);
            deviceCreateInfo.EnabledFeatures = features;
            return physicalDevice.CreateDevice(deviceCreateInfo);
        }

        Queue GetQueue(PhysicalDevice physicalDevice, uint queueFamily)
        {
            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0)
                .Select((properties, index) => index)
                .First();

            return device.GetQueue(queueFamily, (uint)queueNodeIndex);
        }

        CommandPool CreateCommandPool(uint queueFamily)
        {
            var commandPoolCreateInfo = new CommandPoolCreateInfo(queueFamily);
            commandPoolCreateInfo.Flags = CommandPoolCreateFlags.ResetCommandBuffer;
            return device.CreateCommandPool(commandPoolCreateInfo);
        }

        CommandBuffer[] AllocateCommandBuffers(CommandPool commandPool, uint buffersToAllocate)
        {
            var commandBufferAllocationInfo = new CommandBufferAllocateInfo(commandPool, CommandBufferLevel.Primary, buffersToAllocate);
            var commandBuffers = device.AllocateCommandBuffers(commandBufferAllocationInfo);

            if(commandBuffers.Length == 0)
                throw new InvalidOperationException("Couldn't allocate any command buffers");

            return commandBuffers;
        }

        #endregion

        #region Surface / Swapchain

        SurfaceKHR CreateWin32Surface(Instance instance, IntPtr handle)
        {
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR(Process.GetCurrentProcess().Handle, handle);
            var surface = instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
            return surface;
        }

        List<ImageView> InitializeSwapchainImages(Queue queue, CommandPool cmdPool, Image[] images, Format imageFormat)
        {
            var cmdBuffers = AllocateCommandBuffers(cmdPool, 1);
            var cmdBuffer  = cmdBuffers[0];

            var inheritanceInfo = new CommandBufferInheritanceInfo();
            var beginInfo = new CommandBufferBeginInfo { InheritanceInfo = inheritanceInfo };
            cmdBuffer.Begin(beginInfo);

            foreach(var img in images)
                PipelineBarrierSetLayout(cmdBuffer, img, ImageLayout.Undefined, ImageLayout.PresentSrcKHR, AccessFlags.None, AccessFlags.None);

            cmdBuffer.End();

            var submitInfo = new SubmitInfo(null, null, new[] { cmdBuffer }, null);
            queue.Submit(new SubmitInfo[] { submitInfo });
            queue.WaitIdle();

            device.FreeCommandBuffers(cmdPool, new CommandBuffer[] { cmdBuffer });

            var imageDatas = new List<ImageView>();

            foreach(var img in images)
            {
                var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
                var createInfo = new ImageViewCreateInfo(img, ImageViewType.ImageViewType2d, imageFormat, new ComponentMapping(), subresourceRange);
                var view = device.CreateImageView(createInfo);
                imageDatas.Add(view);
            }

            return imageDatas;
        }

        private SwapchainKHR CreateSwapchain(CommandPool cmdPool, PhysicalDevice physicalDevice, Queue queue, SurfaceKHR surface, uint imageWidth, uint imageHeight)
        {
            // surface format
            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            backBufferFormat = surfaceFormats[0].Format;

            var surfaceCapabilities = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            // Buffer count
            var desiredImageCount = Math.Min(surfaceCapabilities.MinImageCount + 1, surfaceCapabilities.MaxImageCount);

            SurfaceTransformFlagsKHR preTransform;
            if ((surfaceCapabilities.SupportedTransforms & SurfaceTransformFlagsKHR.Identity) != 0)
            {
                preTransform = SurfaceTransformFlagsKHR.Identity;
            }
            else
            {
                preTransform = surfaceCapabilities.CurrentTransform;
            }

            // Present mode
            var presentModes = physicalDevice.GetSurfacePresentModesKHR(surface);

            var swapChainPresentMode = PresentModeKHR.Fifo;
            if (presentModes.Contains(PresentModeKHR.Mailbox))
                swapChainPresentMode = PresentModeKHR.Mailbox;
            else if (presentModes.Contains(PresentModeKHR.Immediate))
                swapChainPresentMode = PresentModeKHR.Immediate;
            
            var imageExtent = new Extent2D(imageWidth, imageHeight);
            var swapchainCreateInfo = new SwapchainCreateInfoKHR
            {
                Surface            = surface,
                MinImageCount      = desiredImageCount,

                ImageFormat        = backBufferFormat,
                ImageExtent        = imageExtent,
                ImageArrayLayers   = 1,
                ImageUsage         = ImageUsageFlags.ColorAttachment,
                ImageSharingMode   = SharingMode.Exclusive,

                QueueFamilyIndices = null,
                PreTransform       = preTransform,
                CompositeAlpha     = CompositeAlphaFlagsKHR.Opaque,
                PresentMode        = swapChainPresentMode,
                Clipped            = true,
            };
            return device.CreateSwapchainKHR(swapchainCreateInfo);
        }

        #endregion

        VertexData CreateVertexData()
        {
            var data = new VertexData();

            var triangleVertices = new[,]
            {
                {  0.0f, -0.5f,  0.5f, /* UV Coordinates: */ 1.0f, 0.0f, 0.0f },
                {  0.5f,  0.5f,  0.5f, /* UV Coordinates: */ 0.0f, 1.0f, 0.0f },
                { -0.5f,  0.5f,  0.5f, /* UV Coordinates: */ 0.0f, 0.0f, 1.0f },
            };

            DeviceSize memorySize = (ulong)(sizeof(float) * triangleVertices.Length);
            data.Buffer = CreateBuffer(memorySize, BufferUsageFlags.VertexBuffer);

            var memoryRequirements = device.GetBufferMemoryRequirements(data.Buffer);
            var memoryIndex = 2u;//FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            var allocateInfo = new MemoryAllocateInfo(memoryRequirements.Size, memoryIndex);
            data.DeviceMemory = BindBuffer(data.Buffer, allocateInfo);

            var mapped = device.MapMemory(data.DeviceMemory, 0, memorySize);
            VulkanUtils.Copy2DArray(triangleVertices, mapped, memorySize, memorySize);
            device.UnmapMemory(data.DeviceMemory);

            data.BindingDescriptions = new[]
            {
                new VertexInputBindingDescription(0, (uint)(sizeof(float) * triangleVertices.GetLength(1)), VertexInputRate.Vertex)
            };

            data.AttributeDescriptions = new[]
            {
                new VertexInputAttributeDescription(0, 0, Format.R32g32b32Sfloat, 0),
                new VertexInputAttributeDescription(1, 0, Format.R32g32b32Sfloat, sizeof(float) * 3)
            };

            return data;
        }

        RenderPass CreateRenderPass()
        {
            var imageLayout = ImageLayout.ColorAttachmentOptimal;
            
            var attachmentDescriptions = new[]
            {
                new AttachmentDescription
                {
                    Format         = Format.B8g8r8a8Unorm,
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
            var renderPass = device.CreateRenderPass(createInfo);
            return renderPass;
        }

        PipelineLayout CreatePipelineLayout()
        {
            var createInfo = new PipelineLayoutCreateInfo();
            return device.CreatePipelineLayout(createInfo);
        }

        Pipeline[] CreatePipelines(PipelineLayout pipelineLayout, RenderPass renderPass, VertexData vertexData)
        {
            var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo(PrimitiveTopology.TriangleList, false);
            var vertexInputState = new PipelineVertexInputStateCreateInfo(vertexData.BindingDescriptions, vertexData.AttributeDescriptions);
            
            var rasterizationState = new PipelineRasterizationStateCreateInfo();
            //rasterizationState.RasterizerDiscardEnable = true;
            rasterizationState.LineWidth = 1;
            
            shaderInfos.Add(new PipelineShaderStageCreateInfo(ShaderStageFlags.Vertex, CreateVertexShader(), "main"));
            shaderInfos.Add(new PipelineShaderStageCreateInfo(ShaderStageFlags.Fragment, CreateFragmentShader(), "main"));

            var createInfos = new[]
            {
                new GraphicsPipelineCreateInfo(shaderInfos.ToArray(), vertexInputState, inputAssemblyState, rasterizationState, pipelineLayout, renderPass, 0, 0)
                {
                    ViewportState = new PipelineViewportStateCreateInfo(),
                    MultisampleState = new PipelineMultisampleStateCreateInfo()
                    {
                        RasterizationSamples = SampleCountFlags.SampleCountFlags1
                    }
                }
            };

            return device.CreateGraphicsPipelines(null, createInfos);            
        }

        private ShaderModule CreateVertexShader()
        {
            var bytes = File.ReadAllBytes("vert.spv");
            return CreateShaderModule(bytes);
        }

        private ShaderModule CreateFragmentShader()
        {
            var bytes = File.ReadAllBytes("frag.spv");
            return CreateShaderModule(bytes);
        }

        private ShaderModule CreateShaderModule(byte[] shaderCode)
        {
            var createInfo = new ShaderModuleCreateInfo(shaderCode);
            var module = device.CreateShaderModule(createInfo);
            shaders.Add(module);
            createInfo.Dispose();
            return module;
        }

        List<Framebuffer> CreateFramebuffers(RenderPass renderPass, Image[] swapchainImages, List<ImageView> swapchainViews,  uint imageWidth, uint imageHeight)
        {
            var framebuffers = new List<Framebuffer>(); //new Framebuffer[swapchainImages.Count];
            for (int i = 0; i < swapchainImages.Length; i++)
            {
                var attachment = swapchainViews[i];
                var createInfo = new FramebufferCreateInfo(renderPass, new[] { attachment }, imageWidth, imageHeight, 1);
                framebuffers.Add(device.CreateFramebuffer(createInfo));
            }
            return framebuffers;
        }

        private void Draw()
        {
            var semaphoreCreateInfo = new SemaphoreCreateInfo();
            var presentCompleteSemaphore = device.CreateSemaphore(semaphoreCreateInfo);
            semaphoreCreateInfo.Dispose();

            uint currentBackBufferIndex = 0;
            try
            {
                // Get the index of the next available swapchain image
                currentBackBufferIndex = device.AcquireNextImageKHR(render_swapchain, ulong.MaxValue, presentCompleteSemaphore, null);
            }
            catch (VulkanResultException e) when (e.Result == Result.ErrorOutOfDateKHR)
            {
                // TODO: Handle resize and retry draw
                throw new NotImplementedException();
            }

            // Record drawing command buffer
            var beginInfo = new CommandBufferBeginInfo();
            render_cmdBuffer.Begin(beginInfo);
            beginInfo.Dispose();
            DrawInternal(currentBackBufferIndex);
            render_cmdBuffer.End();

            // Submit
            var drawCommandBuffer = render_cmdBuffer;
            var pipelineStageFlags = PipelineStageFlags.BottomOfPipe;
            var submitInfo = new SubmitInfo(new[] { presentCompleteSemaphore }, new[] { pipelineStageFlags }, new[] { drawCommandBuffer }, null);
            render_queue.Submit(new SubmitInfo[] { submitInfo }, null);
            submitInfo.Dispose();

            // Present
            var currentBackBufferIndexCopy = currentBackBufferIndex;
            var presentInfo = new PresentInfoKHR(new[] { render_swapchain }, new[] { currentBackBufferIndexCopy });
            render_queue.PresentKHR(presentInfo);
            presentInfo.Dispose();

            // Wait
            render_queue.WaitIdle();

            // Cleanup
            device.DestroySemaphore(presentCompleteSemaphore);
        }

        private void DrawInternal(uint currentBackBufferIndex)
        {
            uint imageWidth  = 800;//(uint)window.Width;  // default: 800
            uint imageHeight = 600;//(uint)window.Height; // default: 600

            var cmdBuffer = render_cmdBuffer;
            // Post-present transition
            var memoryBarrier = new ImageMemoryBarrier
            {
                OldLayout = ImageLayout.PresentSrcKHR,
                NewLayout = ImageLayout.ColorAttachmentOptimal,
                SrcAccessMask = AccessFlags.MemoryRead,
                DstAccessMask = AccessFlags.ColorAttachmentWrite,
                Image = render_swapchainImages[(int)currentBackBufferIndex],
                SubresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1),
            };
            cmdBuffer.CmdPipelineBarrier(PipelineStageFlags.TopOfPipe, PipelineStageFlags.TopOfPipe, DependencyFlags.None, null, null, new ImageMemoryBarrier[] { memoryBarrier });
            memoryBarrier.Dispose();

            var clearRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            cmdBuffer.CmdClearColorImage(render_swapchainImages[(int)currentBackBufferIndex], ImageLayout.TransferDstOptimal, new ClearColorValue(), new ImageSubresourceRange[] { clearRange }); // todo...

            // Set viewport 
            var viewport = new Viewport(0, 0, imageWidth, imageHeight, 0, 0);
            cmdBuffer.CmdSetViewport(0, new Viewport[] { viewport });

            // Begin render pass
            var renderArea = new Rect2D(new Offset2D(0, 0), new Extent2D(imageWidth, imageHeight));
            var renderPassBeginInfo = new RenderPassBeginInfo(render_renderPass, render_framebuffers[(int)currentBackBufferIndex], renderArea, null);
            cmdBuffer.CmdBeginRenderPass(renderPassBeginInfo, SubpassContents.Inline);
            renderPassBeginInfo.Dispose();

            // Bind pipeline
            cmdBuffer.CmdBindPipeline(PipelineBindPoint.Graphics, render_pipeline);
            
            // Set scissor
            //var scissor = new Rect2D(new Offset2D(0, 0), new Extent2D((uint)form.ClientSize.Width, (uint)form.ClientSize.Height));
            //cmdBuffer.CmdSetScissor(0, new List<Rect2D> { scissor });

            // Bind vertex buffer
            ulong offset = 0;
            cmdBuffer.CmdBindVertexBuffers(0, new Buffer[] { render_vertexData.Buffer }, new DeviceSize[] { offset });

            // Draw vertices
            cmdBuffer.CmdDraw(3, 1, 0, 0);

            // End render pass
            cmdBuffer.CmdEndRenderPass();

            // Pre-present transition
            memoryBarrier = new ImageMemoryBarrier
            {
                OldLayout = ImageLayout.ColorAttachmentOptimal,
                NewLayout = ImageLayout.PresentSrcKHR,
                SrcAccessMask = AccessFlags.ColorAttachmentWrite,
                DstAccessMask = AccessFlags.MemoryRead,
                Image = render_swapchainImages[(int)currentBackBufferIndex],
                SubresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1),
            };
            cmdBuffer.CmdPipelineBarrier(PipelineStageFlags.AllCommands, PipelineStageFlags.BottomOfPipe, DependencyFlags.None, null, null, new ImageMemoryBarrier[] { memoryBarrier });
            memoryBarrier.Dispose();
        }

        /*private void Destroy()
        {
            device.WaitIdle();
            device.FreeMemory(vertexBufferMemory);
            device.DestroyBuffer(vertexBuffer);
            foreach (var framebuffer in framebuffers)
                device.DestroyFramebuffer(framebuffer);

            device.DestroyRenderPass(renderPass);
            device.DestroyPipeline(pipeline);
            device.DestroyPipelineLayout(pipelineLayout);
            device.FreeCommandBuffers(commandPool, commandBuffer);
            device.DestroyCommandPool(commandPool);
            foreach (var backBufferView in backBufferViews)
                device.DestroyImageView(backBufferView);

            device.DestroySwapchainKHR(swapchain);
            instance.DestroySurfaceKHR(surface);

            device.Destroy();

            DebugUtils.DestroyDebugReportCallback(instance, debugCallback);

            instance.Destroy();

            allocator.AllocationCallbacks.Dispose();

            form.Dispose();

            commandBuffer = null;
            backBuffers = null;
            backBufferViews = null;
            framebuffers = null;
            vertexAttributes = null;
            vertexBindings = null;

            GC.GetTotalMemory(true);
            GC.WaitForPendingFinalizers();
            WriteLine($"[INFO] Allocator: {allocator.CallCount} allocated pointers");
            WriteLine($"[INFO] Allocator: {allocator.TrackedBytes} tracked bytes");
            WriteLine($"[INFO] MemoryUtils: {MemUtil.AllocCount} allocated pointers");
        }*/

        Buffer CreateBuffer(DeviceSize size, BufferUsageFlags flags)
        {
            var bufferCreateInfo = new BufferCreateInfo(size, flags, SharingMode.Exclusive, null);
            return device.CreateBuffer(bufferCreateInfo);
        }

        DeviceMemory BindBuffer(Buffer buffer, MemoryAllocateInfo allocInfo)
        {
            var bufferMem = device.AllocateMemory(allocInfo);
            device.BindBufferMemory(buffer, bufferMem, 0);
            return bufferMem;
        }

        void PipelineBarrierSetLayout(CommandBuffer cmdBuffer, Image image, ImageLayout oldLayout, ImageLayout newLayout, AccessFlags srcMask, AccessFlags dstMask)
        {
            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            var imageMemoryBarrier = new ImageMemoryBarrier(oldLayout, newLayout, 0, 0, image, subresourceRange);
            imageMemoryBarrier.SrcAccessMask = srcMask;
            imageMemoryBarrier.DstAccessMask = dstMask;
            var imageMemoryBarriers = new ImageMemoryBarrier[] { imageMemoryBarrier };
            cmdBuffer.CmdPipelineBarrier(PipelineStageFlags.TopOfPipe, PipelineStageFlags.TopOfPipe, DependencyFlags.None, null, null, imageMemoryBarriers);
            imageMemoryBarrier.Dispose();
        }

        private void GetProcessHandles(out IntPtr HINSTANCE, out IntPtr HWND)
        {
            var process = Process.GetCurrentProcess();
            HINSTANCE = process.Handle;
            HWND = process.MainWindowHandle;
        }

        private void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        private Bool32 DebugReport(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData)
        {
            //WriteLine($"[VULK] [{flags}] {message} ([{messageCode}] {layerPrefix})");
            //if(messageCode != 0)
            Console.WriteLine(message);
            return true;
        }
    }
}
