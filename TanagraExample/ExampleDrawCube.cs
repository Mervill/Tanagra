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
    public class ExampleDrawCube : ExampleBase
    {
        class UniformData
        {
            public Buffer Buffer;
            public DeviceMemory Memory;
            public DescriptorBufferInfo Descriptor;
            public uint AllocSize;
        }

        struct Transform
        {
            public OpenTK.Matrix4 projection;
            public OpenTK.Matrix4 model;
            public OpenTK.Matrix4 view;
        }
        
        public ExampleDrawCube()
        {
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
            
            surface       = CreateWin32Surface(instance, window.Handle);
            physDevice.GetSurfaceSupportKHR(0, surface);

            device        = CreateDevice(physDevice, 0);           // Create a device from the physical device
            queue         = GetQueue(physDevice, 0);               // Get an execution queue from the physical device
            cmdPool       = CreateCommandPool(0);                  // Create a command pool from which command buffers are created
            
            var textureData = LoadTexture("./test-image.png", queue, cmdPool);
            
            var uniformData = CreateUniformBuffer(typeof(Transform));
            var transform = UpdateTransform(new Transform(), imageWidth, imageHeight, -3);
            CopyTransform(transform, uniformData);

            VertexData vertexData;
            RenderPass renderPass;
            PipelineLayout pipelineLayout;
            Pipeline[] pipelines;
            Pipeline pipeline;
            
            // This exercise would be pointless if we had nothing to 
            // render, so lets create that data now.
            vertexData = CreateVertexData();

            var stencilFormat = GetDepthStencilFormat(physDevice);
            var depthStencil = CreateDepthStencil(stencilFormat, imageWidth, imageHeight);
            SetStencilLayout(cmdPool, queue, depthStencil);
            

            // Load shaders from disk and set them up to be passed to `CreatePipeline`
            var shaderInfos = new List<PipelineShaderStageCreateInfo>();
            shaderInfos.Add(GetShaderStageCreateInfo(ShaderStageFlags.Vertex, "./texture.vert.spv"));
            shaderInfos.Add(GetShaderStageCreateInfo(ShaderStageFlags.Fragment, "./texture.frag.spv"));

            // Create the render dependencies
            swapchainData        = CreateSwapchain(physDevice, surface, imageWidth, imageHeight);
            swapchainImages      = device.GetSwapchainImagesKHR(swapchainData.Swapchain);
            swapchainData.Images = InitializeSwapchainImages(queue, cmdPool, swapchainImages, swapchainData.ImageFormat, imageWidth, imageHeight);

            renderPass = CreateRenderPass(swapchainData.ImageFormat, stencilFormat);

            swapchainData.Framebuffers = swapchainData.Images
                .Select(x => CreateFramebuffer(renderPass, x, depthStencil))
                .ToList();

            var descriptorPool      = CreateDescriptorPool();
            var descriptorSetLayout = CreateDescriptorSetLayout();
            var descriptorSet       = CreateDescriptorSet(descriptorPool, descriptorSetLayout, textureData, uniformData);

            pipelineLayout = CreatePipelineLayout(descriptorSetLayout);
            pipelines      = CreatePipelines(pipelineLayout, renderPass, shaderInfos.ToArray(), vertexData);
            pipeline       = pipelines.First();
            
            var cmdBuffers = AllocateCommandBuffers(cmdPool, (uint)swapchainData.Images.Count());
            for(int x = 0; x < swapchainData.Images.Count(); x++)
                CreateCommandBuffer(
                    cmdBuffers[x], 
                    vertexData, 
                    renderPass, 
                    pipelineLayout, 
                    pipeline, 
                    descriptorSet, 
                    swapchainData.Images[x], 
                    swapchainData.Framebuffers[x], 
                    depthStencil);

            RenderLoop.Run(window, () => OnRenderCallback(queue, cmdBuffers, swapchainData, uniformData, transform));

            #region Shutdown
            // Destroy Vulkan handles

            device.DestroyBuffer(uniformData.Buffer);
            device.FreeMemory(uniformData.Memory);

            //device.FreeDescriptorSets(descriptorPool, new[] { descriptorSet });
            device.DestroyDescriptorSetLayout(descriptorSetLayout);
            device.DestroyDescriptorPool(descriptorPool);

            device.DestroyImageView(depthStencil.View);
            device.DestroyImage(depthStencil.Image);
            device.FreeMemory(depthStencil.Memory);

            device.DestroySampler(textureData.Sampler);
            device.DestroyImageView(textureData.View);
            device.DestroyImage(textureData.Image);
            device.FreeMemory(textureData.Memory);

            device.FreeCommandBuffers(cmdPool, cmdBuffers);

            device.DestroyShaderModule(shaderInfos[0].Module);
            device.DestroyShaderModule(shaderInfos[1].Module);

            swapchainData.Images.ForEach(x => device.DestroyImageView(x.View));
            swapchainData.Framebuffers.ForEach(x => device.DestroyFramebuffer(x));
            device.DestroySwapchainKHR(swapchainData.Swapchain);

            device.DestroyPipeline(pipeline);
            device.DestroyPipelineLayout(pipelineLayout);
            device.DestroyRenderPass(renderPass);

            device.DestroyBuffer(vertexData.IndexBuffer);
            device.FreeMemory(vertexData.IndexDeviceMemory);
            device.DestroyBuffer(vertexData.Buffer);
            device.FreeMemory(vertexData.DeviceMemory);

            device.DestroyCommandPool(cmdPool);

            device.Destroy();

            instance.DestroySurfaceKHR(surface);

            DebugUtils.DestroyDebugReportCallback(instance, debugCallback);

            instance.Destroy();
            #endregion
        }
        
        VertexData CreateVertexData()
        {
            var data = new VertexData();

            var quadVertices = new[,]
            {
                {  0.5f, -0.5f,  0.5f,  0f, 0f,   0f,  0f,  1f },
                { -0.5f, -0.5f,  0.5f,  1f, 0f,   0f,  0f,  1f },
                {  0.5f,  0.5f,  0.5f,  0f, 1f,   0f,  0f,  1f },
                { -0.5f,  0.5f,  0.5f,  1f, 1f,   0f,  0f,  1f },
                {  0.5f,  0.5f, -0.5f,  0f, 1f,   0f,  1f,  0f },
                { -0.5f,  0.5f, -0.5f,  1f, 1f,   0f,  1f,  0f },
                {  0.5f, -0.5f, -0.5f,  0f, 1f,   0f,  0f, -1f },
                { -0.5f, -0.5f, -0.5f,  1f, 1f,   0f,  0f, -1f },
                {  0.5f,  0.5f,  0.5f,  0f, 0f,   0f,  1f,  0f },
                { -0.5f,  0.5f,  0.5f,  1f, 0f,   0f,  1f,  0f },
                {  0.5f,  0.5f, -0.5f,  0f, 0f,   0f,  0f, -1f },
                { -0.5f,  0.5f, -0.5f,  1f, 0f,   0f,  0f, -1f },
                {  0.5f, -0.5f, -0.5f,  0f, 0f,   0f, -1f,  0f },
                {  0.5f, -0.5f,  0.5f,  0f, 1f,   0f, -1f,  0f },
                { -0.5f, -0.5f,  0.5f,  1f, 1f,   0f, -1f,  0f },
                { -0.5f, -0.5f, -0.5f,  1f, 0f,   0f, -1f,  0f },
                { -0.5f, -0.5f,  0.5f,  0f, 0f,  -1f,  0f,  0f },
                { -0.5f,  0.5f,  0.5f,  0f, 1f,  -1f,  0f,  0f },
                { -0.5f,  0.5f, -0.5f,  1f, 1f,  -1f,  0f,  0f },
                { -0.5f, -0.5f, -0.5f,  1f, 0f,  -1f,  0f,  0f },
                {  0.5f, -0.5f, -0.5f,  0f, 0f,   1f,  0f,  0f },
                {  0.5f,  0.5f, -0.5f,  0f, 1f,   1f,  0f,  0f },
                {  0.5f,  0.5f,  0.5f,  1f, 1f,   1f,  0f,  0f },
                {  0.5f, -0.5f,  0.5f,  1f, 0f,   1f,  0f,  0f },
            };

            DeviceSize memorySize = (ulong)(sizeof(float) * quadVertices.Length);
            data.Buffer = CreateBuffer(memorySize, BufferUsageFlags.VertexBuffer);

            var memoryRequirements = device.GetBufferMemoryRequirements(data.Buffer);
            var memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            var allocateInfo = new MemoryAllocateInfo(memoryRequirements.Size, memoryIndex);
            data.DeviceMemory = BindBuffer(data.Buffer, allocateInfo);
            
            var vertexPtr = device.MapMemory(data.DeviceMemory, 0, memorySize);
            VulkanUtils.Copy2DArray(quadVertices, vertexPtr, memorySize, memorySize);
            device.UnmapMemory(data.DeviceMemory);

            data.Indicies = new[] 
            {
                 0, 2, 3, // right
                 0, 3, 1,
                 8, 4, 5, // bottom
                 8, 5, 9,
                10, 6, 7, // left
                10, 7,11,
                12,13,14, // top
                12,14,15,
                16,17,18, // back
                16,18,19,
                20,21,22, // front
                20,22,23,
            };

            memorySize = (ulong)(sizeof(uint) * data.Indicies.Length);
            data.IndexBuffer = CreateBuffer(memorySize, BufferUsageFlags.IndexBuffer);

            memoryRequirements = device.GetBufferMemoryRequirements(data.IndexBuffer);
            memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            allocateInfo = new MemoryAllocateInfo(memoryRequirements.Size, memoryIndex);
            data.IndexDeviceMemory = BindBuffer(data.IndexBuffer, allocateInfo);
            
            var bytes = data.Indicies.SelectMany(BitConverter.GetBytes).ToArray(); // oh man, dat Linq tho
            CopyArrayToBuffer(data.IndexDeviceMemory, memorySize, bytes);
            
            data.BindingDescriptions = new[]
            {
                new VertexInputBindingDescription(0, (uint)(sizeof(float) * quadVertices.GetLength(1)), VertexInputRate.Vertex)
            };

            data.AttributeDescriptions = new[]
            {
                new VertexInputAttributeDescription(0, 0, Format.R32G32B32A32_SFLOAT, 0),                 // Vertex: X, Y, Z
                new VertexInputAttributeDescription(1, 0, Format.R32G32B32_SFLOAT, sizeof(float) * 3),    // UV: U, V
                new VertexInputAttributeDescription(2, 0, Format.R32G32B32A32_SFLOAT, sizeof(float) * 5), // Normal: X, Y, Z
            };

            return data;
        }
        
        ImageData LoadTexture(string filename, Queue queue, CommandPool cmdPool)
        {
            //
            var bmp = new Bitmap(filename);

            var bitmapFormat = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bitmapData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmapFormat);
            //
            
            uint imageWidth  = (uint)bmp.Width;
            uint imageHeight = (uint)bmp.Height;

            var imageFormat   = Format.B8G8R8A8_UNORM;
            var imageData     = new ImageData();
            imageData.Width   = imageWidth;
            imageData.Height  = imageHeight;
            imageData.Image   = CreateTextureImage(imageFormat, imageWidth, imageHeight);
            imageData.Memory  = BindImage(imageData.Image);
            imageData.View    = CreateImageView(imageData.Image, imageFormat);
            imageData.Sampler = CreateSampler();
            
            var memRequirements = device.GetImageMemoryRequirements(imageData.Image);
            var imageBuffer = CreateBuffer(memRequirements.Size, BufferUsageFlags.TransferSrc | BufferUsageFlags.TransferDst);
            var memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            var memAlloc = new MemoryAllocateInfo(memRequirements.Size, memoryIndex);
            var bufferMemory = BindBuffer(imageBuffer, memAlloc);

            CopyBitmapToBuffer(bitmapData.Scan0, (int)(imageWidth * imageHeight * 4), bufferMemory, memRequirements.Size);
            
            //
            var cmdBuffers = AllocateCommandBuffers(cmdPool, 1);
            var cmdBuffer = cmdBuffers[0];

            var beginInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(beginInfo);

            PipelineBarrierSetLayout(cmdBuffer, imageData.Image, ImageLayout.Preinitialized, ImageLayout.TransferDstOptimal, AccessFlags.HostWrite, AccessFlags.TransferWrite);
            CopyBufferToImage(cmdBuffer, imageData, imageBuffer);
            PipelineBarrierSetLayout(cmdBuffer, imageData.Image, ImageLayout.TransferDstOptimal, ImageLayout.ShaderReadOnlyOptimal, AccessFlags.TransferWrite, AccessFlags.ShaderRead);

            // wait... why does this work?
            device.DestroyBuffer(imageBuffer);
            device.FreeMemory(bufferMemory);
            
            cmdBuffer.End();
            
            var submitInfo = new SubmitInfo(null, null, new[]{ cmdBuffer }, null);
            queue.Submit(new[] { submitInfo });
            submitInfo.Dispose();
            queue.WaitIdle();

            device.FreeCommandBuffers(cmdPool, new[] { cmdBuffer });
            //

            //CopyBufferToImage(queue, cmdPool, imageData, imageBuffer);

            //
            bmp.UnlockBits(bitmapData);
            bmp.Dispose();
            //
            
            return imageData;
        }

        Format GetDepthStencilFormat(PhysicalDevice physDevice)
        {
            var depthFormats = new[]
            {
                Format.D32_SFLOAT_S8_UINT,
                Format.D32_SFLOAT,
                Format.D24_UNORM_S8_UINT,
                Format.D16_UNORM_S8_UINT,
                Format.D16_UNORM
            };

            foreach(var f in depthFormats)
            {
                var properties = physDevice.GetFormatProperties(f);
                if(properties.OptimalTilingFeatures.HasFlag(FormatFeatureFlags.DepthStencilAttachment))
                    return f;
            }

            throw new Exception("Found no valid depth stencil format!");
        }

        ImageData CreateDepthStencil(Format stencilFormat, uint width, uint height)
        {
            var size = new Extent3D(width, height, 1);
            var usage = ImageUsageFlags.DepthStencilAttachment | ImageUsageFlags.TransferSrc;
            var createImageInfo = new ImageCreateInfo(ImageType.ImageType2d, stencilFormat, size, 1, 1, SampleCountFlags.SampleCountFlags1, ImageTiling.Optimal, usage, SharingMode.Exclusive, null, ImageLayout.Preinitialized);
            var img = device.CreateImage(createImageInfo);

            var imgMem = BindImage(img);

            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Depth | ImageAspectFlags.Stencil, 0, 1, 0, 1);
            var createInfo = new ImageViewCreateInfo(img, ImageViewType.ImageViewType2d, stencilFormat, new ComponentMapping(), subresourceRange);
            var imgView = device.CreateImageView(createInfo);

            return new ImageData
            {
                Height = height,
                Width = width,
                Image = img,
                Memory = imgMem,
                View = imgView
            };
        }

        void SetStencilLayout(CommandPool cmdPool, Queue queue, ImageData stencil)
        {
            var allocInfo = new CommandBufferAllocateInfo(cmdPool, CommandBufferLevel.Primary, 1);
            var cmdBuffer = device.AllocateCommandBuffers(allocInfo).First();

            var beginInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(beginInfo);

            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Depth | ImageAspectFlags.Stencil, 0, 1, 0, 1);
            var imageMemoryBarrier = new ImageMemoryBarrier(ImageLayout.Undefined, ImageLayout.DepthStencilAttachmentOptimal, 0, 0, stencil.Image, subresourceRange);
            imageMemoryBarrier.SrcAccessMask = AccessFlags.None;
            imageMemoryBarrier.DstAccessMask = AccessFlags.DepthStencilAttachmentWrite;
            var imageMemoryBarriers = new[]{ imageMemoryBarrier };
            cmdBuffer.PipelineBarrier(PipelineStageFlags.TopOfPipe, PipelineStageFlags.TopOfPipe, DependencyFlags.None, null, null, imageMemoryBarriers);
            imageMemoryBarrier.Dispose();

            cmdBuffer.End();

            var submitInfo = new SubmitInfo(null, null, new[]{ cmdBuffer }, null);
            queue.Submit(new[] { submitInfo });
            submitInfo.Dispose();

            queue.WaitIdle();
            device.WaitIdle();
        }

        // --

        Sampler CreateSampler()
        {
            var createInfo = new SamplerCreateInfo();
            createInfo.MagFilter = Filter.Linear;
            createInfo.MinFilter = Filter.Linear;
            createInfo.MipmapMode = SamplerMipmapMode.Linear;
            createInfo.MaxLod = 1;
            createInfo.AnisotropyEnable = true;
            createInfo.BorderColor = BorderColor.FloatOpaqueWhite;
            return device.CreateSampler(createInfo);
        }

        UniformData CreateUniformBuffer(Type targetType)
        {
            var data = new UniformData();
            var size = Marshal.SizeOf(targetType);
            data.Buffer = CreateBuffer((ulong)size, BufferUsageFlags.UniformBuffer);

            var memRequirements = device.GetBufferMemoryRequirements(data.Buffer);
            var memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            var memAlloc = new MemoryAllocateInfo(memRequirements.Size, memoryIndex);
            data.Memory = BindBuffer(data.Buffer, memAlloc);

            data.Descriptor = new DescriptorBufferInfo(data.Buffer, 0, (ulong)size);

            data.AllocSize = (uint)memAlloc.AllocationSize;

            return data;
        }

        Transform UpdateTransform(Transform ubo, float width, float height, float zoom)
        {
            ubo.projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(DegreesToRadians(60), width / height, 0.001f, 256.0f);
            ubo.view = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(zoom, -3, -3), OpenTK.Vector3.Zero, OpenTK.Vector3.UnitY);
            ubo.model = OpenTK.Matrix4.Identity;
            return ubo;
        }

        void CopyTransform(Transform ubo, UniformData uniform)
        {   
            var map = device.MapMemory(uniform.Memory, 0, uniform.AllocSize);
            
            var size = Marshal.SizeOf(typeof(Transform));
            var bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(ubo, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);

            Marshal.Copy(bytes, 0, map, size);

            device.UnmapMemory(uniform.Memory);
        }
        
        DescriptorPool CreateDescriptorPool()
        {
            var poolSizes = new[]
            {
                new DescriptorPoolSize(DescriptorType.UniformBuffer, 1),
                new DescriptorPoolSize(DescriptorType.CombinedImageSampler, 1),
            };
            
            var createInfo = new DescriptorPoolCreateInfo(2, poolSizes);
            return device.CreateDescriptorPool(createInfo);
        }
        
        DescriptorSetLayout CreateDescriptorSetLayout()
        {
            var layoutBindings = new[]
            {
                new DescriptorSetLayoutBinding(0, DescriptorType.UniformBuffer, ShaderStageFlags.Vertex),
                new DescriptorSetLayoutBinding(1, DescriptorType.CombinedImageSampler, ShaderStageFlags.Fragment),
            };
            layoutBindings[0].DescriptorCount = 1;
            layoutBindings[1].DescriptorCount = 1;

            var createInfo = new DescriptorSetLayoutCreateInfo(layoutBindings);
            return device.CreateDescriptorSetLayout(createInfo);
        }

        DescriptorSet CreateDescriptorSet(DescriptorPool pool, DescriptorSetLayout layout, ImageData imageData, UniformData uniformData)
        {
            var allocInfo = new DescriptorSetAllocateInfo(pool, new[] { layout });
            var sets = device.AllocateDescriptorSets(allocInfo);
            var descriptorSet = sets.First();
            var texDescriptor = new DescriptorImageInfo(imageData.Sampler, imageData.View, ImageLayout.General);
            var writeDescriptorSets = new[]
            {
                new WriteDescriptorSet(descriptorSet, 0, 0, DescriptorType.UniformBuffer, null, null, null),
                new WriteDescriptorSet(descriptorSet, 1, 0, DescriptorType.CombinedImageSampler, null, null, null),
            };
            writeDescriptorSets[0].BufferInfo = new[] { uniformData.Descriptor };
            writeDescriptorSets[1].ImageInfo = new[] { texDescriptor };
            device.UpdateDescriptorSets(writeDescriptorSets, null);
            return descriptorSet;
        }

        #region Rendering

        void CreateCommandBuffer(CommandBuffer cmdBuffer, VertexData vertexData, RenderPass renderPass, PipelineLayout pipelineLayout, Pipeline pipeline, DescriptorSet descriptorSet, ImageData swapchainImageData, Framebuffer framebuffer, ImageData depthStencil)
        {
            var beginInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(beginInfo);
            beginInfo.Dispose();

            PipelineBarrierSetLayout(cmdBuffer, swapchainImageData.Image, ImageLayout.PresentSrcKHR, ImageLayout.ColorAttachmentOptimal, AccessFlags.MemoryRead, AccessFlags.ColorAttachmentWrite);

            var clearRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            cmdBuffer.ClearColorImage(swapchainImageData.Image, ImageLayout.TransferDstOptimal, new ClearColorValue(), new[] { clearRange });

            var stencilRange = new ImageSubresourceRange(ImageAspectFlags.Depth | ImageAspectFlags.Stencil, 0, 1, 0, 1);
            cmdBuffer.ClearDepthStencilImage(depthStencil.Image, ImageLayout.TransferDstOptimal, new ClearDepthStencilValue(1.0f, 0), new[] { stencilRange });

            RenderTexturedQuad(cmdBuffer, vertexData, swapchainImageData, pipelineLayout, descriptorSet, renderPass, pipeline, framebuffer, swapchainImageData.Width, swapchainImageData.Height);

            PipelineBarrierSetLayout(cmdBuffer, swapchainImageData.Image, ImageLayout.ColorAttachmentOptimal, ImageLayout.PresentSrcKHR, AccessFlags.ColorAttachmentWrite, AccessFlags.MemoryRead);
            
            cmdBuffer.End();
        }
        
        void RenderTexturedQuad(CommandBuffer cmdBuffer, VertexData vertexData, ImageData imageData, PipelineLayout pipelineLayout, DescriptorSet descriptorSet, RenderPass renderPass, Pipeline pipeline, Framebuffer framebuffer, uint width, uint height)
        {
            var viewport = new Viewport(0, 0, width, height, 0, 1);
            cmdBuffer.SetViewport(0, new[] { viewport });

            var renderArea = new Rect2D(new Offset2D(0, 0), new Extent2D(width, height));
            //var clearValues = new[] { new ClearValue { Color = new ClearColorValue() }, new ClearValue { DepthStencil = new ClearDepthStencilValue(1.0f, 0) } };
            var renderPassBegin = new RenderPassBeginInfo(renderPass, framebuffer, renderArea, null);
            //renderPassBegin.ClearValues = clearValues;
            cmdBuffer.BeginRenderPass(renderPassBegin, SubpassContents.Inline);
            renderPassBegin.Dispose();
            
            cmdBuffer.BindDescriptorSets(PipelineBindPoint.Graphics, pipelineLayout, 0, new[] { descriptorSet }, null);

            cmdBuffer.BindPipeline(PipelineBindPoint.Graphics, pipeline);

            cmdBuffer.BindVertexBuffers(0, new[] { vertexData.Buffer }, new DeviceSize[] { 0 });
            cmdBuffer.BindIndexBuffer(vertexData.IndexBuffer, 0, IndexType.Uint32);
            cmdBuffer.DrawIndexed((uint)vertexData.Indicies.Length, 1, 0, 0, 1);
            
            cmdBuffer.EndRenderPass();
        }

        //static int i;

        void OnRenderCallback(Queue queue, CommandBuffer[] cmdBuffer, SwapchainData swapchainData, UniformData uniformData, Transform transform)
        {
            //transform.model *= OpenTK.Matrix4.CreateRotationX(i++);
            //CopyUBO(transform, uniformData);

            var semaphoreCreateInfo = new SemaphoreCreateInfo();
            var presentSemaphore = device.CreateSemaphore(semaphoreCreateInfo);
            semaphoreCreateInfo.Dispose();

            var currentBufferIndex = (int)device.AcquireNextImageKHR(swapchainData.Swapchain, ulong.MaxValue, presentSemaphore, null);
            SubmitForExecution(queue, presentSemaphore, cmdBuffer[currentBufferIndex]);
            
            var presentInfo = new PresentInfoKHR(new[]{ swapchainData.Swapchain }, new[]{ (uint)currentBufferIndex });
            queue.PresentKHR(presentInfo);
            presentInfo.Dispose();

            queue.WaitIdle();

            device.DestroySemaphore(presentSemaphore);
        }

        void CopyImageToBuffer(CommandBuffer cmdBuffer, ImageData imageData, Buffer imageBuffer, uint width, uint height)
        {
            var subresource = new ImageSubresourceLayers(ImageAspectFlags.Color, 0, 0, 1);
            var imageCopy = new BufferImageCopy(0, width, height, subresource, new Offset3D(0, 0, 0), new Extent3D(width, height, 0));
            cmdBuffer.CopyImageToBuffer(imageData.Image, ImageLayout.TransferSrcOptimal, imageBuffer, new[]{ imageCopy });
        }
        
        #endregion
        
        void CopyBufferToImage(CommandBuffer cmdBuffer, ImageData imageData, Buffer imageBuffer)
        {
            var subresource = new ImageSubresourceLayers(ImageAspectFlags.Color, 0, 0, 1);
            var imageCopy = new BufferImageCopy(0, 0, 0, subresource, new Offset3D(0, 0, 0), new Extent3D(imageData.Width, imageData.Height, 1));
            cmdBuffer.CopyBufferToImage(imageBuffer, imageData.Image, ImageLayout.TransferDstOptimal, new[] { imageCopy });
        }

        void CopyArrayToBuffer(DeviceMemory bufferMem, DeviceSize size, byte[] data)
        {
            var map = device.MapMemory(bufferMem, 0, size);
            Marshal.Copy(data, 0, map, (int)((ulong)size));
            device.UnmapMemory(bufferMem);
        }
        
        void CopyBitmapToBuffer(IntPtr scan0, int bitmapSize, DeviceMemory bufferMem, DeviceSize size)
        {
            var map = device.MapMemory(bufferMem, 0, size);
            Copy(scan0, map, bitmapSize);
            device.UnmapMemory(bufferMem);
        }

        void Copy(IntPtr src, IntPtr dest, int size)
        {
            var data = new byte[size];
            Marshal.Copy(src, data, 0, size);
            Marshal.Copy(data, 0, dest, size);
        }
        
    }
}
