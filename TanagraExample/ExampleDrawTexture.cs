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
    public class ExampleDrawTexture
    {
        class VertexData
        {
            public Buffer Buffer;
            public DeviceMemory DeviceMemory;
            public VertexInputBindingDescription[] BindingDescriptions;
            public VertexInputAttributeDescription[] AttributeDescriptions;
            public int[] Indicies;
        }

        class ImageData
        {
            public uint Width;
            public uint Height;
            public Image Image;
            public DeviceMemory Memory;
            public ImageView View;
            public Sampler Sampler;
        }

        class SwapchainData
        {
            public SwapchainKHR Swapchain;
            public List<ImageData> Images;
            public List<Framebuffer> Framebuffers;
            public Format ImageFormat;
        }
        
        class UniformData
        {
            public Buffer Buffer;
            public DeviceMemory Memory;
            public DescriptorBufferInfo Descriptor;
            public uint AllocSize;
            public IntPtr Mapped;
        }

        struct UBO
        {
            public OpenTK.Matrix4 projection;
            public OpenTK.Matrix4 model;
            public OpenTK.Vector4 viewPos;
            public float lodBias;
        }

        const Format ImageFormat = Format.R8g8b8a8Unorm;

        // Device is held as a class member because its used in
        // basically every operation after it's been created.
        Device device;
        
        PhysicalDeviceMemoryProperties physDeviceMem;
        DebugReportCallbackEXT debugCallback;

        static List<ShaderModule> shaders = new List<ShaderModule>();
        static List<PipelineShaderStageCreateInfo> shaderInfos = new List<PipelineShaderStageCreateInfo>();

        public ExampleDrawTexture()
        {
            // The goal of this example is to:
            //
            // - Initialize Vulkan
            // - Create a surface object to interact with a display
            // - Render a triangle to the screen
            //
            
            var window = new RenderForm(nameof(ExampleRenderToWindow));

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

            // Now that we have a command pool, we can begin creating command buffers 
            // and recording commands. You will find however that you can't do much of 
            // anything without first initializing a few more dependencies.

            const float zoom = -2.5f;
            // rotation = { 0.0f, 15.0f, 0.0f };

            var textureData = LoadTexture("./ThisSideUp.jpg", queue, cmdPool);
            var uniform = CreateUniformBuffer(typeof(UBO));
            var ubo = new UBO();
            UpdateUBO(ubo, imageWidth, imageHeight, zoom);
            CopyUBO(ubo, uniform);

            VertexData vertexData;
            RenderPass renderPass;
            PipelineLayout pipelineLayout;
            Pipeline[] pipelines;
            Pipeline pipeline;
            
            // This exercise would be pointless if we had nothing to 
            // render, so lets create that data now.
            vertexData = CreateVertexData();

            // Load shaders from disk and set them up to be passed to `CreatePipeline`
            shaderInfos.Add(GetShaderStageCreateInfo(ShaderStageFlags.Vertex, "./texture.vert.spv"));
            shaderInfos.Add(GetShaderStageCreateInfo(ShaderStageFlags.Fragment, "./texture.frag.spv"));

            // Create the render dependencies
            swapchainData        = CreateSwapchain(physDevice, surface, imageWidth, imageHeight);
            swapchainImages      = device.GetSwapchainImagesKHR(swapchainData.Swapchain);
            swapchainData.Images = InitializeSwapchainImages(queue, cmdPool, swapchainImages, swapchainData.ImageFormat);
            
            renderPass = CreateRenderPass(swapchainData.ImageFormat);

            swapchainData.Framebuffers = swapchainData.Images
                .Select(x => CreateFramebuffer(renderPass, x))
                .ToList();

            pipelineLayout = CreatePipelineLayout();
            pipelines      = CreatePipelines(pipelineLayout, renderPass, shaderInfos.ToArray(), vertexData);
            pipeline       = pipelines.First();
            
            var cmdBuffers = AllocateCommandBuffers(cmdPool, 1);
            var cmdBuffer  = cmdBuffers.First();
            
            RenderLoop.Run(window, () => Render(queue, cmdBuffer, vertexData, renderPass, pipeline, swapchainData));
            
            #region Shutdown
            // Destroy Vulkan handles in reverse order of creation (roughly)
            // todo
            #endregion
        }

        #region  Primary Initialization

        Instance CreateInstance()
        {
            // There is no global state in Vulkan and all per-application state is stored in a 
            // `Instance` object. Creating a `Instance` object initializes the Vulkan library 
            // and allows the application to pass information about itself to the implementation.

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
                //"VK_LAYER_LUNARG_standard_validation"
            };

            var enabledExtensions = new[]
            {
                VulkanConstant.KhrSwapchainExtensionName,
            };

            var features = new PhysicalDeviceFeatures();
            features.ShaderClipDistance = true;

            var queueCreateInfo = new DeviceQueueCreateInfo(queueFamily, new[]{ 0f });
            var deviceCreateInfo = new DeviceCreateInfo(new[]{ queueCreateInfo }, enabledLayers, enabledExtensions);
            deviceCreateInfo.EnabledFeatures = features;
            return physicalDevice.CreateDevice(deviceCreateInfo);
        }

        Queue GetQueue(PhysicalDevice physicalDevice, uint queueFamily)
        {
            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((p, i) => (p.QueueFlags & QueueFlags.Graphics) != 0)
                .Select((p, i) => i)
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
            var cmdBuffer  = cmdBuffers[0];

            var inheritanceInfo = new CommandBufferInheritanceInfo();
            var beginInfo = new CommandBufferBeginInfo { InheritanceInfo = inheritanceInfo };
            cmdBuffer.Begin(beginInfo);  // CommandBuffer Begin
            
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
                var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
                var createInfo = new ImageViewCreateInfo(img, ImageViewType.ImageViewType2d, imageFormat, new ComponentMapping(), subresourceRange);
                imgData.View = device.CreateImageView(createInfo);
                imageDatas.Add(imgData);
            }

            return imageDatas;
        }

        #endregion

        #region Dependencies

        VertexData CreateVertexData()
        {
            var data = new VertexData();

            var quadVertices = new[,]
            {
                {  1.0f,  1.0f,  0.0f, /* UV: */ 1.0f, 1.0f, /* Normal: */ 0.0f, 0.0f, 1.0f },
                { -1.0f,  1.0f,  0.0f, /* UV: */ 0.0f, 1.0f, /* Normal: */ 0.0f, 0.0f, 1.0f },
                { -1.0f, -1.0f,  0.0f, /* UV: */ 0.0f, 0.0f, /* Normal: */ 0.0f, 0.0f, 1.0f },
                {  1.0f, -1.0f,  0.0f, /* UV: */ 1.0f, 0.0f, /* Normal: */ 0.0f, 0.0f, 1.0f },
            };

            DeviceSize memorySize = (ulong)(sizeof(float) * quadVertices.Length);
            data.Buffer = CreateBuffer(memorySize, BufferUsageFlags.VertexBuffer);

            var memoryRequirements = device.GetBufferMemoryRequirements(data.Buffer);
            var memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            var allocateInfo = new MemoryAllocateInfo(memoryRequirements.Size, memoryIndex);
            data.DeviceMemory = BindBuffer(data.Buffer, allocateInfo);
            
            var mapped = device.MapMemory(data.DeviceMemory, 0, memorySize);
            VulkanUtils.Copy2DArray(quadVertices, mapped, memorySize, memorySize);
            device.UnmapMemory(data.DeviceMemory);

            data.Indicies = new[] { 0,1,2, 2,3,0 };

            data.BindingDescriptions = new[]
            {
                new VertexInputBindingDescription(0, (uint)(sizeof(float) * quadVertices.GetLength(1)), VertexInputRate.Vertex)
            };

            data.AttributeDescriptions = new[]
            {
                new VertexInputAttributeDescription(0, 0, Format.R32g32b32Sfloat, 0),                 // Vertex: X, Y, Z
                new VertexInputAttributeDescription(1, 0, Format.R32g32Sfloat, sizeof(float) * 3),    // UV: U, V
                new VertexInputAttributeDescription(2, 0, Format.R32g32b32Sfloat, sizeof(float) * 5), // Normal: X, Y, Z
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
            var components = new ComponentMapping(ComponentSwizzle.R, ComponentSwizzle.G, ComponentSwizzle.B, ComponentSwizzle.A);
            var createInfo = new ImageViewCreateInfo(image, ImageViewType.ImageViewType2d, imageFormat, components, subresourceRange);
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

        PipelineLayout CreatePipelineLayout(DescriptorSetLayout layout)
        {
            // The pipeline layout represents a sequence of descriptor sets with each having a 
            // specific layout. This sequence of layouts is used to determine the interface between 
            // shader stages and shader resources. Each pipeline is created using a pipeline layout.
            
            var createInfo = new PipelineLayoutCreateInfo(new[]{ layout }, null);
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
            //rasterizationState.RasterizerDiscardEnable = true;
            rasterizationState.LineWidth = 1;

            //PipelineDepthStencilStateCreateInfo
            //PipelineDynamicStateCreateInfo
            //viewportState
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

        ImageData LoadTexture(string filename, Queue queue, CommandPool cmdPool)
        {
            //
            var bmp = new Bitmap(filename);

            var bitmapFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            var bitmapData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmapFormat);
            //
            
            uint imageWidth  = (uint)bmp.Width;
            uint imageHeight = (uint)bmp.Height;

            var imageData    = new ImageData();
            imageData.Width  = imageWidth;
            imageData.Height = imageHeight;
            imageData.Image  = CreateImage(ImageFormat, imageWidth, imageHeight);
            imageData.Memory = BindImage(imageData.Image);
            imageData.View   = CreateImageView(imageData.Image, ImageFormat);
            
            var memRequirements = device.GetImageMemoryRequirements(imageData.Image);
            var imageBuffer = CreateBuffer(memRequirements.Size, BufferUsageFlags.TransferSrc | BufferUsageFlags.TransferDst);
            var memoryIndex = FindMemoryIndex(MemoryPropertyFlags.HostVisible);
            var memAlloc = new MemoryAllocateInfo(memRequirements.Size, memoryIndex);
            imageData.Memory = BindBuffer(imageBuffer, memAlloc);
            CopyBitmapToBuffer(bitmapData.Scan0, (int)(imageWidth * imageHeight * 3), imageData.Memory, memRequirements);
            CopyBufferToImage(queue, cmdPool, imageData, imageBuffer);

            //
            bmp.UnlockBits(bitmapData);
            bmp.Dispose();
            //

            return imageData;
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

            data.Descriptor = new DescriptorBufferInfo(data.Buffer, 0, memAlloc.AllocationSize);

            return data;
        }

        void UpdateUBO(UBO ubo, float width, float height, float zoom)
        {
            ubo.projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(DegreesToRadians(60), width / height, 0.001f, 256.0f);

            var viewMatrix = OpenTK.Matrix4.CreateTranslation(0, 0, zoom);
            ubo.model = OpenTK.Matrix4.Identity;

            ubo.viewPos = new OpenTK.Vector4(0, 0, -zoom, 0);

            //return ubo;
        }

        void CopyUBO(UBO ubo, UniformData uniform)
        {
            if(uniform.Mapped == IntPtr.Zero)
                uniform.Mapped = device.MapMemory(uniform.Memory, 0, uniform.AllocSize);
            
            var size = Marshal.SizeOf(typeof(UBO));
            var bytes = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(ubo, ptr, true);
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);

            Marshal.Copy(bytes, 0, uniform.Mapped, size);
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

            var createInfo = new DescriptorSetLayoutCreateInfo(layoutBindings);
            return device.CreateDescriptorSetLayout(createInfo);
        }

        void InitializeDescriptorSet(DescriptorPool pool, DescriptorSetLayout layout, Sampler sampler, ImageData imageData, UniformData uniformData)
        {
            var allocInfo = new DescriptorSetAllocateInfo(pool, new[] { layout });
            var sets = device.AllocateDescriptorSets(allocInfo);
            var descriptorSet = sets.First();
            var texDescriptor = new DescriptorImageInfo(imageData.Sampler, imageData.View, ImageLayout.General);
            var writeDescriptorSets = new[]
            {
                new WriteDescriptorSet(descriptorSet, 0, 0, DescriptorType.UniformBuffer, null, new[]{ uniformData.Descriptor }, null),
                new WriteDescriptorSet(descriptorSet, 1, 0, DescriptorType.CombinedImageSampler, new[]{ texDescriptor }, null, null),
            };
            device.UpdateDescriptorSets(writeDescriptorSets, null);
        }

        #region Rendering

        void Render(Queue queue, CommandBuffer cmdBuffer, VertexData vertexData, RenderPass renderPass, Pipeline pipeline, SwapchainData swapchainData)
        {
            var semaphoreCreateInfo = new SemaphoreCreateInfo();
            var presentSemaphore = device.CreateSemaphore(semaphoreCreateInfo);
            semaphoreCreateInfo.Dispose();

            var currentBufferIndex = (int)device.AcquireNextImageKHR(swapchainData.Swapchain, ulong.MaxValue, presentSemaphore, null);

            var beginInfo = new CommandBufferBeginInfo();
            cmdBuffer.Begin(beginInfo);  // CommandBuffer Begin
            beginInfo.Dispose();

            PipelineBarrierSetLayout(cmdBuffer, swapchainData.Images[currentBufferIndex].Image, ImageLayout.PresentSrcKHR, ImageLayout.ColorAttachmentOptimal, AccessFlags.MemoryRead, AccessFlags.ColorAttachmentWrite);

            var clearRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            cmdBuffer.CmdClearColorImage(swapchainData.Images[currentBufferIndex].Image, ImageLayout.TransferDstOptimal, new ClearColorValue(), new[] { clearRange });

            RenderTriangle(cmdBuffer, vertexData, swapchainData.Images[currentBufferIndex], renderPass, pipeline, swapchainData.Framebuffers[currentBufferIndex]);

            PipelineBarrierSetLayout(cmdBuffer, swapchainData.Images[currentBufferIndex].Image, ImageLayout.ColorAttachmentOptimal, ImageLayout.PresentSrcKHR, AccessFlags.ColorAttachmentWrite, AccessFlags.MemoryRead);

            // End recording commands to the buffer
            cmdBuffer.End();

            SubmitForExecution(queue, presentSemaphore, cmdBuffer);

            // Present the image (display it on the screen)
            var presentInfo = new PresentInfoKHR(new[]{ swapchainData.Swapchain }, new[]{ (uint)currentBufferIndex });
            queue.PresentKHR(presentInfo);
            presentInfo.Dispose();

            queue.WaitIdle(); // wait for execution to finish

            device.DestroySemaphore(presentSemaphore);
        }

        void RenderTriangle(CommandBuffer cmdBuffer, VertexData vertexData, ImageData imageData, RenderPass renderPass, Pipeline pipeline, Framebuffer framebuffer)
        {
            uint width  = imageData.Width;
            uint height = imageData.Height;
            
            // Set the viewport
            var viewport = new Viewport(0, 0, width, height, 0, 0);
            cmdBuffer.CmdSetViewport(0, new[]{ viewport });
            
            // Begin the render pass. Just as all commands must be issued between a Begin() 
            // and End() call, certain commands can only be called bewteen CmdBeginRenderPass()
            // and CmdEndRenderPass()
            var renderArea = new Rect2D(new Offset2D(0, 0), new Extent2D(width, height));
            var renderPassBegin = new RenderPassBeginInfo(renderPass, framebuffer, renderArea, null);
            cmdBuffer.CmdBeginRenderPass(renderPassBegin, SubpassContents.Inline);
            renderPassBegin.Dispose();

            cmdBuffer.CmdBindPipeline(PipelineBindPoint.Graphics, pipeline);

            // Render the triangle
            cmdBuffer.CmdBindVertexBuffers(0, new[] { vertexData.Buffer }, new DeviceSize[] { 0 });
            cmdBuffer.CmdDraw(3, 1, 0, 0);

            // End the RenderPass
            cmdBuffer.CmdEndRenderPass();
        }
        
        void CopyImageToBuffer(CommandBuffer cmdBuffer, ImageData imageData, Buffer imageBuffer, uint width, uint height)
        {
            var subresource = new ImageSubresourceLayers(ImageAspectFlags.Color, 0, 0, 1);
            var imageCopy = new BufferImageCopy(0, width, height, subresource, new Offset3D(0, 0, 0), new Extent3D(width, height, 0));
            cmdBuffer.CmdCopyImageToBuffer(imageData.Image, ImageLayout.TransferSrcOptimal, imageBuffer, new[]{ imageCopy });
        }

        void SubmitForExecution(Queue queue, Semaphore presentSemaphore, CommandBuffer cmdBuffer)
        {
            var submitInfo = new SubmitInfo(new[]{ presentSemaphore }, null, new[]{ cmdBuffer }, null);
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
            cmdBuffer.CmdCopyBufferToImage(imageBuffer, imageData.Image, ImageLayout.TransferDstOptimal, new BufferImageCopy[] { imageCopy });

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

        void CopyBitmapToBuffer(IntPtr scan0, int bitmapSize, DeviceMemory bufferMem, MemoryRequirements memRequirements)
        {
            var map = device.MapMemory(bufferMem, 0, memRequirements.Size);
            Copy(scan0, map, bitmapSize); // (int)(imageWidth * imageHeight * 3)
            device.UnmapMemory(bufferMem);
        }

        void Copy(IntPtr src, IntPtr dest, int size)
        {
            var data = new byte[size];
            Marshal.Copy(src, data, 0, size);
            Marshal.Copy(data, 0, dest, size);
        }

        void WriteBitmap(byte[] imageBytes, string filename)
        {
            // BMP header
            // https://en.wikipedia.org/wiki/BMP_file_format
            var headerBytes = new byte[]
            {
                0x42,0x4D,0x36,0xF9,0x15,0x00,0x00,0x00,0x00,0x00,0x36,0x00,0x00,0x00,0x28,0x00,0x00,0x00,0x20,0x03,0x00,0x00,0x58,0x02,0x00,0x00,0x01,
                0x00,0x18,0x00,0x00,0x00,0x00,0x00,0x00,0xF9,0x15,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00
            };

            // Remove every 4th byte (alpha) to convert the image to a 24bpp (RGB) BMP
            imageBytes = imageBytes.Where((x, i) => (i + 1) % 4 != 0).ToArray();

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
            cmdBuffer.CmdPipelineBarrier(PipelineStageFlags.TopOfPipe, PipelineStageFlags.TopOfPipe, DependencyFlags.None, null, null, imageMemoryBarriers);
            imageMemoryBarrier.Dispose();
        }
        
        uint FindMemoryIndex(MemoryPropertyFlags propertyFlags)
        {
            for(uint x = 0; x < VulkanConstant.MaxMemoryTypes; x++)
                if((physDeviceMem.MemoryTypes[x].PropertyFlags & propertyFlags) == propertyFlags)
                    return x;

            throw new InvalidOperationException();
        }

        float DegreesToRadians(float degrees)
        {
            const float degToRad = (float)System.Math.PI / 180.0f;
            return degrees * degToRad;
        }

        private Bool32 DebugReport(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData)
        {
            if(messageCode != 0) Console.WriteLine(message);
            return true;
        }
    }
}
