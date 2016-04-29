using System;
using System.Runtime.InteropServices;

namespace Vulkan.Interop
{
    internal unsafe static class VK
    {
        const string DllName = "vulkan-1.dll";
        const CallingConvention callingConvention = CallingConvention.Winapi;
        
        [DllImport(DllName, EntryPoint = "vkCreateInstance", CallingConvention = callingConvention)]
        internal static extern Result vkCreateInstance(InstanceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* instance);
        
        [DllImport(DllName, EntryPoint = "vkDestroyInstance", CallingConvention = callingConvention)]
        internal static extern void vkDestroyInstance(IntPtr instance, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = callingConvention)]
        internal static extern Result vkEnumeratePhysicalDevices(IntPtr instance, UInt32* physicalDeviceCount, IntPtr* physicalDevices);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = callingConvention)]
        internal static extern void vkGetPhysicalDeviceProperties(IntPtr physicalDevice, PhysicalDeviceProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = callingConvention)]
        internal static extern void vkGetPhysicalDeviceQueueFamilyProperties(IntPtr physicalDevice, UInt32* queueFamilyPropertyCount, QueueFamilyProperties* queueFamilyProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceMemoryProperties", CallingConvention = callingConvention)]
        internal static extern void vkGetPhysicalDeviceMemoryProperties(IntPtr physicalDevice, PhysicalDeviceMemoryProperties* memoryProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = callingConvention)]
        internal static extern void vkGetPhysicalDeviceFeatures(IntPtr physicalDevice, PhysicalDeviceFeatures* features);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceFormatProperties", CallingConvention = callingConvention)]
        internal static extern void vkGetPhysicalDeviceFormatProperties(IntPtr physicalDevice, Format format, FormatProperties* formatProperties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceImageFormatProperties", CallingConvention = callingConvention)]
        internal static extern Result vkGetPhysicalDeviceImageFormatProperties(IntPtr physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* imageFormatProperties);
        
        [DllImport(DllName, EntryPoint = "vkCreateDevice", CallingConvention = callingConvention)]
        internal static extern Result vkCreateDevice(IntPtr physicalDevice, DeviceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* device);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDevice", CallingConvention = callingConvention)]
        internal static extern void vkDestroyDevice(IntPtr device, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = callingConvention)]
        internal static extern Result vkEnumerateInstanceLayerProperties(UInt32* propertyCount, LayerProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateInstanceExtensionProperties", CallingConvention = callingConvention)]
        internal static extern Result vkEnumerateInstanceExtensionProperties(String layerName, UInt32* propertyCount, ExtensionProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = callingConvention)]
        internal static extern Result vkEnumerateDeviceLayerProperties(IntPtr physicalDevice, UInt32* propertyCount, LayerProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = callingConvention)]
        internal static extern Result vkEnumerateDeviceExtensionProperties(IntPtr physicalDevice, String layerName, UInt32* propertyCount, ExtensionProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceQueue", CallingConvention = callingConvention)]
        internal static extern void vkGetDeviceQueue(IntPtr device, UInt32 queueFamilyIndex, UInt32 queueIndex, IntPtr* queue);
        
        [DllImport(DllName, EntryPoint = "vkQueueSubmit", CallingConvention = callingConvention)]
        internal static extern Result vkQueueSubmit(IntPtr queue, UInt32 submitCount, SubmitInfo* submits, IntPtr fence);
        
        [DllImport(DllName, EntryPoint = "vkQueueWaitIdle", CallingConvention = callingConvention)]
        internal static extern Result vkQueueWaitIdle(IntPtr queue);
        
        [DllImport(DllName, EntryPoint = "vkDeviceWaitIdle", CallingConvention = callingConvention)]
        internal static extern Result vkDeviceWaitIdle(IntPtr device);
        
        [DllImport(DllName, EntryPoint = "vkAllocateMemory", CallingConvention = callingConvention)]
        internal static extern Result vkAllocateMemory(IntPtr device, MemoryAllocateInfo* allocateInfo, AllocationCallbacks* allocator, IntPtr* memory);
        
        [DllImport(DllName, EntryPoint = "vkFreeMemory", CallingConvention = callingConvention)]
        internal static extern void vkFreeMemory(IntPtr device, IntPtr memory, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkMapMemory", CallingConvention = callingConvention)]
        internal static extern Result vkMapMemory(IntPtr device, IntPtr memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr* data);
        
        [DllImport(DllName, EntryPoint = "vkUnmapMemory", CallingConvention = callingConvention)]
        internal static extern void vkUnmapMemory(IntPtr device, IntPtr memory);
        
        [DllImport(DllName, EntryPoint = "vkFlushMappedMemoryRanges", CallingConvention = callingConvention)]
        internal static extern Result vkFlushMappedMemoryRanges(IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* memoryRanges);
        
        [DllImport(DllName, EntryPoint = "vkInvalidateMappedMemoryRanges", CallingConvention = callingConvention)]
        internal static extern Result vkInvalidateMappedMemoryRanges(IntPtr device, UInt32 memoryRangeCount, MappedMemoryRange* memoryRanges);
        
        [DllImport(DllName, EntryPoint = "vkGetDeviceMemoryCommitment", CallingConvention = callingConvention)]
        internal static extern void vkGetDeviceMemoryCommitment(IntPtr device, IntPtr memory, DeviceSize* committedMemoryInBytes);
        
        [DllImport(DllName, EntryPoint = "vkGetBufferMemoryRequirements", CallingConvention = callingConvention)]
        internal static extern void vkGetBufferMemoryRequirements(IntPtr device, IntPtr buffer, MemoryRequirements* memoryRequirements);
        
        [DllImport(DllName, EntryPoint = "vkBindBufferMemory", CallingConvention = callingConvention)]
        internal static extern Result vkBindBufferMemory(IntPtr device, IntPtr buffer, IntPtr memory, DeviceSize memoryOffset);
        
        [DllImport(DllName, EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = callingConvention)]
        internal static extern void vkGetImageMemoryRequirements(IntPtr device, IntPtr image, MemoryRequirements* memoryRequirements);
        
        [DllImport(DllName, EntryPoint = "vkBindImageMemory", CallingConvention = callingConvention)]
        internal static extern Result vkBindImageMemory(IntPtr device, IntPtr image, IntPtr memory, DeviceSize memoryOffset);
        
        [DllImport(DllName, EntryPoint = "vkGetImageSparseMemoryRequirements", CallingConvention = callingConvention)]
        internal static extern void vkGetImageSparseMemoryRequirements(IntPtr device, IntPtr image, UInt32* sparseMemoryRequirementCount, SparseImageMemoryRequirements* sparseMemoryRequirements);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties", CallingConvention = callingConvention)]
        internal static extern void vkGetPhysicalDeviceSparseImageFormatProperties(IntPtr physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32* propertyCount, SparseImageFormatProperties* properties);
        
        [DllImport(DllName, EntryPoint = "vkQueueBindSparse", CallingConvention = callingConvention)]
        internal static extern Result vkQueueBindSparse(IntPtr queue, UInt32 bindInfoCount, BindSparseInfo* bindInfo, IntPtr fence);
        
        [DllImport(DllName, EntryPoint = "vkCreateFence", CallingConvention = callingConvention)]
        internal static extern Result vkCreateFence(IntPtr device, FenceCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* fence);
        
        [DllImport(DllName, EntryPoint = "vkDestroyFence", CallingConvention = callingConvention)]
        internal static extern void vkDestroyFence(IntPtr device, IntPtr fence, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkResetFences", CallingConvention = callingConvention)]
        internal static extern Result vkResetFences(IntPtr device, UInt32 fenceCount, IntPtr* fences);
        
        [DllImport(DllName, EntryPoint = "vkGetFenceStatus", CallingConvention = callingConvention)]
        internal static extern Result vkGetFenceStatus(IntPtr device, IntPtr fence);
        
        [DllImport(DllName, EntryPoint = "vkWaitForFences", CallingConvention = callingConvention)]
        internal static extern Result vkWaitForFences(IntPtr device, UInt32 fenceCount, IntPtr* fences, Boolean waitAll, UInt64 timeout);
        
        [DllImport(DllName, EntryPoint = "vkCreateSemaphore", CallingConvention = callingConvention)]
        internal static extern Result vkCreateSemaphore(IntPtr device, SemaphoreCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* semaphore);
        
        [DllImport(DllName, EntryPoint = "vkDestroySemaphore", CallingConvention = callingConvention)]
        internal static extern void vkDestroySemaphore(IntPtr device, IntPtr semaphore, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateEvent", CallingConvention = callingConvention)]
        internal static extern Result vkCreateEvent(IntPtr device, EventCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* @event);
        
        [DllImport(DllName, EntryPoint = "vkDestroyEvent", CallingConvention = callingConvention)]
        internal static extern void vkDestroyEvent(IntPtr device, IntPtr @event, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetEventStatus", CallingConvention = callingConvention)]
        internal static extern Result vkGetEventStatus(IntPtr device, IntPtr @event);
        
        [DllImport(DllName, EntryPoint = "vkSetEvent", CallingConvention = callingConvention)]
        internal static extern Result vkSetEvent(IntPtr device, IntPtr @event);
        
        [DllImport(DllName, EntryPoint = "vkResetEvent", CallingConvention = callingConvention)]
        internal static extern Result vkResetEvent(IntPtr device, IntPtr @event);
        
        [DllImport(DllName, EntryPoint = "vkCreateQueryPool", CallingConvention = callingConvention)]
        internal static extern Result vkCreateQueryPool(IntPtr device, QueryPoolCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* queryPool);
        
        [DllImport(DllName, EntryPoint = "vkDestroyQueryPool", CallingConvention = callingConvention)]
        internal static extern void vkDestroyQueryPool(IntPtr device, IntPtr queryPool, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetQueryPoolResults", CallingConvention = callingConvention)]
        internal static extern Result vkGetQueryPoolResults(IntPtr device, IntPtr queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr* data, DeviceSize stride, QueryResultFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCreateBuffer", CallingConvention = callingConvention)]
        internal static extern Result vkCreateBuffer(IntPtr device, BufferCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* buffer);
        
        [DllImport(DllName, EntryPoint = "vkDestroyBuffer", CallingConvention = callingConvention)]
        internal static extern void vkDestroyBuffer(IntPtr device, IntPtr buffer, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateBufferView", CallingConvention = callingConvention)]
        internal static extern Result vkCreateBufferView(IntPtr device, BufferViewCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* view);
        
        [DllImport(DllName, EntryPoint = "vkDestroyBufferView", CallingConvention = callingConvention)]
        internal static extern void vkDestroyBufferView(IntPtr device, IntPtr bufferView, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateImage", CallingConvention = callingConvention)]
        internal static extern Result vkCreateImage(IntPtr device, ImageCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* image);
        
        [DllImport(DllName, EntryPoint = "vkDestroyImage", CallingConvention = callingConvention)]
        internal static extern void vkDestroyImage(IntPtr device, IntPtr image, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetImageSubresourceLayout", CallingConvention = callingConvention)]
        internal static extern void vkGetImageSubresourceLayout(IntPtr device, IntPtr image, ImageSubresource* subresource, SubresourceLayout* layout);
        
        [DllImport(DllName, EntryPoint = "vkCreateImageView", CallingConvention = callingConvention)]
        internal static extern Result vkCreateImageView(IntPtr device, ImageViewCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* view);
        
        [DllImport(DllName, EntryPoint = "vkDestroyImageView", CallingConvention = callingConvention)]
        internal static extern void vkDestroyImageView(IntPtr device, IntPtr imageView, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateShaderModule", CallingConvention = callingConvention)]
        internal static extern Result vkCreateShaderModule(IntPtr device, ShaderModuleCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* shaderModule);
        
        [DllImport(DllName, EntryPoint = "vkDestroyShaderModule", CallingConvention = callingConvention)]
        internal static extern void vkDestroyShaderModule(IntPtr device, IntPtr shaderModule, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreatePipelineCache", CallingConvention = callingConvention)]
        internal static extern Result vkCreatePipelineCache(IntPtr device, PipelineCacheCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* pipelineCache);
        
        [DllImport(DllName, EntryPoint = "vkDestroyPipelineCache", CallingConvention = callingConvention)]
        internal static extern void vkDestroyPipelineCache(IntPtr device, IntPtr pipelineCache, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkMergePipelineCaches", CallingConvention = callingConvention)]
        internal static extern Result vkMergePipelineCaches(IntPtr device, IntPtr dstCache, UInt32 srcCacheCount, IntPtr* srcCaches);
        
        [DllImport(DllName, EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = callingConvention)]
        internal static extern Result vkCreateGraphicsPipelines(IntPtr device, IntPtr pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo* createInfos, AllocationCallbacks* allocator, IntPtr* pipelines);
        
        [DllImport(DllName, EntryPoint = "vkCreateComputePipelines", CallingConvention = callingConvention)]
        internal static extern Result vkCreateComputePipelines(IntPtr device, IntPtr pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo* createInfos, AllocationCallbacks* allocator, IntPtr* pipelines);
        
        [DllImport(DllName, EntryPoint = "vkDestroyPipeline", CallingConvention = callingConvention)]
        internal static extern void vkDestroyPipeline(IntPtr device, IntPtr pipeline, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreatePipelineLayout", CallingConvention = callingConvention)]
        internal static extern Result vkCreatePipelineLayout(IntPtr device, PipelineLayoutCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* pipelineLayout);
        
        [DllImport(DllName, EntryPoint = "vkDestroyPipelineLayout", CallingConvention = callingConvention)]
        internal static extern void vkDestroyPipelineLayout(IntPtr device, IntPtr pipelineLayout, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateSampler", CallingConvention = callingConvention)]
        internal static extern Result vkCreateSampler(IntPtr device, SamplerCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* sampler);
        
        [DllImport(DllName, EntryPoint = "vkDestroySampler", CallingConvention = callingConvention)]
        internal static extern void vkDestroySampler(IntPtr device, IntPtr sampler, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = callingConvention)]
        internal static extern Result vkCreateDescriptorSetLayout(IntPtr device, DescriptorSetLayoutCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* setLayout);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = callingConvention)]
        internal static extern void vkDestroyDescriptorSetLayout(IntPtr device, IntPtr descriptorSetLayout, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateDescriptorPool", CallingConvention = callingConvention)]
        internal static extern Result vkCreateDescriptorPool(IntPtr device, DescriptorPoolCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* descriptorPool);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDescriptorPool", CallingConvention = callingConvention)]
        internal static extern void vkDestroyDescriptorPool(IntPtr device, IntPtr descriptorPool, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkResetDescriptorPool", CallingConvention = callingConvention)]
        internal static extern Result vkResetDescriptorPool(IntPtr device, IntPtr descriptorPool, DescriptorPoolResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkAllocateDescriptorSets", CallingConvention = callingConvention)]
        internal static extern Result vkAllocateDescriptorSets(IntPtr device, DescriptorSetAllocateInfo* allocateInfo, IntPtr* descriptorSets);
        
        [DllImport(DllName, EntryPoint = "vkFreeDescriptorSets", CallingConvention = callingConvention)]
        internal static extern Result vkFreeDescriptorSets(IntPtr device, IntPtr descriptorPool, UInt32 descriptorSetCount, IntPtr* descriptorSets);
        
        [DllImport(DllName, EntryPoint = "vkUpdateDescriptorSets", CallingConvention = callingConvention)]
        internal static extern void vkUpdateDescriptorSets(IntPtr device, UInt32 descriptorWriteCount, WriteDescriptorSet* descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet* descriptorCopies);
        
        [DllImport(DllName, EntryPoint = "vkCreateFramebuffer", CallingConvention = callingConvention)]
        internal static extern Result vkCreateFramebuffer(IntPtr device, FramebufferCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* framebuffer);
        
        [DllImport(DllName, EntryPoint = "vkDestroyFramebuffer", CallingConvention = callingConvention)]
        internal static extern void vkDestroyFramebuffer(IntPtr device, IntPtr framebuffer, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkCreateRenderPass", CallingConvention = callingConvention)]
        internal static extern Result vkCreateRenderPass(IntPtr device, RenderPassCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* renderPass);
        
        [DllImport(DllName, EntryPoint = "vkDestroyRenderPass", CallingConvention = callingConvention)]
        internal static extern void vkDestroyRenderPass(IntPtr device, IntPtr renderPass, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetRenderAreaGranularity", CallingConvention = callingConvention)]
        internal static extern void vkGetRenderAreaGranularity(IntPtr device, IntPtr renderPass, Extent2D* granularity);
        
        [DllImport(DllName, EntryPoint = "vkCreateCommandPool", CallingConvention = callingConvention)]
        internal static extern Result vkCreateCommandPool(IntPtr device, CommandPoolCreateInfo* createInfo, AllocationCallbacks* allocator, IntPtr* commandPool);
        
        [DllImport(DllName, EntryPoint = "vkDestroyCommandPool", CallingConvention = callingConvention)]
        internal static extern void vkDestroyCommandPool(IntPtr device, IntPtr commandPool, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkResetCommandPool", CallingConvention = callingConvention)]
        internal static extern Result vkResetCommandPool(IntPtr device, IntPtr commandPool, CommandPoolResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkAllocateCommandBuffers", CallingConvention = callingConvention)]
        internal static extern Result vkAllocateCommandBuffers(IntPtr device, CommandBufferAllocateInfo* allocateInfo, IntPtr* commandBuffers);
        
        [DllImport(DllName, EntryPoint = "vkFreeCommandBuffers", CallingConvention = callingConvention)]
        internal static extern void vkFreeCommandBuffers(IntPtr device, IntPtr commandPool, UInt32 commandBufferCount, IntPtr* commandBuffers);
        
        [DllImport(DllName, EntryPoint = "vkBeginCommandBuffer", CallingConvention = callingConvention)]
        internal static extern Result vkBeginCommandBuffer(IntPtr commandBuffer, CommandBufferBeginInfo* beginInfo);
        
        [DllImport(DllName, EntryPoint = "vkEndCommandBuffer", CallingConvention = callingConvention)]
        internal static extern Result vkEndCommandBuffer(IntPtr commandBuffer);
        
        [DllImport(DllName, EntryPoint = "vkResetCommandBuffer", CallingConvention = callingConvention)]
        internal static extern Result vkResetCommandBuffer(IntPtr commandBuffer, CommandBufferResetFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindPipeline", CallingConvention = callingConvention)]
        internal static extern void vkCmdBindPipeline(IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, IntPtr pipeline);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetViewport", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetViewport(IntPtr commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport* viewports);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetScissor", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetScissor(IntPtr commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D* scissors);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetLineWidth", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetLineWidth(IntPtr commandBuffer, Single lineWidth);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetDepthBias", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetDepthBias(IntPtr commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetBlendConstants", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetBlendConstants(IntPtr commandBuffer, Single blendConstants);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetDepthBounds", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetDepthBounds(IntPtr commandBuffer, Single minDepthBounds, Single maxDepthBounds);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilCompareMask", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetStencilCompareMask(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilWriteMask", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetStencilWriteMask(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetStencilReference", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetStencilReference(IntPtr commandBuffer, StencilFaceFlags faceMask, UInt32 reference);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindDescriptorSets", CallingConvention = callingConvention)]
        internal static extern void vkCmdBindDescriptorSets(IntPtr commandBuffer, PipelineBindPoint pipelineBindPoint, IntPtr layout, UInt32 firstSet, UInt32 descriptorSetCount, IntPtr* descriptorSets, UInt32 dynamicOffsetCount, UInt32* dynamicOffsets);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = callingConvention)]
        internal static extern void vkCmdBindIndexBuffer(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset, IndexType indexType);
        
        [DllImport(DllName, EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = callingConvention)]
        internal static extern void vkCmdBindVertexBuffers(IntPtr commandBuffer, UInt32 firstBinding, UInt32 bindingCount, IntPtr* buffers, DeviceSize* offsets);
        
        [DllImport(DllName, EntryPoint = "vkCmdDraw", CallingConvention = callingConvention)]
        internal static extern void vkCmdDraw(IntPtr commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);
        
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndexed", CallingConvention = callingConvention)]
        internal static extern void vkCmdDrawIndexed(IntPtr commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance);
        
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndirect", CallingConvention = callingConvention)]
        internal static extern void vkCmdDrawIndirect(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        [DllImport(DllName, EntryPoint = "vkCmdDrawIndexedIndirect", CallingConvention = callingConvention)]
        internal static extern void vkCmdDrawIndexedIndirect(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        [DllImport(DllName, EntryPoint = "vkCmdDispatch", CallingConvention = callingConvention)]
        internal static extern void vkCmdDispatch(IntPtr commandBuffer, UInt32 x, UInt32 y, UInt32 z);
        
        [DllImport(DllName, EntryPoint = "vkCmdDispatchIndirect", CallingConvention = callingConvention)]
        internal static extern void vkCmdDispatchIndirect(IntPtr commandBuffer, IntPtr buffer, DeviceSize offset);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyBuffer", CallingConvention = callingConvention)]
        internal static extern void vkCmdCopyBuffer(IntPtr commandBuffer, IntPtr srcBuffer, IntPtr dstBuffer, UInt32 regionCount, BufferCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyImage", CallingConvention = callingConvention)]
        internal static extern void vkCmdCopyImage(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdBlitImage", CallingConvention = callingConvention)]
        internal static extern void vkCmdBlitImage(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit* regions, Filter filter);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyBufferToImage", CallingConvention = callingConvention)]
        internal static extern void vkCmdCopyBufferToImage(IntPtr commandBuffer, IntPtr srcBuffer, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyImageToBuffer", CallingConvention = callingConvention)]
        internal static extern void vkCmdCopyImageToBuffer(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstBuffer, UInt32 regionCount, BufferImageCopy* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdUpdateBuffer", CallingConvention = callingConvention)]
        internal static extern void vkCmdUpdateBuffer(IntPtr commandBuffer, IntPtr dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32* data);
        
        [DllImport(DllName, EntryPoint = "vkCmdFillBuffer", CallingConvention = callingConvention)]
        internal static extern void vkCmdFillBuffer(IntPtr commandBuffer, IntPtr dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);
        
        [DllImport(DllName, EntryPoint = "vkCmdClearColorImage", CallingConvention = callingConvention)]
        internal static extern void vkCmdClearColorImage(IntPtr commandBuffer, IntPtr image, ImageLayout imageLayout, ClearColorValue* color, UInt32 rangeCount, ImageSubresourceRange* ranges);
        
        [DllImport(DllName, EntryPoint = "vkCmdClearDepthStencilImage", CallingConvention = callingConvention)]
        internal static extern void vkCmdClearDepthStencilImage(IntPtr commandBuffer, IntPtr image, ImageLayout imageLayout, ClearDepthStencilValue* depthStencil, UInt32 rangeCount, ImageSubresourceRange* ranges);
        
        [DllImport(DllName, EntryPoint = "vkCmdClearAttachments", CallingConvention = callingConvention)]
        internal static extern void vkCmdClearAttachments(IntPtr commandBuffer, UInt32 attachmentCount, ClearAttachment* attachments, UInt32 rectCount, ClearRect* rects);
        
        [DllImport(DllName, EntryPoint = "vkCmdResolveImage", CallingConvention = callingConvention)]
        internal static extern void vkCmdResolveImage(IntPtr commandBuffer, IntPtr srcImage, ImageLayout srcImageLayout, IntPtr dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve* regions);
        
        [DllImport(DllName, EntryPoint = "vkCmdSetEvent", CallingConvention = callingConvention)]
        internal static extern void vkCmdSetEvent(IntPtr commandBuffer, IntPtr @event, PipelineStageFlags stageMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdResetEvent", CallingConvention = callingConvention)]
        internal static extern void vkCmdResetEvent(IntPtr commandBuffer, IntPtr @event, PipelineStageFlags stageMask);
        
        [DllImport(DllName, EntryPoint = "vkCmdWaitEvents", CallingConvention = callingConvention)]
        internal static extern void vkCmdWaitEvents(IntPtr commandBuffer, UInt32 eventCount, IntPtr* events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier* memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* imageMemoryBarriers);
        
        [DllImport(DllName, EntryPoint = "vkCmdPipelineBarrier", CallingConvention = callingConvention)]
        internal static extern void vkCmdPipelineBarrier(IntPtr commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier* memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* imageMemoryBarriers);
        
        [DllImport(DllName, EntryPoint = "vkCmdBeginQuery", CallingConvention = callingConvention)]
        internal static extern void vkCmdBeginQuery(IntPtr commandBuffer, IntPtr queryPool, UInt32 query, QueryControlFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCmdEndQuery", CallingConvention = callingConvention)]
        internal static extern void vkCmdEndQuery(IntPtr commandBuffer, IntPtr queryPool, UInt32 query);
        
        [DllImport(DllName, EntryPoint = "vkCmdResetQueryPool", CallingConvention = callingConvention)]
        internal static extern void vkCmdResetQueryPool(IntPtr commandBuffer, IntPtr queryPool, UInt32 firstQuery, UInt32 queryCount);
        
        [DllImport(DllName, EntryPoint = "vkCmdWriteTimestamp", CallingConvention = callingConvention)]
        internal static extern void vkCmdWriteTimestamp(IntPtr commandBuffer, PipelineStageFlags pipelineStage, IntPtr queryPool, UInt32 query);
        
        [DllImport(DllName, EntryPoint = "vkCmdCopyQueryPoolResults", CallingConvention = callingConvention)]
        internal static extern void vkCmdCopyQueryPoolResults(IntPtr commandBuffer, IntPtr queryPool, UInt32 firstQuery, UInt32 queryCount, IntPtr dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);
        
        [DllImport(DllName, EntryPoint = "vkCmdPushConstants", CallingConvention = callingConvention)]
        internal static extern void vkCmdPushConstants(IntPtr commandBuffer, IntPtr layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr* values);
        
        [DllImport(DllName, EntryPoint = "vkCmdBeginRenderPass", CallingConvention = callingConvention)]
        internal static extern void vkCmdBeginRenderPass(IntPtr commandBuffer, RenderPassBeginInfo* renderPassBegin, SubpassContents contents);
        
        [DllImport(DllName, EntryPoint = "vkCmdNextSubpass", CallingConvention = callingConvention)]
        internal static extern void vkCmdNextSubpass(IntPtr commandBuffer, SubpassContents contents);
        
        [DllImport(DllName, EntryPoint = "vkCmdEndRenderPass", CallingConvention = callingConvention)]
        internal static extern void vkCmdEndRenderPass(IntPtr commandBuffer);
        
        [DllImport(DllName, EntryPoint = "vkCmdExecuteCommands", CallingConvention = callingConvention)]
        internal static extern void vkCmdExecuteCommands(IntPtr commandBuffer, UInt32 commandBufferCount, IntPtr* commandBuffers);
        
        [DllImport(DllName, EntryPoint = "vkCreateAndroidSurfaceKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateAndroidSurfaceKHR(IntPtr instance, AndroidSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceDisplayPropertiesKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetPhysicalDeviceDisplayPropertiesKHR(IntPtr physicalDevice, UInt32* propertyCount, DisplayPropertiesKHR* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceDisplayPlanePropertiesKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetPhysicalDeviceDisplayPlanePropertiesKHR(IntPtr physicalDevice, UInt32* propertyCount, DisplayPlanePropertiesKHR* properties);
        
        [DllImport(DllName, EntryPoint = "vkGetDisplayPlaneSupportedDisplaysKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetDisplayPlaneSupportedDisplaysKHR(IntPtr physicalDevice, UInt32 planeIndex, UInt32* displayCount, IntPtr* displays);
        
        [DllImport(DllName, EntryPoint = "vkGetDisplayModePropertiesKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetDisplayModePropertiesKHR(IntPtr physicalDevice, IntPtr display, UInt32* propertyCount, DisplayModePropertiesKHR* properties);
        
        [DllImport(DllName, EntryPoint = "vkCreateDisplayModeKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateDisplayModeKHR(IntPtr physicalDevice, IntPtr display, DisplayModeCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* mode);
        
        [DllImport(DllName, EntryPoint = "vkGetDisplayPlaneCapabilitiesKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetDisplayPlaneCapabilitiesKHR(IntPtr physicalDevice, IntPtr mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR* capabilities);
        
        [DllImport(DllName, EntryPoint = "vkCreateDisplayPlaneSurfaceKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateDisplayPlaneSurfaceKHR(IntPtr instance, DisplaySurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkCreateSharedSwapchainsKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateSharedSwapchainsKHR(IntPtr device, UInt32 swapchainCount, SwapchainCreateInfoKHR* createInfos, AllocationCallbacks* allocator, IntPtr* swapchains);
        
        [DllImport(DllName, EntryPoint = "vkCreateMirSurfaceKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateMirSurfaceKHR(IntPtr instance, MirSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceMirPresentationSupportKHR", CallingConvention = callingConvention)]
        internal static extern Boolean vkGetPhysicalDeviceMirPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* connection);
        
        [DllImport(DllName, EntryPoint = "vkDestroySurfaceKHR", CallingConvention = callingConvention)]
        internal static extern void vkDestroySurfaceKHR(IntPtr instance, IntPtr surface, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceSupportKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetPhysicalDeviceSurfaceSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr surface, Boolean* supported);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilitiesKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetPhysicalDeviceSurfaceCapabilitiesKHR(IntPtr physicalDevice, IntPtr surface, SurfaceCapabilitiesKHR* surfaceCapabilities);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceSurfaceFormatsKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetPhysicalDeviceSurfaceFormatsKHR(IntPtr physicalDevice, IntPtr surface, UInt32* surfaceFormatCount, SurfaceFormatKHR* surfaceFormats);
        
        [DllImport(DllName, EntryPoint = "vkCreateSwapchainKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateSwapchainKHR(IntPtr device, SwapchainCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* swapchain);
        
        [DllImport(DllName, EntryPoint = "vkDestroySwapchainKHR", CallingConvention = callingConvention)]
        internal static extern void vkDestroySwapchainKHR(IntPtr device, IntPtr swapchain, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = callingConvention)]
        internal static extern Result vkGetSwapchainImagesKHR(IntPtr device, IntPtr swapchain, UInt32* swapchainImageCount, IntPtr* swapchainImages);
        
        [DllImport(DllName, EntryPoint = "vkAcquireNextImageKHR", CallingConvention = callingConvention)]
        internal static extern Result vkAcquireNextImageKHR(IntPtr device, IntPtr swapchain, UInt64 timeout, IntPtr semaphore, IntPtr fence, UInt32* imageIndex);
        
        [DllImport(DllName, EntryPoint = "vkQueuePresentKHR", CallingConvention = callingConvention)]
        internal static extern Result vkQueuePresentKHR(IntPtr queue, PresentInfoKHR* presentInfo);
        
        [DllImport(DllName, EntryPoint = "vkCreateWaylandSurfaceKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateWaylandSurfaceKHR(IntPtr instance, WaylandSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceWaylandPresentationSupportKHR", CallingConvention = callingConvention)]
        internal static extern Boolean vkGetPhysicalDeviceWaylandPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* display);
        
        [DllImport(DllName, EntryPoint = "vkCreateWin32SurfaceKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateWin32SurfaceKHR(IntPtr instance, Win32SurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceWin32PresentationSupportKHR", CallingConvention = callingConvention)]
        internal static extern Boolean vkGetPhysicalDeviceWin32PresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex);
        
        [DllImport(DllName, EntryPoint = "vkCreateXlibSurfaceKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateXlibSurfaceKHR(IntPtr instance, XlibSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceXlibPresentationSupportKHR", CallingConvention = callingConvention)]
        internal static extern Boolean vkGetPhysicalDeviceXlibPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* dpy, IntPtr visualID);
        
        [DllImport(DllName, EntryPoint = "vkCreateXcbSurfaceKHR", CallingConvention = callingConvention)]
        internal static extern Result vkCreateXcbSurfaceKHR(IntPtr instance, XcbSurfaceCreateInfoKHR* createInfo, AllocationCallbacks* allocator, IntPtr* surface);
        
        [DllImport(DllName, EntryPoint = "vkGetPhysicalDeviceXcbPresentationSupportKHR", CallingConvention = callingConvention)]
        internal static extern Boolean vkGetPhysicalDeviceXcbPresentationSupportKHR(IntPtr physicalDevice, UInt32 queueFamilyIndex, IntPtr* connection, IntPtr visual_id);
        
        [DllImport(DllName, EntryPoint = "vkCreateDebugReportCallbackEXT", CallingConvention = callingConvention)]
        internal static extern Result vkCreateDebugReportCallbackEXT(IntPtr instance, DebugReportCallbackCreateInfoEXT* createInfo, AllocationCallbacks* allocator, IntPtr* callback);
        
        [DllImport(DllName, EntryPoint = "vkDestroyDebugReportCallbackEXT", CallingConvention = callingConvention)]
        internal static extern void vkDestroyDebugReportCallbackEXT(IntPtr instance, IntPtr callback, AllocationCallbacks* allocator);
        
        [DllImport(DllName, EntryPoint = "vkDebugReportMessageEXT", CallingConvention = callingConvention)]
        internal static extern void vkDebugReportMessageEXT(IntPtr instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, String layerPrefix, String message);
        
    }
}
