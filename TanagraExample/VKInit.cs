using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Vulkan;                     // Core Vulkan classes
using Vulkan.Managed;             // A managed interface to Vulkan
using Vulkan.Managed.ObjectModel; // Extentions to object handles

using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    /*
    ## Instance
    ## └ Physical Device
    ##   └ Device
    ##     ├─ Queue
    ##     ├─ Command Pool
    ##     └─ Command Buffer
    */
    public class VKInit
    {
        // Note: Most of the comments in this example are taken right from the Vulkan spec:
        // https://www.khronos.org/registry/vulkan/specs/1.0/xhtml/vkspec.html
        
        Buffer vertexBuffer;
        DeviceMemory vertexBufferMemory;
        VertexInputBindingDescription[] vertexBindingDescriptions;
        VertexInputAttributeDescription[] vertexAttributeDescriptions;

        DebugReportCallbackEXT debugCallback;

        public VKInit()
        {
            Instance instance;
            List<PhysicalDevice> physicalDevices;
            PhysicalDevice physicalDevice;
            Device device;
            Queue queue;
            CommandPool commandPool;
            List<CommandBuffer> commandBuffers;
            CommandBuffer commandBuffer;

            instance        = CreateInstance();
            physicalDevices = EnumeratePhysicalDevices(instance);
            physicalDevice  = physicalDevices[0];
            device          = CreateDevice(physicalDevice);
            queue           = GetQueue(physicalDevice, device);
            commandPool     = CreateCommandPool(device);
            commandBuffers  = AllocateCommandBuffers(device, commandPool, 1);
            commandBuffer   = commandBuffers[0];

            // Now that we have a command buffer, we could immediately begin
            // recording and submitting commands to the execution queue. You
            // will find however that you can't do much of anything without
            // first initializing a few other dependencies.

            RenderPass renderPass;
            PipelineLayout pipelineLayout;
            List<Pipeline> pipelines;
            Pipeline pipeline;
            Image image;
            ImageView imageView;

            // This exercise would be pointless if we had nothing to render, so
            // lets first create that data.
            CreateVertexBuffer(device);

            renderPass = CreateRenderPass(device);

            // Load shaders from disk and set them up to be passed to `CreatePipeline`
            var shaderStageCreateInfos = new[]
            {
                GetShaderStageCreateInfo(device, ShaderStageFlags.Vertex, "vert.spv"),
                GetShaderStageCreateInfo(device, ShaderStageFlags.Fragment, "frag.spv"),
            };

            pipelineLayout = CreatePipelineLayout(device);
            pipelines = CreatePipeline(device, pipelineLayout, renderPass, shaderStageCreateInfos, vertexBindingDescriptions, vertexAttributeDescriptions);
            pipeline = pipelines[0];
            image = CreateImage(device);
            imageView = CreateImageView(device, image);
        }

        #region  Primary Initialization
        
        Instance CreateInstance()
        {
            // There is no global state in Vulkan and all per-application state is stored in a 
            // `Instance` object. Creating a `Instance` object initializes the Vulkan library 
            // and allows the application to pass information about itself to the implementation.

            // For this example, we want Vulkan to act in a 'default' fashion, so we don't
            // pass and ApplicationInfo object and we don't request any layers or extensions

            var instanceEnabledExtensions = new[]
            {
                VulkanConstant.ExtDebugReportExtensionName,
            };

            var instanceCreateInfo = new InstanceCreateInfo(null, instanceEnabledExtensions);
            var instance = Vk.CreateInstance(instanceCreateInfo);
            debugCallback = DebugUtils.CreateDebugReportCallback(instance, DebugReport);
            return instance;
        }

        List<PhysicalDevice> EnumeratePhysicalDevices(Instance instance)
        {
            // Once Vulkan is initialized, devices and queues are the primary objects used to interact
            // with a Vulkan implementation.
            //
            // Vulkan separates the concept of physical and logical devices. A physical device usually
            // represents a single device in a system (perhaps made up of several individual hardware 
            // devices working together), of which there are a finite number. A logical device 
            // represents an application’s view of the device.

            var physicalDevices = instance.EnumeratePhysicalDevices();

            if(physicalDevices.Count == 0)
                throw new InvalidOperationException("Didn't find any physical devices");

            return physicalDevices;
        }

        Device CreateDevice(PhysicalDevice physicalDevice)
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

            var queueCreateInfo = new DeviceQueueCreateInfo(0, new[] { 0f });
            var deviceCreateInfo = new DeviceCreateInfo(new[] { queueCreateInfo }, null, null);
            return physicalDevice.CreateDevice(deviceCreateInfo);
        }

        Queue GetQueue(PhysicalDevice physicalDevice, Device device)
        {
            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0)
                .Select((properties, index) => index)
                .First();

            return device.GetQueue(0, (uint)queueNodeIndex);
        }

        CommandPool CreateCommandPool(Device device)
        {
            // Command pools are opaque objects that command buffer memory is allocated from, and 
            // which allow the implementation to amortize the cost of resource creation across multiple 
            // command buffers. Command pools are application-synchronized, meaning that a command pool
            // must not be used concurrently in multiple threads. That includes use via recording 
            // commands on any command buffers allocated from the pool, as well as operations that 
            // allocate, free, and reset command buffers or the pool itself.

            var commandPoolCreateInfo = new CommandPoolCreateInfo
            {
                QueueFamilyIndex = 0,
                Flags = CommandPoolCreateFlags.ResetCommandBuffer,
            };
            return device.CreateCommandPool(commandPoolCreateInfo);
        }

        List<CommandBuffer> AllocateCommandBuffers(Device device, CommandPool commandPool, uint buffersToAllocate)
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

            if(commandBuffers.Count == 0)
                throw new InvalidOperationException("Couldn't allocate any command buffers");

            return commandBuffers;
        }

        #endregion

        void CreateVertexBuffer(Device device)
        {
            var triangleVertices = new[,]
            {
                {  0.0f, -0.5f,  0.5f, /* UV Coordinates: */ 1.0f, 0.0f, 0.0f },
                {  0.5f,  0.5f,  0.5f, /* UV Coordinates: */ 0.0f, 1.0f, 0.0f },
                { -0.5f,  0.5f,  0.5f, /* UV Coordinates: */ 0.0f, 0.0f, 1.0f },
            };

            var memorySize = (ulong)(sizeof(float) * triangleVertices.Length);
            var createInfo = new BufferCreateInfo(memorySize, BufferUsageFlags.VertexBuffer, SharingMode.Exclusive, null);
            vertexBuffer = device.CreateBuffer(createInfo);

            var memoryRequirements = device.GetBufferMemoryRequirements(vertexBuffer);
            if(memoryRequirements.Size == 0)
                throw new InvalidOperationException();

            var allocateInfo = new MemoryAllocateInfo(memoryRequirements.Size, 2); // MemoryTypeIndex = 2, TODO
            vertexBufferMemory = device.AllocateMemory(allocateInfo);

            var mapped = device.MapMemory(vertexBufferMemory, 0, createInfo.Size, MemoryMapFlags.None);
            MemoryUtils.Copy2DArray(triangleVertices, mapped, createInfo.Size, createInfo.Size);
            device.UnmapMemory(vertexBufferMemory);

            device.BindBufferMemory(vertexBuffer, vertexBufferMemory, 0);

            vertexBindingDescriptions = new[]
            {
                new VertexInputBindingDescription(0, (uint)(sizeof(float) * triangleVertices.GetLength(1)), VertexInputRate.Vertex)
            };

            vertexAttributeDescriptions = new[]
            {
                new VertexInputAttributeDescription(0, 0, Format.R32g32b32Sfloat, 0),
                new VertexInputAttributeDescription(1, 0, Format.R32g32b32Sfloat, sizeof(float) * 3)
            };
        }

        RenderPass CreateRenderPass(Device device)
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
                    Format         = Format.B8g8r8a8Unorm,
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
        
        PipelineShaderStageCreateInfo GetShaderStageCreateInfo(Device device, ShaderStageFlags stage, string filename, string entrypoint = "main\0")
        {
            var shaderBytes = File.ReadAllBytes(filename);
            var shaderModule = CreateShaderModule(device, shaderBytes);
            return new PipelineShaderStageCreateInfo(stage, shaderModule, entrypoint);
        }

        ShaderModule CreateShaderModule(Device device, byte[] shaderCode)
        {
            var createInfo = new ShaderModuleCreateInfo(shaderCode);
            return device.CreateShaderModule(createInfo);
        }

        PipelineLayout CreatePipelineLayout(Device device)
        {
            // The pipeline layout represents a sequence of descriptor sets with each having a 
            // specific layout. This sequence of layouts is used to determine the interface between 
            // shader stages and shader resources. Each pipeline is created using a pipeline layout.

            // We're not using any resources in this example so we dont
            // need to create any descriptor sets

            var createInfo = new PipelineLayoutCreateInfo();
            return device.CreatePipelineLayout(createInfo);
        }

        List<Pipeline> CreatePipeline(Device device, PipelineLayout pipelineLayout, RenderPass renderPass, PipelineShaderStageCreateInfo[] shaderStageCreateInfos, VertexInputBindingDescription[] vertexBindingDescriptions, VertexInputAttributeDescription[] vertexAttributeDescriptions)
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
            var vertexInputState = new PipelineVertexInputStateCreateInfo(vertexBindingDescriptions, vertexAttributeDescriptions);

            // The final resulting primitives are clipped to a clip volume in preparation for the next
            // stage, Rasterization. The rasterizer produces a series of framebuffer addresses and 
            // values using a two-dimensional description of a point, line segment, or triangle. Each 
            // fragment so produced is fed to the next stage (Fragment Shader) that performs operations 
            // on individual fragments before they finally alter the framebuffer.
            var rasterizationState = new PipelineRasterizationStateCreateInfo
            {
                FrontFace   = FrontFace.Clockwise,
            };

            var createInfos = new[]
            {
                new GraphicsPipelineCreateInfo(shaderStageCreateInfos, vertexInputState, inputAssemblyState, rasterizationState, pipelineLayout, renderPass, 0, 0)
            };

            return device.CreateGraphicsPipelines(null, createInfos.ToList());
        }

        Image CreateImage(Device device)
        {
            // Images represent multidimensional - up to 3 - arrays of data which can be used for 
            // various purposes (e.g. attachments, textures), by binding them to a graphics or 
            // compute pipeline via descriptor sets, or by directly specifying them as parameters 
            // to certain commands.

            /*var createImageInfo = new ImageCreateInfo
            {
                ImageType     = ImageType.ImageType2d,
                Format        = Format.B8g8r8a8Unorm,
                Extent        = new Extent3D(32, 32, 1),
                Samples       = SampleCountFlags.SampleCountFlags1,
                Usage         = ImageUsageFlags.ColorAttachment,
                InitialLayout = ImageLayout.ColorAttachmentOptimal,
                MipLevels = 1,
                ArrayLayers = 1,
            };*/
            var size = new Extent3D(800, 600, 1);
            var createImageInfo = new ImageCreateInfo(ImageType.ImageType2d, Format.B8g8r8a8Unorm, size, 1, 1, SampleCountFlags.SampleCountFlags1, ImageTiling.Optimal, ImageUsageFlags.ColorAttachment, SharingMode.Exclusive, null, ImageLayout.Undefined);
            return device.CreateImage(createImageInfo);
        }

        ImageView CreateImageView(Device device, Image image)
        {
            // Image objects are not directly accessed by pipeline shaders for reading or writing 
            // image data. Instead, image views representing contiguous ranges of the image 
            // subresources and containing additional metadata are used for that purpose. Views must 
            // be created on images of compatible types, and must represent a valid subset of image 
            // subresources.

            var subresourceRange = new ImageSubresourceRange(ImageAspectFlags.Color, 0, 1, 0, 1);
            var components = new ComponentMapping(ComponentSwizzle.R, ComponentSwizzle.G, ComponentSwizzle.B, ComponentSwizzle.A);
            var createInfo = new ImageViewCreateInfo(image, ImageViewType.ImageViewType2d, Format.B8g8r8a8Unorm, components, subresourceRange);
            return device.CreateImageView(createInfo);
        }
        
        private Bool32 DebugReport(DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, ulong @object, IntPtr location, int messageCode, string layerPrefix, string message, IntPtr userData)
        {
            Console.WriteLine($"[VULK] [{flags}] {message} ([{messageCode}] {layerPrefix})");
            return true;
        }
    }
}
