using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using SharpDX.Windows;

using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // A managed interface to Vulkan
using Vulkan.Managed.ObjectModel; // Extentions to object handles

namespace TanagraExample
{
    public class ExampleRenderToWindow : RenderToWindowBase
    {
        class SwapchainData
        {
            public SwapchainKHR Swapchain;
            public List<ImageData> Images;
            public List<Framebuffer> Framebuffers;
            public Format ImageFormat;
        }
        
        public ExampleRenderToWindow()
        {
            // The goal of this example is to:
            //
            // - Initialize Vulkan
            // - Create a surface object to interact with a display
            // - Render a triangle to the screen
            //
            
            var window = new RenderForm(GetType().Name);

            uint imageWidth  = 800;
            uint imageHeight = 600;

            Instance instance;
            PhysicalDevice[] physDevices;
            PhysicalDevice physDevice;
            QueueFamilyProperties[] queueFamilies;
            //Device device;
            Queue queue;
            CommandPool cmdPool;

            SurfaceKHR surface;
            SwapchainData swapchainData;
            Image[] swapchainImages;

            instance      = CreateInstance();                      // Create a new Vulkan Instance
            physDevices   = EnumeratePhysicalDevices(instance);    // Discover the physical devices attached to the system
            physDevice    = physDevices.First();                   // Select the first physical device
            queueFamilies = physDevice.GetQueueFamilyProperties(); // Get properties about the queues on the physical device
            physDeviceMem = physDevice.GetMemoryProperties();      // Get properties about the memory on the physical device

            // Initialize the surface object
            surface       = CreateWin32Surface(instance, window.Handle);
            physDevice.GetSurfaceSupportKHR(0, surface);

            device        = CreateDevice(physDevice, 0);           // Create a device from the physical device
            queue         = GetQueue(physDevice, 0);               // Get an execution queue from the physical device
            cmdPool       = CreateCommandPool(0);                  // Create a command pool from which command buffers are created
            
            VertexData vertexData;
            RenderPass renderPass;
            PipelineLayout pipelineLayout;
            Pipeline[] pipelines;
            Pipeline pipeline;
            
            vertexData = CreateVertexData();
            
            var shaderInfos = new List<PipelineShaderStageCreateInfo>();
            shaderInfos.Add(GetShaderStageCreateInfo(ShaderStageFlags.Vertex, "./triangle.vert.spv"));
            shaderInfos.Add(GetShaderStageCreateInfo(ShaderStageFlags.Fragment, "./triangle.frag.spv"));

            // Create the swapchain
            swapchainData        = CreateSwapchain(physDevice, surface, imageWidth, imageHeight);
            swapchainImages      = device.GetSwapchainImagesKHR(swapchainData.Swapchain);
            swapchainData.Images = InitializeSwapchainImages(queue, cmdPool, swapchainImages, swapchainData.ImageFormat);
            
            renderPass     = CreateRenderPass(swapchainData.ImageFormat);
            pipelineLayout = CreatePipelineLayout();
            pipelines      = CreatePipelines(pipelineLayout, renderPass, shaderInfos.ToArray(), vertexData);
            pipeline       = pipelines.First();

            // Create a framebuffer for each swapchain image
            swapchainData.Framebuffers = swapchainData.Images
                .Select(x => CreateFramebuffer(renderPass, x))
                .ToList();
            
            var cmdBuffers = AllocateCommandBuffers(cmdPool, (uint)swapchainData.Images.Count());
            for (int x = 0; x < swapchainData.Images.Count(); x++)
                CreateCommandBuffer(cmdBuffers[x], vertexData, renderPass, pipeline, swapchainData.Images[x], swapchainData.Framebuffers[x]);

            RenderLoop.Run(window, () => OnRenderCallback(queue, cmdBuffers, swapchainData));

            #region Shutdown
            // Destroy Vulkan handles

            device.FreeCommandBuffers(cmdPool, cmdBuffers);

            device.DestroyShaderModule(shaderInfos[0].Module);
            device.DestroyShaderModule(shaderInfos[1].Module);

            swapchainData.Images.ForEach(x => device.DestroyImageView(x.View));
            swapchainData.Framebuffers.ForEach(x => device.DestroyFramebuffer(x));
            device.DestroySwapchainKHR(swapchainData.Swapchain);
            
            device.DestroyPipeline(pipeline);
            device.DestroyPipelineLayout(pipelineLayout);
            device.DestroyRenderPass(renderPass);

            device.DestroyBuffer(vertexData.Buffer);
            device.FreeMemory(vertexData.DeviceMemory);

            device.DestroyCommandPool(cmdPool);

            device.Destroy();

            instance.DestroySurfaceKHR(surface);

            DebugUtils.DestroyDebugReportCallback(instance, debugCallback);

            instance.Destroy();
            #endregion
        }
        
        #region Surface / Swapchain
        
        SurfaceKHR CreateWin32Surface(Instance instance, IntPtr formHandle)
        {
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR(Process.GetCurrentProcess().Handle, formHandle);
            return instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
        }

        SwapchainData CreateSwapchain(PhysicalDevice physicalDevice, SurfaceKHR surface, uint windowWidth, uint windowHeight)
        {
            var data = new SwapchainData();

            // surface format
            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            var surfaceFormat  = surfaceFormats[0].Format;

            var surfaceCapabilities = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            // Buffer count
            var desiredImageCount = Math.Min(surfaceCapabilities.MinImageCount + 1, surfaceCapabilities.MaxImageCount);
            
            // Transform
            SurfaceTransformFlagsKHR preTransform;
            if((surfaceCapabilities.SupportedTransforms & SurfaceTransformFlagsKHR.Identity) != 0)
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

        List<ImageData> InitializeSwapchainImages(Queue queue, CommandPool cmdPool, Image[] images, Format imageFormat)
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
            queue.Submit(new[]{ submitInfo });
            queue.WaitIdle();

            device.FreeCommandBuffers(cmdPool, new[]{ cmdBuffer });
            
            var imageDatas = new List<ImageData>();

            foreach(var img in images)
            {
                var imgData = new ImageData();
                imgData.Image = img;
                imgData.Width = 800;
                imgData.Height = 600;
                imgData.View = CreateImageView(img, imageFormat);
                imageDatas.Add(imgData);
            }

            return imageDatas;
        }

        #endregion

        protected VertexData CreateVertexData()
        {
            var data = new VertexData();

            var triangleVertices = new[,]
            {
                {  0.5f,  0.5f,  0.0f, /* Vertex Color: */ 1.0f, 0.0f, 0.0f },
                { -0.5f,  0.5f,  0.0f, /* Vertex Color: */ 0.0f, 1.0f, 0.0f },
                {  0.0f, -0.5f,  0.0f, /* Vertex Color: */ 0.0f, 0.0f, 1.0f },
            };

            DeviceSize memorySize = (ulong)(sizeof(float) * triangleVertices.Length);
            data.Buffer = CreateBuffer(memorySize, BufferUsageFlags.VertexBuffer);

            var memoryRequirements = device.GetBufferMemoryRequirements(data.Buffer);
            var memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
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

        #region Rendering

        void CreateCommandBuffer(CommandBuffer cmdBuffer, VertexData vertexData, RenderPass renderPass, Pipeline pipeline, ImageData swapchainImageData, Framebuffer framebuffer)
        {
            var beginInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(beginInfo);  // CommandBuffer Begin
            beginInfo.Dispose();

            PipelineBarrierSetLayout(cmdBuffer, swapchainImageData.Image, ImageLayout.PresentSrcKHR, ImageLayout.ColorAttachmentOptimal, AccessFlags.MemoryRead, AccessFlags.ColorAttachmentWrite);

            var clearRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            cmdBuffer.ClearColorImage(swapchainImageData.Image, ImageLayout.TransferDstOptimal, new ClearColorValue(), new[] { clearRange });

            RenderTriangle(cmdBuffer, vertexData, renderPass, framebuffer, pipeline, swapchainImageData.Width, swapchainImageData.Height);

            PipelineBarrierSetLayout(cmdBuffer, swapchainImageData.Image, ImageLayout.ColorAttachmentOptimal, ImageLayout.PresentSrcKHR, AccessFlags.ColorAttachmentWrite, AccessFlags.MemoryRead);

            // End recording commands to the buffer
            cmdBuffer.End();
        }
        
        void RenderTriangle(CommandBuffer cmdBuffer, VertexData vertexData, RenderPass renderPass, Framebuffer framebuffer, Pipeline pipeline, uint width, uint height)
        {
            // Set the viewport
            var viewport = new Viewport(0, 0, width, height, 0, 0);
            cmdBuffer.SetViewport(0, new[]{ viewport });

            var renderArea = new Rect2D(new Offset2D(0, 0), new Extent2D(width, height));
            var renderPassBegin = new RenderPassBeginInfo(renderPass, framebuffer, renderArea, null);
            cmdBuffer.BeginRenderPass(renderPassBegin, SubpassContents.Inline);
            renderPassBegin.Dispose();

            cmdBuffer.BindPipeline(PipelineBindPoint.Graphics, pipeline);

            // Render the triangle
            cmdBuffer.BindVertexBuffers(0, new[] { vertexData.Buffer }, new DeviceSize[] { 0 });
            cmdBuffer.Draw(3, 1, 0, 0);

            // End the RenderPass
            cmdBuffer.EndRenderPass();
        }

        void OnRenderCallback(Queue queue, CommandBuffer[] cmdBuffer, SwapchainData swapchainData)
        {
            var semaphoreCreateInfo = new SemaphoreCreateInfo();
            var presentSemaphore = device.CreateSemaphore(semaphoreCreateInfo);
            semaphoreCreateInfo.Dispose();

            var currentBufferIndex = (int)device.AcquireNextImageKHR(swapchainData.Swapchain, ulong.MaxValue, presentSemaphore, null);
            SubmitForExecution(queue, presentSemaphore, cmdBuffer[currentBufferIndex]);

            // Present the image (display it on the screen)
            var presentInfo = new PresentInfoKHR(new[] { swapchainData.Swapchain }, new[] { (uint)currentBufferIndex });
            queue.PresentKHR(presentInfo);
            presentInfo.Dispose();

            queue.WaitIdle(); // wait for execution to finish

            device.DestroySemaphore(presentSemaphore);
        }
        
        #endregion
    }
}
