using System;
using System.Runtime.InteropServices;

namespace Vulkan.Interop
{
    internal unsafe static class VK
    {
        const string DllName = "vulkan-1.dll";
        
        static VK()
        {
        }
        
        [DllImport(DllName, EntryPoint = "vkCreateInstance", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateInstance(InstanceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* instance);
        
        [DllImport(DllName, EntryPoint = "vkDestroyInstance", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyInstance(IntPtr instance, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkEnumeratePhysicalDevices(IntPtr instance, UInt32* physicalDeviceCount, IntPtr* physicalDevices);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceProcAddr", CallingConvention = CallingConvention.Winapi)]
        public static extern PFN_vkVoidFunction vkGetDeviceProcAddr(IntPtr device, Char* name);
        
        [DllImport(DllName, EntryPoint = "vkGetInstanceProcAddr", CallingConvention = CallingConvention.Winapi)]
        public static extern PFN_vkVoidFunction vkGetInstanceProcAddr(IntPtr instance, Char* name);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetPhysicalDeviceProperties(IntPtr physicalDevice, PhysicalDeviceProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetPhysicalDeviceQueueFamilyProperties(IntPtr physicalDevice, UInt32* queueFamilyPropertyCount, QueueFamilyProperties* queueFamilyProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceMemoryProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetPhysicalDeviceMemoryProperties(IntPtr physicalDevice, PhysicalDeviceMemoryProperties* memoryProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetPhysicalDeviceFeatures(IntPtr physicalDevice, PhysicalDeviceFeatures* features);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceFormatProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetPhysicalDeviceFormatProperties(IntPtr physicalDevice, Format format, FormatProperties* formatProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPhysicalDeviceImageFormatProperties(IntPtr physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* imageFormatProperties);
        
        [DllImport(DllName, EntryPoint = "vkCreateDevice", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateDevice(IntPtr physicalDevice, DeviceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* device);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDevice", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyDevice(IntPtr device, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkEnumerateInstanceLayerProperties(UInt32* propertyCount, LayerProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateInstanceExtensionProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkEnumerateInstanceExtensionProperties(Char* layerName, UInt32* propertyCount, ExtensionProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkEnumerateDeviceLayerProperties(IntPtr physicalDevice, UInt32* propertyCount, LayerProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkEnumerateDeviceExtensionProperties(IntPtr physicalDevice, Char* layerName, UInt32* propertyCount, ExtensionProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceQueue", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetDeviceQueue(IntPtr device, UInt32 queueFamilyIndex, UInt32 queueIndex, IntPtr* queue);
        
        [DllImport(DllName, EntryPoint = "vkQueueSubmit", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkQueueSubmit(IntPtr queue, UInt32 submitCount, SubmitInfo* submits, IntPtr fence);
        
        [DllImport(DllName, EntryPoint = "vkQueueWaitIdle", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkQueueWaitIdle(IntPtr queue);
        
        [DllImport(DllName, EntryPoint = "vkDeviceWaitIdle", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkDeviceWaitIdle(IntPtr device);
        
        [DllImport(DllName, EntryPoint = "vkAllocateMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkAllocateMemory(IntPtr device, MemoryAllocateInfo* allocateInfo, AllocationCallbacks* allocator, IntPtr* memory);
        
        [DllImport(DllName, EntryPoint = "vkFreeMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkFreeMemory(IntPtr device, IntPtr memory, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkMapMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkMapMemory(IntPtr device, IntPtr memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr** data);
        
        [DllImport(DllName, EntryPoint = "vkUnmapMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkUnmapMemory(IntPtr device, IntPtr memory);
        
        [DllImport(DllName, EntryPoint = "vkFlushMappedMemoryRanges", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkFlushMappedMemoryRanges(IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* memoryRanges);
        
        [DllImport(DllName, EntryPoint = "vkInvalidateMappedMemoryRanges", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkInvalidateMappedMemoryRanges(IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* memoryRanges);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceMemoryCommitment", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetDeviceMemoryCommitment(IntPtr device, IntPtr memory, DeviceSize* committedMemoryInBytes);
        
        [DllImport(DllName, EntryPoint = "vkGetBufferMemoryRequirements", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetBufferMemoryRequirements(IntPtr device, IntPtr buffer, MemoryRequirements* memoryRequirements);
        
        [DllImport(DllName, EntryPoint = "vkBindBufferMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkBindBufferMemory(IntPtr device, IntPtr buffer, IntPtr memory, DeviceSize memoryOffset);
        
        [DllImport(DllName, EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetImageMemoryRequirements(IntPtr device, IntPtr image, MemoryRequirements* memoryRequirements);
        
        [DllImport(DllName, EntryPoint = "vkBindImageMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkBindImageMemory(IntPtr device, IntPtr image, IntPtr memory, DeviceSize memoryOffset);
        
        [DllImport(DllName, EntryPoint = "vkGetImageSparseMemoryRequirements", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetImageSparseMemoryRequirements(IntPtr device, IntPtr image, UInt32* sparseMemoryRequirementCount, SparseImageMemoryRequirements* sparseMemoryRequirements);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetPhysicalDeviceSparseImageFormatProperties(IntPtr physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32* propertyCount, SparseImageFormatProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkQueueBindSparse", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkQueueBindSparse(IntPtr queue, UInt32 bindInfoCount, BindSparseInfo* bindInfo, IntPtr fence);
        
        [DllImport(DllName, EntryPoint = "vkCreateFence", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateFence(IntPtr device, FenceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* fence);
        
        [DllImport(DllName, EntryPoint = "vkDestroyFence", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyFence(IntPtr device, IntPtr fence, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkResetFences", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetFences(IntPtr device, UInt32 fenceCount, IntPtr* fences);
        
        [DllImport(DllName, EntryPoint = "vkGetFenceStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetFenceStatus(IntPtr device, IntPtr fence);
        
        [DllImport(DllName, EntryPoint = "vkWaitForFences", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkWaitForFences(IntPtr device, UInt32 fenceCount, IntPtr* fences, Boolean waitAll, UInt64 timeout);
        
        [DllImport(DllName, EntryPoint = "vkCreateSemaphore", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateSemaphore(IntPtr device, SemaphoreCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* semaphore);
        
        [DllImport(DllName, EntryPoint = "vkDestroySemaphore", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroySemaphore(IntPtr device, IntPtr semaphore, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateEvent(IntPtr device, EventCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* @event);
        
        [DllImport(DllName, EntryPoint = "vkDestroyEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyEvent(IntPtr device, IntPtr @event, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetEventStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetEventStatus(IntPtr device, IntPtr @event);
        
        [DllImport(DllName, EntryPoint = "vkSetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkSetEvent(IntPtr device, IntPtr @event);
        
        [DllImport(DllName, EntryPoint = "vkResetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetEvent(IntPtr device, IntPtr @event);
        
        [DllImport(DllName, EntryPoint = "vkCreateQueryPool", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateQueryPool(IntPtr device, QueryPoolCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* queryPool);
        
        [DllImport(DllName, EntryPoint = "vkDestroyQueryPool", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyQueryPool(IntPtr device, IntPtr queryPool, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetQueryPoolResults", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetQueryPoolResults(IntPtr device, IntPtr queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr* data, DeviceSize stride, QueryResultFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCreateBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateBuffer(IntPtr device, BufferCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* buffer);
        
        [DllImport(DllName, EntryPoint = "vkDestroyBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyBuffer(IntPtr device, IntPtr buffer, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateBufferView", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateBufferView(IntPtr device, BufferViewCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* view);
        
        [DllImport(DllName, EntryPoint = "vkDestroyBufferView", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyBufferView(IntPtr device, IntPtr bufferView, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateImage", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateImage(IntPtr device, ImageCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* image);
        
        [DllImport(DllName, EntryPoint = "vkDestroyImage", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyImage(IntPtr device, IntPtr image, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetImageSubresourceLayout", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetImageSubresourceLayout(IntPtr device, IntPtr image, ImageSubresource* subresource, SubresourceLayout* layout);
        
        [DllImport(DllName, EntryPoint = "vkCreateImageView", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateImageView(IntPtr device, ImageViewCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* view);
        
        [DllImport(DllName, EntryPoint = "vkDestroyImageView", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyImageView(IntPtr device, IntPtr imageView, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateShaderModule", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateShaderModule(IntPtr device, ShaderModuleCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* shaderModule);
        
        [DllImport(DllName, EntryPoint = "vkDestroyShaderModule", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyShaderModule(IntPtr device, IntPtr shaderModule, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreatePipelineCache", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreatePipelineCache(IntPtr device, PipelineCacheCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* pipelineCache);
        
        [DllImport(DllName, EntryPoint = "vkDestroyPipelineCache", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyPipelineCache(IntPtr device, IntPtr pipelineCache, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetPipelineCacheData", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPipelineCacheData(IntPtr device, IntPtr pipelineCache, UIntPtr* dataSize, IntPtr* data);
        
        [DllImport(DllName, EntryPoint = "vkMergePipelineCaches", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkMergePipelineCaches(IntPtr device, IntPtr dstCache, UInt32 srcCacheCount, IntPtr* srcCaches);
        
        [DllImport(DllName, EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateGraphicsPipelines(IntPtr device, IntPtr pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo* createInfos, AllocationCallbacks* allocator, IntPtr* pipelines);
        
        [DllImport(DllName, EntryPoint = "vkCreateComputePipelines", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateComputePipelines(IntPtr device, IntPtr pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo* createInfos, AllocationCallbacks* allocator, IntPtr* pipelines);
        
        [DllImport(DllName, EntryPoint = "vkDestroyPipeline", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyPipeline(IntPtr device, IntPtr pipeline, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreatePipelineLayout", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreatePipelineLayout(IntPtr device, PipelineLayoutCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* pipelineLayout);
        
        [DllImport(DllName, EntryPoint = "vkDestroyPipelineLayout", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyPipelineLayout(IntPtr device, IntPtr pipelineLayout, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateSampler", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateSampler(IntPtr device, SamplerCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* sampler);
        
        [DllImport(DllName, EntryPoint = "vkDestroySampler", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroySampler(IntPtr device, IntPtr sampler, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateDescriptorSetLayout(IntPtr device, DescriptorSetLayoutCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* setLayout);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyDescriptorSetLayout(IntPtr device, IntPtr descriptorSetLayout, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateDescriptorPool", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateDescriptorPool(IntPtr device, DescriptorPoolCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* descriptorPool);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDescriptorPool", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyDescriptorPool(IntPtr device, IntPtr descriptorPool, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkResetDescriptorPool", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetDescriptorPool(IntPtr device, IntPtr descriptorPool, DescriptorPoolResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkAllocateDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkAllocateDescriptorSets(IntPtr device, DescriptorSetAllocateInfo* allocateInfo, IntPtr* descriptorSets);
        
        [DllImport(DllName, EntryPoint = "vkFreeDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkFreeDescriptorSets(IntPtr device, IntPtr descriptorPool, UInt32 descriptorSetCount, IntPtr* descriptorSets);
        
        [DllImport(DllName, EntryPoint = "vkUpdateDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkUpdateDescriptorSets(IntPtr device, UInt32 descriptorWriteCount, WriteDescriptorSet* descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet* descriptorCopies);
        
        [DllImport(DllName, EntryPoint = "vkCreateFramebuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateFramebuffer(IntPtr device, FramebufferCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* framebuffer);
        
        [DllImport(DllName, EntryPoint = "vkDestroyFramebuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyFramebuffer(IntPtr device, IntPtr framebuffer, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateRenderPass(IntPtr device, RenderPassCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* renderPass);
        
        [DllImport(DllName, EntryPoint = "vkDestroyRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyRenderPass(IntPtr device, IntPtr renderPass, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetRenderAreaGranularity", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkGetRenderAreaGranularity(IntPtr device, IntPtr renderPass, Extent2D* granularity);
        
        [DllImport(DllName, EntryPoint = "vkCreateCommandPool", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateCommandPool(IntPtr device, CommandPoolCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* commandPool);
        
        [DllImport(DllName, EntryPoint = "vkDestroyCommandPool", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyCommandPool(IntPtr device, IntPtr commandPool, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkResetCommandPool", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetCommandPool(IntPtr device, IntPtr commandPool, CommandPoolResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkAllocateCommandBuffers", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkAllocateCommandBuffers(IntPtr device, CommandBufferAllocateInfo* allocateInfo, IntPtr* commandBuffers);
        
        [DllImport(DllName, EntryPoint = "vkFreeCommandBuffers", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkFreeCommandBuffers(IntPtr device, IntPtr commandPool, UInt32 commandBufferCount, IntPtr* commandBuffers);
        
        [DllImport(DllName, EntryPoint = "vkBeginCommandBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkBeginCommandBuffer(IntPtr commandBuffer, CommandBufferBeginInfo* beginInfo);
        
        [DllImport(DllName, EntryPoint = "vkEndCommandBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkEndCommandBuffer(IntPtr commandBuffer);
        
        [DllImport(DllName, EntryPoint = "vkResetCommandBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetCommandBuffer(IntPtr commandBuffer, CommandBufferResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindPipeline", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdBindPipeline(IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, IntPtr pipeline);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetViewport", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetViewport(IntPtr commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport* viewports);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetScissor", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetScissor(IntPtr commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D* scissors);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetLineWidth", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetLineWidth(IntPtr commandBuffer, Single lineWidth);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetDepthBias", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetDepthBias(IntPtr commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetBlendConstants", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetBlendConstants(IntPtr commandBuffer, Single blendConstants);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetDepthBounds", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetDepthBounds(IntPtr commandBuffer, Single minDepthBounds, Single maxDepthBounds);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilCompareMask", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetStencilCompareMask(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilWriteMask", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetStencilWriteMask(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilReference", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetStencilReference(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 reference);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdBindDescriptorSets(IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, IntPtr layout, UInt32 firstSet, UInt32 descriptorSetCount, IntPtr* descriptorSets, UInt32 dynamicOffsetCount, UInt32* dynamicOffsets);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdBindIndexBuffer(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset, IndexType indexType);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdBindVertexBuffers(IntPtr commandBuffer, UInt32 firstBinding, UInt32 bindingCount, IntPtr* buffers, DeviceSize* offsets);
        
        [DllImport(DllName, EntryPoint = "vkCmdDraw", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdDraw(IntPtr commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);
        
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndexed", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdDrawIndexed(IntPtr commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance);
        
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndirect", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdDrawIndirect(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndexedIndirect", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdDrawIndexedIndirect(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        [DllImport(DllName, EntryPoint = "vkCmdDispatch", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdDispatch(IntPtr commandBuffer, UInt32 x, UInt32 y, UInt32 z);
        
        [DllImport(DllName, EntryPoint = "vkCmdDispatchIndirect", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdDispatchIndirect(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdCopyBuffer(IntPtr commandBuffer, IntPtr srcBuffer, IntPtr dstBuffer, UInt32 regionCount, BufferCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyImage", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdCopyImage(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdBlitImage", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdBlitImage(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit* regions, Filter filter);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyBufferToImage", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdCopyBufferToImage(IntPtr commandBuffer, IntPtr srcBuffer, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyImageToBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdCopyImageToBuffer(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstBuffer, UInt32 regionCount, BufferImageCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdUpdateBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdUpdateBuffer(IntPtr commandBuffer, IntPtr dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32* data);
        
        [DllImport(DllName, EntryPoint = "vkCmdFillBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdFillBuffer(IntPtr commandBuffer, IntPtr dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);
        
        [DllImport(DllName, EntryPoint = "vkCmdClearColorImage", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdClearColorImage(IntPtr commandBuffer, IntPtr image, ImageLayout imageLayout, ClearColorValue* color, UInt32 rangeCount, ImageSubresourceRange* ranges);
        
        [DllImport(DllName, EntryPoint = "vkCmdClearDepthStencilImage", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdClearDepthStencilImage(IntPtr commandBuffer, IntPtr image, ImageLayout imageLayout, ClearDepthStencilValue* depthStencil, UInt32 rangeCount, ImageSubresourceRange* ranges);
        
        [DllImport(DllName, EntryPoint = "vkCmdClearAttachments", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdClearAttachments(IntPtr commandBuffer, UInt32 attachmentCount, ClearAttachment* attachments, UInt32 rectCount, ClearRect* rects);
        
        [DllImport(DllName, EntryPoint = "vkCmdResolveImage", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdResolveImage(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdSetEvent(IntPtr commandBuffer, IntPtr @event, PipelineStageFlags stageMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdResetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdResetEvent(IntPtr commandBuffer, IntPtr @event, PipelineStageFlags stageMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdWaitEvents", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdWaitEvents(IntPtr commandBuffer, UInt32 eventCount, IntPtr* events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier* memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* imageMemoryBarriers);
        
        [DllImport(DllName, EntryPoint = "vkCmdPipelineBarrier", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdPipelineBarrier(IntPtr commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier* memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* imageMemoryBarriers);
        
        [DllImport(DllName, EntryPoint = "vkCmdBeginQuery", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdBeginQuery(IntPtr commandBuffer, IntPtr queryPool, UInt32 query, QueryControlFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCmdEndQuery", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdEndQuery(IntPtr commandBuffer, IntPtr queryPool, UInt32 query);
        
        [DllImport(DllName, EntryPoint = "vkCmdResetQueryPool", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdResetQueryPool(IntPtr commandBuffer, IntPtr queryPool, UInt32 firstQuery, UInt32 queryCount);
        
        [DllImport(DllName, EntryPoint = "vkCmdWriteTimestamp", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdWriteTimestamp(IntPtr commandBuffer, PipelineStageFlags pipelineStage, IntPtr queryPool, UInt32 query);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyQueryPoolResults", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdCopyQueryPoolResults(IntPtr commandBuffer, IntPtr queryPool, UInt32 firstQuery, UInt32 queryCount, IntPtr dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCmdPushConstants", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdPushConstants(IntPtr commandBuffer, IntPtr layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr* values);
        
        [DllImport(DllName, EntryPoint = "vkCmdBeginRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdBeginRenderPass(IntPtr commandBuffer, RenderPassBeginInfo* renderPassBegin, SubpassContents contents);
        
        [DllImport(DllName, EntryPoint = "vkCmdNextSubpass", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdNextSubpass(IntPtr commandBuffer, SubpassContents contents);
        
        [DllImport(DllName, EntryPoint = "vkCmdEndRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdEndRenderPass(IntPtr commandBuffer);
        
        [DllImport(DllName, EntryPoint = "vkCmdExecuteCommands", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkCmdExecuteCommands(IntPtr commandBuffer, UInt32 commandBufferCount, IntPtr* commandBuffers);
        
        [DllImport(DllName, EntryPoint = "vkCreateAndroidSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateAndroidSurfaceKHR(IntPtr instance, AndroidSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceDisplayPropertiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPhysicalDeviceDisplayPropertiesKHR(IntPtr physicalDevice, UInt32* propertyCount, DisplayPropertiesKHR* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceDisplayPlanePropertiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPhysicalDeviceDisplayPlanePropertiesKHR(IntPtr physicalDevice, UInt32* propertyCount, DisplayPlanePropertiesKHR* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetDisplayPlaneSupportedDisplaysKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetDisplayPlaneSupportedDisplaysKHR(IntPtr physicalDevice, UInt32 planeIndex, UInt32* displayCount, IntPtr* displays);
        
        [DllImport(DllName, EntryPoint = "vkGetDisplayModePropertiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetDisplayModePropertiesKHR(IntPtr physicalDevice, IntPtr display, UInt32* propertyCount, DisplayModePropertiesKHR* properties);
        
        [DllImport(DllName, EntryPoint = "vkCreateDisplayModeKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateDisplayModeKHR(IntPtr physicalDevice, IntPtr display, DisplayModeCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* mode);
        
        [DllImport(DllName, EntryPoint = "vkGetDisplayPlaneCapabilitiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetDisplayPlaneCapabilitiesKHR(IntPtr physicalDevice, IntPtr mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR* capabilities);
        
        [DllImport(DllName, EntryPoint = "vkCreateDisplayPlaneSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateDisplayPlaneSurfaceKHR(IntPtr instance, DisplaySurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkCreateSharedSwapchainsKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateSharedSwapchainsKHR(IntPtr device, UInt32 swapchainCount, SwapchainCreateInfoKHR* createInfos, AllocationCallbacks* allocator, IntPtr* swapchains);
        
        [DllImport(DllName, EntryPoint = "vkCreateMirSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateMirSurfaceKHR(IntPtr instance, MirSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceMirPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Boolean vkGetPhysicalDeviceMirPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, MirConnection* connection);
        
        [DllImport(DllName, EntryPoint = "vkDestroySurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroySurfaceKHR(IntPtr instance, IntPtr surface, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPhysicalDeviceSurfaceSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr surface, Boolean* supported);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilitiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPhysicalDeviceSurfaceCapabilitiesKHR(IntPtr physicalDevice, IntPtr surface, SurfaceCapabilitiesKHR* surfaceCapabilities);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceFormatsKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPhysicalDeviceSurfaceFormatsKHR(IntPtr physicalDevice, IntPtr surface, UInt32* surfaceFormatCount, SurfaceFormatKHR* surfaceFormats);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfacePresentModesKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetPhysicalDeviceSurfacePresentModesKHR(IntPtr physicalDevice, IntPtr surface, UInt32* presentModeCount, PresentModeKHR* presentModes);
        
        [DllImport(DllName, EntryPoint = "vkCreateSwapchainKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateSwapchainKHR(IntPtr device, SwapchainCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* swapchain);
        
        [DllImport(DllName, EntryPoint = "vkDestroySwapchainKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroySwapchainKHR(IntPtr device, IntPtr swapchain, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetSwapchainImagesKHR(IntPtr device, IntPtr swapchain, UInt32* swapchainImageCount, IntPtr* swapchainImages);
        
        [DllImport(DllName, EntryPoint = "vkAcquireNextImageKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkAcquireNextImageKHR(IntPtr device, IntPtr swapchain, UInt64 timeout, IntPtr semaphore, IntPtr fence, UInt32* imageIndex);
        
        [DllImport(DllName, EntryPoint = "vkQueuePresentKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkQueuePresentKHR(IntPtr queue, PresentInfoKHR* presentInfo);
        
        [DllImport(DllName, EntryPoint = "vkCreateWaylandSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateWaylandSurfaceKHR(IntPtr instance, WaylandSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceWaylandPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Boolean vkGetPhysicalDeviceWaylandPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, wl_display* display);
        
        [DllImport(DllName, EntryPoint = "vkCreateWin32SurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateWin32SurfaceKHR(IntPtr instance, Win32SurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceWin32PresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Boolean vkGetPhysicalDeviceWin32PresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex);
        
        [DllImport(DllName, EntryPoint = "vkCreateXlibSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateXlibSurfaceKHR(IntPtr instance, XlibSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceXlibPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Boolean vkGetPhysicalDeviceXlibPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, Display* dpy, VisualID visualID);
        
        [DllImport(DllName, EntryPoint = "vkCreateXcbSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateXcbSurfaceKHR(IntPtr instance, XcbSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceXcbPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Boolean vkGetPhysicalDeviceXcbPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, xcb_connection_t* connection, xcb_visualid_t visual_id);
        
        [DllImport(DllName, EntryPoint = "vkCreateDebugReportCallbackEXT", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkCreateDebugReportCallbackEXT(IntPtr instance, DebugReportCallbackCreateInfoEXT* createInfo, AllocationCallbacks* allocator, IntPtr* callback);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDebugReportCallbackEXT", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDestroyDebugReportCallbackEXT(IntPtr instance, IntPtr callback, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkDebugReportMessageEXT", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr vkDebugReportMessageEXT(IntPtr instance, VkDebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, Char* layerPrefix, Char* message);
        
    }
}
