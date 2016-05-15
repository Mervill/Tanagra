using System;
using System.Collections.Generic;

namespace Vulkan.ObjectModel
{
    public static class HandleExtensions
    {
        #region Instance
        
        public static void Destroy(this Instance instance, AllocationCallbacks allocator = null)
        {
            VK.DestroyInstance(instance, allocator);
        }
        
        public static List<PhysicalDevice> EnumeratePhysicalDevices(this Instance instance)
        {
            return VK.EnumeratePhysicalDevices(instance);
        }
        
        public static IntPtr GetProcAddr(this Instance instance, String name)
        {
            return VK.GetInstanceProcAddr(instance, name);
        }
        
        public static SurfaceKHR CreateAndroidSurfaceKHR(this Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateAndroidSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateDisplayPlaneSurfaceKHR(this Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateDisplayPlaneSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateMirSurfaceKHR(this Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateMirSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static void DestroySurfaceKHR(this Instance instance, SurfaceKHR surface, AllocationCallbacks allocator = null)
        {
            VK.DestroySurfaceKHR(instance, surface, allocator);
        }
        
        public static SurfaceKHR CreateWaylandSurfaceKHR(this Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateWaylandSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateWin32SurfaceKHR(this Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateWin32SurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateXlibSurfaceKHR(this Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateXlibSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateXcbSurfaceKHR(this Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateXcbSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static DebugReportCallbackEXT CreateDebugReportCallbackEXT(this Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateDebugReportCallbackEXT(instance, createInfo, allocator);
        }
        
        public static void DestroyDebugReportCallbackEXT(this Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator = null)
        {
            VK.DestroyDebugReportCallbackEXT(instance, callback, allocator);
        }
        
        public static void DebugReportMessageEXT(this Instance instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UInt32 location, Int32 messageCode, String layerPrefix, String message)
        {
            VK.DebugReportMessageEXT(instance, flags, objectType, @object, location, messageCode, layerPrefix, message);
        }
        
        #endregion
        
        #region PhysicalDevice
        
        public static PhysicalDeviceProperties GetProperties(this PhysicalDevice physicalDevice)
        {
            return VK.GetPhysicalDeviceProperties(physicalDevice);
        }
        
        public static List<QueueFamilyProperties> GetQueueFamilyProperties(this PhysicalDevice physicalDevice)
        {
            return VK.GetPhysicalDeviceQueueFamilyProperties(physicalDevice);
        }
        
        public static PhysicalDeviceMemoryProperties GetMemoryProperties(this PhysicalDevice physicalDevice)
        {
            return VK.GetPhysicalDeviceMemoryProperties(physicalDevice);
        }
        
        public static PhysicalDeviceFeatures GetFeatures(this PhysicalDevice physicalDevice)
        {
            return VK.GetPhysicalDeviceFeatures(physicalDevice);
        }
        
        public static FormatProperties GetFormatProperties(this PhysicalDevice physicalDevice, Format format)
        {
            return VK.GetPhysicalDeviceFormatProperties(physicalDevice, format);
        }
        
        public static ImageFormatProperties GetImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags)
        {
            return VK.GetPhysicalDeviceImageFormatProperties(physicalDevice, format, type, tiling, usage, flags);
        }
        
        public static Device CreateDevice(this PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateDevice(physicalDevice, createInfo, allocator);
        }
        
        public static List<LayerProperties> EnumerateDeviceLayerProperties(this PhysicalDevice physicalDevice)
        {
            return VK.EnumerateDeviceLayerProperties(physicalDevice);
        }
        
        public static List<ExtensionProperties> EnumerateDeviceExtensionProperties(this PhysicalDevice physicalDevice, String layerName)
        {
            return VK.EnumerateDeviceExtensionProperties(physicalDevice, layerName);
        }
        
        public static List<SparseImageFormatProperties> GetSparseImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
        {
            return VK.GetPhysicalDeviceSparseImageFormatProperties(physicalDevice, format, type, samples, usage, tiling);
        }
        
        public static List<DisplayPropertiesKHR> GetDisplayPropertiesKHR(this PhysicalDevice physicalDevice)
        {
            return VK.GetPhysicalDeviceDisplayPropertiesKHR(physicalDevice);
        }
        
        public static List<DisplayPlanePropertiesKHR> GetDisplayPlanePropertiesKHR(this PhysicalDevice physicalDevice)
        {
            return VK.GetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice);
        }
        
        public static List<DisplayKHR> GetDisplayPlaneSupportedDisplaysKHR(this PhysicalDevice physicalDevice, UInt32 planeIndex)
        {
            return VK.GetDisplayPlaneSupportedDisplaysKHR(physicalDevice, planeIndex);
        }
        
        public static List<DisplayModePropertiesKHR> GetDisplayModePropertiesKHR(this PhysicalDevice physicalDevice, DisplayKHR display)
        {
            return VK.GetDisplayModePropertiesKHR(physicalDevice, display);
        }
        
        public static DisplayModeKHR CreateDisplayModeKHR(this PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateDisplayModeKHR(physicalDevice, display, createInfo, allocator);
        }
        
        public static DisplayPlaneCapabilitiesKHR GetDisplayPlaneCapabilitiesKHR(this PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex)
        {
            return VK.GetDisplayPlaneCapabilitiesKHR(physicalDevice, mode, planeIndex);
        }
        
        public static IntPtr GetMirPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            return VK.GetPhysicalDeviceMirPresentationSupportKHR(physicalDevice, queueFamilyIndex);
        }
        
        public static Bool32 GetSurfaceSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface)
        {
            return VK.GetPhysicalDeviceSurfaceSupportKHR(physicalDevice, queueFamilyIndex, surface);
        }
        
        public static SurfaceCapabilitiesKHR GetSurfaceCapabilitiesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            return VK.GetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface);
        }
        
        public static List<SurfaceFormatKHR> GetSurfaceFormatsKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            return VK.GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface);
        }
        
        public static List<PresentModeKHR> GetSurfacePresentModesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            return VK.GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface);
        }
        
        public static IntPtr GetWaylandPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            return VK.GetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice, queueFamilyIndex);
        }
        
        public static Bool32 GetWin32PresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            return VK.GetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice, queueFamilyIndex);
        }
        
        public static Bool32 GetXlibPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr dpy, IntPtr visualID)
        {
            return VK.GetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice, queueFamilyIndex, dpy, visualID);
        }
        
        public static Bool32 GetXcbPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr connection, IntPtr visual_id)
        {
            return VK.GetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice, queueFamilyIndex, connection, visual_id);
        }
        
        #endregion
        
        #region Device
        
        public static IntPtr GetProcAddr(this Device device, String name)
        {
            return VK.GetDeviceProcAddr(device, name);
        }
        
        public static void Destroy(this Device device, AllocationCallbacks allocator = null)
        {
            VK.DestroyDevice(device, allocator);
        }
        
        public static Queue GetQueue(this Device device, UInt32 queueFamilyIndex, UInt32 queueIndex)
        {
            return VK.GetDeviceQueue(device, queueFamilyIndex, queueIndex);
        }
        
        public static void WaitIdle(this Device device)
        {
            VK.DeviceWaitIdle(device);
        }
        
        public static DeviceMemory AllocateMemory(this Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator = null)
        {
            return VK.AllocateMemory(device, allocateInfo, allocator);
        }
        
        public static void FreeMemory(this Device device, DeviceMemory memory, AllocationCallbacks allocator = null)
        {
            VK.FreeMemory(device, memory, allocator);
        }
        
        public static IntPtr MapMemory(this Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags)
        {
            return VK.MapMemory(device, memory, offset, size, flags);
        }
        
        public static void UnmapMemory(this Device device, DeviceMemory memory)
        {
            VK.UnmapMemory(device, memory);
        }
        
        public static void FlushMappedMemoryRanges(this Device device, List<MappedMemoryRange> memoryRanges)
        {
            VK.FlushMappedMemoryRanges(device, memoryRanges);
        }
        
        public static void InvalidateMappedMemoryRanges(this Device device, List<MappedMemoryRange> memoryRanges)
        {
            VK.InvalidateMappedMemoryRanges(device, memoryRanges);
        }
        
        public static DeviceSize GetMemoryCommitment(this Device device, DeviceMemory memory)
        {
            return VK.GetDeviceMemoryCommitment(device, memory);
        }
        
        public static MemoryRequirements GetBufferMemoryRequirements(this Device device, Buffer buffer)
        {
            return VK.GetBufferMemoryRequirements(device, buffer);
        }
        
        public static void BindBufferMemory(this Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            VK.BindBufferMemory(device, buffer, memory, memoryOffset);
        }
        
        public static MemoryRequirements GetImageMemoryRequirements(this Device device, Image image)
        {
            return VK.GetImageMemoryRequirements(device, image);
        }
        
        public static void BindImageMemory(this Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            VK.BindImageMemory(device, image, memory, memoryOffset);
        }
        
        public static List<SparseImageMemoryRequirements> GetImageSparseMemoryRequirements(this Device device, Image image)
        {
            return VK.GetImageSparseMemoryRequirements(device, image);
        }
        
        public static Fence CreateFence(this Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateFence(device, createInfo, allocator);
        }
        
        public static void DestroyFence(this Device device, Fence fence, AllocationCallbacks allocator = null)
        {
            VK.DestroyFence(device, fence, allocator);
        }
        
        public static void ResetFences(this Device device, List<Fence> fences)
        {
            VK.ResetFences(device, fences);
        }
        
        public static void GetFenceStatus(this Device device, Fence fence)
        {
            VK.GetFenceStatus(device, fence);
        }
        
        public static void WaitForFences(this Device device, List<Fence> fences, Bool32 waitAll, UInt64 timeout)
        {
            VK.WaitForFences(device, fences, waitAll, timeout);
        }
        
        public static Semaphore CreateSemaphore(this Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateSemaphore(device, createInfo, allocator);
        }
        
        public static void DestroySemaphore(this Device device, Semaphore semaphore, AllocationCallbacks allocator = null)
        {
            VK.DestroySemaphore(device, semaphore, allocator);
        }
        
        public static Event CreateEvent(this Device device, EventCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateEvent(device, createInfo, allocator);
        }
        
        public static void DestroyEvent(this Device device, Event @event, AllocationCallbacks allocator = null)
        {
            VK.DestroyEvent(device, @event, allocator);
        }
        
        public static void GetEventStatus(this Device device, Event @event)
        {
            VK.GetEventStatus(device, @event);
        }
        
        public static void SetEvent(this Device device, Event @event)
        {
            VK.SetEvent(device, @event);
        }
        
        public static void ResetEvent(this Device device, Event @event)
        {
            VK.ResetEvent(device, @event);
        }
        
        public static QueryPool CreateQueryPool(this Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateQueryPool(device, createInfo, allocator);
        }
        
        public static void DestroyQueryPool(this Device device, QueryPool queryPool, AllocationCallbacks allocator = null)
        {
            VK.DestroyQueryPool(device, queryPool, allocator);
        }
        
        public static void GetQueryPoolResults(this Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, List<IntPtr> data, DeviceSize stride, QueryResultFlags flags)
        {
            VK.GetQueryPoolResults(device, queryPool, firstQuery, queryCount, data, stride, flags);
        }
        
        public static Buffer CreateBuffer(this Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateBuffer(device, createInfo, allocator);
        }
        
        public static void DestroyBuffer(this Device device, Buffer buffer, AllocationCallbacks allocator = null)
        {
            VK.DestroyBuffer(device, buffer, allocator);
        }
        
        public static BufferView CreateBufferView(this Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateBufferView(device, createInfo, allocator);
        }
        
        public static void DestroyBufferView(this Device device, BufferView bufferView, AllocationCallbacks allocator = null)
        {
            VK.DestroyBufferView(device, bufferView, allocator);
        }
        
        public static Image CreateImage(this Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateImage(device, createInfo, allocator);
        }
        
        public static void DestroyImage(this Device device, Image image, AllocationCallbacks allocator = null)
        {
            VK.DestroyImage(device, image, allocator);
        }
        
        public static SubresourceLayout GetImageSubresourceLayout(this Device device, Image image, ImageSubresource subresource)
        {
            return VK.GetImageSubresourceLayout(device, image, subresource);
        }
        
        public static ImageView CreateImageView(this Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateImageView(device, createInfo, allocator);
        }
        
        public static void DestroyImageView(this Device device, ImageView imageView, AllocationCallbacks allocator = null)
        {
            VK.DestroyImageView(device, imageView, allocator);
        }
        
        public static ShaderModule CreateShaderModule(this Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateShaderModule(device, createInfo, allocator);
        }
        
        public static void DestroyShaderModule(this Device device, ShaderModule shaderModule, AllocationCallbacks allocator = null)
        {
            VK.DestroyShaderModule(device, shaderModule, allocator);
        }
        
        public static PipelineCache CreatePipelineCache(this Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreatePipelineCache(device, createInfo, allocator);
        }
        
        public static void DestroyPipelineCache(this Device device, PipelineCache pipelineCache, AllocationCallbacks allocator = null)
        {
            VK.DestroyPipelineCache(device, pipelineCache, allocator);
        }
        
        public static List<IntPtr> GetPipelineCacheData(this Device device, PipelineCache pipelineCache)
        {
            return VK.GetPipelineCacheData(device, pipelineCache);
        }
        
        public static void MergePipelineCaches(this Device device, PipelineCache dstCache, List<PipelineCache> srcCaches)
        {
            VK.MergePipelineCaches(device, dstCache, srcCaches);
        }
        
        public static List<Pipeline> CreateGraphicsPipelines(this Device device, PipelineCache pipelineCache, List<GraphicsPipelineCreateInfo> createInfos, AllocationCallbacks allocator = null)
        {
            return VK.CreateGraphicsPipelines(device, pipelineCache, createInfos, allocator);
        }
        
        public static List<Pipeline> CreateComputePipelines(this Device device, PipelineCache pipelineCache, List<ComputePipelineCreateInfo> createInfos, AllocationCallbacks allocator = null)
        {
            return VK.CreateComputePipelines(device, pipelineCache, createInfos, allocator);
        }
        
        public static void DestroyPipeline(this Device device, Pipeline pipeline, AllocationCallbacks allocator = null)
        {
            VK.DestroyPipeline(device, pipeline, allocator);
        }
        
        public static PipelineLayout CreatePipelineLayout(this Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreatePipelineLayout(device, createInfo, allocator);
        }
        
        public static void DestroyPipelineLayout(this Device device, PipelineLayout pipelineLayout, AllocationCallbacks allocator = null)
        {
            VK.DestroyPipelineLayout(device, pipelineLayout, allocator);
        }
        
        public static Sampler CreateSampler(this Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateSampler(device, createInfo, allocator);
        }
        
        public static void DestroySampler(this Device device, Sampler sampler, AllocationCallbacks allocator = null)
        {
            VK.DestroySampler(device, sampler, allocator);
        }
        
        public static DescriptorSetLayout CreateDescriptorSetLayout(this Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateDescriptorSetLayout(device, createInfo, allocator);
        }
        
        public static void DestroyDescriptorSetLayout(this Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks allocator = null)
        {
            VK.DestroyDescriptorSetLayout(device, descriptorSetLayout, allocator);
        }
        
        public static DescriptorPool CreateDescriptorPool(this Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateDescriptorPool(device, createInfo, allocator);
        }
        
        public static void DestroyDescriptorPool(this Device device, DescriptorPool descriptorPool, AllocationCallbacks allocator = null)
        {
            VK.DestroyDescriptorPool(device, descriptorPool, allocator);
        }
        
        public static void ResetDescriptorPool(this Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            VK.ResetDescriptorPool(device, descriptorPool, flags);
        }
        
        public static List<DescriptorSet> AllocateDescriptorSets(this Device device, DescriptorSetAllocateInfo allocateInfo)
        {
            return VK.AllocateDescriptorSets(device, allocateInfo);
        }
        
        public static void FreeDescriptorSets(this Device device, DescriptorPool descriptorPool, List<DescriptorSet> descriptorSets)
        {
            VK.FreeDescriptorSets(device, descriptorPool, descriptorSets);
        }
        
        public static void UpdateDescriptorSets(this Device device, List<WriteDescriptorSet> descriptorWrites, List<CopyDescriptorSet> descriptorCopies)
        {
            VK.UpdateDescriptorSets(device, descriptorWrites, descriptorCopies);
        }
        
        public static Framebuffer CreateFramebuffer(this Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateFramebuffer(device, createInfo, allocator);
        }
        
        public static void DestroyFramebuffer(this Device device, Framebuffer framebuffer, AllocationCallbacks allocator = null)
        {
            VK.DestroyFramebuffer(device, framebuffer, allocator);
        }
        
        public static RenderPass CreateRenderPass(this Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateRenderPass(device, createInfo, allocator);
        }
        
        public static void DestroyRenderPass(this Device device, RenderPass renderPass, AllocationCallbacks allocator = null)
        {
            VK.DestroyRenderPass(device, renderPass, allocator);
        }
        
        public static Extent2D GetRenderAreaGranularity(this Device device, RenderPass renderPass)
        {
            return VK.GetRenderAreaGranularity(device, renderPass);
        }
        
        public static CommandPool CreateCommandPool(this Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateCommandPool(device, createInfo, allocator);
        }
        
        public static void DestroyCommandPool(this Device device, CommandPool commandPool, AllocationCallbacks allocator = null)
        {
            VK.DestroyCommandPool(device, commandPool, allocator);
        }
        
        public static void ResetCommandPool(this Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            VK.ResetCommandPool(device, commandPool, flags);
        }
        
        public static List<CommandBuffer> AllocateCommandBuffers(this Device device, CommandBufferAllocateInfo allocateInfo)
        {
            return VK.AllocateCommandBuffers(device, allocateInfo);
        }
        
        public static void FreeCommandBuffers(this Device device, CommandPool commandPool, List<CommandBuffer> commandBuffers)
        {
            VK.FreeCommandBuffers(device, commandPool, commandBuffers);
        }
        
        public static List<SwapchainKHR> CreateSharedSwapchainsKHR(this Device device, List<SwapchainCreateInfoKHR> createInfos, AllocationCallbacks allocator = null)
        {
            return VK.CreateSharedSwapchainsKHR(device, createInfos, allocator);
        }
        
        public static SwapchainKHR CreateSwapchainKHR(this Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return VK.CreateSwapchainKHR(device, createInfo, allocator);
        }
        
        public static void DestroySwapchainKHR(this Device device, SwapchainKHR swapchain, AllocationCallbacks allocator = null)
        {
            VK.DestroySwapchainKHR(device, swapchain, allocator);
        }
        
        public static List<Image> GetSwapchainImagesKHR(this Device device, SwapchainKHR swapchain)
        {
            return VK.GetSwapchainImagesKHR(device, swapchain);
        }
        
        public static UInt32 AcquireNextImageKHR(this Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence)
        {
            return VK.AcquireNextImageKHR(device, swapchain, timeout, semaphore, fence);
        }
        
        public static DebugMarkerObjectNameInfoEXT DebugMarkerSetObjectNameEXT(this Device device)
        {
            return VK.DebugMarkerSetObjectNameEXT(device);
        }
        
        public static DebugMarkerObjectTagInfoEXT DebugMarkerSetObjectTagEXT(this Device device)
        {
            return VK.DebugMarkerSetObjectTagEXT(device);
        }
        
        #endregion
        
        #region Queue
        
        public static void Submit(this Queue queue, List<SubmitInfo> submits, Fence fence)
        {
            VK.QueueSubmit(queue, submits, fence);
        }
        
        public static void WaitIdle(this Queue queue)
        {
            VK.QueueWaitIdle(queue);
        }
        
        public static void BindSparse(this Queue queue, List<BindSparseInfo> bindInfo, Fence fence)
        {
            VK.QueueBindSparse(queue, bindInfo, fence);
        }
        
        public static void PresentKHR(this Queue queue, PresentInfoKHR presentInfo)
        {
            VK.QueuePresentKHR(queue, presentInfo);
        }
        
        #endregion
        
        #region CommandBuffer
        
        public static void Begin(this CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            VK.BeginCommandBuffer(commandBuffer, beginInfo);
        }
        
        public static void End(this CommandBuffer commandBuffer)
        {
            VK.EndCommandBuffer(commandBuffer);
        }
        
        public static void Reset(this CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            VK.ResetCommandBuffer(commandBuffer, flags);
        }
        
        public static void CmdBindPipeline(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            VK.CmdBindPipeline(commandBuffer, pipelineBindPoint, pipeline);
        }
        
        public static void CmdSetViewport(this CommandBuffer commandBuffer, UInt32 firstViewport, List<Viewport> viewports)
        {
            VK.CmdSetViewport(commandBuffer, firstViewport, viewports);
        }
        
        public static void CmdSetScissor(this CommandBuffer commandBuffer, UInt32 firstScissor, List<Rect2D> scissors)
        {
            VK.CmdSetScissor(commandBuffer, firstScissor, scissors);
        }
        
        public static void CmdSetLineWidth(this CommandBuffer commandBuffer, Single lineWidth)
        {
            VK.CmdSetLineWidth(commandBuffer, lineWidth);
        }
        
        public static void CmdSetDepthBias(this CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            VK.CmdSetDepthBias(commandBuffer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        }
        
        public static void CmdSetBlendConstants(this CommandBuffer commandBuffer, Single blendConstants)
        {
            VK.CmdSetBlendConstants(commandBuffer, blendConstants);
        }
        
        public static void CmdSetDepthBounds(this CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            VK.CmdSetDepthBounds(commandBuffer, minDepthBounds, maxDepthBounds);
        }
        
        public static void CmdSetStencilCompareMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            VK.CmdSetStencilCompareMask(commandBuffer, faceMask, compareMask);
        }
        
        public static void CmdSetStencilWriteMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            VK.CmdSetStencilWriteMask(commandBuffer, faceMask, writeMask);
        }
        
        public static void CmdSetStencilReference(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            VK.CmdSetStencilReference(commandBuffer, faceMask, reference);
        }
        
        public static void CmdBindDescriptorSets(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, List<DescriptorSet> descriptorSets, List<UInt32> dynamicOffsets)
        {
            VK.CmdBindDescriptorSets(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSets, dynamicOffsets);
        }
        
        public static void CmdBindIndexBuffer(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            VK.CmdBindIndexBuffer(commandBuffer, buffer, offset, indexType);
        }
        
        public static void CmdBindVertexBuffers(this CommandBuffer commandBuffer, UInt32 firstBinding, List<Buffer> buffers, List<DeviceSize> offsets)
        {
            VK.CmdBindVertexBuffers(commandBuffer, firstBinding, buffers, offsets);
        }
        
        public static void CmdDraw(this CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            VK.CmdDraw(commandBuffer, vertexCount, instanceCount, firstVertex, firstInstance);
        }
        
        public static void CmdDrawIndexed(this CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            VK.CmdDrawIndexed(commandBuffer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        }
        
        public static void CmdDrawIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            VK.CmdDrawIndirect(commandBuffer, buffer, offset, drawCount, stride);
        }
        
        public static void CmdDrawIndexedIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            VK.CmdDrawIndexedIndirect(commandBuffer, buffer, offset, drawCount, stride);
        }
        
        public static void CmdDispatch(this CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            VK.CmdDispatch(commandBuffer, x, y, z);
        }
        
        public static void CmdDispatchIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            VK.CmdDispatchIndirect(commandBuffer, buffer, offset);
        }
        
        public static void CmdCopyBuffer(this CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, List<BufferCopy> regions)
        {
            VK.CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, regions);
        }
        
        public static void CmdCopyImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageCopy> regions)
        {
            VK.CmdCopyImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        }
        
        public static void CmdBlitImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageBlit> regions, Filter filter)
        {
            VK.CmdBlitImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions, filter);
        }
        
        public static void CmdCopyBufferToImage(this CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, List<BufferImageCopy> regions)
        {
            VK.CmdCopyBufferToImage(commandBuffer, srcBuffer, dstImage, dstImageLayout, regions);
        }
        
        public static void CmdCopyImageToBuffer(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, List<BufferImageCopy> regions)
        {
            VK.CmdCopyImageToBuffer(commandBuffer, srcImage, srcImageLayout, dstBuffer, regions);
        }
        
        public static void CmdUpdateBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, List<Byte> data)
        {
            VK.CmdUpdateBuffer(commandBuffer, dstBuffer, dstOffset, data);
        }
        
        public static void CmdFillBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            VK.CmdFillBuffer(commandBuffer, dstBuffer, dstOffset, size, data);
        }
        
        public static void CmdClearColorImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, List<ImageSubresourceRange> ranges)
        {
            VK.CmdClearColorImage(commandBuffer, image, imageLayout, color, ranges);
        }
        
        public static void CmdClearDepthStencilImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, List<ImageSubresourceRange> ranges)
        {
            VK.CmdClearDepthStencilImage(commandBuffer, image, imageLayout, depthStencil, ranges);
        }
        
        public static void CmdClearAttachments(this CommandBuffer commandBuffer, List<ClearAttachment> attachments, List<ClearRect> rects)
        {
            VK.CmdClearAttachments(commandBuffer, attachments, rects);
        }
        
        public static void CmdResolveImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageResolve> regions)
        {
            VK.CmdResolveImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        }
        
        public static void CmdSetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            VK.CmdSetEvent(commandBuffer, @event, stageMask);
        }
        
        public static void CmdResetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            VK.CmdResetEvent(commandBuffer, @event, stageMask);
        }
        
        public static void CmdWaitEvents(this CommandBuffer commandBuffer, List<Event> events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            VK.CmdWaitEvents(commandBuffer, events, srcStageMask, dstStageMask, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        }
        
        public static void CmdPipelineBarrier(this CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            VK.CmdPipelineBarrier(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        }
        
        public static void CmdBeginQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags)
        {
            VK.CmdBeginQuery(commandBuffer, queryPool, query, flags);
        }
        
        public static void CmdEndQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            VK.CmdEndQuery(commandBuffer, queryPool, query);
        }
        
        public static void CmdResetQueryPool(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            VK.CmdResetQueryPool(commandBuffer, queryPool, firstQuery, queryCount);
        }
        
        public static void CmdWriteTimestamp(this CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            VK.CmdWriteTimestamp(commandBuffer, pipelineStage, queryPool, query);
        }
        
        public static void CmdCopyQueryPoolResults(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
        {
            VK.CmdCopyQueryPoolResults(commandBuffer, queryPool, firstQuery, queryCount, dstBuffer, dstOffset, stride, flags);
        }
        
        public static void CmdPushConstants(this CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, List<IntPtr> values)
        {
            VK.CmdPushConstants(commandBuffer, layout, stageFlags, offset, values);
        }
        
        public static void CmdBeginRenderPass(this CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
        {
            VK.CmdBeginRenderPass(commandBuffer, renderPassBegin, contents);
        }
        
        public static void CmdNextSubpass(this CommandBuffer commandBuffer, SubpassContents contents)
        {
            VK.CmdNextSubpass(commandBuffer, contents);
        }
        
        public static void CmdEndRenderPass(this CommandBuffer commandBuffer)
        {
            VK.CmdEndRenderPass(commandBuffer);
        }
        
        public static void CmdExecuteCommands(this CommandBuffer commandBuffer, List<CommandBuffer> commandBuffers)
        {
            VK.CmdExecuteCommands(commandBuffer, commandBuffers);
        }
        
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerBeginEXT(this CommandBuffer commandBuffer)
        {
            return VK.CmdDebugMarkerBeginEXT(commandBuffer);
        }
        
        public static void CmdDebugMarkerEndEXT(this CommandBuffer commandBuffer)
        {
            VK.CmdDebugMarkerEndEXT(commandBuffer);
        }
        
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerInsertEXT(this CommandBuffer commandBuffer)
        {
            return VK.CmdDebugMarkerInsertEXT(commandBuffer);
        }
        
        #endregion
        
    }
}
