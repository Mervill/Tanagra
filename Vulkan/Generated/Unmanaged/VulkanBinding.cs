using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    public unsafe static class VulkanBinding
    {
        const string DllName = "vulkan-1.dll";
        const CallingConvention callingConvention = CallingConvention.Winapi;
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateInstance", CallingConvention = callingConvention)]
        public static extern Result vkCreateInstance(InstanceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* instance);
        
        /// <param name="instance">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyInstance", CallingConvention = callingConvention)]
        public static extern void vkDestroyInstance(IntPtr instance, AllocationCallbacks* allocator);
        
        /// <param name="physicalDevices">Optional</param>
        [DllImport(DllName, EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = callingConvention)]
        public static extern Result vkEnumeratePhysicalDevices(IntPtr instance, UInt32* physicalDeviceCount, IntPtr* physicalDevices);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceProcAddr", CallingConvention = callingConvention)]
        public static extern IntPtr vkGetDeviceProcAddr(IntPtr device, String name);
        
        /// <param name="instance">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetInstanceProcAddr", CallingConvention = callingConvention)]
        public static extern IntPtr vkGetInstanceProcAddr(IntPtr instance, String name);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = callingConvention)]
        public static extern void vkGetPhysicalDeviceProperties(IntPtr physicalDevice, PhysicalDeviceProperties* properties);
        
        /// <param name="queueFamilyProperties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = callingConvention)]
        public static extern void vkGetPhysicalDeviceQueueFamilyProperties(IntPtr physicalDevice, UInt32* queueFamilyPropertyCount, QueueFamilyProperties* queueFamilyProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceMemoryProperties", CallingConvention = callingConvention)]
        public static extern void vkGetPhysicalDeviceMemoryProperties(IntPtr physicalDevice, PhysicalDeviceMemoryProperties* memoryProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = callingConvention)]
        public static extern void vkGetPhysicalDeviceFeatures(IntPtr physicalDevice, PhysicalDeviceFeatures* features);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceFormatProperties", CallingConvention = callingConvention)]
        public static extern void vkGetPhysicalDeviceFormatProperties(IntPtr physicalDevice, Format format, FormatProperties* formatProperties);
        
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties", CallingConvention = callingConvention)]
        public static extern Result vkGetPhysicalDeviceImageFormatProperties(IntPtr physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* imageFormatProperties);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateDevice", CallingConvention = callingConvention)]
        public static extern Result vkCreateDevice(IntPtr physicalDevice, DeviceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* device);
        
        /// <param name="device">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyDevice", CallingConvention = callingConvention)]
        public static extern void vkDestroyDevice(IntPtr device, AllocationCallbacks* allocator);
        
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = callingConvention)]
        public static extern Result vkEnumerateInstanceLayerProperties(UInt32* propertyCount, LayerProperties* properties);
        
        /// <param name="layerName">Optional</param>
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkEnumerateInstanceExtensionProperties", CallingConvention = callingConvention)]
        public static extern Result vkEnumerateInstanceExtensionProperties(String layerName, UInt32* propertyCount, ExtensionProperties* properties);
        
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = callingConvention)]
        public static extern Result vkEnumerateDeviceLayerProperties(IntPtr physicalDevice, UInt32* propertyCount, LayerProperties* properties);
        
        /// <param name="layerName">Optional</param>
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = callingConvention)]
        public static extern Result vkEnumerateDeviceExtensionProperties(IntPtr physicalDevice, String layerName, UInt32* propertyCount, ExtensionProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceQueue", CallingConvention = callingConvention)]
        public static extern void vkGetDeviceQueue(IntPtr device, UInt32 queueFamilyIndex, UInt32 queueIndex, IntPtr* queue);
        
        /// <param name="queue">ExternSync</param>
        /// <param name="submitCount">Optional</param>
        /// <param name="fence">ExternSync, Optional</param>
        [DllImport(DllName, EntryPoint = "vkQueueSubmit", CallingConvention = callingConvention)]
        public static extern Result vkQueueSubmit(IntPtr queue, UInt32 submitCount, SubmitInfo* submits, UInt64 fence);
        
        [DllImport(DllName, EntryPoint = "vkQueueWaitIdle", CallingConvention = callingConvention)]
        public static extern Result vkQueueWaitIdle(IntPtr queue);
        
        [DllImport(DllName, EntryPoint = "vkDeviceWaitIdle", CallingConvention = callingConvention)]
        public static extern Result vkDeviceWaitIdle(IntPtr device);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkAllocateMemory", CallingConvention = callingConvention)]
        public static extern Result vkAllocateMemory(IntPtr device, MemoryAllocateInfo* allocateInfo, AllocationCallbacks* allocator, UInt64* memory);
        
        /// <param name="memory">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkFreeMemory", CallingConvention = callingConvention)]
        public static extern void vkFreeMemory(IntPtr device, UInt64 memory, AllocationCallbacks* allocator);
        
        /// <param name="memory">ExternSync</param>
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkMapMemory", CallingConvention = callingConvention)]
        public static extern Result vkMapMemory(IntPtr device, UInt64 memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr* data);
        
        /// <param name="memory">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkUnmapMemory", CallingConvention = callingConvention)]
        public static extern void vkUnmapMemory(IntPtr device, UInt64 memory);
        
        [DllImport(DllName, EntryPoint = "vkFlushMappedMemoryRanges", CallingConvention = callingConvention)]
        public static extern Result vkFlushMappedMemoryRanges(IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* memoryRanges);
        
        [DllImport(DllName, EntryPoint = "vkInvalidateMappedMemoryRanges", CallingConvention = callingConvention)]
        public static extern Result vkInvalidateMappedMemoryRanges(IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* memoryRanges);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceMemoryCommitment", CallingConvention = callingConvention)]
        public static extern void vkGetDeviceMemoryCommitment(IntPtr device, UInt64 memory, DeviceSize* committedMemoryInBytes);
        
        [DllImport(DllName, EntryPoint = "vkGetBufferMemoryRequirements", CallingConvention = callingConvention)]
        public static extern void vkGetBufferMemoryRequirements(IntPtr device, UInt64 buffer, MemoryRequirements* memoryRequirements);
        
        /// <param name="buffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkBindBufferMemory", CallingConvention = callingConvention)]
        public static extern Result vkBindBufferMemory(IntPtr device, UInt64 buffer, UInt64 memory, DeviceSize memoryOffset);
        
        [DllImport(DllName, EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = callingConvention)]
        public static extern void vkGetImageMemoryRequirements(IntPtr device, UInt64 image, MemoryRequirements* memoryRequirements);
        
        /// <param name="image">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkBindImageMemory", CallingConvention = callingConvention)]
        public static extern Result vkBindImageMemory(IntPtr device, UInt64 image, UInt64 memory, DeviceSize memoryOffset);
        
        /// <param name="sparseMemoryRequirements">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetImageSparseMemoryRequirements", CallingConvention = callingConvention)]
        public static extern void vkGetImageSparseMemoryRequirements(IntPtr device, UInt64 image, UInt32* sparseMemoryRequirementCount, SparseImageMemoryRequirements* sparseMemoryRequirements);
        
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties", CallingConvention = callingConvention)]
        public static extern void vkGetPhysicalDeviceSparseImageFormatProperties(IntPtr physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32* propertyCount, SparseImageFormatProperties* properties);
        
        /// <summary>
        /// [<see cref="QueueFlags"/>: Sparse_binding] 
        /// </summary>
        /// <param name="queue">ExternSync</param>
        /// <param name="bindInfoCount">Optional</param>
        /// <param name="fence">ExternSync, Optional</param>
        [DllImport(DllName, EntryPoint = "vkQueueBindSparse", CallingConvention = callingConvention)]
        public static extern Result vkQueueBindSparse(IntPtr queue, UInt32 bindInfoCount, BindSparseInfo* bindInfo, UInt64 fence);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateFence", CallingConvention = callingConvention)]
        public static extern Result vkCreateFence(IntPtr device, FenceCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* fence);
        
        /// <param name="fence">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyFence", CallingConvention = callingConvention)]
        public static extern void vkDestroyFence(IntPtr device, UInt64 fence, AllocationCallbacks* allocator);
        
        /// <param name="fences">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkResetFences", CallingConvention = callingConvention)]
        public static extern Result vkResetFences(IntPtr device, UInt32 fenceCount, UInt64* fences);
        
        [DllImport(DllName, EntryPoint = "vkGetFenceStatus", CallingConvention = callingConvention)]
        public static extern Result vkGetFenceStatus(IntPtr device, UInt64 fence);
        
        [DllImport(DllName, EntryPoint = "vkWaitForFences", CallingConvention = callingConvention)]
        public static extern Result vkWaitForFences(IntPtr device, UInt32 fenceCount, UInt64* fences, Bool32 waitAll, UInt64 timeout);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateSemaphore", CallingConvention = callingConvention)]
        public static extern Result vkCreateSemaphore(IntPtr device, SemaphoreCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* semaphore);
        
        /// <param name="semaphore">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroySemaphore", CallingConvention = callingConvention)]
        public static extern void vkDestroySemaphore(IntPtr device, UInt64 semaphore, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateEvent", CallingConvention = callingConvention)]
        public static extern Result vkCreateEvent(IntPtr device, EventCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* @event);
        
        /// <param name="@event">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyEvent", CallingConvention = callingConvention)]
        public static extern void vkDestroyEvent(IntPtr device, UInt64 @event, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetEventStatus", CallingConvention = callingConvention)]
        public static extern Result vkGetEventStatus(IntPtr device, UInt64 @event);
        
        /// <param name="@event">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkSetEvent", CallingConvention = callingConvention)]
        public static extern Result vkSetEvent(IntPtr device, UInt64 @event);
        
        /// <param name="@event">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkResetEvent", CallingConvention = callingConvention)]
        public static extern Result vkResetEvent(IntPtr device, UInt64 @event);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateQueryPool", CallingConvention = callingConvention)]
        public static extern Result vkCreateQueryPool(IntPtr device, QueryPoolCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* queryPool);
        
        /// <param name="queryPool">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyQueryPool", CallingConvention = callingConvention)]
        public static extern void vkDestroyQueryPool(IntPtr device, UInt64 queryPool, AllocationCallbacks* allocator);
        
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetQueryPoolResults", CallingConvention = callingConvention)]
        public static extern Result vkGetQueryPoolResults(IntPtr device, UInt64 queryPool, UInt32 firstQuery, UInt32 queryCount, UInt32 dataSize, IntPtr* data, DeviceSize stride, QueryResultFlags flags);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateBuffer", CallingConvention = callingConvention)]
        public static extern Result vkCreateBuffer(IntPtr device, BufferCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* buffer);
        
        /// <param name="buffer">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyBuffer", CallingConvention = callingConvention)]
        public static extern void vkDestroyBuffer(IntPtr device, UInt64 buffer, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateBufferView", CallingConvention = callingConvention)]
        public static extern Result vkCreateBufferView(IntPtr device, BufferViewCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* view);
        
        /// <param name="bufferView">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyBufferView", CallingConvention = callingConvention)]
        public static extern void vkDestroyBufferView(IntPtr device, UInt64 bufferView, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateImage", CallingConvention = callingConvention)]
        public static extern Result vkCreateImage(IntPtr device, ImageCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* image);
        
        /// <param name="image">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyImage", CallingConvention = callingConvention)]
        public static extern void vkDestroyImage(IntPtr device, UInt64 image, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetImageSubresourceLayout", CallingConvention = callingConvention)]
        public static extern void vkGetImageSubresourceLayout(IntPtr device, UInt64 image, ImageSubresource* subresource, SubresourceLayout* layout);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateImageView", CallingConvention = callingConvention)]
        public static extern Result vkCreateImageView(IntPtr device, ImageViewCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* view);
        
        /// <param name="imageView">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyImageView", CallingConvention = callingConvention)]
        public static extern void vkDestroyImageView(IntPtr device, UInt64 imageView, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateShaderModule", CallingConvention = callingConvention)]
        public static extern Result vkCreateShaderModule(IntPtr device, ShaderModuleCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* shaderModule);
        
        /// <param name="shaderModule">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyShaderModule", CallingConvention = callingConvention)]
        public static extern void vkDestroyShaderModule(IntPtr device, UInt64 shaderModule, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreatePipelineCache", CallingConvention = callingConvention)]
        public static extern Result vkCreatePipelineCache(IntPtr device, PipelineCacheCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* pipelineCache);
        
        /// <param name="pipelineCache">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyPipelineCache", CallingConvention = callingConvention)]
        public static extern void vkDestroyPipelineCache(IntPtr device, UInt64 pipelineCache, AllocationCallbacks* allocator);
        
        /// <param name="data">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPipelineCacheData", CallingConvention = callingConvention)]
        public static extern Result vkGetPipelineCacheData(IntPtr device, UInt64 pipelineCache, UInt32* dataSize, IntPtr* data);
        
        /// <param name="dstCache">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkMergePipelineCaches", CallingConvention = callingConvention)]
        public static extern Result vkMergePipelineCaches(IntPtr device, UInt64 dstCache, UInt32 srcCacheCount, UInt64* srcCaches);
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = callingConvention)]
        public static extern Result vkCreateGraphicsPipelines(IntPtr device, UInt64 pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo* createInfos, AllocationCallbacks* allocator, UInt64* pipelines);
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateComputePipelines", CallingConvention = callingConvention)]
        public static extern Result vkCreateComputePipelines(IntPtr device, UInt64 pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo* createInfos, AllocationCallbacks* allocator, UInt64* pipelines);
        
        /// <param name="pipeline">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyPipeline", CallingConvention = callingConvention)]
        public static extern void vkDestroyPipeline(IntPtr device, UInt64 pipeline, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreatePipelineLayout", CallingConvention = callingConvention)]
        public static extern Result vkCreatePipelineLayout(IntPtr device, PipelineLayoutCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* pipelineLayout);
        
        /// <param name="pipelineLayout">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyPipelineLayout", CallingConvention = callingConvention)]
        public static extern void vkDestroyPipelineLayout(IntPtr device, UInt64 pipelineLayout, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateSampler", CallingConvention = callingConvention)]
        public static extern Result vkCreateSampler(IntPtr device, SamplerCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* sampler);
        
        /// <param name="sampler">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroySampler", CallingConvention = callingConvention)]
        public static extern void vkDestroySampler(IntPtr device, UInt64 sampler, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = callingConvention)]
        public static extern Result vkCreateDescriptorSetLayout(IntPtr device, DescriptorSetLayoutCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* setLayout);
        
        /// <param name="descriptorSetLayout">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = callingConvention)]
        public static extern void vkDestroyDescriptorSetLayout(IntPtr device, UInt64 descriptorSetLayout, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateDescriptorPool", CallingConvention = callingConvention)]
        public static extern Result vkCreateDescriptorPool(IntPtr device, DescriptorPoolCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* descriptorPool);
        
        /// <param name="descriptorPool">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyDescriptorPool", CallingConvention = callingConvention)]
        public static extern void vkDestroyDescriptorPool(IntPtr device, UInt64 descriptorPool, AllocationCallbacks* allocator);
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkResetDescriptorPool", CallingConvention = callingConvention)]
        public static extern Result vkResetDescriptorPool(IntPtr device, UInt64 descriptorPool, DescriptorPoolResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkAllocateDescriptorSets", CallingConvention = callingConvention)]
        public static extern Result vkAllocateDescriptorSets(IntPtr device, DescriptorSetAllocateInfo* allocateInfo, UInt64* descriptorSets);
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="descriptorSets">ExternSync, No Auto Validity</param>
        [DllImport(DllName, EntryPoint = "vkFreeDescriptorSets", CallingConvention = callingConvention)]
        public static extern Result vkFreeDescriptorSets(IntPtr device, UInt64 descriptorPool, UInt32 descriptorSetCount, UInt64* descriptorSets);
        
        /// <param name="descriptorWriteCount">Optional</param>
        /// <param name="descriptorCopyCount">Optional</param>
        [DllImport(DllName, EntryPoint = "vkUpdateDescriptorSets", CallingConvention = callingConvention)]
        public static extern void vkUpdateDescriptorSets(IntPtr device, UInt32 descriptorWriteCount, WriteDescriptorSet* descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet* descriptorCopies);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateFramebuffer", CallingConvention = callingConvention)]
        public static extern Result vkCreateFramebuffer(IntPtr device, FramebufferCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* framebuffer);
        
        /// <param name="framebuffer">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyFramebuffer", CallingConvention = callingConvention)]
        public static extern void vkDestroyFramebuffer(IntPtr device, UInt64 framebuffer, AllocationCallbacks* allocator);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateRenderPass", CallingConvention = callingConvention)]
        public static extern Result vkCreateRenderPass(IntPtr device, RenderPassCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* renderPass);
        
        /// <param name="renderPass">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyRenderPass", CallingConvention = callingConvention)]
        public static extern void vkDestroyRenderPass(IntPtr device, UInt64 renderPass, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetRenderAreaGranularity", CallingConvention = callingConvention)]
        public static extern void vkGetRenderAreaGranularity(IntPtr device, UInt64 renderPass, Extent2D* granularity);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateCommandPool", CallingConvention = callingConvention)]
        public static extern Result vkCreateCommandPool(IntPtr device, CommandPoolCreateInfo* createInfo, AllocationCallbacks* allocator, UInt64* commandPool);
        
        /// <param name="commandPool">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyCommandPool", CallingConvention = callingConvention)]
        public static extern void vkDestroyCommandPool(IntPtr device, UInt64 commandPool, AllocationCallbacks* allocator);
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkResetCommandPool", CallingConvention = callingConvention)]
        public static extern Result vkResetCommandPool(IntPtr device, UInt64 commandPool, CommandPoolResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkAllocateCommandBuffers", CallingConvention = callingConvention)]
        public static extern Result vkAllocateCommandBuffers(IntPtr device, CommandBufferAllocateInfo* allocateInfo, IntPtr* commandBuffers);
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="commandBuffers">ExternSync, No Auto Validity</param>
        [DllImport(DllName, EntryPoint = "vkFreeCommandBuffers", CallingConvention = callingConvention)]
        public static extern void vkFreeCommandBuffers(IntPtr device, UInt64 commandPool, UInt32 commandBufferCount, IntPtr* commandBuffers);
        
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkBeginCommandBuffer", CallingConvention = callingConvention)]
        public static extern Result vkBeginCommandBuffer(IntPtr commandBuffer, CommandBufferBeginInfo* beginInfo);
        
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkEndCommandBuffer", CallingConvention = callingConvention)]
        public static extern Result vkEndCommandBuffer(IntPtr commandBuffer);
        
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkResetCommandBuffer", CallingConvention = callingConvention)]
        public static extern Result vkResetCommandBuffer(IntPtr commandBuffer, CommandBufferResetFlags flags);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdBindPipeline", CallingConvention = callingConvention)]
        public static extern void vkCmdBindPipeline(IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, UInt64 pipeline);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetViewport", CallingConvention = callingConvention)]
        public static extern void vkCmdSetViewport(IntPtr commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport* viewports);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetScissor", CallingConvention = callingConvention)]
        public static extern void vkCmdSetScissor(IntPtr commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D* scissors);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetLineWidth", CallingConvention = callingConvention)]
        public static extern void vkCmdSetLineWidth(IntPtr commandBuffer, Single lineWidth);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetDepthBias", CallingConvention = callingConvention)]
        public static extern void vkCmdSetDepthBias(IntPtr commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetBlendConstants", CallingConvention = callingConvention)]
        public static extern void vkCmdSetBlendConstants(IntPtr commandBuffer, Single blendConstants);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetDepthBounds", CallingConvention = callingConvention)]
        public static extern void vkCmdSetDepthBounds(IntPtr commandBuffer, Single minDepthBounds, Single maxDepthBounds);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilCompareMask", CallingConvention = callingConvention)]
        public static extern void vkCmdSetStencilCompareMask(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilWriteMask", CallingConvention = callingConvention)]
        public static extern void vkCmdSetStencilWriteMask(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilReference", CallingConvention = callingConvention)]
        public static extern void vkCmdSetStencilReference(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 reference);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="dynamicOffsetCount">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCmdBindDescriptorSets", CallingConvention = callingConvention)]
        public static extern void vkCmdBindDescriptorSets(IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, UInt64 layout, UInt32 firstSet, UInt32 descriptorSetCount, UInt64* descriptorSets, UInt32 dynamicOffsetCount, UInt32* dynamicOffsets);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = callingConvention)]
        public static extern void vkCmdBindIndexBuffer(IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, IndexType indexType);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = callingConvention)]
        public static extern void vkCmdBindVertexBuffers(IntPtr commandBuffer, UInt32 firstBinding, UInt32 bindingCount, UInt64* buffers, DeviceSize* offsets);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdDraw", CallingConvention = callingConvention)]
        public static extern void vkCmdDraw(IntPtr commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndexed", CallingConvention = callingConvention)]
        public static extern void vkCmdDrawIndexed(IntPtr commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndirect", CallingConvention = callingConvention)]
        public static extern void vkCmdDrawIndirect(IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndexedIndirect", CallingConvention = callingConvention)]
        public static extern void vkCmdDrawIndexedIndirect(IntPtr commandBuffer, UInt64 buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdDispatch", CallingConvention = callingConvention)]
        public static extern void vkCmdDispatch(IntPtr commandBuffer, UInt32 x, UInt32 y, UInt32 z);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdDispatchIndirect", CallingConvention = callingConvention)]
        public static extern void vkCmdDispatchIndirect(IntPtr commandBuffer, UInt64 buffer, DeviceSize offset);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdCopyBuffer", CallingConvention = callingConvention)]
        public static extern void vkCmdCopyBuffer(IntPtr commandBuffer, UInt64 srcBuffer, UInt64 dstBuffer, UInt32 regionCount, BufferCopy* regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdCopyImage", CallingConvention = callingConvention)]
        public static extern void vkCmdCopyImage(IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy* regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdBlitImage", CallingConvention = callingConvention)]
        public static extern void vkCmdBlitImage(IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit* regions, Filter filter);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdCopyBufferToImage", CallingConvention = callingConvention)]
        public static extern void vkCmdCopyBufferToImage(IntPtr commandBuffer, UInt64 srcBuffer, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy* regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdCopyImageToBuffer", CallingConvention = callingConvention)]
        public static extern void vkCmdCopyImageToBuffer(IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstBuffer, UInt32 regionCount, BufferImageCopy* regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdUpdateBuffer", CallingConvention = callingConvention)]
        public static extern void vkCmdUpdateBuffer(IntPtr commandBuffer, UInt64 dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, Byte* data);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdFillBuffer", CallingConvention = callingConvention)]
        public static extern void vkCmdFillBuffer(IntPtr commandBuffer, UInt64 dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdClearColorImage", CallingConvention = callingConvention)]
        public static extern void vkCmdClearColorImage(IntPtr commandBuffer, UInt64 image, ImageLayout imageLayout, ClearColorValue* color, UInt32 rangeCount, ImageSubresourceRange* ranges);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdClearDepthStencilImage", CallingConvention = callingConvention)]
        public static extern void vkCmdClearDepthStencilImage(IntPtr commandBuffer, UInt64 image, ImageLayout imageLayout, ClearDepthStencilValue* depthStencil, UInt32 rangeCount, ImageSubresourceRange* ranges);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdClearAttachments", CallingConvention = callingConvention)]
        public static extern void vkCmdClearAttachments(IntPtr commandBuffer, UInt32 attachmentCount, ClearAttachment* attachments, UInt32 rectCount, ClearRect* rects);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdResolveImage", CallingConvention = callingConvention)]
        public static extern void vkCmdResolveImage(IntPtr commandBuffer, UInt64 srcImage, ImageLayout srcImageLayout, UInt64 dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve* regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdSetEvent", CallingConvention = callingConvention)]
        public static extern void vkCmdSetEvent(IntPtr commandBuffer, UInt64 @event, PipelineStageFlags stageMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdResetEvent", CallingConvention = callingConvention)]
        public static extern void vkCmdResetEvent(IntPtr commandBuffer, UInt64 @event, PipelineStageFlags stageMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="memoryBarrierCount">Optional</param>
        /// <param name="bufferMemoryBarrierCount">Optional</param>
        /// <param name="imageMemoryBarrierCount">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCmdWaitEvents", CallingConvention = callingConvention)]
        public static extern void vkCmdWaitEvents(IntPtr commandBuffer, UInt32 eventCount, UInt64* events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier* memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* imageMemoryBarriers);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="dependencyFlags">Optional</param>
        /// <param name="memoryBarrierCount">Optional</param>
        /// <param name="bufferMemoryBarrierCount">Optional</param>
        /// <param name="imageMemoryBarrierCount">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCmdPipelineBarrier", CallingConvention = callingConvention)]
        public static extern void vkCmdPipelineBarrier(IntPtr commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier* memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* imageMemoryBarriers);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCmdBeginQuery", CallingConvention = callingConvention)]
        public static extern void vkCmdBeginQuery(IntPtr commandBuffer, UInt64 queryPool, UInt32 query, QueryControlFlags flags);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdEndQuery", CallingConvention = callingConvention)]
        public static extern void vkCmdEndQuery(IntPtr commandBuffer, UInt64 queryPool, UInt32 query);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdResetQueryPool", CallingConvention = callingConvention)]
        public static extern void vkCmdResetQueryPool(IntPtr commandBuffer, UInt64 queryPool, UInt32 firstQuery, UInt32 queryCount);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdWriteTimestamp", CallingConvention = callingConvention)]
        public static extern void vkCmdWriteTimestamp(IntPtr commandBuffer, PipelineStageFlags pipelineStage, UInt64 queryPool, UInt32 query);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCmdCopyQueryPoolResults", CallingConvention = callingConvention)]
        public static extern void vkCmdCopyQueryPoolResults(IntPtr commandBuffer, UInt64 queryPool, UInt32 firstQuery, UInt32 queryCount, UInt64 dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdPushConstants", CallingConvention = callingConvention)]
        public static extern void vkCmdPushConstants(IntPtr commandBuffer, UInt64 layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr* values);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdBeginRenderPass", CallingConvention = callingConvention)]
        public static extern void vkCmdBeginRenderPass(IntPtr commandBuffer, RenderPassBeginInfo* renderPassBegin, SubpassContents contents);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdNextSubpass", CallingConvention = callingConvention)]
        public static extern void vkCmdNextSubpass(IntPtr commandBuffer, SubpassContents contents);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdEndRenderPass", CallingConvention = callingConvention)]
        public static extern void vkCmdEndRenderPass(IntPtr commandBuffer);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkCmdExecuteCommands", CallingConvention = callingConvention)]
        public static extern void vkCmdExecuteCommands(IntPtr commandBuffer, UInt32 commandBufferCount, IntPtr* commandBuffers);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateAndroidSurfaceKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateAndroidSurfaceKHR(IntPtr instance, AndroidSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* surface);
        
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceDisplayPropertiesKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetPhysicalDeviceDisplayPropertiesKHR(IntPtr physicalDevice, UInt32* propertyCount, DisplayPropertiesKHR* properties);
        
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceDisplayPlanePropertiesKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetPhysicalDeviceDisplayPlanePropertiesKHR(IntPtr physicalDevice, UInt32* propertyCount, DisplayPlanePropertiesKHR* properties);
        
        /// <param name="displays">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetDisplayPlaneSupportedDisplaysKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetDisplayPlaneSupportedDisplaysKHR(IntPtr physicalDevice, UInt32 planeIndex, UInt32* displayCount, UInt64* displays);
        
        /// <param name="properties">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetDisplayModePropertiesKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetDisplayModePropertiesKHR(IntPtr physicalDevice, UInt64 display, UInt32* propertyCount, DisplayModePropertiesKHR* properties);
        
        /// <param name="display">ExternSync</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateDisplayModeKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateDisplayModeKHR(IntPtr physicalDevice, UInt64 display, DisplayModeCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* mode);
        
        /// <param name="mode">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkGetDisplayPlaneCapabilitiesKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetDisplayPlaneCapabilitiesKHR(IntPtr physicalDevice, UInt64 mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR* capabilities);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateDisplayPlaneSurfaceKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateDisplayPlaneSurfaceKHR(IntPtr instance, DisplaySurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* surface);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateSharedSwapchainsKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateSharedSwapchainsKHR(IntPtr device, UInt32 swapchainCount, SwapchainCreateInfoKHR* createInfos, AllocationCallbacks* allocator, UInt64* swapchains);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateMirSurfaceKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateMirSurfaceKHR(IntPtr instance, MirSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceMirPresentationSupportKHR", CallingConvention = callingConvention)]
        public static extern Bool32 vkGetPhysicalDeviceMirPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* connection);
        
        /// <param name="surface">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroySurfaceKHR", CallingConvention = callingConvention)]
        public static extern void vkDestroySurfaceKHR(IntPtr instance, UInt64 surface, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceSupportKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetPhysicalDeviceSurfaceSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, UInt64 surface, Bool32* supported);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilitiesKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetPhysicalDeviceSurfaceCapabilitiesKHR(IntPtr physicalDevice, UInt64 surface, SurfaceCapabilitiesKHR* surfaceCapabilities);
        
        /// <param name="surfaceFormats">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceFormatsKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetPhysicalDeviceSurfaceFormatsKHR(IntPtr physicalDevice, UInt64 surface, UInt32* surfaceFormatCount, SurfaceFormatKHR* surfaceFormats);
        
        /// <param name="presentModes">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfacePresentModesKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetPhysicalDeviceSurfacePresentModesKHR(IntPtr physicalDevice, UInt64 surface, UInt32* presentModeCount, PresentModeKHR* presentModes);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateSwapchainKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateSwapchainKHR(IntPtr device, SwapchainCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* swapchain);
        
        /// <param name="swapchain">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroySwapchainKHR", CallingConvention = callingConvention)]
        public static extern void vkDestroySwapchainKHR(IntPtr device, UInt64 swapchain, AllocationCallbacks* allocator);
        
        /// <param name="swapchainImages">Optional</param>
        [DllImport(DllName, EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = callingConvention)]
        public static extern Result vkGetSwapchainImagesKHR(IntPtr device, UInt64 swapchain, UInt32* swapchainImageCount, UInt64* swapchainImages);
        
        /// <param name="swapchain">ExternSync</param>
        /// <param name="semaphore">ExternSync, Optional</param>
        /// <param name="fence">ExternSync, Optional</param>
        [DllImport(DllName, EntryPoint = "vkAcquireNextImageKHR", CallingConvention = callingConvention)]
        public static extern Result vkAcquireNextImageKHR(IntPtr device, UInt64 swapchain, UInt64 timeout, UInt64 semaphore, UInt64 fence, UInt32* imageIndex);
        
        /// <param name="queue">ExternSync</param>
        [DllImport(DllName, EntryPoint = "vkQueuePresentKHR", CallingConvention = callingConvention)]
        public static extern Result vkQueuePresentKHR(IntPtr queue, PresentInfoKHR* presentInfo);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateWaylandSurfaceKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateWaylandSurfaceKHR(IntPtr instance, WaylandSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceWaylandPresentationSupportKHR", CallingConvention = callingConvention)]
        public static extern Bool32 vkGetPhysicalDeviceWaylandPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* display);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateWin32SurfaceKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateWin32SurfaceKHR(IntPtr instance, Win32SurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceWin32PresentationSupportKHR", CallingConvention = callingConvention)]
        public static extern Bool32 vkGetPhysicalDeviceWin32PresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateXlibSurfaceKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateXlibSurfaceKHR(IntPtr instance, XlibSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceXlibPresentationSupportKHR", CallingConvention = callingConvention)]
        public static extern Bool32 vkGetPhysicalDeviceXlibPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* dpy, IntPtr visualID);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateXcbSurfaceKHR", CallingConvention = callingConvention)]
        public static extern Result vkCreateXcbSurfaceKHR(IntPtr instance, XcbSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, UInt64* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceXcbPresentationSupportKHR", CallingConvention = callingConvention)]
        public static extern Bool32 vkGetPhysicalDeviceXcbPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* connection, IntPtr visual_id);
        
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkCreateDebugReportCallbackEXT", CallingConvention = callingConvention)]
        public static extern Result vkCreateDebugReportCallbackEXT(IntPtr instance, DebugReportCallbackCreateInfoEXT* createInfo, AllocationCallbacks* allocator, UInt64* callback);
        
        /// <param name="callback">ExternSync</param>
        /// <param name="allocator">Optional</param>
        [DllImport(DllName, EntryPoint = "vkDestroyDebugReportCallbackEXT", CallingConvention = callingConvention)]
        public static extern void vkDestroyDebugReportCallbackEXT(IntPtr instance, UInt64 callback, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkDebugReportMessageEXT", CallingConvention = callingConvention)]
        public static extern void vkDebugReportMessageEXT(IntPtr instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UInt32 location, Int32 messageCode, String layerPrefix, String message);
        
        [DllImport(DllName, EntryPoint = "vkDebugMarkerSetObjectNameEXT", CallingConvention = callingConvention)]
        public static extern Result vkDebugMarkerSetObjectNameEXT(IntPtr device, DebugMarkerObjectNameInfoEXT* nameInfo);
        
        [DllImport(DllName, EntryPoint = "vkDebugMarkerSetObjectTagEXT", CallingConvention = callingConvention)]
        public static extern Result vkDebugMarkerSetObjectTagEXT(IntPtr device, DebugMarkerObjectTagInfoEXT* tagInfo);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        [DllImport(DllName, EntryPoint = "vkCmdDebugMarkerBeginEXT", CallingConvention = callingConvention)]
        public static extern void vkCmdDebugMarkerBeginEXT(IntPtr commandBuffer, DebugMarkerMarkerInfoEXT* markerInfo);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        [DllImport(DllName, EntryPoint = "vkCmdDebugMarkerEndEXT", CallingConvention = callingConvention)]
        public static extern void vkCmdDebugMarkerEndEXT(IntPtr commandBuffer);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        [DllImport(DllName, EntryPoint = "vkCmdDebugMarkerInsertEXT", CallingConvention = callingConvention)]
        public static extern void vkCmdDebugMarkerInsertEXT(IntPtr commandBuffer, DebugMarkerMarkerInfoEXT* markerInfo);
        
    }
}
