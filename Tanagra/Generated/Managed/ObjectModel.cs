using System;
using System.Collections.Generic;

namespace Vulkan.Managed.ObjectModel
{
    public static class HandleExtensions
    {
        #region Instance
        
        public static void Destroy(this Instance instance, AllocationCallbacks allocator = null)
        {
            Vk.DestroyInstance(instance, allocator);
        }
        
        public static List<PhysicalDevice> EnumeratePhysicalDevices(this Instance instance)
        {
            return Vk.EnumeratePhysicalDevices(instance);
        }
        
        public static IntPtr GetProcAddr(this Instance instance, String name)
        {
            return Vk.GetInstanceProcAddr(instance, name);
        }
        
        public static SurfaceKHR CreateAndroidSurfaceKHR(this Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateAndroidSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateDisplayPlaneSurfaceKHR(this Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateDisplayPlaneSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateMirSurfaceKHR(this Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateMirSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static void DestroySurfaceKHR(this Instance instance, SurfaceKHR surface, AllocationCallbacks allocator = null)
        {
            Vk.DestroySurfaceKHR(instance, surface, allocator);
        }
        
        public static SurfaceKHR CreateWaylandSurfaceKHR(this Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateWaylandSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateWin32SurfaceKHR(this Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateWin32SurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateXlibSurfaceKHR(this Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateXlibSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static SurfaceKHR CreateXcbSurfaceKHR(this Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateXcbSurfaceKHR(instance, createInfo, allocator);
        }
        
        public static DebugReportCallbackEXT CreateDebugReportCallbackEXT(this Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateDebugReportCallbackEXT(instance, createInfo, allocator);
        }
        
        public static void DestroyDebugReportCallbackEXT(this Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator = null)
        {
            Vk.DestroyDebugReportCallbackEXT(instance, callback, allocator);
        }
        
        public static void DebugReportMessageEXT(this Instance instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UInt32 location, Int32 messageCode, String layerPrefix, String message)
        {
            Vk.DebugReportMessageEXT(instance, flags, objectType, @object, location, messageCode, layerPrefix, message);
        }
        
        #endregion
        
        #region PhysicalDevice
        
        public static PhysicalDeviceProperties GetProperties(this PhysicalDevice physicalDevice)
        {
            return Vk.GetPhysicalDeviceProperties(physicalDevice);
        }
        
        public static List<QueueFamilyProperties> GetQueueFamilyProperties(this PhysicalDevice physicalDevice)
        {
            return Vk.GetPhysicalDeviceQueueFamilyProperties(physicalDevice);
        }
        
        public static PhysicalDeviceMemoryProperties GetMemoryProperties(this PhysicalDevice physicalDevice)
        {
            return Vk.GetPhysicalDeviceMemoryProperties(physicalDevice);
        }
        
        public static PhysicalDeviceFeatures GetFeatures(this PhysicalDevice physicalDevice)
        {
            return Vk.GetPhysicalDeviceFeatures(physicalDevice);
        }
        
        public static FormatProperties GetFormatProperties(this PhysicalDevice physicalDevice, Format format)
        {
            return Vk.GetPhysicalDeviceFormatProperties(physicalDevice, format);
        }
        
        public static ImageFormatProperties GetImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags)
        {
            return Vk.GetPhysicalDeviceImageFormatProperties(physicalDevice, format, type, tiling, usage, flags);
        }
        
        public static Device CreateDevice(this PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateDevice(physicalDevice, createInfo, allocator);
        }
        
        public static List<LayerProperties> EnumerateDeviceLayerProperties(this PhysicalDevice physicalDevice)
        {
            return Vk.EnumerateDeviceLayerProperties(physicalDevice);
        }
        
        public static List<ExtensionProperties> EnumerateDeviceExtensionProperties(this PhysicalDevice physicalDevice, String layerName)
        {
            return Vk.EnumerateDeviceExtensionProperties(physicalDevice, layerName);
        }
        
        public static List<SparseImageFormatProperties> GetSparseImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
        {
            return Vk.GetPhysicalDeviceSparseImageFormatProperties(physicalDevice, format, type, samples, usage, tiling);
        }
        
        public static List<DisplayPropertiesKHR> GetDisplayPropertiesKHR(this PhysicalDevice physicalDevice)
        {
            return Vk.GetPhysicalDeviceDisplayPropertiesKHR(physicalDevice);
        }
        
        public static List<DisplayPlanePropertiesKHR> GetDisplayPlanePropertiesKHR(this PhysicalDevice physicalDevice)
        {
            return Vk.GetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice);
        }
        
        public static List<DisplayKHR> GetDisplayPlaneSupportedDisplaysKHR(this PhysicalDevice physicalDevice, UInt32 planeIndex)
        {
            return Vk.GetDisplayPlaneSupportedDisplaysKHR(physicalDevice, planeIndex);
        }
        
        public static List<DisplayModePropertiesKHR> GetDisplayModePropertiesKHR(this PhysicalDevice physicalDevice, DisplayKHR display)
        {
            return Vk.GetDisplayModePropertiesKHR(physicalDevice, display);
        }
        
        public static DisplayModeKHR CreateDisplayModeKHR(this PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateDisplayModeKHR(physicalDevice, display, createInfo, allocator);
        }
        
        public static DisplayPlaneCapabilitiesKHR GetDisplayPlaneCapabilitiesKHR(this PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex)
        {
            return Vk.GetDisplayPlaneCapabilitiesKHR(physicalDevice, mode, planeIndex);
        }
        
        public static IntPtr GetMirPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            return Vk.GetPhysicalDeviceMirPresentationSupportKHR(physicalDevice, queueFamilyIndex);
        }
        
        public static Bool32 GetSurfaceSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface)
        {
            return Vk.GetPhysicalDeviceSurfaceSupportKHR(physicalDevice, queueFamilyIndex, surface);
        }
        
        public static SurfaceCapabilitiesKHR GetSurfaceCapabilitiesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            return Vk.GetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface);
        }
        
        public static List<SurfaceFormatKHR> GetSurfaceFormatsKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            return Vk.GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface);
        }
        
        public static List<PresentModeKHR> GetSurfacePresentModesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            return Vk.GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface);
        }
        
        public static IntPtr GetWaylandPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            return Vk.GetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice, queueFamilyIndex);
        }
        
        public static Bool32 GetWin32PresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            return Vk.GetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice, queueFamilyIndex);
        }
        
        public static Bool32 GetXlibPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr dpy, IntPtr visualID)
        {
            return Vk.GetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice, queueFamilyIndex, dpy, visualID);
        }
        
        public static Bool32 GetXcbPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr connection, IntPtr visual_id)
        {
            return Vk.GetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice, queueFamilyIndex, connection, visual_id);
        }
        
        #endregion
        
        #region Device
        
        public static IntPtr GetProcAddr(this Device device, String name)
        {
            return Vk.GetDeviceProcAddr(device, name);
        }
        
        public static void Destroy(this Device device, AllocationCallbacks allocator = null)
        {
            Vk.DestroyDevice(device, allocator);
        }
        
        public static Queue GetQueue(this Device device, UInt32 queueFamilyIndex, UInt32 queueIndex)
        {
            return Vk.GetDeviceQueue(device, queueFamilyIndex, queueIndex);
        }
        
        public static void WaitIdle(this Device device)
        {
            Vk.DeviceWaitIdle(device);
        }
        
        public static DeviceMemory AllocateMemory(this Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator = null)
        {
            return Vk.AllocateMemory(device, allocateInfo, allocator);
        }
        
        public static void FreeMemory(this Device device, DeviceMemory memory, AllocationCallbacks allocator = null)
        {
            Vk.FreeMemory(device, memory, allocator);
        }
        
        public static IntPtr MapMemory(this Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags)
        {
            return Vk.MapMemory(device, memory, offset, size, flags);
        }
        
        public static void UnmapMemory(this Device device, DeviceMemory memory)
        {
            Vk.UnmapMemory(device, memory);
        }
        
        public static void FlushMappedMemoryRanges(this Device device, List<MappedMemoryRange> memoryRanges)
        {
            Vk.FlushMappedMemoryRanges(device, memoryRanges);
        }
        
        public static void InvalidateMappedMemoryRanges(this Device device, List<MappedMemoryRange> memoryRanges)
        {
            Vk.InvalidateMappedMemoryRanges(device, memoryRanges);
        }
        
        public static DeviceSize GetMemoryCommitment(this Device device, DeviceMemory memory)
        {
            return Vk.GetDeviceMemoryCommitment(device, memory);
        }
        
        public static MemoryRequirements GetBufferMemoryRequirements(this Device device, Buffer buffer)
        {
            return Vk.GetBufferMemoryRequirements(device, buffer);
        }
        
        public static void BindBufferMemory(this Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            Vk.BindBufferMemory(device, buffer, memory, memoryOffset);
        }
        
        public static MemoryRequirements GetImageMemoryRequirements(this Device device, Image image)
        {
            return Vk.GetImageMemoryRequirements(device, image);
        }
        
        public static void BindImageMemory(this Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            Vk.BindImageMemory(device, image, memory, memoryOffset);
        }
        
        public static List<SparseImageMemoryRequirements> GetImageSparseMemoryRequirements(this Device device, Image image)
        {
            return Vk.GetImageSparseMemoryRequirements(device, image);
        }
        
        public static Fence CreateFence(this Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateFence(device, createInfo, allocator);
        }
        
        public static void DestroyFence(this Device device, Fence fence, AllocationCallbacks allocator = null)
        {
            Vk.DestroyFence(device, fence, allocator);
        }
        
        public static void ResetFences(this Device device, List<Fence> fences)
        {
            Vk.ResetFences(device, fences);
        }
        
        public static void GetFenceStatus(this Device device, Fence fence)
        {
            Vk.GetFenceStatus(device, fence);
        }
        
        public static void WaitForFences(this Device device, List<Fence> fences, Bool32 waitAll, UInt64 timeout)
        {
            Vk.WaitForFences(device, fences, waitAll, timeout);
        }
        
        public static Semaphore CreateSemaphore(this Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateSemaphore(device, createInfo, allocator);
        }
        
        public static void DestroySemaphore(this Device device, Semaphore semaphore, AllocationCallbacks allocator = null)
        {
            Vk.DestroySemaphore(device, semaphore, allocator);
        }
        
        public static Event CreateEvent(this Device device, EventCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateEvent(device, createInfo, allocator);
        }
        
        public static void DestroyEvent(this Device device, Event @event, AllocationCallbacks allocator = null)
        {
            Vk.DestroyEvent(device, @event, allocator);
        }
        
        public static void GetEventStatus(this Device device, Event @event)
        {
            Vk.GetEventStatus(device, @event);
        }
        
        public static void SetEvent(this Device device, Event @event)
        {
            Vk.SetEvent(device, @event);
        }
        
        public static void ResetEvent(this Device device, Event @event)
        {
            Vk.ResetEvent(device, @event);
        }
        
        public static QueryPool CreateQueryPool(this Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateQueryPool(device, createInfo, allocator);
        }
        
        public static void DestroyQueryPool(this Device device, QueryPool queryPool, AllocationCallbacks allocator = null)
        {
            Vk.DestroyQueryPool(device, queryPool, allocator);
        }
        
        public static void GetQueryPoolResults(this Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, List<IntPtr> data, DeviceSize stride, QueryResultFlags flags)
        {
            Vk.GetQueryPoolResults(device, queryPool, firstQuery, queryCount, data, stride, flags);
        }
        
        public static Buffer CreateBuffer(this Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateBuffer(device, createInfo, allocator);
        }
        
        public static void DestroyBuffer(this Device device, Buffer buffer, AllocationCallbacks allocator = null)
        {
            Vk.DestroyBuffer(device, buffer, allocator);
        }
        
        public static BufferView CreateBufferView(this Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateBufferView(device, createInfo, allocator);
        }
        
        public static void DestroyBufferView(this Device device, BufferView bufferView, AllocationCallbacks allocator = null)
        {
            Vk.DestroyBufferView(device, bufferView, allocator);
        }
        
        public static Image CreateImage(this Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateImage(device, createInfo, allocator);
        }
        
        public static void DestroyImage(this Device device, Image image, AllocationCallbacks allocator = null)
        {
            Vk.DestroyImage(device, image, allocator);
        }
        
        public static SubresourceLayout GetImageSubresourceLayout(this Device device, Image image, ImageSubresource subresource)
        {
            return Vk.GetImageSubresourceLayout(device, image, subresource);
        }
        
        public static ImageView CreateImageView(this Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateImageView(device, createInfo, allocator);
        }
        
        public static void DestroyImageView(this Device device, ImageView imageView, AllocationCallbacks allocator = null)
        {
            Vk.DestroyImageView(device, imageView, allocator);
        }
        
        public static ShaderModule CreateShaderModule(this Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateShaderModule(device, createInfo, allocator);
        }
        
        public static void DestroyShaderModule(this Device device, ShaderModule shaderModule, AllocationCallbacks allocator = null)
        {
            Vk.DestroyShaderModule(device, shaderModule, allocator);
        }
        
        public static PipelineCache CreatePipelineCache(this Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreatePipelineCache(device, createInfo, allocator);
        }
        
        public static void DestroyPipelineCache(this Device device, PipelineCache pipelineCache, AllocationCallbacks allocator = null)
        {
            Vk.DestroyPipelineCache(device, pipelineCache, allocator);
        }
        
        public static List<IntPtr> GetPipelineCacheData(this Device device, PipelineCache pipelineCache)
        {
            return Vk.GetPipelineCacheData(device, pipelineCache);
        }
        
        public static void MergePipelineCaches(this Device device, PipelineCache dstCache, List<PipelineCache> srcCaches)
        {
            Vk.MergePipelineCaches(device, dstCache, srcCaches);
        }
        
        public static List<Pipeline> CreateGraphicsPipelines(this Device device, PipelineCache pipelineCache, List<GraphicsPipelineCreateInfo> createInfos, AllocationCallbacks allocator = null)
        {
            return Vk.CreateGraphicsPipelines(device, pipelineCache, createInfos, allocator);
        }
        
        public static List<Pipeline> CreateComputePipelines(this Device device, PipelineCache pipelineCache, List<ComputePipelineCreateInfo> createInfos, AllocationCallbacks allocator = null)
        {
            return Vk.CreateComputePipelines(device, pipelineCache, createInfos, allocator);
        }
        
        public static void DestroyPipeline(this Device device, Pipeline pipeline, AllocationCallbacks allocator = null)
        {
            Vk.DestroyPipeline(device, pipeline, allocator);
        }
        
        public static PipelineLayout CreatePipelineLayout(this Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreatePipelineLayout(device, createInfo, allocator);
        }
        
        public static void DestroyPipelineLayout(this Device device, PipelineLayout pipelineLayout, AllocationCallbacks allocator = null)
        {
            Vk.DestroyPipelineLayout(device, pipelineLayout, allocator);
        }
        
        public static Sampler CreateSampler(this Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateSampler(device, createInfo, allocator);
        }
        
        public static void DestroySampler(this Device device, Sampler sampler, AllocationCallbacks allocator = null)
        {
            Vk.DestroySampler(device, sampler, allocator);
        }
        
        public static DescriptorSetLayout CreateDescriptorSetLayout(this Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateDescriptorSetLayout(device, createInfo, allocator);
        }
        
        public static void DestroyDescriptorSetLayout(this Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks allocator = null)
        {
            Vk.DestroyDescriptorSetLayout(device, descriptorSetLayout, allocator);
        }
        
        public static DescriptorPool CreateDescriptorPool(this Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateDescriptorPool(device, createInfo, allocator);
        }
        
        public static void DestroyDescriptorPool(this Device device, DescriptorPool descriptorPool, AllocationCallbacks allocator = null)
        {
            Vk.DestroyDescriptorPool(device, descriptorPool, allocator);
        }
        
        public static void ResetDescriptorPool(this Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            Vk.ResetDescriptorPool(device, descriptorPool, flags);
        }
        
        public static List<DescriptorSet> AllocateDescriptorSets(this Device device, DescriptorSetAllocateInfo allocateInfo)
        {
            return Vk.AllocateDescriptorSets(device, allocateInfo);
        }
        
        public static void FreeDescriptorSets(this Device device, DescriptorPool descriptorPool, List<DescriptorSet> descriptorSets)
        {
            Vk.FreeDescriptorSets(device, descriptorPool, descriptorSets);
        }
        
        public static void UpdateDescriptorSets(this Device device, List<WriteDescriptorSet> descriptorWrites, List<CopyDescriptorSet> descriptorCopies)
        {
            Vk.UpdateDescriptorSets(device, descriptorWrites, descriptorCopies);
        }
        
        public static Framebuffer CreateFramebuffer(this Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateFramebuffer(device, createInfo, allocator);
        }
        
        public static void DestroyFramebuffer(this Device device, Framebuffer framebuffer, AllocationCallbacks allocator = null)
        {
            Vk.DestroyFramebuffer(device, framebuffer, allocator);
        }
        
        public static RenderPass CreateRenderPass(this Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateRenderPass(device, createInfo, allocator);
        }
        
        public static void DestroyRenderPass(this Device device, RenderPass renderPass, AllocationCallbacks allocator = null)
        {
            Vk.DestroyRenderPass(device, renderPass, allocator);
        }
        
        public static Extent2D GetRenderAreaGranularity(this Device device, RenderPass renderPass)
        {
            return Vk.GetRenderAreaGranularity(device, renderPass);
        }
        
        public static CommandPool CreateCommandPool(this Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateCommandPool(device, createInfo, allocator);
        }
        
        public static void DestroyCommandPool(this Device device, CommandPool commandPool, AllocationCallbacks allocator = null)
        {
            Vk.DestroyCommandPool(device, commandPool, allocator);
        }
        
        public static void ResetCommandPool(this Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            Vk.ResetCommandPool(device, commandPool, flags);
        }
        
        public static List<CommandBuffer> AllocateCommandBuffers(this Device device, CommandBufferAllocateInfo allocateInfo)
        {
            return Vk.AllocateCommandBuffers(device, allocateInfo);
        }
        
        public static void FreeCommandBuffers(this Device device, CommandPool commandPool, List<CommandBuffer> commandBuffers)
        {
            Vk.FreeCommandBuffers(device, commandPool, commandBuffers);
        }
        
        public static List<SwapchainKHR> CreateSharedSwapchainsKHR(this Device device, List<SwapchainCreateInfoKHR> createInfos, AllocationCallbacks allocator = null)
        {
            return Vk.CreateSharedSwapchainsKHR(device, createInfos, allocator);
        }
        
        public static SwapchainKHR CreateSwapchainKHR(this Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            return Vk.CreateSwapchainKHR(device, createInfo, allocator);
        }
        
        public static void DestroySwapchainKHR(this Device device, SwapchainKHR swapchain, AllocationCallbacks allocator = null)
        {
            Vk.DestroySwapchainKHR(device, swapchain, allocator);
        }
        
        public static List<Image> GetSwapchainImagesKHR(this Device device, SwapchainKHR swapchain)
        {
            return Vk.GetSwapchainImagesKHR(device, swapchain);
        }
        
        public static UInt32 AcquireNextImageKHR(this Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence)
        {
            return Vk.AcquireNextImageKHR(device, swapchain, timeout, semaphore, fence);
        }
        
        public static DebugMarkerObjectNameInfoEXT DebugMarkerSetObjectNameEXT(this Device device)
        {
            return Vk.DebugMarkerSetObjectNameEXT(device);
        }
        
        public static DebugMarkerObjectTagInfoEXT DebugMarkerSetObjectTagEXT(this Device device)
        {
            return Vk.DebugMarkerSetObjectTagEXT(device);
        }
        
        #endregion
        
        #region Queue
        
        public static void Submit(this Queue queue, List<SubmitInfo> submits, Fence fence)
        {
            Vk.QueueSubmit(queue, submits, fence);
        }
        
        public static void WaitIdle(this Queue queue)
        {
            Vk.QueueWaitIdle(queue);
        }
        
        public static void BindSparse(this Queue queue, List<BindSparseInfo> bindInfo, Fence fence)
        {
            Vk.QueueBindSparse(queue, bindInfo, fence);
        }
        
        public static void PresentKHR(this Queue queue, PresentInfoKHR presentInfo)
        {
            Vk.QueuePresentKHR(queue, presentInfo);
        }
        
        #endregion
        
        #region CommandBuffer
        
        public static void Begin(this CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            Vk.BeginCommandBuffer(commandBuffer, beginInfo);
        }
        
        public static void End(this CommandBuffer commandBuffer)
        {
            Vk.EndCommandBuffer(commandBuffer);
        }
        
        public static void Reset(this CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            Vk.ResetCommandBuffer(commandBuffer, flags);
        }
        
        public static void CmdBindPipeline(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            Vk.CmdBindPipeline(commandBuffer, pipelineBindPoint, pipeline);
        }
        
        public static void CmdSetViewport(this CommandBuffer commandBuffer, UInt32 firstViewport, List<Viewport> viewports)
        {
            Vk.CmdSetViewport(commandBuffer, firstViewport, viewports);
        }
        
        public static void CmdSetScissor(this CommandBuffer commandBuffer, UInt32 firstScissor, List<Rect2D> scissors)
        {
            Vk.CmdSetScissor(commandBuffer, firstScissor, scissors);
        }
        
        public static void CmdSetLineWidth(this CommandBuffer commandBuffer, Single lineWidth)
        {
            Vk.CmdSetLineWidth(commandBuffer, lineWidth);
        }
        
        public static void CmdSetDepthBias(this CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            Vk.CmdSetDepthBias(commandBuffer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        }
        
        public static void CmdSetBlendConstants(this CommandBuffer commandBuffer, Single blendConstants)
        {
            Vk.CmdSetBlendConstants(commandBuffer, blendConstants);
        }
        
        public static void CmdSetDepthBounds(this CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            Vk.CmdSetDepthBounds(commandBuffer, minDepthBounds, maxDepthBounds);
        }
        
        public static void CmdSetStencilCompareMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            Vk.CmdSetStencilCompareMask(commandBuffer, faceMask, compareMask);
        }
        
        public static void CmdSetStencilWriteMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            Vk.CmdSetStencilWriteMask(commandBuffer, faceMask, writeMask);
        }
        
        public static void CmdSetStencilReference(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            Vk.CmdSetStencilReference(commandBuffer, faceMask, reference);
        }
        
        public static void CmdBindDescriptorSets(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, List<DescriptorSet> descriptorSets, List<UInt32> dynamicOffsets)
        {
            Vk.CmdBindDescriptorSets(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSets, dynamicOffsets);
        }
        
        public static void CmdBindIndexBuffer(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            Vk.CmdBindIndexBuffer(commandBuffer, buffer, offset, indexType);
        }
        
        public static void CmdBindVertexBuffers(this CommandBuffer commandBuffer, UInt32 firstBinding, List<Buffer> buffers, List<DeviceSize> offsets)
        {
            Vk.CmdBindVertexBuffers(commandBuffer, firstBinding, buffers, offsets);
        }
        
        public static void CmdDraw(this CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            Vk.CmdDraw(commandBuffer, vertexCount, instanceCount, firstVertex, firstInstance);
        }
        
        public static void CmdDrawIndexed(this CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            Vk.CmdDrawIndexed(commandBuffer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        }
        
        public static void CmdDrawIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            Vk.CmdDrawIndirect(commandBuffer, buffer, offset, drawCount, stride);
        }
        
        public static void CmdDrawIndexedIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            Vk.CmdDrawIndexedIndirect(commandBuffer, buffer, offset, drawCount, stride);
        }
        
        public static void CmdDispatch(this CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            Vk.CmdDispatch(commandBuffer, x, y, z);
        }
        
        public static void CmdDispatchIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            Vk.CmdDispatchIndirect(commandBuffer, buffer, offset);
        }
        
        public static void CmdCopyBuffer(this CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, List<BufferCopy> regions)
        {
            Vk.CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, regions);
        }
        
        public static void CmdCopyImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageCopy> regions)
        {
            Vk.CmdCopyImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        }
        
        public static void CmdBlitImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageBlit> regions, Filter filter)
        {
            Vk.CmdBlitImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions, filter);
        }
        
        public static void CmdCopyBufferToImage(this CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, List<BufferImageCopy> regions)
        {
            Vk.CmdCopyBufferToImage(commandBuffer, srcBuffer, dstImage, dstImageLayout, regions);
        }
        
        public static void CmdCopyImageToBuffer(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, List<BufferImageCopy> regions)
        {
            Vk.CmdCopyImageToBuffer(commandBuffer, srcImage, srcImageLayout, dstBuffer, regions);
        }
        
        public static void CmdUpdateBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, List<Byte> data)
        {
            Vk.CmdUpdateBuffer(commandBuffer, dstBuffer, dstOffset, data);
        }
        
        public static void CmdFillBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            Vk.CmdFillBuffer(commandBuffer, dstBuffer, dstOffset, size, data);
        }
        
        public static void CmdClearColorImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, List<ImageSubresourceRange> ranges)
        {
            Vk.CmdClearColorImage(commandBuffer, image, imageLayout, color, ranges);
        }
        
        public static void CmdClearDepthStencilImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, List<ImageSubresourceRange> ranges)
        {
            Vk.CmdClearDepthStencilImage(commandBuffer, image, imageLayout, depthStencil, ranges);
        }
        
        public static void CmdClearAttachments(this CommandBuffer commandBuffer, List<ClearAttachment> attachments, List<ClearRect> rects)
        {
            Vk.CmdClearAttachments(commandBuffer, attachments, rects);
        }
        
        public static void CmdResolveImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageResolve> regions)
        {
            Vk.CmdResolveImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        }
        
        public static void CmdSetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            Vk.CmdSetEvent(commandBuffer, @event, stageMask);
        }
        
        public static void CmdResetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            Vk.CmdResetEvent(commandBuffer, @event, stageMask);
        }
        
        public static void CmdWaitEvents(this CommandBuffer commandBuffer, List<Event> events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            Vk.CmdWaitEvents(commandBuffer, events, srcStageMask, dstStageMask, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        }
        
        public static void CmdPipelineBarrier(this CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            Vk.CmdPipelineBarrier(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        }
        
        public static void CmdBeginQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags)
        {
            Vk.CmdBeginQuery(commandBuffer, queryPool, query, flags);
        }
        
        public static void CmdEndQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            Vk.CmdEndQuery(commandBuffer, queryPool, query);
        }
        
        public static void CmdResetQueryPool(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            Vk.CmdResetQueryPool(commandBuffer, queryPool, firstQuery, queryCount);
        }
        
        public static void CmdWriteTimestamp(this CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            Vk.CmdWriteTimestamp(commandBuffer, pipelineStage, queryPool, query);
        }
        
        public static void CmdCopyQueryPoolResults(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
        {
            Vk.CmdCopyQueryPoolResults(commandBuffer, queryPool, firstQuery, queryCount, dstBuffer, dstOffset, stride, flags);
        }
        
        public static void CmdPushConstants(this CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, List<IntPtr> values)
        {
            Vk.CmdPushConstants(commandBuffer, layout, stageFlags, offset, values);
        }
        
        public static void CmdBeginRenderPass(this CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
        {
            Vk.CmdBeginRenderPass(commandBuffer, renderPassBegin, contents);
        }
        
        public static void CmdNextSubpass(this CommandBuffer commandBuffer, SubpassContents contents)
        {
            Vk.CmdNextSubpass(commandBuffer, contents);
        }
        
        public static void CmdEndRenderPass(this CommandBuffer commandBuffer)
        {
            Vk.CmdEndRenderPass(commandBuffer);
        }
        
        public static void CmdExecuteCommands(this CommandBuffer commandBuffer, List<CommandBuffer> commandBuffers)
        {
            Vk.CmdExecuteCommands(commandBuffer, commandBuffers);
        }
        
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerBeginEXT(this CommandBuffer commandBuffer)
        {
            return Vk.CmdDebugMarkerBeginEXT(commandBuffer);
        }
        
        public static void CmdDebugMarkerEndEXT(this CommandBuffer commandBuffer)
        {
            Vk.CmdDebugMarkerEndEXT(commandBuffer);
        }
        
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerInsertEXT(this CommandBuffer commandBuffer)
        {
            return Vk.CmdDebugMarkerInsertEXT(commandBuffer);
        }
        
        #endregion
        
    }
}
