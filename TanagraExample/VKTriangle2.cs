using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

using SharpDX.Windows;

using Tanagra;
using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // A managed interface to Vulkan
using Vulkan.Managed.ObjectModel; // Extentions to object handles

using ImageLayout = Vulkan.ImageLayout;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    class VKTriangle2
    {
        private Form form;

        Vulkan.Allocation.Allocator allocator;

        // Handles
        private Instance instance;
        private PhysicalDevice physicalDevice;
        private SurfaceKHR surface;
        private Device device;
        private Queue queue;
        private CommandPool commandPool;
        private List<CommandBuffer> commandBuffer;
        private CommandBuffer setupCommanBuffer;

        private SwapchainKHR swapchain;

        private Format backBufferFormat;
        private List<Image> backBuffers;
        private List<ImageView> backBufferViews;
        private uint currentBackBufferIndex;

        private RenderPass renderPass;
        private PipelineLayout pipelineLayout;
        private Pipeline pipeline;
        private Framebuffer[] framebuffers;

        private Buffer vertexBuffer;
        private DeviceMemory vertexBufferMemory;
        private VertexInputAttributeDescription[] vertexAttributes;
        private VertexInputBindingDescription[] vertexBindings;

        private DebugReportCallbackEXT debugCallback;

        public void Main(string[] args)
        {
            var ptrSize = IntPtr.Size;
            WriteLine($"[INFO] Running in {((ptrSize == 4) ? "x86" : "x64")} mode, IntPtr.Size = {ptrSize}");

            form = new RenderForm("Tanagra - Vulkan Sample");

            CreateInstance();
            
            CreateSurface();
            CreateDevice();
            CreateCommandBuffer();

            CreateSwapchain();
            CreateBackBufferViews();

            CreateVertexBuffer();
            CreateRenderPass();
            CreatePipelineLayout();
            CreatePipeline();
            CreateFramebuffers();

            WriteLine($"[INFO] Allocator: {allocator.CallCount} allocated pointers");
            WriteLine($"[INFO] Allocator: {allocator.TrackedBytes} tracked bytes");
            WriteLine($"[INFO] MemoryUtils: {MemUtil.AllocCount} allocated pointers");

            WriteLine("Any key to continue");
            WriteLine("[INFO] Starup OK, Launching...");
            //Console.ReadKey();
            RenderLoop.Run(form, Draw);

            WriteLine("[INFO] Render window lost!");

            Destroy();
        }

        private void CreateInstance()
        {
            var ver = new Vulkan.Version(1, 0, 8);
            WriteLine($"version {ver.ToString(true)}");

            allocator = new Vulkan.Allocation.Allocator();
            //allocator.DebugLog = true;

            var enabledExtensions = new[]
            {
                VulkanConstant.KhrSurfaceExtensionName,
                VulkanConstant.KhrWin32SurfaceExtensionName,
                VulkanConstant.ExtDebugReportExtensionName,
            };

            var instanceCreateInfo = new InstanceCreateInfo(null, enabledExtensions);
            instance = Vk.CreateInstance(instanceCreateInfo, allocator.AllocationCallbacks);
            instanceCreateInfo.Dispose();
            WriteLine($"[ OK ] {instance}");

            var physicalDevices = instance.EnumeratePhysicalDevices();
            WriteLine($"[INFO] Physical Devices: {physicalDevices.Count}");

            physicalDevice = physicalDevices[0];
            WriteLine($"[ OK ] {physicalDevice}");

            debugCallback = DebugUtils.CreateDebugReportCallback(instance, DebugReport);
            WriteLine($"[ OK ] {debugCallback}");            
        }

        private Bool32 DebugReport(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData)
        {
            WriteLine($"[VULK] [{flags}] {message} ([{messageCode}] {layerPrefix})");
            return true;
        }

        private void CreateSurface()
        {
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR(Process.GetCurrentProcess().Handle, form.Handle);
            surface = instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
        }

        private void CreateDevice()
        {
            var deviceEnabledExtensions = new[]
            {
                VulkanConstant.KhrSwapchainExtensionName,
            };

            var queueCreateInfo = new DeviceQueueCreateInfo(0, new[] { 0f });
            var deviceCreateInfo = new DeviceCreateInfo(new[] { queueCreateInfo }, null, deviceEnabledExtensions);
            device = physicalDevice.CreateDevice(deviceCreateInfo);

            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0 && physicalDevice.GetSurfaceSupportKHR((uint)index, surface))
                .Select((properties, index) => index)
                .First();

            queue = device.GetQueue(0, (uint)queueNodeIndex);
        }

        private void CreateCommandBuffer()
        {
            var commandPoolCreateInfo = new CommandPoolCreateInfo
            {
                QueueFamilyIndex = 0,
                Flags = CommandPoolCreateFlags.ResetCommandBuffer,
            };
            commandPool = device.CreateCommandPool(commandPoolCreateInfo);
            var commandBufferAllocationInfo = new CommandBufferAllocateInfo(commandPool, CommandBufferLevel.Primary, 1);
            commandBuffer = device.AllocateCommandBuffers(commandBufferAllocationInfo);
        }

        private void CreateSwapchain()
        {
            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            if (surfaceFormats.Count == 1 && surfaceFormats[0].Format == Format.Undefined)
            {
                backBufferFormat = Format.B8g8r8a8Unorm;
                WriteLine($"[INFO] using default backBufferFormat {backBufferFormat}");
            }
            else
            {
                backBufferFormat = surfaceFormats[0].Format;
                WriteLine($"[INFO] backBufferFormat {backBufferFormat}");
            }

            var surfaceCapabilities = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            var desiredImageCount = surfaceCapabilities.MinImageCount + 1;
            if (surfaceCapabilities.MaxImageCount > 0 && desiredImageCount > surfaceCapabilities.MaxImageCount)
            {
                desiredImageCount = surfaceCapabilities.MaxImageCount;
            }

            SurfaceTransformFlagsKHR preTransform;
            if ((surfaceCapabilities.SupportedTransforms & SurfaceTransformFlagsKHR.Identity) != 0)
            {
                preTransform = SurfaceTransformFlagsKHR.Identity;
            }
            else
            {
                preTransform = surfaceCapabilities.CurrentTransform;
            }

            var presentModes = physicalDevice.GetSurfacePresentModesKHR(surface);

            var swapChainPresentMode = PresentModeKHR.Fifo;
            if (presentModes.Contains(PresentModeKHR.Mailbox))
                swapChainPresentMode = PresentModeKHR.Mailbox;
            else if (presentModes.Contains(PresentModeKHR.Immediate))
                swapChainPresentMode = PresentModeKHR.Immediate;

            WriteLine($"swapChainPresentMode {swapChainPresentMode}");

            var imageExtent = new Extent2D((uint)form.ClientSize.Width, (uint)form.ClientSize.Height);
            
            var swapchainCreateInfo = new SwapchainCreateInfoKHR
            {
                Surface = surface,
                MinImageCount = desiredImageCount,
                ImageFormat = backBufferFormat,
                ImageExtent = imageExtent,
                ImageArrayLayers = 1,
                ImageUsage = ImageUsageFlags.ColorAttachment,
                QueueFamilyIndices = null,
                PreTransform = preTransform,
                CompositeAlpha = CompositeAlphaFlagsKHR.Opaque,
                PresentMode = swapChainPresentMode,
                Clipped = true,
            };
            swapchain = device.CreateSwapchainKHR(swapchainCreateInfo);
            swapchainCreateInfo.Dispose();
            WriteLine($"[ OK ] {swapchain}");

            backBuffers = device.GetSwapchainImagesKHR(swapchain);
            /*WriteLine($"[INFO] backBuffers {backBuffers.Count}");
            foreach (var image in backBuffers)
            {
                SetImageLayout(image, ImageAspectFlags.Color, ImageLayout.Undefined, ImageLayout.PresentSrcKHR);
            }
            Flush();*/
        }

        private void SetImageLayout(Image image, ImageAspectFlags imageAspect, ImageLayout oldLayout, ImageLayout newLayout)
        {
            if (setupCommanBuffer == null)
            {
                var allocateInfo = new CommandBufferAllocateInfo(commandPool, CommandBufferLevel.Primary, 1);
                var setupBuffer = device.AllocateCommandBuffers(allocateInfo)[0];
                setupCommanBuffer = setupBuffer;

                var inheritanceInfo = new CommandBufferInheritanceInfo();
                var beginInfo = new CommandBufferBeginInfo { InheritanceInfo = inheritanceInfo };
                setupCommanBuffer.Begin(beginInfo);
            }

            var imageMemoryBarrier = new ImageMemoryBarrier(oldLayout, newLayout, 0, 0, image, new ImageSubresourceRange(imageAspect, 0, 1, 0, 1));

            switch (newLayout)
            {
                case ImageLayout.TransferDstOptimal:
                imageMemoryBarrier.DstAccessMask = AccessFlags.TransferRead;
                break;
                case ImageLayout.ColorAttachmentOptimal:
                imageMemoryBarrier.DstAccessMask = AccessFlags.ColorAttachmentWrite;
                break;
                case ImageLayout.DepthStencilAttachmentOptimal:
                imageMemoryBarrier.DstAccessMask = AccessFlags.DepthStencilAttachmentWrite;
                break;
                case ImageLayout.ShaderReadOnlyOptimal:
                imageMemoryBarrier.DstAccessMask = AccessFlags.ShaderRead | AccessFlags.InputAttachmentRead;
                break;
            }

            var sourceStages = PipelineStageFlags.TopOfPipe;
            var destinationStages = PipelineStageFlags.TopOfPipe;

            setupCommanBuffer.CmdPipelineBarrier(sourceStages, destinationStages, DependencyFlags.None, null, null, new List<ImageMemoryBarrier> { imageMemoryBarrier });
        }

        private void Flush()
        {
            if (setupCommanBuffer == null)
                return;

            setupCommanBuffer.End();
            WriteLine("[ OK ] setupCommanBuffer.End");

            var submitInfo = new SubmitInfo(null, null, new[] { setupCommanBuffer }, null);

            WriteLine($"[ OK ] {setupCommanBuffer} / {submitInfo.CommandBuffers[0]}");

            queue.Submit(new List<SubmitInfo> { submitInfo }, null);
            WriteLine("[ OK ] queue.Submit");

            queue.WaitIdle();
            WriteLine("[ OK ] queue.WaitIdle");

            device.FreeCommandBuffers(commandPool, new List<CommandBuffer> { setupCommanBuffer });
            WriteLine("[ OK ] device.DisposeCommandBuffers");

            setupCommanBuffer = null;

            submitInfo.Dispose();
        }

        private void CreateBackBufferViews()
        {
            backBufferViews = new List<ImageView>();
            foreach (var img in backBuffers)
            {
                var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
                var createInfo = new ImageViewCreateInfo(img, ImageViewType.ImageViewType2d, backBufferFormat, new ComponentMapping(), subresourceRange);
                backBufferViews.Add(device.CreateImageView(createInfo));
            }
        }

        private void CreateVertexBuffer()
        {
            var vertices = new[,]
            {
                {  0.0f, -0.5f,  0.5f, 1.0f, 0.0f, 0.0f },
                {  0.5f,  0.5f,  0.5f, 0.0f, 1.0f, 0.0f },
                { -0.5f,  0.5f,  0.5f, 0.0f, 0.0f, 1.0f },
            };

            var bufferSize = (ulong)(sizeof(float) * vertices.Length);
            var createInfo = new BufferCreateInfo
            {
                Usage = BufferUsageFlags.VertexBuffer,
                Size = bufferSize,
            };
            vertexBuffer = device.CreateBuffer(createInfo);

            var memoryRequirements = device.GetBufferMemoryRequirements(vertexBuffer);

            if (memoryRequirements.Size == 0) return;

            var allocateInfo = new MemoryAllocateInfo(memoryRequirements.Size, 2);
            vertexBufferMemory = device.AllocateMemory(allocateInfo);

            var mapped = device.MapMemory(vertexBufferMemory, 0, bufferSize);
            MemUtil.Copy2DArray(vertices, mapped, bufferSize, bufferSize);
            device.UnmapMemory(vertexBufferMemory);

            device.BindBufferMemory(vertexBuffer, vertexBufferMemory, 0);

            vertexAttributes = new[]
            {
                new VertexInputAttributeDescription(0, 0, Format.R32g32b32Sfloat, 0),
                new VertexInputAttributeDescription(1, 0, Format.R32g32b32Sfloat, sizeof(float) * 3)
            };

            vertexBindings = new[]
            {
                new VertexInputBindingDescription(0, (uint)(sizeof(float) * vertices.GetLength(1)), VertexInputRate.Vertex)
            };
        }

        private void CreateRenderPass()
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
            renderPass = device.CreateRenderPass(createInfo);
        }

        private void CreatePipelineLayout()
        {
            var createInfo = new PipelineLayoutCreateInfo();
            pipelineLayout = device.CreatePipelineLayout(createInfo);
        }

        private void CreatePipeline()
        {
            var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo(PrimitiveTopology.TriangleList, false);
            var vertexInputState = new PipelineVertexInputStateCreateInfo(vertexBindings, vertexAttributes);
            
            var rasterizationState = new PipelineRasterizationStateCreateInfo();
            //rasterizationState.RasterizerDiscardEnable = true;
            //rasterizationState.LineWidth = 1;

            var shaderStages = new[]
            {
                new PipelineShaderStageCreateInfo(ShaderStageFlags.Vertex, CreateVertexShader(), "main\0"),
                new PipelineShaderStageCreateInfo(ShaderStageFlags.Fragment, CreateFragmentShader(), "main\0"),
            };

            var createInfos = new[]
            {
                new GraphicsPipelineCreateInfo(shaderStages, vertexInputState, inputAssemblyState, rasterizationState, pipelineLayout, renderPass, 0, 0)
            };

            var pipelines = device.CreateGraphicsPipelines(null, createInfos.ToList());
            pipeline = pipelines[0];
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
            createInfo.Dispose();
            return module;
        }

        private void CreateFramebuffers()
        {
            framebuffers = new Framebuffer[backBuffers.Count];
            for (int i = 0; i < backBuffers.Count; i++)
            {
                var attachment = backBufferViews[i];
                var createInfo = new FramebufferCreateInfo(renderPass, new[] { attachment }, (uint)form.ClientSize.Width, (uint)form.ClientSize.Height, 1);
                framebuffers[i] = device.CreateFramebuffer(createInfo);
            }
        }

        private void Draw()
        {
            var semaphoreCreateInfo = new SemaphoreCreateInfo();
            var presentCompleteSemaphore = device.CreateSemaphore(semaphoreCreateInfo);
            semaphoreCreateInfo.Dispose();

            try
            {
                // Get the index of the next available swapchain image
                currentBackBufferIndex = device.AcquireNextImageKHR(swapchain, ulong.MaxValue, presentCompleteSemaphore, null);
            }
            catch (VulkanCommandException e) when (e.Result == Result.ErrorOutOfDateKHR)
            {
                // TODO: Handle resize and retry draw
                throw new NotImplementedException();
            }

            // Record drawing command buffer
            var beginInfo = new CommandBufferBeginInfo();
            commandBuffer[0].Begin(beginInfo);
            beginInfo.Dispose();
            DrawInternal();
            commandBuffer[0].End();

            // Submit
            var drawCommandBuffer = commandBuffer[0];
            var pipelineStageFlags = PipelineStageFlags.BottomOfPipe;
            var submitInfo = new SubmitInfo(new[] { presentCompleteSemaphore }, new[] { pipelineStageFlags }, new[] { drawCommandBuffer }, null);
            queue.Submit(new List<SubmitInfo> { submitInfo }, null);
            submitInfo.Dispose();

            // Present
            var currentBackBufferIndexCopy = currentBackBufferIndex;
            var presentInfo = new PresentInfoKHR(new[] { swapchain }, new[] { currentBackBufferIndexCopy });
            queue.PresentKHR(presentInfo);
            presentInfo.Dispose();

            // Wait
            queue.WaitIdle();

            // Cleanup
            device.DestroySemaphore(presentCompleteSemaphore);
        }

        private void DrawInternal()
        {
            var cmdBuffer = commandBuffer[0];
            // Post-present transition
            var memoryBarrier = new ImageMemoryBarrier
            {
                OldLayout = ImageLayout.PresentSrcKHR,
                NewLayout = ImageLayout.ColorAttachmentOptimal,
                SrcAccessMask = AccessFlags.MemoryRead,
                DstAccessMask = AccessFlags.ColorAttachmentWrite,
                Image = backBuffers[(int)currentBackBufferIndex],
                SubresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1),
            };
            cmdBuffer.CmdPipelineBarrier(PipelineStageFlags.TopOfPipe, PipelineStageFlags.TopOfPipe, DependencyFlags.None, null, null, new List<ImageMemoryBarrier> { memoryBarrier });
            memoryBarrier.Dispose();

            var clearRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            cmdBuffer.CmdClearColorImage(backBuffers[(int)currentBackBufferIndex], ImageLayout.TransferDstOptimal, new ClearColorValue(), new List<ImageSubresourceRange> { clearRange }); // todo...

            // Begin render pass
            var renderArea = new Rect2D(new Offset2D(0, 0), new Extent2D((uint)form.ClientSize.Width, (uint)form.ClientSize.Height));
            var renderPassBeginInfo = new RenderPassBeginInfo(renderPass, framebuffers[currentBackBufferIndex], renderArea, null);
            cmdBuffer.CmdBeginRenderPass(renderPassBeginInfo, SubpassContents.Inline);
            renderPassBeginInfo.Dispose();

            // Bind pipeline
            cmdBuffer.CmdBindPipeline(PipelineBindPoint.Graphics, pipeline);

            // Set viewport 
            var viewport = new Viewport(0, 0, form.ClientSize.Width, form.ClientSize.Height, 0, 0);
            cmdBuffer.CmdSetViewport(0, new List<Viewport> { viewport });

            // Set scissor
            var scissor = new Rect2D(new Offset2D(0, 0), new Extent2D((uint)form.ClientSize.Width, (uint)form.ClientSize.Height));
            cmdBuffer.CmdSetScissor(0, new List<Rect2D> { scissor });

            // Bind vertex buffer
            var vertexBufferCopy = vertexBuffer; // todo!
            ulong offset = 0;
            cmdBuffer.CmdBindVertexBuffers(0, new List<Buffer> { vertexBufferCopy }, new List<DeviceSize> { offset });

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
                Image = backBuffers[(int)currentBackBufferIndex],
                SubresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1),
            };
            cmdBuffer.CmdPipelineBarrier(PipelineStageFlags.AllCommands, PipelineStageFlags.BottomOfPipe, DependencyFlags.None, null, null, new List<ImageMemoryBarrier> { memoryBarrier });
            memoryBarrier.Dispose();
        }

        private void Destroy()
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
    }
}
