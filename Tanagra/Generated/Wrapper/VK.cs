using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public unsafe static class VK
    {
        public static Result CreateInstance(InstanceCreateInfo createInfo, AllocationCallbacks allocator, Instance instance)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyInstance(Instance instance, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result EnumeratePhysicalDevices(Instance instance, UInt32 physicalDeviceCount, PhysicalDevice physicalDevices)
        {
            throw new NotImplementedException();
        }
        
        public static PFN_vkVoidFunction GetDeviceProcAddr(Device device, Char name)
        {
            throw new NotImplementedException();
        }
        
        public static PFN_vkVoidFunction GetInstanceProcAddr(Instance instance, Char name)
        {
            throw new NotImplementedException();
        }
        
        public static void GetPhysicalDeviceProperties(PhysicalDevice physicalDevice, PhysicalDeviceProperties properties)
        {
            throw new NotImplementedException();
        }
        
        public static void GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, UInt32 queueFamilyPropertyCount, QueueFamilyProperties queueFamilyProperties)
        {
            throw new NotImplementedException();
        }
        
        public static void GetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, PhysicalDeviceMemoryProperties memoryProperties)
        {
            throw new NotImplementedException();
        }
        
        public static void GetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, PhysicalDeviceFeatures features)
        {
            throw new NotImplementedException();
        }
        
        public static void GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, FormatProperties formatProperties)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties imageFormatProperties)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator, Device device)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyDevice(Device device, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result EnumerateInstanceLayerProperties(UInt32 propertyCount, LayerProperties properties)
        {
            throw new NotImplementedException();
        }
        
        public static Result EnumerateInstanceExtensionProperties(Char layerName, UInt32 propertyCount, ExtensionProperties properties)
        {
            throw new NotImplementedException();
        }
        
        public static Result EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, UInt32 propertyCount, LayerProperties properties)
        {
            throw new NotImplementedException();
        }
        
        public static Result EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, Char layerName, UInt32 propertyCount, ExtensionProperties properties)
        {
            throw new NotImplementedException();
        }
        
        public static void GetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, Queue queue)
        {
            throw new NotImplementedException();
        }
        
        public static Result QueueSubmit(Queue queue, UInt32 submitCount, SubmitInfo submits, Fence fence)
        {
            throw new NotImplementedException();
        }
        
        public static Result QueueWaitIdle(Queue queue)
        {
            throw new NotImplementedException();
        }
        
        public static Result DeviceWaitIdle(Device device)
        {
            throw new NotImplementedException();
        }
        
        public static Result AllocateMemory(Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator, DeviceMemory memory)
        {
            throw new NotImplementedException();
        }
        
        public static void FreeMemory(Device device, DeviceMemory memory, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result MapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr data)
        {
            throw new NotImplementedException();
        }
        
        public static void UnmapMemory(Device device, DeviceMemory memory)
        {
            throw new NotImplementedException();
        }
        
        public static Result FlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            throw new NotImplementedException();
        }
        
        public static Result InvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            throw new NotImplementedException();
        }
        
        public static void GetDeviceMemoryCommitment(Device device, DeviceMemory memory, DeviceSize committedMemoryInBytes)
        {
            throw new NotImplementedException();
        }
        
        public static void GetBufferMemoryRequirements(Device device, Buffer buffer, MemoryRequirements memoryRequirements)
        {
            throw new NotImplementedException();
        }
        
        public static Result BindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            throw new NotImplementedException();
        }
        
        public static void GetImageMemoryRequirements(Device device, Image image, MemoryRequirements memoryRequirements)
        {
            throw new NotImplementedException();
        }
        
        public static Result BindImageMemory(Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            throw new NotImplementedException();
        }
        
        public static void GetImageSparseMemoryRequirements(Device device, Image image, UInt32 sparseMemoryRequirementCount, SparseImageMemoryRequirements sparseMemoryRequirements)
        {
            throw new NotImplementedException();
        }
        
        public static void GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32 propertyCount, SparseImageFormatProperties properties)
        {
            throw new NotImplementedException();
        }
        
        public static Result QueueBindSparse(Queue queue, UInt32 bindInfoCount, BindSparseInfo bindInfo, Fence fence)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateFence(Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator, Fence fence)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyFence(Device device, Fence fence, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result ResetFences(Device device, UInt32 fenceCount, Fence fences)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetFenceStatus(Device device, Fence fence)
        {
            throw new NotImplementedException();
        }
        
        public static Result WaitForFences(Device device, UInt32 fenceCount, Fence fences, Boolean waitAll, UInt64 timeout)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateSemaphore(Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator, Semaphore semaphore)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroySemaphore(Device device, Semaphore semaphore, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateEvent(Device device, EventCreateInfo createInfo, AllocationCallbacks allocator, Event @event)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyEvent(Device device, Event @event, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetEventStatus(Device device, Event @event)
        {
            throw new NotImplementedException();
        }
        
        public static Result SetEvent(Device device, Event @event)
        {
            throw new NotImplementedException();
        }
        
        public static Result ResetEvent(Device device, Event @event)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateQueryPool(Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator, QueryPool queryPool)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyQueryPool(Device device, QueryPool queryPool, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr data, DeviceSize stride, QueryResultFlags flags)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateBuffer(Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator, Buffer buffer)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyBuffer(Device device, Buffer buffer, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateBufferView(Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator, BufferView view)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyBufferView(Device device, BufferView bufferView, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateImage(Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator, Image image)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyImage(Device device, Image image, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static void GetImageSubresourceLayout(Device device, Image image, ImageSubresource subresource, SubresourceLayout layout)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateImageView(Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator, ImageView view)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyImageView(Device device, ImageView imageView, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateShaderModule(Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator, ShaderModule shaderModule)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyShaderModule(Device device, ShaderModule shaderModule, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreatePipelineCache(Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator, PipelineCache pipelineCache)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyPipelineCache(Device device, PipelineCache pipelineCache, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPipelineCacheData(Device device, PipelineCache pipelineCache, UIntPtr dataSize, IntPtr data)
        {
            throw new NotImplementedException();
        }
        
        public static Result MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache srcCaches)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreatePipelineLayout(Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator, PipelineLayout pipelineLayout)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateSampler(Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator, Sampler sampler)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroySampler(Device device, Sampler sampler, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateDescriptorSetLayout(Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator, DescriptorSetLayout setLayout)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateDescriptorPool(Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator, DescriptorPool descriptorPool)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result ResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            throw new NotImplementedException();
        }
        
        public static Result AllocateDescriptorSets(Device device, DescriptorSetAllocateInfo allocateInfo, DescriptorSet descriptorSets)
        {
            throw new NotImplementedException();
        }
        
        public static Result FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet descriptorSets)
        {
            throw new NotImplementedException();
        }
        
        public static void UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, WriteDescriptorSet descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet descriptorCopies)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateFramebuffer(Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator, Framebuffer framebuffer)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyFramebuffer(Device device, Framebuffer framebuffer, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateRenderPass(Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator, RenderPass renderPass)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyRenderPass(Device device, RenderPass renderPass, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static void GetRenderAreaGranularity(Device device, RenderPass renderPass, Extent2D granularity)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateCommandPool(Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator, CommandPool commandPool)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyCommandPool(Device device, CommandPool commandPool, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            throw new NotImplementedException();
        }
        
        public static Result AllocateCommandBuffers(Device device, CommandBufferAllocateInfo allocateInfo, CommandBuffer commandBuffers)
        {
            throw new NotImplementedException();
        }
        
        public static void FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            throw new NotImplementedException();
        }
        
        public static Result BeginCommandBuffer(CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            throw new NotImplementedException();
        }
        
        public static Result EndCommandBuffer(CommandBuffer commandBuffer)
        {
            throw new NotImplementedException();
        }
        
        public static Result ResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport viewports)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D scissors)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetLineWidth(CommandBuffer commandBuffer, Single lineWidth)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetDepthBias(CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetBlendConstants(CommandBuffer commandBuffer, Single blendConstants)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetDepthBounds(CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, DescriptorSet descriptorSets, UInt32 dynamicOffsetCount, UInt32 dynamicOffsets)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, Buffer buffers, DeviceSize offsets)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdDispatch(CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy regions)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy regions)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit regions, Filter filter)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy regions)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy regions)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32 data)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ClearAttachment attachments, UInt32 rectCount, ClearRect rects)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve regions)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, Event events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr values)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdBeginRenderPass(CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdEndRenderPass(CommandBuffer commandBuffer)
        {
            throw new NotImplementedException();
        }
        
        public static void CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateAndroidSurfaceKHR(Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice, UInt32 propertyCount, DisplayPropertiesKHR properties)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice, UInt32 propertyCount, DisplayPlanePropertiesKHR properties)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex, UInt32 displayCount, DisplayKHR displays)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display, UInt32 propertyCount, DisplayModePropertiesKHR properties)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator, DisplayModeKHR mode)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR capabilities)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateDisplayPlaneSurfaceKHR(Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR createInfos, AllocationCallbacks allocator, SwapchainKHR swapchains)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateMirSurfaceKHR(Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            throw new NotImplementedException();
        }
        
        public static Boolean GetPhysicalDeviceMirPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, MirConnection connection)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroySurfaceKHR(Instance instance, SurfaceKHR surface, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, Boolean supported)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, SurfaceCapabilitiesKHR surfaceCapabilities)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32 surfaceFormatCount, SurfaceFormatKHR surfaceFormats)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32 presentModeCount, PresentModeKHR presentModes)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateSwapchainKHR(Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator, SwapchainKHR swapchain)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroySwapchainKHR(Device device, SwapchainKHR swapchain, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static Result GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain, UInt32 swapchainImageCount, Image swapchainImages)
        {
            throw new NotImplementedException();
        }
        
        public static Result AcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, UInt32 imageIndex)
        {
            throw new NotImplementedException();
        }
        
        public static Result QueuePresentKHR(Queue queue, PresentInfoKHR presentInfo)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateWaylandSurfaceKHR(Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            throw new NotImplementedException();
        }
        
        public static Boolean GetPhysicalDeviceWaylandPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, wl_display display)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateWin32SurfaceKHR(Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            throw new NotImplementedException();
        }
        
        public static Boolean GetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateXlibSurfaceKHR(Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            throw new NotImplementedException();
        }
        
        public static Boolean GetPhysicalDeviceXlibPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, Display dpy, VisualID visualID)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateXcbSurfaceKHR(Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            throw new NotImplementedException();
        }
        
        public static Boolean GetPhysicalDeviceXcbPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, xcb_connection_t connection, xcb_visualid_t visual_id)
        {
            throw new NotImplementedException();
        }
        
        public static Result CreateDebugReportCallbackEXT(Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator, DebugReportCallbackEXT callback)
        {
            throw new NotImplementedException();
        }
        
        public static void DestroyDebugReportCallbackEXT(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator)
        {
            throw new NotImplementedException();
        }
        
        public static void DebugReportMessageEXT(Instance instance, VkDebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, Char layerPrefix, Char message)
        {
            throw new NotImplementedException();
        }
        
    }
}
