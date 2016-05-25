using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vulkan;
using Vulkan.Managed;
using Vulkan.Managed.ObjectModel;

namespace TanagraExample
{
    public class ExampleBase
    {
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
        //VulkanSwapChain swapChain;

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

        void initVulkan()
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
            var queue = device.GetQueue(queueNodeIndex, 0);
            //todo

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
            // todo
        }

        void createInstance()
        {
            var instanceEnabledExtensions = new[]
            {
                VulkanConstant.KhrSurfaceExtensionName,
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
    }
}
