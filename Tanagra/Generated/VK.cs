using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public static class VK
    {
        
        static VK()
        {
        }
        
        // Result vkCreateInstance(const InstanceCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Instance* Instance)
        public static unsafe Result CreateInstance(InstanceCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Instance* Instance)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyInstance(Instance instance, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyInstance(Instance instance, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkEnumeratePhysicalDevices(Instance instance, UInt32* PhysicalDeviceCount, PhysicalDevice* PhysicalDevices)
        public static unsafe Result EnumeratePhysicalDevices(Instance instance, UInt32* PhysicalDeviceCount, PhysicalDevice* PhysicalDevices)
        {
            throw new NotImplementedException();
        }
        
        // PFN_vkVoidFunction vkGetDeviceProcAddr(Device device, const Char* Name)
        public static unsafe PFN_vkVoidFunction GetDeviceProcAddr(Device device, Char* Name)
        {
            throw new NotImplementedException();
        }
        
        // PFN_vkVoidFunction vkGetInstanceProcAddr(Instance instance, const Char* Name)
        public static unsafe PFN_vkVoidFunction GetInstanceProcAddr(Instance instance, Char* Name)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetPhysicalDeviceProperties(PhysicalDevice physicalDevice, PhysicalDeviceProperties* Properties)
        public static unsafe void GetPhysicalDeviceProperties(PhysicalDevice physicalDevice, PhysicalDeviceProperties* Properties)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, UInt32* QueueFamilyPropertyCount, QueueFamilyProperties* QueueFamilyProperties)
        public static unsafe void GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, UInt32* QueueFamilyPropertyCount, QueueFamilyProperties* QueueFamilyProperties)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, PhysicalDeviceMemoryProperties* MemoryProperties)
        public static unsafe void GetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, PhysicalDeviceMemoryProperties* MemoryProperties)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, PhysicalDeviceFeatures* Features)
        public static unsafe void GetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, PhysicalDeviceFeatures* Features)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, FormatProperties* FormatProperties)
        public static unsafe void GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, FormatProperties* FormatProperties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* ImageFormatProperties)
        public static unsafe Result GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* ImageFormatProperties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateDevice(PhysicalDevice physicalDevice, const DeviceCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Device* Device)
        public static unsafe Result CreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Device* Device)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyDevice(Device device, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyDevice(Device device, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkEnumerateInstanceLayerProperties(UInt32* PropertyCount, LayerProperties* Properties)
        public static unsafe Result EnumerateInstanceLayerProperties(UInt32* PropertyCount, LayerProperties* Properties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkEnumerateInstanceExtensionProperties(const Char* LayerName, UInt32* PropertyCount, ExtensionProperties* Properties)
        public static unsafe Result EnumerateInstanceExtensionProperties(Char* LayerName, UInt32* PropertyCount, ExtensionProperties* Properties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkEnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, UInt32* PropertyCount, LayerProperties* Properties)
        public static unsafe Result EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, UInt32* PropertyCount, LayerProperties* Properties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkEnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, const Char* LayerName, UInt32* PropertyCount, ExtensionProperties* Properties)
        public static unsafe Result EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, Char* LayerName, UInt32* PropertyCount, ExtensionProperties* Properties)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, Queue* Queue)
        public static unsafe void GetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, Queue* Queue)
        {
            throw new NotImplementedException();
        }
        
        // Result vkQueueSubmit(Queue queue, UInt32 submitCount, const SubmitInfo* Submits, Fence fence)
        public static unsafe Result QueueSubmit(Queue queue, UInt32 submitCount, SubmitInfo* Submits, Fence fence)
        {
            throw new NotImplementedException();
        }
        
        // Result vkQueueWaitIdle(Queue queue)
        public static Result QueueWaitIdle(Queue queue)
        {
            throw new NotImplementedException();
        }
        
        // Result vkDeviceWaitIdle(Device device)
        public static Result DeviceWaitIdle(Device device)
        {
            throw new NotImplementedException();
        }
        
        // Result vkAllocateMemory(Device device, const MemoryAllocateInfo* AllocateInfo, const AllocationCallbacks* Allocator, DeviceMemory* Memory)
        public static unsafe Result AllocateMemory(Device device, MemoryAllocateInfo* AllocateInfo, AllocationCallbacks* Allocator, DeviceMemory* Memory)
        {
            throw new NotImplementedException();
        }
        
        // void vkFreeMemory(Device device, DeviceMemory memory, const AllocationCallbacks* Allocator)
        public static unsafe void FreeMemory(Device device, DeviceMemory memory, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkMapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, void** Data)
        public static unsafe Result MapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr** Data)
        {
            throw new NotImplementedException();
        }
        
        // void vkUnmapMemory(Device device, DeviceMemory memory)
        public static void UnmapMemory(Device device, DeviceMemory memory)
        {
            throw new NotImplementedException();
        }
        
        // Result vkFlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, const MappedMemoryRange* MemoryRanges)
        public static unsafe Result FlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange* MemoryRanges)
        {
            throw new NotImplementedException();
        }
        
        // Result vkInvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, const MappedMemoryRange* MemoryRanges)
        public static unsafe Result InvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange* MemoryRanges)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetDeviceMemoryCommitment(Device device, DeviceMemory memory, DeviceSize* CommittedMemoryInBytes)
        public static unsafe void GetDeviceMemoryCommitment(Device device, DeviceMemory memory, DeviceSize* CommittedMemoryInBytes)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetBufferMemoryRequirements(Device device, Buffer buffer, MemoryRequirements* MemoryRequirements)
        public static unsafe void GetBufferMemoryRequirements(Device device, Buffer buffer, MemoryRequirements* MemoryRequirements)
        {
            throw new NotImplementedException();
        }
        
        // Result vkBindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        public static Result BindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetImageMemoryRequirements(Device device, Image image, MemoryRequirements* MemoryRequirements)
        public static unsafe void GetImageMemoryRequirements(Device device, Image image, MemoryRequirements* MemoryRequirements)
        {
            throw new NotImplementedException();
        }
        
        // Result vkBindImageMemory(Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        public static Result BindImageMemory(Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetImageSparseMemoryRequirements(Device device, Image image, UInt32* SparseMemoryRequirementCount, SparseImageMemoryRequirements* SparseMemoryRequirements)
        public static unsafe void GetImageSparseMemoryRequirements(Device device, Image image, UInt32* SparseMemoryRequirementCount, SparseImageMemoryRequirements* SparseMemoryRequirements)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32* PropertyCount, SparseImageFormatProperties* Properties)
        public static unsafe void GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32* PropertyCount, SparseImageFormatProperties* Properties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkQueueBindSparse(Queue queue, UInt32 bindInfoCount, const BindSparseInfo* BindInfo, Fence fence)
        public static unsafe Result QueueBindSparse(Queue queue, UInt32 bindInfoCount, BindSparseInfo* BindInfo, Fence fence)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateFence(Device device, const FenceCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Fence* Fence)
        public static unsafe Result CreateFence(Device device, FenceCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Fence* Fence)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyFence(Device device, Fence fence, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyFence(Device device, Fence fence, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkResetFences(Device device, UInt32 fenceCount, const Fence* Fences)
        public static unsafe Result ResetFences(Device device, UInt32 fenceCount, Fence* Fences)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetFenceStatus(Device device, Fence fence)
        public static Result GetFenceStatus(Device device, Fence fence)
        {
            throw new NotImplementedException();
        }
        
        // Result vkWaitForFences(Device device, UInt32 fenceCount, const Fence* Fences, Boolean waitAll, UInt64 timeout)
        public static unsafe Result WaitForFences(Device device, UInt32 fenceCount, Fence* Fences, Boolean waitAll, UInt64 timeout)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateSemaphore(Device device, const SemaphoreCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Semaphore* Semaphore)
        public static unsafe Result CreateSemaphore(Device device, SemaphoreCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Semaphore* Semaphore)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroySemaphore(Device device, Semaphore semaphore, const AllocationCallbacks* Allocator)
        public static unsafe void DestroySemaphore(Device device, Semaphore semaphore, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateEvent(Device device, const EventCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Event* Event)
        public static unsafe Result CreateEvent(Device device, EventCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Event* Event)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyEvent(Device device, Event @event, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyEvent(Device device, Event @event, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetEventStatus(Device device, Event @event)
        public static Result GetEventStatus(Device device, Event @event)
        {
            throw new NotImplementedException();
        }
        
        // Result vkSetEvent(Device device, Event @event)
        public static Result SetEvent(Device device, Event @event)
        {
            throw new NotImplementedException();
        }
        
        // Result vkResetEvent(Device device, Event @event)
        public static Result ResetEvent(Device device, Event @event)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateQueryPool(Device device, const QueryPoolCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, QueryPool* QueryPool)
        public static unsafe Result CreateQueryPool(Device device, QueryPoolCreateInfo* CreateInfo, AllocationCallbacks* Allocator, QueryPool* QueryPool)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyQueryPool(Device device, QueryPool queryPool, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyQueryPool(Device device, QueryPool queryPool, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, void* Data, DeviceSize stride, QueryResultFlags flags)
        public static unsafe Result GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr* Data, DeviceSize stride, QueryResultFlags flags)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateBuffer(Device device, const BufferCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Buffer* Buffer)
        public static unsafe Result CreateBuffer(Device device, BufferCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Buffer* Buffer)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyBuffer(Device device, Buffer buffer, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyBuffer(Device device, Buffer buffer, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateBufferView(Device device, const BufferViewCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, BufferView* View)
        public static unsafe Result CreateBufferView(Device device, BufferViewCreateInfo* CreateInfo, AllocationCallbacks* Allocator, BufferView* View)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyBufferView(Device device, BufferView bufferView, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyBufferView(Device device, BufferView bufferView, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateImage(Device device, const ImageCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Image* Image)
        public static unsafe Result CreateImage(Device device, ImageCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Image* Image)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyImage(Device device, Image image, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyImage(Device device, Image image, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetImageSubresourceLayout(Device device, Image image, const ImageSubresource* Subresource, SubresourceLayout* Layout)
        public static unsafe void GetImageSubresourceLayout(Device device, Image image, ImageSubresource* Subresource, SubresourceLayout* Layout)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateImageView(Device device, const ImageViewCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, ImageView* View)
        public static unsafe Result CreateImageView(Device device, ImageViewCreateInfo* CreateInfo, AllocationCallbacks* Allocator, ImageView* View)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyImageView(Device device, ImageView imageView, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyImageView(Device device, ImageView imageView, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateShaderModule(Device device, const ShaderModuleCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, ShaderModule* ShaderModule)
        public static unsafe Result CreateShaderModule(Device device, ShaderModuleCreateInfo* CreateInfo, AllocationCallbacks* Allocator, ShaderModule* ShaderModule)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyShaderModule(Device device, ShaderModule shaderModule, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyShaderModule(Device device, ShaderModule shaderModule, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreatePipelineCache(Device device, const PipelineCacheCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, PipelineCache* PipelineCache)
        public static unsafe Result CreatePipelineCache(Device device, PipelineCacheCreateInfo* CreateInfo, AllocationCallbacks* Allocator, PipelineCache* PipelineCache)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyPipelineCache(Device device, PipelineCache pipelineCache, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyPipelineCache(Device device, PipelineCache pipelineCache, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPipelineCacheData(Device device, PipelineCache pipelineCache, UIntPtr* DataSize, void* Data)
        public static unsafe Result GetPipelineCacheData(Device device, PipelineCache pipelineCache, UIntPtr* DataSize, IntPtr* Data)
        {
            throw new NotImplementedException();
        }
        
        // Result vkMergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, const PipelineCache* SrcCaches)
        public static unsafe Result MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache* SrcCaches)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, const GraphicsPipelineCreateInfo* CreateInfos, const AllocationCallbacks* Allocator, Pipeline* Pipelines)
        public static unsafe Result CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo* CreateInfos, AllocationCallbacks* Allocator, Pipeline* Pipelines)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, const ComputePipelineCreateInfo* CreateInfos, const AllocationCallbacks* Allocator, Pipeline* Pipelines)
        public static unsafe Result CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo* CreateInfos, AllocationCallbacks* Allocator, Pipeline* Pipelines)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyPipeline(Device device, Pipeline pipeline, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreatePipelineLayout(Device device, const PipelineLayoutCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, PipelineLayout* PipelineLayout)
        public static unsafe Result CreatePipelineLayout(Device device, PipelineLayoutCreateInfo* CreateInfo, AllocationCallbacks* Allocator, PipelineLayout* PipelineLayout)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateSampler(Device device, const SamplerCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Sampler* Sampler)
        public static unsafe Result CreateSampler(Device device, SamplerCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Sampler* Sampler)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroySampler(Device device, Sampler sampler, const AllocationCallbacks* Allocator)
        public static unsafe void DestroySampler(Device device, Sampler sampler, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateDescriptorSetLayout(Device device, const DescriptorSetLayoutCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, DescriptorSetLayout* SetLayout)
        public static unsafe Result CreateDescriptorSetLayout(Device device, DescriptorSetLayoutCreateInfo* CreateInfo, AllocationCallbacks* Allocator, DescriptorSetLayout* SetLayout)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateDescriptorPool(Device device, const DescriptorPoolCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, DescriptorPool* DescriptorPool)
        public static unsafe Result CreateDescriptorPool(Device device, DescriptorPoolCreateInfo* CreateInfo, AllocationCallbacks* Allocator, DescriptorPool* DescriptorPool)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyDescriptorPool(Device device, DescriptorPool descriptorPool, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        public static Result ResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            throw new NotImplementedException();
        }
        
        // Result vkAllocateDescriptorSets(Device device, const DescriptorSetAllocateInfo* AllocateInfo, DescriptorSet* DescriptorSets)
        public static unsafe Result AllocateDescriptorSets(Device device, DescriptorSetAllocateInfo* AllocateInfo, DescriptorSet* DescriptorSets)
        {
            throw new NotImplementedException();
        }
        
        // Result vkFreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, const DescriptorSet* DescriptorSets)
        public static unsafe Result FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet* DescriptorSets)
        {
            throw new NotImplementedException();
        }
        
        // void vkUpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, const WriteDescriptorSet* DescriptorWrites, UInt32 descriptorCopyCount, const CopyDescriptorSet* DescriptorCopies)
        public static unsafe void UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, WriteDescriptorSet* DescriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet* DescriptorCopies)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateFramebuffer(Device device, const FramebufferCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, Framebuffer* Framebuffer)
        public static unsafe Result CreateFramebuffer(Device device, FramebufferCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Framebuffer* Framebuffer)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyFramebuffer(Device device, Framebuffer framebuffer, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyFramebuffer(Device device, Framebuffer framebuffer, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateRenderPass(Device device, const RenderPassCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, RenderPass* RenderPass)
        public static unsafe Result CreateRenderPass(Device device, RenderPassCreateInfo* CreateInfo, AllocationCallbacks* Allocator, RenderPass* RenderPass)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyRenderPass(Device device, RenderPass renderPass, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyRenderPass(Device device, RenderPass renderPass, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // void vkGetRenderAreaGranularity(Device device, RenderPass renderPass, Extent2D* Granularity)
        public static unsafe void GetRenderAreaGranularity(Device device, RenderPass renderPass, Extent2D* Granularity)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateCommandPool(Device device, const CommandPoolCreateInfo* CreateInfo, const AllocationCallbacks* Allocator, CommandPool* CommandPool)
        public static unsafe Result CreateCommandPool(Device device, CommandPoolCreateInfo* CreateInfo, AllocationCallbacks* Allocator, CommandPool* CommandPool)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyCommandPool(Device device, CommandPool commandPool, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyCommandPool(Device device, CommandPool commandPool, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        public static Result ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            throw new NotImplementedException();
        }
        
        // Result vkAllocateCommandBuffers(Device device, const CommandBufferAllocateInfo* AllocateInfo, CommandBuffer* CommandBuffers)
        public static unsafe Result AllocateCommandBuffers(Device device, CommandBufferAllocateInfo* AllocateInfo, CommandBuffer* CommandBuffers)
        {
            throw new NotImplementedException();
        }
        
        // void vkFreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, const CommandBuffer* CommandBuffers)
        public static unsafe void FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer* CommandBuffers)
        {
            throw new NotImplementedException();
        }
        
        // Result vkBeginCommandBuffer(CommandBuffer commandBuffer, const CommandBufferBeginInfo* BeginInfo)
        public static unsafe Result BeginCommandBuffer(CommandBuffer commandBuffer, CommandBufferBeginInfo* BeginInfo)
        {
            throw new NotImplementedException();
        }
        
        // Result vkEndCommandBuffer(CommandBuffer commandBuffer)
        public static Result EndCommandBuffer(CommandBuffer commandBuffer)
        {
            throw new NotImplementedException();
        }
        
        // Result vkResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        public static Result ResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        public static void CmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, const Viewport* Viewports)
        public static unsafe void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport* Viewports)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, const Rect2D* Scissors)
        public static unsafe void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D* Scissors)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetLineWidth(CommandBuffer commandBuffer, Single lineWidth)
        public static void CmdSetLineWidth(CommandBuffer commandBuffer, Single lineWidth)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetDepthBias(CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        public static void CmdSetDepthBias(CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetBlendConstants(CommandBuffer commandBuffer, const Single blendConstants)
        public static void CmdSetBlendConstants(CommandBuffer commandBuffer, Single blendConstants)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetDepthBounds(CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        public static void CmdSetDepthBounds(CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        public static void CmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        public static void CmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        public static void CmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, const DescriptorSet* DescriptorSets, UInt32 dynamicOffsetCount, const UInt32* DynamicOffsets)
        public static unsafe void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, DescriptorSet* DescriptorSets, UInt32 dynamicOffsetCount, UInt32* DynamicOffsets)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        public static void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, const Buffer* Buffers, const DeviceSize* Offsets)
        public static unsafe void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, Buffer* Buffers, DeviceSize* Offsets)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        public static void CmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        public static void CmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        public static void CmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        public static void CmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdDispatch(CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        public static void CmdDispatch(CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        public static void CmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, const BufferCopy* Regions)
        public static unsafe void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy* Regions)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, const ImageCopy* Regions)
        public static unsafe void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy* Regions)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, const ImageBlit* Regions, Filter filter)
        public static unsafe void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit* Regions, Filter filter)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, const BufferImageCopy* Regions)
        public static unsafe void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy* Regions)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, const BufferImageCopy* Regions)
        public static unsafe void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy* Regions)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, const UInt32* Data)
        public static unsafe void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32* Data)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        public static void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, const ClearColorValue* Color, UInt32 rangeCount, const ImageSubresourceRange* Ranges)
        public static unsafe void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue* Color, UInt32 rangeCount, ImageSubresourceRange* Ranges)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, const ClearDepthStencilValue* DepthStencil, UInt32 rangeCount, const ImageSubresourceRange* Ranges)
        public static unsafe void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue* DepthStencil, UInt32 rangeCount, ImageSubresourceRange* Ranges)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, const ClearAttachment* Attachments, UInt32 rectCount, const ClearRect* Rects)
        public static unsafe void CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ClearAttachment* Attachments, UInt32 rectCount, ClearRect* Rects)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, const ImageResolve* Regions)
        public static unsafe void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve* Regions)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        public static void CmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        public static void CmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, const Event* Events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, const MemoryBarrier* MemoryBarriers, UInt32 bufferMemoryBarrierCount, const BufferMemoryBarrier* BufferMemoryBarriers, UInt32 imageMemoryBarrierCount, const ImageMemoryBarrier* ImageMemoryBarriers)
        public static unsafe void CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, Event* Events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier* MemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* BufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* ImageMemoryBarriers)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, const MemoryBarrier* MemoryBarriers, UInt32 bufferMemoryBarrierCount, const BufferMemoryBarrier* BufferMemoryBarriers, UInt32 imageMemoryBarrierCount, const ImageMemoryBarrier* ImageMemoryBarriers)
        public static unsafe void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier* MemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* BufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* ImageMemoryBarriers)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags)
        public static void CmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        public static void CmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        public static void CmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        public static void CmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
        public static void CmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, const void* Values)
        public static unsafe void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr* Values)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdBeginRenderPass(CommandBuffer commandBuffer, const RenderPassBeginInfo* RenderPassBegin, SubpassContents contents)
        public static unsafe void CmdBeginRenderPass(CommandBuffer commandBuffer, RenderPassBeginInfo* RenderPassBegin, SubpassContents contents)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents)
        public static void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdEndRenderPass(CommandBuffer commandBuffer)
        public static void CmdEndRenderPass(CommandBuffer commandBuffer)
        {
            throw new NotImplementedException();
        }
        
        // void vkCmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, const CommandBuffer* CommandBuffers)
        public static unsafe void CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, CommandBuffer* CommandBuffers)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateAndroidSurfaceKHR(Instance instance, const AndroidSurfaceCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        public static unsafe Result CreateAndroidSurfaceKHR(Instance instance, AndroidSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice, UInt32* PropertyCount, DisplayPropertiesKHR* Properties)
        public static unsafe Result GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice, UInt32* PropertyCount, DisplayPropertiesKHR* Properties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice, UInt32* PropertyCount, DisplayPlanePropertiesKHR* Properties)
        public static unsafe Result GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice, UInt32* PropertyCount, DisplayPlanePropertiesKHR* Properties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex, UInt32* DisplayCount, DisplayKHR* Displays)
        public static unsafe Result GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex, UInt32* DisplayCount, DisplayKHR* Displays)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display, UInt32* PropertyCount, DisplayModePropertiesKHR* Properties)
        public static unsafe Result GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display, UInt32* PropertyCount, DisplayModePropertiesKHR* Properties)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, const DisplayModeCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, DisplayModeKHR* Mode)
        public static unsafe Result CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, DisplayModeKHR* Mode)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR* Capabilities)
        public static unsafe Result GetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR* Capabilities)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateDisplayPlaneSurfaceKHR(Instance instance, const DisplaySurfaceCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        public static unsafe Result CreateDisplayPlaneSurfaceKHR(Instance instance, DisplaySurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, const SwapchainCreateInfoKHR* CreateInfos, const AllocationCallbacks* Allocator, SwapchainKHR* Swapchains)
        public static unsafe Result CreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR* CreateInfos, AllocationCallbacks* Allocator, SwapchainKHR* Swapchains)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateMirSurfaceKHR(Instance instance, const MirSurfaceCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        public static unsafe Result CreateMirSurfaceKHR(Instance instance, MirSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        {
            throw new NotImplementedException();
        }
        
        // Boolean vkGetPhysicalDeviceMirPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, MirConnection* connection)
        public static unsafe Boolean GetPhysicalDeviceMirPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, MirConnection* connection)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroySurfaceKHR(Instance instance, SurfaceKHR surface, const AllocationCallbacks* Allocator)
        public static unsafe void DestroySurfaceKHR(Instance instance, SurfaceKHR surface, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, Boolean* Supported)
        public static unsafe Result GetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, Boolean* Supported)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, SurfaceCapabilitiesKHR* SurfaceCapabilities)
        public static unsafe Result GetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, SurfaceCapabilitiesKHR* SurfaceCapabilities)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32* SurfaceFormatCount, SurfaceFormatKHR* SurfaceFormats)
        public static unsafe Result GetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32* SurfaceFormatCount, SurfaceFormatKHR* SurfaceFormats)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32* PresentModeCount, PresentModeKHR* PresentModes)
        public static unsafe Result GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32* PresentModeCount, PresentModeKHR* PresentModes)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateSwapchainKHR(Device device, const SwapchainCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SwapchainKHR* Swapchain)
        public static unsafe Result CreateSwapchainKHR(Device device, SwapchainCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SwapchainKHR* Swapchain)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroySwapchainKHR(Device device, SwapchainKHR swapchain, const AllocationCallbacks* Allocator)
        public static unsafe void DestroySwapchainKHR(Device device, SwapchainKHR swapchain, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // Result vkGetSwapchainImagesKHR(Device device, SwapchainKHR swapchain, UInt32* SwapchainImageCount, Image* SwapchainImages)
        public static unsafe Result GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain, UInt32* SwapchainImageCount, Image* SwapchainImages)
        {
            throw new NotImplementedException();
        }
        
        // Result vkAcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, UInt32* ImageIndex)
        public static unsafe Result AcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, UInt32* ImageIndex)
        {
            throw new NotImplementedException();
        }
        
        // Result vkQueuePresentKHR(Queue queue, const PresentInfoKHR* PresentInfo)
        public static unsafe Result QueuePresentKHR(Queue queue, PresentInfoKHR* PresentInfo)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateWaylandSurfaceKHR(Instance instance, const WaylandSurfaceCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        public static unsafe Result CreateWaylandSurfaceKHR(Instance instance, WaylandSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        {
            throw new NotImplementedException();
        }
        
        // Boolean vkGetPhysicalDeviceWaylandPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, wl_display* display)
        public static unsafe Boolean GetPhysicalDeviceWaylandPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, wl_display* display)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateWin32SurfaceKHR(Instance instance, const Win32SurfaceCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        public static unsafe Result CreateWin32SurfaceKHR(Instance instance, Win32SurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        {
            throw new NotImplementedException();
        }
        
        // Boolean vkGetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        public static Boolean GetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateXlibSurfaceKHR(Instance instance, const XlibSurfaceCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        public static unsafe Result CreateXlibSurfaceKHR(Instance instance, XlibSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        {
            throw new NotImplementedException();
        }
        
        // Boolean vkGetPhysicalDeviceXlibPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, Display* dpy, VisualID visualID)
        public static unsafe Boolean GetPhysicalDeviceXlibPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, Display* dpy, VisualID visualID)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateXcbSurfaceKHR(Instance instance, const XcbSurfaceCreateInfoKHR* CreateInfo, const AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        public static unsafe Result CreateXcbSurfaceKHR(Instance instance, XcbSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface)
        {
            throw new NotImplementedException();
        }
        
        // Boolean vkGetPhysicalDeviceXcbPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, xcb_connection_t* connection, xcb_visualid_t visual_id)
        public static unsafe Boolean GetPhysicalDeviceXcbPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, xcb_connection_t* connection, xcb_visualid_t visual_id)
        {
            throw new NotImplementedException();
        }
        
        // Result vkCreateDebugReportCallbackEXT(Instance instance, const DebugReportCallbackCreateInfoEXT* CreateInfo, const AllocationCallbacks* Allocator, DebugReportCallbackEXT* Callback)
        public static unsafe Result CreateDebugReportCallbackEXT(Instance instance, DebugReportCallbackCreateInfoEXT* CreateInfo, AllocationCallbacks* Allocator, DebugReportCallbackEXT* Callback)
        {
            throw new NotImplementedException();
        }
        
        // void vkDestroyDebugReportCallbackEXT(Instance instance, DebugReportCallbackEXT callback, const AllocationCallbacks* Allocator)
        public static unsafe void DestroyDebugReportCallbackEXT(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks* Allocator)
        {
            throw new NotImplementedException();
        }
        
        // void vkDebugReportMessageEXT(Instance instance, VkDebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, const Char* LayerPrefix, const Char* Message)
        public static unsafe void DebugReportMessageEXT(Instance instance, VkDebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, Char* LayerPrefix, Char* Message)
        {
            throw new NotImplementedException();
        }
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateInstance", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateInstance(InstanceCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Instance* Instance);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyInstance", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyInstance(Instance instance, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkEnumeratePhysicalDevices(Instance instance, UInt32* PhysicalDeviceCount, PhysicalDevice* PhysicalDevices);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDeviceProcAddr", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern PFN_vkVoidFunction vkGetDeviceProcAddr(Device device, Char* Name);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetInstanceProcAddr", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern PFN_vkVoidFunction vkGetInstanceProcAddr(Instance instance, Char* Name);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetPhysicalDeviceProperties(PhysicalDevice physicalDevice, PhysicalDeviceProperties* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, UInt32* QueueFamilyPropertyCount, QueueFamilyProperties* QueueFamilyProperties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceMemoryProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, PhysicalDeviceMemoryProperties* MemoryProperties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, PhysicalDeviceFeatures* Features);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceFormatProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, FormatProperties* FormatProperties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceImageFormatProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* ImageFormatProperties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDevice", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Device* Device);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDevice", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyDevice(Device device, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkEnumerateInstanceLayerProperties(UInt32* PropertyCount, LayerProperties* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateInstanceExtensionProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkEnumerateInstanceExtensionProperties(Char* LayerName, UInt32* PropertyCount, ExtensionProperties* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkEnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, UInt32* PropertyCount, LayerProperties* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkEnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, Char* LayerName, UInt32* PropertyCount, ExtensionProperties* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDeviceQueue", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, Queue* Queue);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkQueueSubmit", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkQueueSubmit(Queue queue, UInt32 submitCount, SubmitInfo* Submits, Fence fence);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkQueueWaitIdle", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkQueueWaitIdle(Queue queue);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDeviceWaitIdle", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkDeviceWaitIdle(Device device);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkAllocateMemory", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkAllocateMemory(Device device, MemoryAllocateInfo* AllocateInfo, AllocationCallbacks* Allocator, DeviceMemory* Memory);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkFreeMemory", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkFreeMemory(Device device, DeviceMemory memory, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkMapMemory", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkMapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr** Data);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkUnmapMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkUnmapMemory(Device device, DeviceMemory memory);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkFlushMappedMemoryRanges", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkFlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange* MemoryRanges);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkInvalidateMappedMemoryRanges", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkInvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange* MemoryRanges);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDeviceMemoryCommitment", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetDeviceMemoryCommitment(Device device, DeviceMemory memory, DeviceSize* CommittedMemoryInBytes);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetBufferMemoryRequirements", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetBufferMemoryRequirements(Device device, Buffer buffer, MemoryRequirements* MemoryRequirements);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkBindBufferMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkBindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetImageMemoryRequirements(Device device, Image image, MemoryRequirements* MemoryRequirements);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkBindImageMemory", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkBindImageMemory(Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetImageSparseMemoryRequirements", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetImageSparseMemoryRequirements(Device device, Image image, UInt32* SparseMemoryRequirementCount, SparseImageMemoryRequirements* SparseMemoryRequirements);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceSparseImageFormatProperties", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32* PropertyCount, SparseImageFormatProperties* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkQueueBindSparse", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkQueueBindSparse(Queue queue, UInt32 bindInfoCount, BindSparseInfo* BindInfo, Fence fence);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateFence", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateFence(Device device, FenceCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Fence* Fence);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyFence", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyFence(Device device, Fence fence, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkResetFences", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkResetFences(Device device, UInt32 fenceCount, Fence* Fences);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetFenceStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetFenceStatus(Device device, Fence fence);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkWaitForFences", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkWaitForFences(Device device, UInt32 fenceCount, Fence* Fences, Boolean waitAll, UInt64 timeout);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateSemaphore", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateSemaphore(Device device, SemaphoreCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Semaphore* Semaphore);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroySemaphore", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroySemaphore(Device device, Semaphore semaphore, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateEvent", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateEvent(Device device, EventCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Event* Event);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyEvent", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyEvent(Device device, Event @event, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetEventStatus", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkGetEventStatus(Device device, Event @event);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkSetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkSetEvent(Device device, Event @event);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkResetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetEvent(Device device, Event @event);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateQueryPool", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateQueryPool(Device device, QueryPoolCreateInfo* CreateInfo, AllocationCallbacks* Allocator, QueryPool* QueryPool);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyQueryPool", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyQueryPool(Device device, QueryPool queryPool, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetQueryPoolResults", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr* Data, DeviceSize stride, QueryResultFlags flags);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateBuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateBuffer(Device device, BufferCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Buffer* Buffer);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyBuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyBuffer(Device device, Buffer buffer, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateBufferView", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateBufferView(Device device, BufferViewCreateInfo* CreateInfo, AllocationCallbacks* Allocator, BufferView* View);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyBufferView", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyBufferView(Device device, BufferView bufferView, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateImage(Device device, ImageCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Image* Image);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyImage(Device device, Image image, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetImageSubresourceLayout", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetImageSubresourceLayout(Device device, Image image, ImageSubresource* Subresource, SubresourceLayout* Layout);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateImageView", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateImageView(Device device, ImageViewCreateInfo* CreateInfo, AllocationCallbacks* Allocator, ImageView* View);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyImageView", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyImageView(Device device, ImageView imageView, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateShaderModule", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateShaderModule(Device device, ShaderModuleCreateInfo* CreateInfo, AllocationCallbacks* Allocator, ShaderModule* ShaderModule);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyShaderModule", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyShaderModule(Device device, ShaderModule shaderModule, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreatePipelineCache", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreatePipelineCache(Device device, PipelineCacheCreateInfo* CreateInfo, AllocationCallbacks* Allocator, PipelineCache* PipelineCache);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyPipelineCache", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyPipelineCache(Device device, PipelineCache pipelineCache, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPipelineCacheData", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPipelineCacheData(Device device, PipelineCache pipelineCache, UIntPtr* DataSize, IntPtr* Data);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkMergePipelineCaches", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkMergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache* SrcCaches);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo* CreateInfos, AllocationCallbacks* Allocator, Pipeline* Pipelines);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateComputePipelines", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo* CreateInfos, AllocationCallbacks* Allocator, Pipeline* Pipelines);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyPipeline", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreatePipelineLayout", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreatePipelineLayout(Device device, PipelineLayoutCreateInfo* CreateInfo, AllocationCallbacks* Allocator, PipelineLayout* PipelineLayout);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyPipelineLayout", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateSampler", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateSampler(Device device, SamplerCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Sampler* Sampler);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroySampler", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroySampler(Device device, Sampler sampler, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateDescriptorSetLayout(Device device, DescriptorSetLayoutCreateInfo* CreateInfo, AllocationCallbacks* Allocator, DescriptorSetLayout* SetLayout);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDescriptorPool", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateDescriptorPool(Device device, DescriptorPoolCreateInfo* CreateInfo, AllocationCallbacks* Allocator, DescriptorPool* DescriptorPool);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDescriptorPool", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyDescriptorPool(Device device, DescriptorPool descriptorPool, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkResetDescriptorPool", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkAllocateDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkAllocateDescriptorSets(Device device, DescriptorSetAllocateInfo* AllocateInfo, DescriptorSet* DescriptorSets);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkFreeDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkFreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet* DescriptorSets);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkUpdateDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkUpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, WriteDescriptorSet* DescriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet* DescriptorCopies);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateFramebuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateFramebuffer(Device device, FramebufferCreateInfo* CreateInfo, AllocationCallbacks* Allocator, Framebuffer* Framebuffer);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyFramebuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyFramebuffer(Device device, Framebuffer framebuffer, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateRenderPass(Device device, RenderPassCreateInfo* CreateInfo, AllocationCallbacks* Allocator, RenderPass* RenderPass);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyRenderPass(Device device, RenderPass renderPass, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetRenderAreaGranularity", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkGetRenderAreaGranularity(Device device, RenderPass renderPass, Extent2D* Granularity);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateCommandPool", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateCommandPool(Device device, CommandPoolCreateInfo* CreateInfo, AllocationCallbacks* Allocator, CommandPool* CommandPool);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyCommandPool", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyCommandPool(Device device, CommandPool commandPool, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkResetCommandPool", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkAllocateCommandBuffers", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkAllocateCommandBuffers(Device device, CommandBufferAllocateInfo* AllocateInfo, CommandBuffer* CommandBuffers);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkFreeCommandBuffers", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkFreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer* CommandBuffers);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkBeginCommandBuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkBeginCommandBuffer(CommandBuffer commandBuffer, CommandBufferBeginInfo* BeginInfo);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkEndCommandBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkEndCommandBuffer(CommandBuffer commandBuffer);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkResetCommandBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern Result vkResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindPipeline", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetViewport", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport* Viewports);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetScissor", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D* Scissors);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetLineWidth", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetLineWidth(CommandBuffer commandBuffer, Single lineWidth);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetDepthBias", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetDepthBias(CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetBlendConstants", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetBlendConstants(CommandBuffer commandBuffer, Single blendConstants);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetDepthBounds", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetDepthBounds(CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetStencilCompareMask", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetStencilWriteMask", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetStencilReference", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindDescriptorSets", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, DescriptorSet* DescriptorSets, UInt32 dynamicOffsetCount, UInt32* DynamicOffsets);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, Buffer* Buffers, DeviceSize* Offsets);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdDraw", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdDrawIndexed", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdDrawIndirect", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdDrawIndexedIndirect", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdDispatch", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdDispatch(CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdDispatchIndirect", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdCopyBuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy* Regions);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdCopyImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy* Regions);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBlitImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit* Regions, Filter filter);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdCopyBufferToImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy* Regions);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdCopyImageToBuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy* Regions);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdUpdateBuffer", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32* Data);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdFillBuffer", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdClearColorImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue* Color, UInt32 rangeCount, ImageSubresourceRange* Ranges);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdClearDepthStencilImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue* DepthStencil, UInt32 rangeCount, ImageSubresourceRange* Ranges);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdClearAttachments", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ClearAttachment* Attachments, UInt32 rectCount, ClearRect* Rects);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdResolveImage", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve* Regions);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdResetEvent", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdWaitEvents", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, Event* Events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier* MemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* BufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* ImageMemoryBarriers);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdPipelineBarrier", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier* MemoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier* BufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier* ImageMemoryBarriers);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBeginQuery", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdEndQuery", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdResetQueryPool", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdWriteTimestamp", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdCopyQueryPoolResults", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdPushConstants", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr* Values);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBeginRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdBeginRenderPass(CommandBuffer commandBuffer, RenderPassBeginInfo* RenderPassBegin, SubpassContents contents);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdNextSubpass", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdEndRenderPass", CallingConvention = CallingConvention.Winapi)]
        public static extern void vkCmdEndRenderPass(CommandBuffer commandBuffer);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdExecuteCommands", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkCmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, CommandBuffer* CommandBuffers);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateAndroidSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateAndroidSurfaceKHR(Instance instance, AndroidSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceDisplayPropertiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice, UInt32* PropertyCount, DisplayPropertiesKHR* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceDisplayPlanePropertiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice, UInt32* PropertyCount, DisplayPlanePropertiesKHR* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDisplayPlaneSupportedDisplaysKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex, UInt32* DisplayCount, DisplayKHR* Displays);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDisplayModePropertiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display, UInt32* PropertyCount, DisplayModePropertiesKHR* Properties);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDisplayModeKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, DisplayModeKHR* Mode);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDisplayPlaneCapabilitiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR* Capabilities);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDisplayPlaneSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateDisplayPlaneSurfaceKHR(Instance instance, DisplaySurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateSharedSwapchainsKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR* CreateInfos, AllocationCallbacks* Allocator, SwapchainKHR* Swapchains);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateMirSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateMirSurfaceKHR(Instance instance, MirSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceMirPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Boolean vkGetPhysicalDeviceMirPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, MirConnection* connection);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroySurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroySurfaceKHR(Instance instance, SurfaceKHR surface, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceSurfaceSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, Boolean* Supported);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceSurfaceCapabilitiesKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, SurfaceCapabilitiesKHR* SurfaceCapabilities);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceSurfaceFormatsKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32* SurfaceFormatCount, SurfaceFormatKHR* SurfaceFormats);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceSurfacePresentModesKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32* PresentModeCount, PresentModeKHR* PresentModes);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateSwapchainKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateSwapchainKHR(Device device, SwapchainCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SwapchainKHR* Swapchain);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroySwapchainKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroySwapchainKHR(Device device, SwapchainKHR swapchain, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetSwapchainImagesKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkGetSwapchainImagesKHR(Device device, SwapchainKHR swapchain, UInt32* SwapchainImageCount, Image* SwapchainImages);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkAcquireNextImageKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkAcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, UInt32* ImageIndex);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkQueuePresentKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkQueuePresentKHR(Queue queue, PresentInfoKHR* PresentInfo);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateWaylandSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateWaylandSurfaceKHR(Instance instance, WaylandSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceWaylandPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Boolean vkGetPhysicalDeviceWaylandPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, wl_display* display);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateWin32SurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateWin32SurfaceKHR(Instance instance, Win32SurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceWin32PresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static extern Boolean vkGetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateXlibSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateXlibSurfaceKHR(Instance instance, XlibSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceXlibPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Boolean vkGetPhysicalDeviceXlibPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, Display* dpy, VisualID visualID);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateXcbSurfaceKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateXcbSurfaceKHR(Instance instance, XcbSurfaceCreateInfoKHR* CreateInfo, AllocationCallbacks* Allocator, SurfaceKHR* Surface);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceXcbPresentationSupportKHR", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Boolean vkGetPhysicalDeviceXcbPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, xcb_connection_t* connection, xcb_visualid_t visual_id);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDebugReportCallbackEXT", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern Result vkCreateDebugReportCallbackEXT(Instance instance, DebugReportCallbackCreateInfoEXT* CreateInfo, AllocationCallbacks* Allocator, DebugReportCallbackEXT* Callback);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDebugReportCallbackEXT", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDestroyDebugReportCallbackEXT(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks* Allocator);
        
        [DllImport("vulkan-1.dll", EntryPoint = "vkDebugReportMessageEXT", CallingConvention = CallingConvention.Winapi)]
        public static unsafe extern void vkDebugReportMessageEXT(Instance instance, VkDebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, Char* LayerPrefix, Char* Message);
        
    }
}
