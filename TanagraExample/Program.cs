using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

using SharpDX;
using SharpDX.Text;
using SharpDX.Windows;

using Tanagra;
using Vulkan;
using Vulkan.ObjectModel;

using ImageLayout = Vulkan.ImageLayout;
using Buffer = Vulkan.Buffer;

namespace TanagraExample
{
    class Program
    {
        static Form form;

        // Handles
        static Instance instance;
        static PhysicalDevice physicalDevice;
        static SurfaceKHR surface;
        static Device device;
        static Queue queue;
        static CommandPool commandPool;
        static List<CommandBuffer> commandBuffer;
        static CommandBuffer setupCommanBuffer;
        static SwapchainKHR swapchain;

        static Format backBufferFormat;
        static List<Image> backBuffers;
        static List<ImageView> backBufferViews;

        static RenderPass renderPass;
        static PipelineLayout pipelineLayout;
        static List<Pipeline> pipeline;
        static Framebuffer[] framebuffers;

        static Buffer vertexBuffer;
        static DeviceMemory vertexBufferMemory;
        static VertexInputAttributeDescription[] vertexAttributes;
        static VertexInputBindingDescription[] vertexBindings;

        static void Main(string[] args)
        {
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
            //CreatePipeline();
            CreateFramebuffers();

            Console.WriteLine("program complete");
            Console.ReadKey();
        }

        static void CreateInstance()
        {
            var version = MakeVersion(1, 0, 8);
            var ver = new Tanagra.Version(version);
            Console.WriteLine($"version {ver}");

            var appInfo = new ApplicationInfo();
            appInfo.ApplicationName = "vulkanExample";
            appInfo.EngineName = "vulkanExample";
            appInfo.ApiVersion = version;

            var instanceEnabledExtensions = new[]
            {
                "VK_KHR_surface",       // VK_KHR_SURFACE_EXTENSION_NAME
                "VK_KHR_win32_surface", // VK_KHR_WIN32_SURFACE_EXTENSION_NAME
            };

            var instanceCreateInfo = new InstanceCreateInfo();
            instanceCreateInfo.ApplicationInfo = appInfo;
            instanceCreateInfo.EnabledExtensionNames = instanceEnabledExtensions;

            Console.WriteLine(instanceCreateInfo.ApplicationInfo.ApplicationName);

            instance = VK.CreateInstance(instanceCreateInfo);
            Console.WriteLine($"[ OK ] Instance {instance}");

            var physicalDevices = instance.EnumeratePhysicalDevices();
            Console.WriteLine($"[INFO] Physical Devices: {physicalDevices.Count}");

            physicalDevice = physicalDevices[0];
            Console.WriteLine($"[ OK ] Physical Device {physicalDevice}");

            PhysicalDeviceProperties();
        }

        static void CreateDevice()
        {
            var queueCreateInfo = new DeviceQueueCreateInfo
            {
                QueueFamilyIndex = 0,
                QueueCount       = 1,
                QueuePriorities  = 0,
            };

            var deviceEnabledExtensions = new[]
            {
                "VK_KHR_swapchain",
            };

            var deviceCreateInfo = new DeviceCreateInfo
            {
                QueueCreateInfoCount  = 1,
                QueueCreateInfos      = queueCreateInfo,
                EnabledExtensionNames = deviceEnabledExtensions,
            };

            device = physicalDevice.CreateDevice(deviceCreateInfo);
            Console.WriteLine("[ OK ] Device " + device);

            Console.WriteLine($"[INFO] Begin GetQueueFamilyProperties");
            var queueNodeIndex = physicalDevice.GetQueueFamilyProperties()
                .Where((properties, index) => (properties.QueueFlags & QueueFlags.Graphics) != 0 && physicalDevice.GetSurfaceSupportKHR((uint)index, surface))
                .Select((properties, index) => index)
                .First();

            queue = device.GetQueue(0, (uint)queueNodeIndex);
            Console.WriteLine($"[ OK ] Queue {queue}");
        }

        static void CreateSurface()
        {
            IntPtr HINSTANCE, HWND;
            GetProcessHandles(out HINSTANCE, out HWND);
            var surfaceCreateInfo = new Win32SurfaceCreateInfoKHR
            {
                Hinstance = HINSTANCE,
                Hwnd = form.Handle//HWND,
            };
            surface = instance.CreateWin32SurfaceKHR(surfaceCreateInfo);
            Console.WriteLine($"[ OK ] Surface {surface}");
        }

        static void CreateCommandBuffer()
        {
            // Command pool
            var commandPoolCreateInfo = new CommandPoolCreateInfo
            {
                QueueFamilyIndex = 0,
                Flags = CommandPoolCreateFlags.ResetCommandBuffer,
            };
            commandPool = device.CreateCommandPool(commandPoolCreateInfo);
            Console.WriteLine($"[ OK ] Command Pool {commandPool}");

            // Command Buffer
            var commandBufferAllocationInfo = new CommandBufferAllocateInfo
            {
                Level              = CommandBufferLevel.Primary,
                CommandPool        = commandPool,
                CommandBufferCount = 1,
            };
            commandBuffer = device.AllocateCommandBuffers(commandBufferAllocationInfo);
            Console.WriteLine("[INFO] commandBuffers: " + commandBuffer.Count);
            Console.WriteLine("[ OK ] Command Buffer " + commandBuffer[0]);
            //if (!commandBuffer[0].IsValid) throw new Exception();
        }

        static void CreateSwapchain()
        {
            // surface format
            var surfaceFormats = physicalDevice.GetSurfaceFormatsKHR(surface);
            if(surfaceFormats.Count == 1 && surfaceFormats[0].Format == Format.Undefined)
            {
                backBufferFormat = Format.B8g8r8a8Unorm;
                Console.WriteLine($"using default backBufferFormat {backBufferFormat}");
            }
            else
            {
                backBufferFormat = surfaceFormats[0].Format;
                Console.WriteLine($"backBufferFormat {backBufferFormat}");
            }

            var surfaceCapabilities = physicalDevice.GetSurfaceCapabilitiesKHR(surface);

            // Buffer count
            var desiredImageCount = surfaceCapabilities.MinImageCount + 1;
            if(surfaceCapabilities.MaxImageCount > 0 && desiredImageCount > surfaceCapabilities.MaxImageCount)
            {
                desiredImageCount = surfaceCapabilities.MaxImageCount;
            }

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

            Console.WriteLine($"swapChainPresentMode {swapChainPresentMode}");

            var imageExtent = new Extent2D { Width = (uint)form.ClientSize.Width, Height = (uint)form.ClientSize.Height };
            // Create swapchain
            var swapchainCreateInfo = new SwapchainCreateInfoKHR
            {
                Surface          = surface,
                ImageSharingMode = SharingMode.Exclusive,
                ImageExtent      = imageExtent,
                ImageArrayLayers = 1,
                ImageFormat      = backBufferFormat,
                ImageColorSpace  = ColorSpaceKHR.ColorspaceSrgbNonlinear,
                ImageUsage       = ImageUsageFlags.ColorAttachment,
                PresentMode      = swapChainPresentMode,
                CompositeAlpha   = CompositeAlphaFlagsKHR.Opaque,
                MinImageCount    = desiredImageCount,
                PreTransform     = preTransform,
                Clipped          = true,
            };
            swapchain = device.CreateSwapchainKHR(swapchainCreateInfo);
            Console.WriteLine($"[ OK ] Swapchain {swapchain}");

            backBuffers = device.GetSwapchainImagesKHR(swapchain);
            Console.WriteLine($"[INFO] backBuffers {backBuffers.Count}");
            foreach(var image in backBuffers)
            {
                SetImageLayout(image, ImageAspectFlags.Color, ImageLayout.Undefined, ImageLayout.PresentSrcKHR);
            }
            Flush();
        }

        static void SetImageLayout(Image image, ImageAspectFlags imageAspect, ImageLayout oldLayout, ImageLayout newLayout)
        {
            if(setupCommanBuffer == null)
            {
                CommandBuffer setupBuffer;
                var allocateInfo = new CommandBufferAllocateInfo
                {
                    CommandPool = commandPool,
                    Level = CommandBufferLevel.Primary,
                    CommandBufferCount = 1,
                };
                setupBuffer = device.AllocateCommandBuffers(allocateInfo)[0];
                setupCommanBuffer = setupBuffer;
                Console.WriteLine($"[ OK ] Command Buffer {setupCommanBuffer}");

                var inheritanceInfo = new CommandBufferInheritanceInfo();
                var beginInfo = new CommandBufferBeginInfo
                {
                    InheritanceInfo = inheritanceInfo
                };
                setupCommanBuffer.Begin(beginInfo);
                Console.WriteLine("[ OK ] setupCommanBuffer.Begin");
            }

            var imageMemoryBarrier = new ImageMemoryBarrier
            {
                OldLayout = oldLayout,
                NewLayout = newLayout,
                Image = image,
                SubresourceRange = new ImageSubresourceRange
                {
                    AspectMask     = imageAspect,
                    BaseArrayLayer = 0,
                    LayerCount     = 1,
                    BaseMipLevel   = 0,
                    LevelCount     = 1,
                }
            };

            switch(newLayout)
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

            setupCommanBuffer.CmdPipelineBarrier(sourceStages, destinationStages, DependencyFlags.None, new List<MemoryBarrier>(), new List<BufferMemoryBarrier>(), new List<ImageMemoryBarrier> { imageMemoryBarrier });
            Console.WriteLine("[ OK ] setupCommanBuffer.CmdPipelineBarrier");
        }

        static void Flush()
        {
            if(setupCommanBuffer == null)
                return;

            setupCommanBuffer.End();
            Console.WriteLine("[ OK ] setupCommanBuffer.End");

            var submitInfo = new SubmitInfo
            {
                CommandBufferCount = 1,
                CommandBuffers     = setupCommanBuffer
            };

            try
            {
                queue.Submit(new List<SubmitInfo> { submitInfo }, null);
            }
            catch(Exception e)
            {
                Console.WriteLine($"[FAIL] {e.Message}");
                //https://www.khronos.org/registry/vulkan/specs/1.0/xhtml/vkspec.html#devsandqueues-lost-device
                //queue = device.GetQueue(0, 0U);
                //Console.WriteLine("[ OK ] Queue " + queue);
            }

            Console.WriteLine("[ OK ] queue.Submit");

            queue.WaitIdle();
            Console.WriteLine("[ OK ] queue.WaitIdle");

            device.FreeCommandBuffers(commandPool, new List<CommandBuffer> { setupCommanBuffer });
            Console.WriteLine("[ OK ] device.FreeCommandBuffers");

            setupCommanBuffer = null;
        }

        static void CreateBackBufferViews()
        {
            backBufferViews = new List<ImageView>();
            for(int x = 0; x < backBuffers.Count; x++)
            {
                var createInfo = new ImageViewCreateInfo
                {
                    ViewType = ImageViewType.ImageViewType2d,
                    Format = backBufferFormat,
                    Image = backBuffers[x],
                    Components = new ComponentMapping(),
                    SubresourceRange = new ImageSubresourceRange
                    {
                        AspectMask     = ImageAspectFlags.Color,
                        BaseArrayLayer = 0,
                        LayerCount     = 1,
                        BaseMipLevel   = 0,
                        LevelCount     = 1,
                    }
                };

                backBufferViews.Add(device.CreateImageView(createInfo));
            }
            Console.WriteLine($"[INFO] backBufferViews {backBufferViews.Count}");
        }

        static void CreateVertexBuffer()
        {
            var vertices = new[,]
            {
                {  0.0f, -0.5f,  0.5f, 1.0f, 0.0f, 0.0f },
                {  0.5f,  0.5f,  0.5f, 0.0f, 1.0f, 0.0f },
                { -0.5f,  0.5f,  0.5f, 0.0f, 0.0f, 1.0f },
            };

            var createInfo = new BufferCreateInfo
            {
                Usage = BufferUsageFlags.VertexBuffer,
                Size = (ulong)(sizeof(float) * vertices.Length),
            };
            vertexBuffer = device.CreateBuffer(createInfo);
            Console.WriteLine($"[ OK ] vertexBuffer {vertexBuffer}");

            var memoryRequirements = device.GetBufferMemoryRequirements(vertexBuffer);

            if(memoryRequirements.Size == 0) return;
            Console.WriteLine($"[ OK ] memoryRequirements {memoryRequirements.Size}");

            var allocateInfo = new MemoryAllocateInfo
            {
                AllocationSize = memoryRequirements.Size,
                MemoryTypeIndex = 2,
            };
            vertexBufferMemory = device.AllocateMemory(allocateInfo);
            Console.WriteLine($"[ OK ] vertexBufferMemory {vertexBufferMemory}");

            var mapped = device.MapMemory(vertexBufferMemory, 0, createInfo.Size, MemoryMapFlags.None);
            Utils.Copy2DArray(vertices, mapped, createInfo.Size, createInfo.Size);
            device.UnmapMemory(vertexBufferMemory);

            device.BindBufferMemory(vertexBuffer, vertexBufferMemory, 0);
            Console.WriteLine($"[ OK ] device.BindBufferMemory");

            vertexAttributes = new[]
            {
                new VertexInputAttributeDescription { Binding = 0, Location = 0, Format = Format.R32g32b32Sfloat, Offset = 0 },
                new VertexInputAttributeDescription { Binding = 0, Location = 1, Format = Format.R32g32b32Sfloat, Offset = sizeof(float) * 3 },
            };

            vertexBindings = new[]
            {
                new VertexInputBindingDescription { Binding = 0, InputRate = VertexInputRate.Vertex, Stride = (uint)(sizeof(float) * vertices.GetLength(1)) }
            };
        }

        static void CreateRenderPass()
        {
            var colorAttachmentReference        = new AttachmentReference { Attachment = 0, Layout = ImageLayout.ColorAttachmentOptimal        };
            var depthStencilAttachmentReference = new AttachmentReference { Attachment = 1, Layout = ImageLayout.DepthStencilAttachmentOptimal };

            var subpass = new SubpassDescription
            {
                PipelineBindPoint    = PipelineBindPoint.Graphics,
                ColorAttachmentCount = 1,
                ColorAttachments     = colorAttachmentReference,
            };
            
            var attachments = new[]
            {
                new AttachmentDescription
                {
                    Format         = backBufferFormat,
                    Samples        = SampleCountFlags.SampleCountFlags1,
                    LoadOp         = AttachmentLoadOp.Load,
                    StoreOp        = AttachmentStoreOp.Store,
                    StencilLoadOp  = AttachmentLoadOp.DontCare,
                    StencilStoreOp = AttachmentStoreOp.DontCare,
                    InitialLayout  = ImageLayout.ColorAttachmentOptimal,
                    FinalLayout    = ImageLayout.ColorAttachmentOptimal
                },
            };

            var createInfo = new RenderPassCreateInfo
            {
                AttachmentCount = (uint)attachments.Length,
                Attachments     = attachments[0],
                SubpassCount    = 1,
                Subpasses       = subpass
            };

            Console.WriteLine(createInfo.Attachments.Format);

            var subpasses = createInfo.Subpasses;
            Console.WriteLine(subpasses.ColorAttachments.Layout);
            Console.WriteLine(createInfo.Subpasses.ColorAttachments.Layout);

            renderPass = device.CreateRenderPass(createInfo);
            Console.WriteLine($"[ OK ] renderPass {renderPass}");
        }

        static void CreatePipelineLayout()
        {
            // We don't need any descriptors, since we don't use any resources/uniforms
            var descriptorSetLayoutCreateInfo = new DescriptorSetLayoutCreateInfo();
            var descriptorSetLayout = device.CreateDescriptorSetLayout(descriptorSetLayoutCreateInfo);

            var createInfo = new PipelineLayoutCreateInfo();
            pipelineLayout = device.CreatePipelineLayout(createInfo);
            Console.WriteLine($"[ OK ] pipelineLayout {pipelineLayout}");

            // Destroy temporary layout
            device.DestroyDescriptorSetLayout(descriptorSetLayout);
        }

        /*private void CreatePipeline()
        {
            var dynamicStates = new [] { DynamicState.Viewport, DynamicState.Scissor };

            var entryPointName = System.Text.Encoding.UTF8.GetBytes("main\0");

            var dynamicState = new PipelineDynamicStateCreateInfo
            {
                DynamicStateCount = 1, //(uint)dynamicStates.Length,
                DynamicStates = dynamicStates[0]
            };

            var viewportState = new PipelineViewportStateCreateInfo
            {
                ScissorCount = 1,
                ViewportCount = 1,
            };
            
            var vertexInputState = new PipelineVertexInputStateCreateInfo
            {
                VertexAttributeDescriptionCount = 1, //(uint)vertexAttributes.Length,
                VertexAttributeDescriptions = vertexAttributes[0],
                VertexBindingDescriptionCount = 1, //(uint)vertexBindings.Length,
                VertexBindingDescriptions = vertexBindings[0],
            };

            var inputAssemblyState = new PipelineInputAssemblyStateCreateInfo
            {
                Topology = PrimitiveTopology.TriangleList
            };

            var rasterizerState = new PipelineRasterizationStateCreateInfo
            {
                PolygonMode = PolygonMode.Fill,
                CullMode = CullModeFlags.None,
                FrontFace = FrontFace.Clockwise,
            };

            var colorBlendAttachment = new PipelineColorBlendAttachmentState { ColorWriteMask = ColorComponentFlags.R | ColorComponentFlags.G | ColorComponentFlags.B | ColorComponentFlags.A };
            var blendState = new PipelineColorBlendStateCreateInfo
            {
                AttachmentCount = 1,
                Attachments = colorBlendAttachment
            };

            var depthStencilState = new PipelineDepthStencilStateCreateInfo
            {
                DepthTestEnable = false,
                DepthWriteEnable = true,
                DepthCompareOp = CompareOp.LessOrEqual,
                Back = new StencilOpState { CompareOp = CompareOp.Always },
                Front = new StencilOpState { CompareOp = CompareOp.Always }
            };

            var shaderStages = new[]
            {
                new PipelineShaderStageCreateInfo
                {
                    Name = "main\0",
                    Stage = ShaderStageFlags.Vertex,
                    Module = CreateVertexShader()
                },
                new PipelineShaderStageCreateInfo
                {
                    Name = "main\0",
                    Stage = ShaderStageFlags.Fragment,
                    Module = CreateFragmentShader()
                }
            };

                
            var createInfo = new GraphicsPipelineCreateInfo
            {
                Layout = pipelineLayout,
                DynamicState = dynamicState,
                ViewportState = viewportState,
                VertexInputState = vertexInputState,
                InputAssemblyState = inputAssemblyState,
                RasterizationState = rasterizerState,
                ColorBlendState = blendState,
                DepthStencilState = depthStencilState,
                StageCount = 1, //(uint)shaderStages.Length,
                Stages = shaderStages[0],
                RenderPass = renderPass
            };
            pipeline = device.CreateGraphicsPipelines(null, new List<GraphicsPipelineCreateInfo> { createInfo });
                

            foreach(var shaderStage in shaderStages)
            {
                device.DestroyShaderModule(shaderStage.Module);
            }
        }*/

        /*private ShaderModule CreateVertexShader()
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
            var createInfo = new ShaderModuleCreateInfo
            {
                CodeSize = shaderCode.Length,
                Code = new IntPtr(codePointer)
            };
            return device.CreateShaderModule(createInfo);
        }*/

        static void CreateFramebuffers()
        {
            framebuffers = new Framebuffer[backBuffers.Count];
            for(int i = 0; i < backBuffers.Count; i++)
            {
                var attachment = backBufferViews[i];
                var createInfo = new FramebufferCreateInfo
                {
                    RenderPass = renderPass,
                    AttachmentCount = 1,
                    Attachments = attachment,
                    Width = (uint)form.ClientSize.Width,
                    Height = (uint)form.ClientSize.Height,
                    Layers = 1
                };
                framebuffers[i] = device.CreateFramebuffer(createInfo);
                Console.WriteLine($"[ OK ] framebuffers {framebuffers[i]} {i}/{backBuffers.Count}");
            }
        }

        static void PhysicalDeviceProperties()
        {
            var props = physicalDevice.GetProperties();
            var ver = new Tanagra.Version(props.ApiVersion);

            Console.WriteLine($"ApiVersion        {ver.ToString()}");
            Console.WriteLine($"DriverVersion     {props.DriverVersion}");
            Console.WriteLine($"VendorID          {props.VendorID.ToString("X4")}");
            Console.WriteLine($"DeviceID          {props.DeviceID.ToString("X4")}");
            Console.WriteLine($"DeviceType        {props.DeviceType}");
            Console.WriteLine($"DeviceName        {props.DeviceName}");
            //Console.WriteLine($"PipelineCacheUUID {props.PipelineCacheUUID}");

            Console.WriteLine();

            var limits = props.Limits;
            Console.WriteLine("Limits");
            Console.WriteLine("----------");
            Console.WriteLine($"MaxImageDimension1D                   {limits.MaxImageDimension1D.ToString("X")}");
            Console.WriteLine($"MaxImageDimension2D                   {limits.MaxImageDimension2D.ToString("X")}");
            Console.WriteLine($"MaxImageDimension3D                   {limits.MaxImageDimension3D.ToString("X")}");
            Console.WriteLine($"MaxImageDimensionCube                 {limits.MaxImageDimensionCube.ToString("X")}");
            Console.WriteLine($"MaxImageArrayLayers                   {limits.MaxImageArrayLayers.ToString("X")}");
            Console.WriteLine($"MaxTexelBufferElements                {limits.MaxTexelBufferElements.ToString("X")}");
            Console.WriteLine($"MaxUniformBufferRange                 {limits.MaxUniformBufferRange.ToString("X")}");
            Console.WriteLine($"MaxStorageBufferRange                 {limits.MaxStorageBufferRange.ToString("X")}");
            Console.WriteLine($"MaxPushConstantsSize                  {limits.MaxPushConstantsSize.ToString("X")}");
            Console.WriteLine($"MaxMemoryAllocationCount              {limits.MaxMemoryAllocationCount.ToString("X")}");
            Console.WriteLine($"MaxSamplerAllocationCount             {limits.MaxSamplerAllocationCount.ToString("X")}");
            Console.WriteLine($"BufferImageGranularity                {limits.BufferImageGranularity.ToString("X")}"); // DeviceSize
            Console.WriteLine($"SparseAddressSpaceSize                {limits.SparseAddressSpaceSize.ToString("X")}"); // DeviceSize
            Console.WriteLine($"MaxBoundDescriptorSets                {limits.MaxBoundDescriptorSets.ToString("X")}");
            Console.WriteLine($"MaxPerStageDescriptorSamplers         {limits.MaxPerStageDescriptorSamplers.ToString("X")}");
            Console.WriteLine($"MaxPerStageDescriptorUniformBuffers   {limits.MaxPerStageDescriptorUniformBuffers.ToString("X")}");
            Console.WriteLine($"MaxPerStageDescriptorStorageBuffers   {limits.MaxPerStageDescriptorStorageBuffers.ToString("X")}");
            Console.WriteLine($"MaxPerStageDescriptorSampledImages    {limits.MaxPerStageDescriptorSampledImages.ToString("X")}");
            Console.WriteLine($"MaxPerStageDescriptorStorageImages    {limits.MaxPerStageDescriptorStorageImages.ToString("X")}");
            Console.WriteLine($"MaxPerStageDescriptorInputAttachments {limits.MaxPerStageDescriptorInputAttachments.ToString("X")}");
            Console.WriteLine($"MaxPerStageResources                  {limits.MaxPerStageResources.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetSamplers              {limits.MaxDescriptorSetSamplers.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetUniformBuffers        {limits.MaxDescriptorSetUniformBuffers.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetUniformBuffersDynamic {limits.MaxDescriptorSetUniformBuffersDynamic.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetStorageBuffers        {limits.MaxDescriptorSetStorageBuffers.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetStorageBuffersDynamic {limits.MaxDescriptorSetStorageBuffersDynamic.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetSampledImages         {limits.MaxDescriptorSetSampledImages.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetStorageImages         {limits.MaxDescriptorSetStorageImages.ToString("X")}");
            Console.WriteLine($"MaxDescriptorSetInputAttachments      {limits.MaxDescriptorSetInputAttachments.ToString("X")}");
            Console.WriteLine($"MaxVertexInputAttributes              {limits.MaxVertexInputAttributes.ToString("X")}");
            Console.WriteLine($"MaxVertexInputBindings                {limits.MaxVertexInputBindings.ToString("X")}");
            Console.WriteLine($"MaxVertexInputAttributeOffset         {limits.MaxVertexInputAttributeOffset.ToString("X")}");
            Console.WriteLine($"MaxVertexInputBindingStride           {limits.MaxVertexInputBindingStride.ToString("X")}");
            Console.WriteLine($"MaxVertexOutputComponents             {limits.MaxVertexOutputComponents.ToString("X")}");
            Console.WriteLine($"MaxTessellationGenerationLevel                  {limits.MaxTessellationGenerationLevel.ToString("X")}");
            Console.WriteLine($"MaxTessellationPatchSize                        {limits.MaxTessellationPatchSize.ToString("X")}");
            Console.WriteLine($"MaxTessellationControlPerVertexInputComponents  {limits.MaxTessellationControlPerVertexInputComponents.ToString("X")}");
            Console.WriteLine($"MaxTessellationControlPerVertexOutputComponents {limits.MaxTessellationControlPerVertexOutputComponents.ToString("X")}");
            Console.WriteLine($"MaxTessellationControlPerPatchOutputComponents  {limits.MaxTessellationControlPerPatchOutputComponents.ToString("X")}");
            Console.WriteLine($"MaxTessellationControlTotalOutputComponents     {limits.MaxTessellationControlTotalOutputComponents.ToString("X")}");
            Console.WriteLine($"MaxTessellationEvaluationInputComponents        {limits.MaxTessellationEvaluationInputComponents.ToString("X")}");
            Console.WriteLine($"MaxTessellationEvaluationOutputComponents       {limits.MaxTessellationEvaluationOutputComponents.ToString("X")}");
            Console.WriteLine($"MaxGeometryShaderInvocations          {limits.MaxGeometryShaderInvocations.ToString("X")}");
            Console.WriteLine($"MaxGeometryInputComponents            {limits.MaxGeometryInputComponents.ToString("X")}");
            Console.WriteLine($"MaxGeometryOutputComponents           {limits.MaxGeometryOutputComponents.ToString("X")}");
            Console.WriteLine($"MaxGeometryOutputVertices             {limits.MaxGeometryOutputVertices.ToString("X")}");
            Console.WriteLine($"MaxGeometryTotalOutputComponents      {limits.MaxGeometryTotalOutputComponents.ToString("X")}");
            Console.WriteLine($"MaxFragmentInputComponents            {limits.MaxFragmentInputComponents.ToString("X")}");
            Console.WriteLine($"MaxFragmentOutputAttachments          {limits.MaxFragmentOutputAttachments.ToString("X")}");
            Console.WriteLine($"MaxFragmentDualSrcAttachments         {limits.MaxFragmentDualSrcAttachments.ToString("X")}");
            Console.WriteLine($"MaxFragmentCombinedOutputResources    {limits.MaxFragmentCombinedOutputResources.ToString("X")}");
            Console.WriteLine($"MaxComputeSharedMemorySize            {limits.MaxComputeSharedMemorySize.ToString("X")}");

            Console.WriteLine();

            var sparse = props.SparseProperties;
            Console.WriteLine("SparseProperties");
            Console.WriteLine("----------");
            Console.WriteLine($"  ResidencyStandard2DBlockShape            {sparse.ResidencyStandard2DBlockShape}");
            Console.WriteLine($"  ResidencyStandard2DMultisampleBlockShape {sparse.ResidencyStandard2DMultisampleBlockShape}");
            Console.WriteLine($"  ResidencyStandard3DBlockShape            {sparse.ResidencyStandard3DBlockShape}");
            Console.WriteLine($"  ResidencyAlignedMipSize                  {sparse.ResidencyAlignedMipSize}");
            Console.WriteLine($"  ResidencyNonResidentStrict               {sparse.ResidencyNonResidentStrict}");
        }

        static void GetProcessHandles(out IntPtr HINSTANCE, out IntPtr HWND)
        {
            var process = Process.GetCurrentProcess();
            HINSTANCE = process.Handle;
            HWND = process.MainWindowHandle;
        }

        static uint MakeVersion(int major, int minor, int patch)
        {
            return (uint)(major << 22 | minor << 12 | patch);
        }
    }
}
