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
    class VKTriangle
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

            //PhysicalDeviceProperties();
            //QueueFamilyProperties();
            //WriteLine("");
            //GetPhysicalDeviceFeatures();

            //var vkInfo = new VulkanInfo();
            //vkInfo.Write(physicalDevice);

            //var physicalDevices = instance.EnumeratePhysicalDevices();
            //WriteLine($"[INFO] Physical Devices: {physicalDevices.Count}");

            //physicalDevice = physicalDevices[0];
            //WriteLine($"[ OK ] {physicalDevice}");

            //PhysicalDeviceProperties();

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
            Console.ReadKey();
            RenderLoop.Run(form, Draw);

            WriteLine("[INFO] Render window lost!");

            Destroy();
        }

        private void CreateInstance()
        {
            var ver = new Vulkan.Version(1, 0, 8);
            WriteLine($"version {ver.ToString(true)}");

            /*var appInfo = new ApplicationInfo
            {
                //ApplicationName = "vulkanExample",
                //EngineName      = "vulkanExample",
                //ApiVersion      = ver
            };*/

            var instanceEnabledExtensions = new[]
            {
                VulkanConstant.KhrSurfaceExtensionName,
                VulkanConstant.KhrWin32SurfaceExtensionName,
                VulkanConstant.ExtDebugReportExtensionName,
            };

            var instanceCreateInfo = new InstanceCreateInfo
            {
                //ApplicationInfo = appInfo,
                EnabledExtensionNames = instanceEnabledExtensions,
            };

            //WriteLine(instanceCreateInfo.ApplicationInfo.ApplicationName);

            allocator = new Vulkan.Allocation.Allocator();
            //allocator.DebugLog = true;

            instance = Vk.CreateInstance(instanceCreateInfo, allocator.AllocationCallbacks);
            WriteLine($"[ OK ] {instance}");

            var physicalDevices = instance.EnumeratePhysicalDevices();
            WriteLine($"[INFO] Physical Devices: {physicalDevices.Count}");

            physicalDevice = physicalDevices[0];
            WriteLine($"[ OK ] {physicalDevice}");

            debugCallback = DebugUtils.CreateDebugReportCallback(instance, DebugReport);
            WriteLine($"[ OK ] {debugCallback}");

            //appInfo.Dispose();
            instanceCreateInfo.Dispose();
            //PhysicalDeviceProperties();
        }

        private Bool32 DebugReport(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData)
        {
            WriteLine($"[VULK] [{flags}] {message} ([{messageCode}] {layerPrefix})");
            return true;
        }

        private void CreateSurface()
        {
            //IntPtr HINSTANCE, HWND;
            //GetProcessHandles(out HINSTANCE, out HWND);
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR(Process.GetCurrentProcess().Handle, form.Handle);
            surface = instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
            WriteLine($"[ OK ] {surface}");
            surfaceCreateInfo.Dispose();
        }

        private void CreateDevice()
        {
            var queueCreateInfo = new DeviceQueueCreateInfo(0, new[] { 0f });

            var deviceEnabledExtensions = new[]
            {
                VulkanConstant.KhrSwapchainExtensionName,
            };

            var enabledFeatures = new PhysicalDeviceFeatures();
            
            var deviceCreateInfo = new DeviceCreateInfo
            {
                QueueCreateInfos = new[] { queueCreateInfo },
                EnabledExtensionNames = deviceEnabledExtensions,
                EnabledFeatures = enabledFeatures,
            };
            device = physicalDevice.CreateDevice(deviceCreateInfo);
            queueCreateInfo.Dispose();
            deviceCreateInfo.Dispose();
            WriteLine($"[ OK ] {device}");

            WriteLine($"[INFO] Begin GetQueueFamilyProperties");
            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0 && physicalDevice.GetSurfaceSupportKHR((uint)index, surface))
                .Select((properties, index) => index)
                .First();

            queue = device.GetQueue(0, (uint)queueNodeIndex);
            WriteLine($"[ OK ] {queue}");
        }
        
        private void CreateCommandBuffer()
        {
            // Command pool
            var commandPoolCreateInfo = new CommandPoolCreateInfo
            {
                QueueFamilyIndex = 0,
                Flags = CommandPoolCreateFlags.ResetCommandBuffer,
            };
            commandPool = device.CreateCommandPool(commandPoolCreateInfo);
            commandPoolCreateInfo.Dispose();
            WriteLine($"[ OK ] {commandPool}");

            // Command Buffer
            var commandBufferAllocationInfo = new CommandBufferAllocateInfo(commandPool, CommandBufferLevel.Primary, 1);
            commandBuffer = device.AllocateCommandBuffers(commandBufferAllocationInfo);
            commandBufferAllocationInfo.Dispose();
            WriteLine("[INFO] commandBuffers: " + commandBuffer.Count);
            WriteLine($"[ OK ] {commandBuffer[0]}");
        }

        private void CreateSwapchain()
        {
            // surface format
            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            if (surfaceFormats.Count == 1 && surfaceFormats[0].Format == Format.Undefined)
            {
                backBufferFormat = Format.B8g8r8a8Unorm;
                WriteLine($"using default backBufferFormat {backBufferFormat}");
            }
            else
            {
                backBufferFormat = surfaceFormats[0].Format;
                WriteLine($"backBufferFormat {backBufferFormat}");
            }

            var surfaceCapabilities = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            // Buffer count
            var desiredImageCount = surfaceCapabilities.MinImageCount + 1;
            if (surfaceCapabilities.MaxImageCount > 0 && desiredImageCount > surfaceCapabilities.MaxImageCount)
            {
                desiredImageCount = surfaceCapabilities.MaxImageCount;
            }

            // Transform
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

            WriteLine($"swapChainPresentMode {swapChainPresentMode}");

            var imageExtent = new Extent2D((uint)form.ClientSize.Width, (uint)form.ClientSize.Height);
            // Create swapchain
            var swapchainCreateInfo = new SwapchainCreateInfoKHR
            {
                Surface            = surface,
                MinImageCount      = desiredImageCount,
                ImageFormat        = backBufferFormat,
                //ImageColorSpace    = ColorSpaceKHR.SrgbNonlinear,
                ImageExtent        = imageExtent,
                ImageArrayLayers   = 1,
                ImageUsage         = ImageUsageFlags.ColorAttachment,
                //ImageSharingMode   = SharingMode.Exclusive,
                QueueFamilyIndices = null,
                PreTransform       = preTransform,
                CompositeAlpha     = CompositeAlphaFlagsKHR.Opaque,
                PresentMode        = swapChainPresentMode,
                Clipped            = true,
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
                WriteLine($"[ OK ] {setupCommanBuffer}");

                var inheritanceInfo = new CommandBufferInheritanceInfo();
                var beginInfo = new CommandBufferBeginInfo { InheritanceInfo = inheritanceInfo };
                setupCommanBuffer.Begin(beginInfo);
                WriteLine("[ OK ] setupCommanBuffer.Begin");

                allocateInfo.Dispose();
                inheritanceInfo.Dispose();
                beginInfo.Dispose();
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
            WriteLine("[ OK ] setupCommanBuffer.CmdPipelineBarrier");

            imageMemoryBarrier.Dispose();
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
                createInfo.Dispose();
            }
            WriteLine($"[INFO] backBufferViews {backBufferViews.Count}");
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
                Size  = bufferSize,
            };
            vertexBuffer = device.CreateBuffer(createInfo);
            createInfo.Dispose();
            WriteLine($"[ OK ] {vertexBuffer}");

            var memoryRequirements = device.GetBufferMemoryRequirements(vertexBuffer);

            if (memoryRequirements.Size == 0) return;
            WriteLine($"[ OK ] memoryRequirements {memoryRequirements.Size}");

            var allocateInfo = new MemoryAllocateInfo(memoryRequirements.Size, 2); // MemoryTypeIndex = 2, TODO
            vertexBufferMemory = device.AllocateMemory(allocateInfo);
            allocateInfo.Dispose();
            WriteLine($"[ OK ] {vertexBufferMemory}");

            var mapped = device.MapMemory(vertexBufferMemory, 0, bufferSize, MemoryMapFlags.None);
            MemUtil.Copy2DArray(vertices, mapped, bufferSize, bufferSize);
            device.UnmapMemory(vertexBufferMemory);

            device.BindBufferMemory(vertexBuffer, vertexBufferMemory, 0);
            WriteLine($"[ OK ] device.BindBufferMemory");

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
            var colorAttachmentReference = new AttachmentReference(0, ImageLayout.ColorAttachmentOptimal);
            var depthStencilAttachmentReference = new AttachmentReference(1, ImageLayout.DepthStencilAttachmentOptimal);
            
            var subpass = new SubpassDescription(PipelineBindPoint.Graphics, null, new[] { colorAttachmentReference }, null);

            var attachments = new[]
            {
                new AttachmentDescription
                {
                    Format         = backBufferFormat,
                    Samples        = SampleCountFlags.SampleCountFlags1,
                    //LoadOp         = AttachmentLoadOp.Load,
                    //StoreOp        = AttachmentStoreOp.Store,
                    StencilLoadOp  = AttachmentLoadOp.DontCare,
                    StencilStoreOp = AttachmentStoreOp.DontCare,
                    InitialLayout  = ImageLayout.ColorAttachmentOptimal,
                    FinalLayout    = ImageLayout.ColorAttachmentOptimal
                },
            };
            
            var createInfo = new RenderPassCreateInfo(attachments, new[] { subpass }, null);
            
            renderPass = device.CreateRenderPass(createInfo);
            WriteLine($"[ OK ] {renderPass}");

            subpass.Dispose();
            createInfo.Dispose();
        }

        private void CreatePipelineLayout()
        {
            // We don't need any descriptors, since we don't use any resources/uniforms
            var descriptorSetLayoutCreateInfo = new DescriptorSetLayoutCreateInfo();
            var descriptorSetLayout = device.CreateDescriptorSetLayout(descriptorSetLayoutCreateInfo);
            descriptorSetLayoutCreateInfo.Dispose();
            WriteLine($"[ OK ] {descriptorSetLayout}");

            var createInfo = new PipelineLayoutCreateInfo();
            pipelineLayout = device.CreatePipelineLayout(createInfo);
            createInfo.Dispose();
            WriteLine($"[ OK ] {pipelineLayout}");

            // Destroy temporary layout
            device.DestroyDescriptorSetLayout(descriptorSetLayout);
        }

        private void CreatePipeline()
        {
            var dynamicStates = new[] { DynamicState.Viewport, DynamicState.Scissor };
            var dynamicState = new PipelineDynamicStateCreateInfo(dynamicStates);
            var viewportState = new PipelineViewportStateCreateInfo(); // ??
            var vertexInputState = new PipelineVertexInputStateCreateInfo(vertexBindings, vertexAttributes);
            var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo(PrimitiveTopology.TriangleList, false);

            var rasterizerState = new PipelineRasterizationStateCreateInfo();

            var colorBlendAttachment = new PipelineColorBlendAttachmentState { ColorWriteMask = ColorComponentFlags.R | ColorComponentFlags.G | ColorComponentFlags.B | ColorComponentFlags.A };
            var blendState = new PipelineColorBlendStateCreateInfo
            {
                Attachments = new[] { colorBlendAttachment }
            };

            var depthStencilState = new PipelineDepthStencilStateCreateInfo
            {
                DepthTestEnable  = false,
                DepthWriteEnable = true,
                DepthCompareOp   = CompareOp.LessOrEqual,
                Back             = new StencilOpState { CompareOp = CompareOp.Always },
                Front            = new StencilOpState { CompareOp = CompareOp.Always }
            };

            var shaderStages = new[]
            {
                new PipelineShaderStageCreateInfo(ShaderStageFlags.Vertex, CreateVertexShader(), "main\0"),
                new PipelineShaderStageCreateInfo(ShaderStageFlags.Fragment, CreateFragmentShader(), "main\0"),
            };

            var createInfo = new GraphicsPipelineCreateInfo
            {
                Stages = shaderStages,
                VertexInputState = vertexInputState,
                InputAssemblyState = inputAssemblyState,
                RasterizationState = rasterizerState,
                Layout = pipelineLayout,
                RenderPass = renderPass,
                //Subpass = 0,
                //BasePipelineIndex = 0,

                DynamicState = dynamicState,
                ViewportState = viewportState,
                ColorBlendState = blendState,
                DepthStencilState = depthStencilState,
            };
            var pipelines = device.CreateGraphicsPipelines(null, new List<GraphicsPipelineCreateInfo> { createInfo });
            pipeline = pipelines[0];
            WriteLine($"[ OK ] {pipeline}");

            foreach (var shaderStage in shaderStages)
            {
                device.DestroyShaderModule(shaderStage.Module);
                WriteLine("[INFO] device.DestroyShaderModule");
            }

            createInfo.Dispose();
            shaderStages[0].Dispose();
            shaderStages[1].Dispose();
            depthStencilState.Dispose();
            blendState.Dispose();
            rasterizerState.Dispose();
            inputAssemblyState.Dispose();
            vertexInputState.Dispose();
            viewportState.Dispose();
            dynamicState.Dispose();
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
                createInfo.Dispose();
                WriteLine($"[ OK ] {framebuffers[i]} {i}/{backBuffers.Count}");
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
            catch (VulkanResultException e) when (e.Result == Result.ErrorOutOfDateKHR)
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
                OldLayout        = ImageLayout.PresentSrcKHR,
                NewLayout        = ImageLayout.ColorAttachmentOptimal,
                SrcAccessMask    = AccessFlags.MemoryRead,
                DstAccessMask    = AccessFlags.ColorAttachmentWrite,
                Image            = backBuffers[(int)currentBackBufferIndex],
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
                OldLayout        = ImageLayout.ColorAttachmentOptimal,
                NewLayout        = ImageLayout.PresentSrcKHR,
                SrcAccessMask    = AccessFlags.ColorAttachmentWrite,
                DstAccessMask    = AccessFlags.MemoryRead,
                Image            = backBuffers[(int)currentBackBufferIndex],
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
            foreach(var framebuffer in framebuffers)
                device.DestroyFramebuffer(framebuffer);

            device.DestroyRenderPass(renderPass);
            device.DestroyPipeline(pipeline);
            device.DestroyPipelineLayout(pipelineLayout);
            device.FreeCommandBuffers(commandPool, commandBuffer);
            device.DestroyCommandPool(commandPool);
            foreach(var backBufferView in backBufferViews)
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
