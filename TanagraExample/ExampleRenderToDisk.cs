using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;

using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // A managed interface to Vulkan
using Vulkan.Managed.ObjectModel; // Extentions to object handles

using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    public class ExampleRenderToDisk
    {
        // NOTE: This example does NOT render to the screen! Instead it renders to an image and then
        //       writes that image to a file. This allows us to focus on the core Vulkan API. Presenting
        //       images to the screen in covered in another example.

        // Note: Some of the comments in this example are taken right from the Vulkan spec:
        // https://www.khronos.org/registry/vulkan/specs/1.0/xhtml/vkspec.html
        
        class VertexData
        {
            public Buffer Buffer;
            public DeviceMemory DeviceMemory;
            public VertexInputBindingDescription[] BindingDescriptions;
            public VertexInputAttributeDescription[] AttributeDescriptions;
        }

        class ImageData
        {
            public uint Width;
            public uint Height;
            public Image Image;
            public DeviceMemory Memory;
            public ImageView View;
        }
        
        // Device is held as a class member because its used in
        // basically every operation after it's been created.
        Device device;
        
        PhysicalDeviceMemoryProperties physDeviceMem;
        DebugReportCallbackEXT debugCallback;

        public ExampleRenderToDisk()
        {
            // The goal of this example is to:
            //
            // - Initialize Vulkan
            // - Create an empty image of size `imageWidth` x `imageHeight`
            // - Use that image as a render target for a triangle
            // - Save the render to disk
            // - Shutdown Vulkan
            //

            const string OutputFilename = "./out.bmp";
            const Format ImageFormat = Format.R8G8B8A8_UNORM;

            uint imageWidth  = 800;
            uint imageHeight = 600;

            Instance instance;
            PhysicalDevice[] physDevices;
            PhysicalDevice physDevice;
            QueueFamilyProperties[] queueFamilies;
            //Device device;
            Queue queue;
            CommandPool cmdPool;
            
            instance      = CreateInstance();                      // Create a new Vulkan Instance
            physDevices   = EnumeratePhysicalDevices(instance);    // Discover the physical devices attached to the system
            physDevice    = physDevices[0];                        // Select the first physical device
            queueFamilies = physDevice.GetQueueFamilyProperties(); // Get properties about the queues on the physical device
            physDeviceMem = physDevice.GetMemoryProperties();      // Get properties about the memory on the physical device
            device        = CreateDevice(physDevice, 0);           // Create a device from the physical device
            queue         = GetQueue(physDevice, 0);               // Get an execution queue from the physical device
            cmdPool       = CreateCommandPool(0);                  // Create a command pool from which command buffers are created
            
            // Now that we have a command pool, we can begin creating command buffers 
            // and recording commands. You will find however that you can't do much of 
            // anything without first initializing a few more dependencies.

            VertexData vertexData;
            ImageData imageData;
            Buffer imageBuffer;
            RenderPass renderPass;
            PipelineLayout pipelineLayout;
            Pipeline[] pipelines;
            Pipeline pipeline;
            Framebuffer framebuffer;
            
            // This exercise would be pointless if we had nothing to 
            // render, so lets create that data now.
            vertexData = CreateVertexData();
            
            // Since we didn't enable any extensions, we don't have access to 
            // any display surfaces to render too. Instead we'll create an image
            // in memory and have Vulkan use it as the render target
            imageData        = new ImageData();
            imageData.Width  = imageWidth;
            imageData.Height = imageHeight;
            imageData.Image  = CreateImage(ImageFormat, imageWidth, imageHeight);
            imageData.Memory = BindImage(imageData.Image);
            imageData.View   = CreateImageView(imageData.Image, ImageFormat);

            // Allocate device memory to the image so that it can be read from and written to
            var memRequirements = device.GetImageMemoryRequirements(imageData.Image);
            imageBuffer = CreateBuffer(memRequirements.Size, BufferUsageFlags.TransferSrc | BufferUsageFlags.TransferDst);
            var memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            var memAlloc = new MemoryAllocateInfo(memRequirements.Size, memoryIndex);
            var bufferMem = BindBuffer(imageBuffer, memAlloc);
            
            // Load shaders from disk and set them up to be passed to `CreatePipeline`
            var shaderStageCreateInfos = new[]
            {
                GetShaderStageCreateInfo(ShaderStageFlags.Vertex, "triangle.vert.spv"),
                GetShaderStageCreateInfo(ShaderStageFlags.Fragment, "triangle.frag.spv"),
            };

            // Create the render dependencies
            renderPass     = CreateRenderPass(ImageFormat);
            pipelineLayout = CreatePipelineLayout();
            pipelines      = CreatePipelines(pipelineLayout, renderPass, shaderStageCreateInfos, vertexData);
            pipeline       = pipelines.First();
            framebuffer    = CreateFramebuffer(renderPass, imageData);
            
            // Render the triangle to the image
            Render(queue, cmdPool, vertexData, imageData, imageBuffer, renderPass, pipeline, framebuffer);

            var renderData = CopyBufferToArray(bufferMem, memRequirements);
            WriteBitmap(renderData, OutputFilename, (int)imageWidth, (int)imageHeight);
            Console.WriteLine($"Render written to {OutputFilename}");

            #region Shutdown
            // Destroy Vulkan handles in reverse order of creation (roughly)
            
            device.DestroyShaderModule(shaderStageCreateInfos[0].Module);
            device.DestroyShaderModule(shaderStageCreateInfos[1].Module);

            device.DestroyBuffer(imageBuffer);
            device.FreeMemory(bufferMem);
            
            device.DestroyImageView(imageData.View);
            device.DestroyImage(imageData.Image);
            device.FreeMemory(imageData.Memory);

            device.DestroyBuffer(vertexData.Buffer);
            device.FreeMemory(vertexData.DeviceMemory);

            device.DestroyFramebuffer(framebuffer);
            device.DestroyPipeline(pipeline);
            device.DestroyPipelineLayout(pipelineLayout);
            device.DestroyRenderPass(renderPass);

            device.DestroyCommandPool(cmdPool);

            device.Destroy();

            DebugUtils.DestroyDebugReportCallback(instance, debugCallback);

            instance.Destroy();
            #endregion
        }

        #region  Primary Initialization

        Instance CreateInstance()
        {
            // There is no global state in Vulkan and all per-application state is stored in a 
            // `Instance` object. Creating a `Instance` object initializes the Vulkan library 
            // and allows the application to pass information about itself to the implementation.

            // For this example, we want Vulkan to act in a 'default' fashion, so we don't
            // pass and ApplicationInfo object and we don't request any layers or extensions

            String[] enabledLayers = new string[]
            {
                "VK_LAYER_LUNARG_standard_validation"
            };

            var enabledExtensions = new[]
            {
                VulkanConstant.ExtDebugReportExtensionName,
            };

            var instanceCreateInfo = new InstanceCreateInfo(enabledLayers, enabledExtensions);
            var instance = Vk.CreateInstance(instanceCreateInfo);

            debugCallback = DebugUtils.CreateDebugReportCallback(instance, DebugReport);

            return instance;
        }

        PhysicalDevice[] EnumeratePhysicalDevices(Instance instance)
        {
            // Once Vulkan is initialized, devices and queues are the primary objects used to interact
            // with a Vulkan implementation.
            //
            // Vulkan separates the concept of physical and logical devices. A physical device usually
            // represents a single device in a system (perhaps made up of several individual hardware 
            // devices working together), of which there are a finite number. A logical device 
            // represents an application’s view of the device.

            var physicalDevices = instance.EnumeratePhysicalDevices();

            if(physicalDevices.Length == 0)
                throw new InvalidOperationException("Didn't find any physical devices");

            return physicalDevices;
        }

        Device CreateDevice(PhysicalDevice physicalDevice, uint queueFamily)
        {
            // Device objects represent logical connections to physical devices. Each device exposes 
            // a number of queue families each having one or more queues. All queues in a queue family 
            // support the same operations.
            //
            // As described above, a Vulkan application will first query for all physical
            // devices in a system. Each physical device can then be queried for its capabilities, 
            // including its queue and queue family properties. Once an acceptable physical device is 
            // identified, an application will create a corresponding logical device. An application 
            // must create a separate logical device for each physical device it will use. The created 
            // logical device is then the primary interface to the physical device.

            String[] enabledLayers = new string[]
            {
                "VK_LAYER_LUNARG_standard_validation"
            };

            var features = new PhysicalDeviceFeatures();
            features.ShaderClipDistance = true;
            features.ShaderCullDistance = true;

            var queueCreateInfo = new DeviceQueueCreateInfo(queueFamily, new[]{ 0f });
            var deviceCreateInfo = new DeviceCreateInfo(new[]{ queueCreateInfo }, enabledLayers, null);
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
            // Command pools are opaque objects that command buffer memory is allocated from, and 
            // which allow the implementation to amortize the cost of resource creation across multiple 
            // command buffers. Command pools are application-synchronized, meaning that a command pool
            // must not be used concurrently in multiple threads. That includes use via recording 
            // commands on any command buffers allocated from the pool, as well as operations that 
            // allocate, free, and reset command buffers or the pool itself.

            var commandPoolCreateInfo = new CommandPoolCreateInfo(queueFamily);
            commandPoolCreateInfo.Flags = CommandPoolCreateFlags.ResetCommandBuffer;
            return device.CreateCommandPool(commandPoolCreateInfo);
        }

        CommandBuffer[] AllocateCommandBuffers(CommandPool commandPool, uint buffersToAllocate)
        {
            // Command buffers are objects used to record commands which can be subsequently submitted 
            // to a device queue for execution. There are two levels of command buffers - primary 
            // command buffers, which can execute secondary command buffers, and which are submitted to
            // queues, and secondary command buffers, which can be executed by primary command buffers,
            // and which are not directly submitted to queues.
            //
            // Recorded commands include commands to bind pipelines and descriptor sets to the command 
            // buffer, commands to modify dynamic state, commands to draw (for graphics rendering), 
            // commands to dispatch(for compute), commands to execute secondary command buffers (for 
            // primary command buffers only), commands to copy buffers and images, and other commands.

            var commandBufferAllocationInfo = new CommandBufferAllocateInfo(commandPool, CommandBufferLevel.Primary, buffersToAllocate);
            var commandBuffers = device.AllocateCommandBuffers(commandBufferAllocationInfo);

            if(commandBuffers.Length == 0)
                throw new InvalidOperationException("Couldn't allocate any command buffers");

            return commandBuffers;
        }

        #endregion

        #region Dependencies

        VertexData CreateVertexData()
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
                new VertexInputAttributeDescription(0, 0, Format.R32G32B32_SFLOAT, 0),
                new VertexInputAttributeDescription(1, 0, Format.R32G32B32_SFLOAT, sizeof(float) * 3)
            };

            return data;
        }

        Image CreateImage(Format imageFormat, uint width, uint height)
        {
            // Images represent multidimensional - up to 3 - arrays of data which can be used for 
            // various purposes (e.g. attachments, textures), by binding them to a graphics or 
            // compute pipeline via descriptor sets, or by directly specifying them as parameters 
            // to certain commands.

            var size = new Extent3D(width, height, 1);
            var usage = ImageUsageFlags.ColorAttachment | ImageUsageFlags.TransferSrc | ImageUsageFlags.TransferDst;
            var createImageInfo = new ImageCreateInfo(ImageType.ImageType2d, imageFormat, size, 1, 1, SampleCountFlags.SampleCountFlags1, ImageTiling.Optimal, usage, SharingMode.Exclusive, null, ImageLayout.Preinitialized);
            return device.CreateImage(createImageInfo);
        }

        DeviceMemory BindImage(Image image)
        {
            var memRequirements = device.GetImageMemoryRequirements(image);
            var memTypeIndex = FindMemoryIndex(MemoryPropertyFlags.DeviceLocal);
            var memAlloc = new MemoryAllocateInfo(memRequirements.Size, memTypeIndex);
            var deviceMem = device.AllocateMemory(memAlloc);
            device.BindImageMemory(image, deviceMem, 0);
            return deviceMem;
        }

        ImageView CreateImageView(Image image, Format imageFormat)
        {
            // Image objects are not directly accessed by pipeline shaders for reading or writing 
            // image data. Instead, image views representing contiguous ranges of the image 
            // subresources and containing additional metadata are used for that purpose. Views must 
            // be created on images of compatible types, and must represent a valid subset of image 
            // subresources.

            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            var createInfo = new ImageViewCreateInfo(image, ImageViewType.ImageViewType2d, imageFormat, new ComponentMapping(), subresourceRange);
            return device.CreateImageView(createInfo);
        }

        RenderPass CreateRenderPass(Format imageFormat)
        {
            // A `RenderPass` represents a collection of attachments, subpasses, and dependencies 
            // between the subpasses, and describes how the attachments are used over the course of 
            // the subpasses.

            // Optimal layout when image is only used for color attachment read/write
            var imageLayout = ImageLayout.ColorAttachmentOptimal;

            // An `AttachmentDescription` describes the properties of an attachment including its 
            // format, sample count, and how its contents are treated at the beginning and end of 
            // each `RenderPass` instance.

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

            // A subpass represents a phase of rendering that reads and writes a subset of the 
            // attachments in a `RenderPass`. Rendering commands are recorded into a particular subpass 
            // of a `RenderPass` instance.

            // `colorAttachmentReferences` lists which of the `RenderPass`’s attachments will be used 
            // as color attachments in the subpass, and what layout the attachment images will be in 
            // during the subpass. Each element of the array correponds to a fragment shader output 
            // location, i.e. if the shader declared an output variable `layout(location=X)` then it 
            // uses the attachment provided in `colorAttachmentReferences[X]`.

            var colorAttachmentReferences = new[]
            {
                new AttachmentReference(0, imageLayout)
            };

            // A `SubpassDescription` describes the subset of attachments that is involved in the 
            // execution of a subpass. Each subpass can read from some attachments as input attachments,
            // write to some as color attachments or depth/stencil attachments, and do resolve 
            // operations to others as resolve attachments. A subpass description can also include a 
            // set of preserve attachments, which are attachments that are not read or written by the 
            // subpass but whose contents must be preserved throughout the subpass.

            var subpassDescriptions = new[]
            {
                new SubpassDescription(PipelineBindPoint.Graphics, null, colorAttachmentReferences, null)
            };
            
            var createInfo = new RenderPassCreateInfo(attachmentDescriptions, subpassDescriptions, null);
            return device.CreateRenderPass(createInfo);
        }

        PipelineShaderStageCreateInfo GetShaderStageCreateInfo(ShaderStageFlags stage, string filename, string entrypoint = "main")
        {
            var shaderBytes = File.ReadAllBytes(filename);
            return new PipelineShaderStageCreateInfo(stage, CreateShaderModule(shaderBytes), entrypoint);
        }

        ShaderModule CreateShaderModule(byte[] shaderCode)
        {
            // Shader modules contain shader code and one or more entry points. Shaders are selected 
            // from a shader module by specifying an entry point as part of pipeline creation. The 
            // stages of a pipeline can use shaders that come from different modules. The shader code 
            // defining a shader module must be in the SPIR-V format, as described by the 'Vulkan 
            // Environment for SPIR-V' specification.

            var createInfo = new ShaderModuleCreateInfo(shaderCode);
            return device.CreateShaderModule(createInfo);
        }

        PipelineLayout CreatePipelineLayout()
        {
            // The pipeline layout represents a sequence of descriptor sets with each having a 
            // specific layout. This sequence of layouts is used to determine the interface between 
            // shader stages and shader resources. Each pipeline is created using a pipeline layout.

            // We're not using any resources in this example so we dont
            // need to create any descriptor sets

            var createInfo = new PipelineLayoutCreateInfo();
            return device.CreatePipelineLayout(createInfo);
        }

        Pipeline[] CreatePipelines(PipelineLayout pipelineLayout, RenderPass renderPass, PipelineShaderStageCreateInfo[] shaderStageCreateInfos, VertexData vertexData)
        {
            // Some Vulkan commands specify geometric objects to be drawn or computational work to be 
            // performed, while others specify state controlling how objects are handled by the various 
            // pipeline stages, or control data transfer between memory organized as images and 
            // buffers. Commands are effectively sent through a processing 'pipeline', either a
            // graphics pipeline or a compute pipeline.

            // (In our case, we want a graphics pipeline)

            // The first stage of the graphics pipeline (Input Assembler) assembles vertices to form 
            // geometric primitives such as points, lines, and triangles, based on a requested 
            // primitive topology.
            var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo(PrimitiveTopology.TriangleList, false);

            // In the next stage (Vertex Shader) vertices can be transformed, computing positions and 
            // attributes for each vertex.
            var vertexInputState = new PipelineVertexInputStateCreateInfo(vertexData.BindingDescriptions, vertexData.AttributeDescriptions);

            // The final resulting primitives are clipped to a clip volume in preparation for the next
            // stage, Rasterization. The rasterizer produces a series of framebuffer addresses and 
            // values using a two-dimensional description of a point, line segment, or triangle. Each 
            // fragment so produced is fed to the next stage (Fragment Shader) that performs operations 
            // on individual fragments before they finally alter the framebuffer.
            var rasterizationState = new PipelineRasterizationStateCreateInfo();
            rasterizationState.LineWidth = 1;

            var createInfos = new[]
            {
                new GraphicsPipelineCreateInfo(shaderStageCreateInfos, vertexInputState, inputAssemblyState, rasterizationState, pipelineLayout, renderPass, 0, 0)
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

        Framebuffer CreateFramebuffer(RenderPass renderPass, ImageData imageData)
        {
            // Render passes operate in conjunction with framebuffers, which represent a collection 
            // of specific memory attachments that a render pass instance uses.

            var attachments = new[]{ imageData.View };
            var createInfo = new FramebufferCreateInfo(renderPass, attachments, imageData.Width, imageData.Height, 1);
            return device.CreateFramebuffer(createInfo);
        }

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

        #endregion

        #region Rendering

        void Render(Queue queue, CommandPool cmdPool, VertexData vertexData, ImageData imageData, Buffer imageBuffer, RenderPass renderPass, Pipeline pipeline, Framebuffer framebuffer)
        {
            uint width  = imageData.Width;
            uint height = imageData.Height;

            var cmdBuffers = AllocateCommandBuffers(cmdPool, 1);
            var cmdBuffer  = cmdBuffers[0];

            var beginInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(beginInfo);  // CommandBuffer Begin

            PipelineBarrierSetLayout(cmdBuffer, imageData.Image, ImageLayout.Preinitialized, ImageLayout.ColorAttachmentOptimal, AccessFlags.HostWrite, AccessFlags.ColorAttachmentWrite);

            var clearRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            cmdBuffer.ClearColorImage(imageData.Image, ImageLayout.TransferDstOptimal, new ClearColorValue(), new[]{ clearRange });

            RenderTriangle(cmdBuffer, vertexData, renderPass, pipeline, framebuffer, width, height);

            // Prepare the render target for copying
            PipelineBarrierSetLayout(cmdBuffer, imageData.Image, ImageLayout.ColorAttachmentOptimal, ImageLayout.TransferSrcOptimal, AccessFlags.ColorAttachmentWrite, AccessFlags.TransferRead);

            // Copy the render target image to a buffer
            CopyImageToBuffer(cmdBuffer, imageData, imageBuffer, width, height);

            // End recording commands to the buffer
            cmdBuffer.End();

            SubmitForExecution(queue, cmdBuffer);

            queue.WaitIdle(); // wait for execution to finish

            device.FreeCommandBuffers(cmdPool, new[] { cmdBuffer });
        }

        void RenderTriangle(CommandBuffer cmdBuffer, VertexData vertexData, RenderPass renderPass, Pipeline pipeline, Framebuffer framebuffer, uint width, uint height)
        {
            // Set the viewport
            var viewport = new Viewport(0, 0, width, height, 0, 0);
            cmdBuffer.SetViewport(0, new[]{ viewport });
            
            // Begin the render pass. Just as all commands must be issued between a Begin() 
            // and End() call, certain commands can only be called bewteen BeginRenderPass()
            // and EndRenderPass()
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
        
        void CopyImageToBuffer(CommandBuffer cmdBuffer, ImageData imageData, Buffer imageBuffer, uint width, uint height)
        {
            var subresource = new ImageSubresourceLayers(ImageAspectFlags.Color, 0, 0, 1);
            var imageCopy = new BufferImageCopy(0, width, height, subresource, new Offset3D(0, 0, 0), new Extent3D(width, height, 0));
            cmdBuffer.CopyImageToBuffer(imageData.Image, ImageLayout.TransferSrcOptimal, imageBuffer, new[]{ imageCopy });
        }

        void SubmitForExecution(Queue queue, CommandBuffer cmdBuffer)
        {
            var submitInfo = new SubmitInfo(null, null, new[]{ cmdBuffer }, null);
            queue.Submit(new[]{ submitInfo });
            submitInfo.Dispose();
        }

        #endregion

        void CopyBufferToImage(Queue queue, CommandPool cmdPool, ImageData imageData, Buffer imageBuffer)
        {
            var cmdBuffers = AllocateCommandBuffers(cmdPool, 1);
            var cmdBuffer = cmdBuffers[0];

            var beginInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(beginInfo);

            PipelineBarrierSetLayout(cmdBuffer, imageData.Image, ImageLayout.Preinitialized, ImageLayout.TransferDstOptimal, AccessFlags.HostWrite, AccessFlags.TransferWrite);

            var subresource = new ImageSubresourceLayers(ImageAspectFlags.Color, 0, 0, 1);
            var imageCopy = new BufferImageCopy(0, 0, 0, subresource, new Offset3D(0, 0, 0), new Extent3D(imageData.Width, imageData.Height, 1));
            cmdBuffer.CopyBufferToImage(imageBuffer, imageData.Image, ImageLayout.TransferDstOptimal, new BufferImageCopy[] { imageCopy });

            PipelineBarrierSetLayout(cmdBuffer, imageData.Image, ImageLayout.TransferDstOptimal, ImageLayout.ColorAttachmentOptimal, AccessFlags.TransferWrite, AccessFlags.ColorAttachmentWrite);

            cmdBuffer.End();

            var submitInfo = new SubmitInfo(null, null, new[]{ cmdBuffer }, null);
            queue.Submit(new[]{ submitInfo });
            submitInfo.Dispose();
            queue.WaitIdle();

            device.FreeCommandBuffers(cmdPool, new[]{ cmdBuffer });
        }

        void CopyArrayToBuffer(DeviceMemory bufferMem, DeviceSize size, byte[] data)
        {
            var map = device.MapMemory(bufferMem, 0, size);
            Marshal.Copy(data, 0, map, (int)((ulong)size));
            device.UnmapMemory(bufferMem);
        }

        byte[] CopyBufferToArray(DeviceMemory bufferMem, MemoryRequirements memRequirements)
        {
            var map = device.MapMemory(bufferMem, 0, memRequirements.Size);
            var data = new byte[memRequirements.Size];
            Marshal.Copy(map, data, 0, (int)((ulong)memRequirements.Size));
            device.UnmapMemory(bufferMem);
            return data;
        }

        void WriteBitmap(byte[] imageBytes, string filename, int width, int height)
        {
            // BMP header
            // https://en.wikipedia.org/wiki/BMP_file_format
            var headerBytes = new byte[]
            {
                0x42,0x4D,0x36,0xF9,0x15,0x00,0x00,0x00,0x00,0x00,0x36,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,
                0x00,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0xF9,0x15,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
            };

            var widthBits = BitConverter.GetBytes(width);
            Array.Copy(widthBits, 0, headerBytes, 0x12, 0x4);

            var heightBits = BitConverter.GetBytes(height);
            Array.Copy(heightBits, 0, headerBytes, 0x16, 0x4);

            // Remove every 4th byte (alpha) to convert the image to a 24bpp (RGB) BMP
            imageBytes = imageBytes.Where((x, i) => (i + 1) % 4 != 0).ToArray();

            // The image will be flipped vertically from the correct output,
            // this is because of the BMP format
            imageBytes = imageBytes.Reverse().ToArray();

            var final = headerBytes.ToList();
            final.AddRange(imageBytes);

            File.WriteAllBytes(filename, final.ToArray());
        }

        void PipelineBarrierSetLayout(CommandBuffer cmdBuffer, Image image, ImageLayout oldLayout, ImageLayout newLayout, AccessFlags srcMask, AccessFlags dstMask)
        {
            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            var imageMemoryBarrier = new ImageMemoryBarrier(oldLayout, newLayout, 0, 0, image, subresourceRange);
            imageMemoryBarrier.SrcAccessMask = srcMask;
            imageMemoryBarrier.DstAccessMask = dstMask;
            var imageMemoryBarriers = new[]{ imageMemoryBarrier };
            cmdBuffer.PipelineBarrier(PipelineStageFlags.TopOfPipe, PipelineStageFlags.TopOfPipe, DependencyFlags.None, null, null, imageMemoryBarriers);
            imageMemoryBarrier.Dispose();
        }
        
        uint FindMemoryIndex(MemoryPropertyFlags propertyFlags)
        {
            for(uint x = 0; x < VulkanConstant.MaxMemoryTypes; x++)
                if((physDeviceMem.MemoryTypes[x].PropertyFlags & propertyFlags) == propertyFlags)
                    return x;

            throw new InvalidOperationException();
        }

        Bool32 DebugReport(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData)
        {
            if (messageCode != 0)
                Console.WriteLine(message);
            return false;
        }
    }
}
