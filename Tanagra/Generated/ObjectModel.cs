using System;

namespace Vulkan.ObjectModel
{
    public static class HandleExtensions
    {
        #region Instance
        
        public static void DestroyInstance(this Instance instance, AllocationCallbacks allocator)
        {
            VK.DestroyInstance(instance, allocator);
        }
        
        public static void EnumeratePhysicalDevices(this Instance instance, UInt32 physicalDeviceCount, PhysicalDevice physicalDevices)
        {
            VK.EnumeratePhysicalDevices(instance, physicalDeviceCount, physicalDevices);
        }
        
        public static PFN_vkVoidFunction GetInstanceProcAddr(this Instance instance, Char name)
        {
            return VK.GetInstanceProcAddr(instance, name);
        }
        
        public static void CreateAndroidSurfaceKHR(this Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            VK.CreateAndroidSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void CreateDisplayPlaneSurfaceKHR(this Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            VK.CreateDisplayPlaneSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void CreateMirSurfaceKHR(this Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            VK.CreateMirSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void DestroySurfaceKHR(this Instance instance, SurfaceKHR surface, AllocationCallbacks allocator)
        {
            VK.DestroySurfaceKHR(instance, surface, allocator);
        }
        
        public static void CreateWaylandSurfaceKHR(this Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            VK.CreateWaylandSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void CreateWin32SurfaceKHR(this Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            VK.CreateWin32SurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void CreateXlibSurfaceKHR(this Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            VK.CreateXlibSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void CreateXcbSurfaceKHR(this Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            VK.CreateXcbSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void CreateDebugReportCallbackEXT(this Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator, DebugReportCallbackEXT callback)
        {
            VK.CreateDebugReportCallbackEXT(instance, createInfo, allocator, callback);
        }
        
        public static void DestroyDebugReportCallbackEXT(this Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator)
        {
            VK.DestroyDebugReportCallbackEXT(instance, callback, allocator);
        }
        
        public static void DebugReportMessageEXT(this Instance instance, VkDebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, Char layerPrefix, Char message)
        {
            VK.DebugReportMessageEXT(instance, flags, objectType, @object, location, messageCode, layerPrefix, message);
        }
        
        #endregion
        
        #region PhysicalDevice
        
        public static void GetPhysicalDeviceProperties(this PhysicalDevice physicalDevice, PhysicalDeviceProperties properties)
        {
            VK.GetPhysicalDeviceProperties(physicalDevice, properties);
        }
        
        public static void GetPhysicalDeviceQueueFamilyProperties(this PhysicalDevice physicalDevice, UInt32 queueFamilyPropertyCount, QueueFamilyProperties queueFamilyProperties)
        {
            VK.GetPhysicalDeviceQueueFamilyProperties(physicalDevice, queueFamilyPropertyCount, queueFamilyProperties);
        }
        
        public static void GetPhysicalDeviceMemoryProperties(this PhysicalDevice physicalDevice, PhysicalDeviceMemoryProperties memoryProperties)
        {
            VK.GetPhysicalDeviceMemoryProperties(physicalDevice, memoryProperties);
        }
        
        public static void GetPhysicalDeviceFeatures(this PhysicalDevice physicalDevice, PhysicalDeviceFeatures features)
        {
            VK.GetPhysicalDeviceFeatures(physicalDevice, features);
        }
        
        public static void GetPhysicalDeviceFormatProperties(this PhysicalDevice physicalDevice, Format format, FormatProperties formatProperties)
        {
            VK.GetPhysicalDeviceFormatProperties(physicalDevice, format, formatProperties);
        }
        
        public static void GetPhysicalDeviceImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties imageFormatProperties)
        {
            VK.GetPhysicalDeviceImageFormatProperties(physicalDevice, format, type, tiling, usage, flags, imageFormatProperties);
        }
        
        public static void CreateDevice(this PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator, Device device)
        {
            VK.CreateDevice(physicalDevice, createInfo, allocator, device);
        }
        
        public static void EnumerateDeviceLayerProperties(this PhysicalDevice physicalDevice, UInt32 propertyCount, LayerProperties properties)
        {
            VK.EnumerateDeviceLayerProperties(physicalDevice, propertyCount, properties);
        }
        
        public static void EnumerateDeviceExtensionProperties(this PhysicalDevice physicalDevice, Char layerName, UInt32 propertyCount, ExtensionProperties properties)
        {
            VK.EnumerateDeviceExtensionProperties(physicalDevice, layerName, propertyCount, properties);
        }
        
        public static void GetPhysicalDeviceSparseImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32 propertyCount, SparseImageFormatProperties properties)
        {
            VK.GetPhysicalDeviceSparseImageFormatProperties(physicalDevice, format, type, samples, usage, tiling, propertyCount, properties);
        }
        
        public static void GetPhysicalDeviceDisplayPropertiesKHR(this PhysicalDevice physicalDevice, UInt32 propertyCount, DisplayPropertiesKHR properties)
        {
            VK.GetPhysicalDeviceDisplayPropertiesKHR(physicalDevice, propertyCount, properties);
        }
        
        public static void GetPhysicalDeviceDisplayPlanePropertiesKHR(this PhysicalDevice physicalDevice, UInt32 propertyCount, DisplayPlanePropertiesKHR properties)
        {
            VK.GetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice, propertyCount, properties);
        }
        
        public static void GetDisplayPlaneSupportedDisplaysKHR(this PhysicalDevice physicalDevice, UInt32 planeIndex, UInt32 displayCount, DisplayKHR displays)
        {
            VK.GetDisplayPlaneSupportedDisplaysKHR(physicalDevice, planeIndex, displayCount, displays);
        }
        
        public static void GetDisplayModePropertiesKHR(this PhysicalDevice physicalDevice, DisplayKHR display, UInt32 propertyCount, DisplayModePropertiesKHR properties)
        {
            VK.GetDisplayModePropertiesKHR(physicalDevice, display, propertyCount, properties);
        }
        
        public static void CreateDisplayModeKHR(this PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator, DisplayModeKHR mode)
        {
            VK.CreateDisplayModeKHR(physicalDevice, display, createInfo, allocator, mode);
        }
        
        public static void GetDisplayPlaneCapabilitiesKHR(this PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR capabilities)
        {
            VK.GetDisplayPlaneCapabilitiesKHR(physicalDevice, mode, planeIndex, capabilities);
        }
        
        public static Boolean GetPhysicalDeviceMirPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, MirConnection connection)
        {
            return VK.GetPhysicalDeviceMirPresentationSupportKHR(physicalDevice, queueFamilyIndex, connection);
        }
        
        public static void GetPhysicalDeviceSurfaceSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, Boolean supported)
        {
            VK.GetPhysicalDeviceSurfaceSupportKHR(physicalDevice, queueFamilyIndex, surface, supported);
        }
        
        public static void GetPhysicalDeviceSurfaceCapabilitiesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface, SurfaceCapabilitiesKHR surfaceCapabilities)
        {
            VK.GetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface, surfaceCapabilities);
        }
        
        public static void GetPhysicalDeviceSurfaceFormatsKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32 surfaceFormatCount, SurfaceFormatKHR surfaceFormats)
        {
            VK.GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, surfaceFormatCount, surfaceFormats);
        }
        
        public static void GetPhysicalDeviceSurfacePresentModesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32 presentModeCount, PresentModeKHR presentModes)
        {
            VK.GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, presentModeCount, presentModes);
        }
        
        public static Boolean GetPhysicalDeviceWaylandPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, wl_display display)
        {
            return VK.GetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice, queueFamilyIndex, display);
        }
        
        public static Boolean GetPhysicalDeviceWin32PresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            return VK.GetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice, queueFamilyIndex);
        }
        
        public static Boolean GetPhysicalDeviceXlibPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, Display dpy, VisualID visualID)
        {
            return VK.GetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice, queueFamilyIndex, dpy, visualID);
        }
        
        public static Boolean GetPhysicalDeviceXcbPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, xcb_connection_t connection, xcb_visualid_t visual_id)
        {
            return VK.GetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice, queueFamilyIndex, connection, visual_id);
        }
        
        #endregion
        
        #region Device
        
        public static PFN_vkVoidFunction GetDeviceProcAddr(this Device device, Char name)
        {
            return VK.GetDeviceProcAddr(device, name);
        }
        
        public static void DestroyDevice(this Device device, AllocationCallbacks allocator)
        {
            VK.DestroyDevice(device, allocator);
        }
        
        public static void GetDeviceQueue(this Device device, UInt32 queueFamilyIndex, UInt32 queueIndex, Queue queue)
        {
            VK.GetDeviceQueue(device, queueFamilyIndex, queueIndex, queue);
        }
        
        public static void DeviceWaitIdle(this Device device)
        {
            VK.DeviceWaitIdle(device);
        }
        
        public static void AllocateMemory(this Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator, DeviceMemory memory)
        {
            VK.AllocateMemory(device, allocateInfo, allocator, memory);
        }
        
        public static void FreeMemory(this Device device, DeviceMemory memory, AllocationCallbacks allocator)
        {
            VK.FreeMemory(device, memory, allocator);
        }
        
        public static void MapMemory(this Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr data)
        {
            VK.MapMemory(device, memory, offset, size, flags, data);
        }
        
        public static void UnmapMemory(this Device device, DeviceMemory memory)
        {
            VK.UnmapMemory(device, memory);
        }
        
        public static void FlushMappedMemoryRanges(this Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            VK.FlushMappedMemoryRanges(device, memoryRangeCount, memoryRanges);
        }
        
        public static void InvalidateMappedMemoryRanges(this Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            VK.InvalidateMappedMemoryRanges(device, memoryRangeCount, memoryRanges);
        }
        
        public static void GetDeviceMemoryCommitment(this Device device, DeviceMemory memory, DeviceSize committedMemoryInBytes)
        {
            VK.GetDeviceMemoryCommitment(device, memory, committedMemoryInBytes);
        }
        
        public static void GetBufferMemoryRequirements(this Device device, Buffer buffer, MemoryRequirements memoryRequirements)
        {
            VK.GetBufferMemoryRequirements(device, buffer, memoryRequirements);
        }
        
        public static void BindBufferMemory(this Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            VK.BindBufferMemory(device, buffer, memory, memoryOffset);
        }
        
        public static void GetImageMemoryRequirements(this Device device, Image image, MemoryRequirements memoryRequirements)
        {
            VK.GetImageMemoryRequirements(device, image, memoryRequirements);
        }
        
        public static void BindImageMemory(this Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            VK.BindImageMemory(device, image, memory, memoryOffset);
        }
        
        public static void GetImageSparseMemoryRequirements(this Device device, Image image, UInt32 sparseMemoryRequirementCount, SparseImageMemoryRequirements sparseMemoryRequirements)
        {
            VK.GetImageSparseMemoryRequirements(device, image, sparseMemoryRequirementCount, sparseMemoryRequirements);
        }
        
        public static void CreateFence(this Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator, Fence fence)
        {
            VK.CreateFence(device, createInfo, allocator, fence);
        }
        
        public static void DestroyFence(this Device device, Fence fence, AllocationCallbacks allocator)
        {
            VK.DestroyFence(device, fence, allocator);
        }
        
        public static void ResetFences(this Device device, UInt32 fenceCount, Fence fences)
        {
            VK.ResetFences(device, fenceCount, fences);
        }
        
        public static void GetFenceStatus(this Device device, Fence fence)
        {
            VK.GetFenceStatus(device, fence);
        }
        
        public static void WaitForFences(this Device device, UInt32 fenceCount, Fence fences, Boolean waitAll, UInt64 timeout)
        {
            VK.WaitForFences(device, fenceCount, fences, waitAll, timeout);
        }
        
        public static void CreateSemaphore(this Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator, Semaphore semaphore)
        {
            VK.CreateSemaphore(device, createInfo, allocator, semaphore);
        }
        
        public static void DestroySemaphore(this Device device, Semaphore semaphore, AllocationCallbacks allocator)
        {
            VK.DestroySemaphore(device, semaphore, allocator);
        }
        
        public static void CreateEvent(this Device device, EventCreateInfo createInfo, AllocationCallbacks allocator, Event @event)
        {
            VK.CreateEvent(device, createInfo, allocator, @event);
        }
        
        public static void DestroyEvent(this Device device, Event @event, AllocationCallbacks allocator)
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
        
        public static void CreateQueryPool(this Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator, QueryPool queryPool)
        {
            VK.CreateQueryPool(device, createInfo, allocator, queryPool);
        }
        
        public static void DestroyQueryPool(this Device device, QueryPool queryPool, AllocationCallbacks allocator)
        {
            VK.DestroyQueryPool(device, queryPool, allocator);
        }
        
        public static void GetQueryPoolResults(this Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr data, DeviceSize stride, QueryResultFlags flags)
        {
            VK.GetQueryPoolResults(device, queryPool, firstQuery, queryCount, dataSize, data, stride, flags);
        }
        
        public static void CreateBuffer(this Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator, Buffer buffer)
        {
            VK.CreateBuffer(device, createInfo, allocator, buffer);
        }
        
        public static void DestroyBuffer(this Device device, Buffer buffer, AllocationCallbacks allocator)
        {
            VK.DestroyBuffer(device, buffer, allocator);
        }
        
        public static void CreateBufferView(this Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator, BufferView view)
        {
            VK.CreateBufferView(device, createInfo, allocator, view);
        }
        
        public static void DestroyBufferView(this Device device, BufferView bufferView, AllocationCallbacks allocator)
        {
            VK.DestroyBufferView(device, bufferView, allocator);
        }
        
        public static void CreateImage(this Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator, Image image)
        {
            VK.CreateImage(device, createInfo, allocator, image);
        }
        
        public static void DestroyImage(this Device device, Image image, AllocationCallbacks allocator)
        {
            VK.DestroyImage(device, image, allocator);
        }
        
        public static void GetImageSubresourceLayout(this Device device, Image image, ImageSubresource subresource, SubresourceLayout layout)
        {
            VK.GetImageSubresourceLayout(device, image, subresource, layout);
        }
        
        public static void CreateImageView(this Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator, ImageView view)
        {
            VK.CreateImageView(device, createInfo, allocator, view);
        }
        
        public static void DestroyImageView(this Device device, ImageView imageView, AllocationCallbacks allocator)
        {
            VK.DestroyImageView(device, imageView, allocator);
        }
        
        public static void CreateShaderModule(this Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator, ShaderModule shaderModule)
        {
            VK.CreateShaderModule(device, createInfo, allocator, shaderModule);
        }
        
        public static void DestroyShaderModule(this Device device, ShaderModule shaderModule, AllocationCallbacks allocator)
        {
            VK.DestroyShaderModule(device, shaderModule, allocator);
        }
        
        public static void CreatePipelineCache(this Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator, PipelineCache pipelineCache)
        {
            VK.CreatePipelineCache(device, createInfo, allocator, pipelineCache);
        }
        
        public static void DestroyPipelineCache(this Device device, PipelineCache pipelineCache, AllocationCallbacks allocator)
        {
            VK.DestroyPipelineCache(device, pipelineCache, allocator);
        }
        
        public static void GetPipelineCacheData(this Device device, PipelineCache pipelineCache, UIntPtr dataSize, IntPtr data)
        {
            VK.GetPipelineCacheData(device, pipelineCache, dataSize, data);
        }
        
        public static void MergePipelineCaches(this Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache srcCaches)
        {
            VK.MergePipelineCaches(device, dstCache, srcCacheCount, srcCaches);
        }
        
        public static void CreateGraphicsPipelines(this Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            VK.CreateGraphicsPipelines(device, pipelineCache, createInfoCount, createInfos, allocator, pipelines);
        }
        
        public static void CreateComputePipelines(this Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            VK.CreateComputePipelines(device, pipelineCache, createInfoCount, createInfos, allocator, pipelines);
        }
        
        public static void DestroyPipeline(this Device device, Pipeline pipeline, AllocationCallbacks allocator)
        {
            VK.DestroyPipeline(device, pipeline, allocator);
        }
        
        public static void CreatePipelineLayout(this Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator, PipelineLayout pipelineLayout)
        {
            VK.CreatePipelineLayout(device, createInfo, allocator, pipelineLayout);
        }
        
        public static void DestroyPipelineLayout(this Device device, PipelineLayout pipelineLayout, AllocationCallbacks allocator)
        {
            VK.DestroyPipelineLayout(device, pipelineLayout, allocator);
        }
        
        public static void CreateSampler(this Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator, Sampler sampler)
        {
            VK.CreateSampler(device, createInfo, allocator, sampler);
        }
        
        public static void DestroySampler(this Device device, Sampler sampler, AllocationCallbacks allocator)
        {
            VK.DestroySampler(device, sampler, allocator);
        }
        
        public static void CreateDescriptorSetLayout(this Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator, DescriptorSetLayout setLayout)
        {
            VK.CreateDescriptorSetLayout(device, createInfo, allocator, setLayout);
        }
        
        public static void DestroyDescriptorSetLayout(this Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks allocator)
        {
            VK.DestroyDescriptorSetLayout(device, descriptorSetLayout, allocator);
        }
        
        public static void CreateDescriptorPool(this Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator, DescriptorPool descriptorPool)
        {
            VK.CreateDescriptorPool(device, createInfo, allocator, descriptorPool);
        }
        
        public static void DestroyDescriptorPool(this Device device, DescriptorPool descriptorPool, AllocationCallbacks allocator)
        {
            VK.DestroyDescriptorPool(device, descriptorPool, allocator);
        }
        
        public static void ResetDescriptorPool(this Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            VK.ResetDescriptorPool(device, descriptorPool, flags);
        }
        
        public static void AllocateDescriptorSets(this Device device, DescriptorSetAllocateInfo allocateInfo, DescriptorSet descriptorSets)
        {
            VK.AllocateDescriptorSets(device, allocateInfo, descriptorSets);
        }
        
        public static void FreeDescriptorSets(this Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet descriptorSets)
        {
            VK.FreeDescriptorSets(device, descriptorPool, descriptorSetCount, descriptorSets);
        }
        
        public static void UpdateDescriptorSets(this Device device, UInt32 descriptorWriteCount, WriteDescriptorSet descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet descriptorCopies)
        {
            VK.UpdateDescriptorSets(device, descriptorWriteCount, descriptorWrites, descriptorCopyCount, descriptorCopies);
        }
        
        public static void CreateFramebuffer(this Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator, Framebuffer framebuffer)
        {
            VK.CreateFramebuffer(device, createInfo, allocator, framebuffer);
        }
        
        public static void DestroyFramebuffer(this Device device, Framebuffer framebuffer, AllocationCallbacks allocator)
        {
            VK.DestroyFramebuffer(device, framebuffer, allocator);
        }
        
        public static void CreateRenderPass(this Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator, RenderPass renderPass)
        {
            VK.CreateRenderPass(device, createInfo, allocator, renderPass);
        }
        
        public static void DestroyRenderPass(this Device device, RenderPass renderPass, AllocationCallbacks allocator)
        {
            VK.DestroyRenderPass(device, renderPass, allocator);
        }
        
        public static void GetRenderAreaGranularity(this Device device, RenderPass renderPass, Extent2D granularity)
        {
            VK.GetRenderAreaGranularity(device, renderPass, granularity);
        }
        
        public static void CreateCommandPool(this Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator, CommandPool commandPool)
        {
            VK.CreateCommandPool(device, createInfo, allocator, commandPool);
        }
        
        public static void DestroyCommandPool(this Device device, CommandPool commandPool, AllocationCallbacks allocator)
        {
            VK.DestroyCommandPool(device, commandPool, allocator);
        }
        
        public static void ResetCommandPool(this Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            VK.ResetCommandPool(device, commandPool, flags);
        }
        
        public static void AllocateCommandBuffers(this Device device, CommandBufferAllocateInfo allocateInfo, CommandBuffer commandBuffers)
        {
            VK.AllocateCommandBuffers(device, allocateInfo, commandBuffers);
        }
        
        public static void FreeCommandBuffers(this Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            VK.FreeCommandBuffers(device, commandPool, commandBufferCount, commandBuffers);
        }
        
        public static void CreateSharedSwapchainsKHR(this Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR createInfos, AllocationCallbacks allocator, SwapchainKHR swapchains)
        {
            VK.CreateSharedSwapchainsKHR(device, swapchainCount, createInfos, allocator, swapchains);
        }
        
        public static void CreateSwapchainKHR(this Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator, SwapchainKHR swapchain)
        {
            VK.CreateSwapchainKHR(device, createInfo, allocator, swapchain);
        }
        
        public static void DestroySwapchainKHR(this Device device, SwapchainKHR swapchain, AllocationCallbacks allocator)
        {
            VK.DestroySwapchainKHR(device, swapchain, allocator);
        }
        
        public static void GetSwapchainImagesKHR(this Device device, SwapchainKHR swapchain, UInt32 swapchainImageCount, Image swapchainImages)
        {
            VK.GetSwapchainImagesKHR(device, swapchain, swapchainImageCount, swapchainImages);
        }
        
        public static void AcquireNextImageKHR(this Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, UInt32 imageIndex)
        {
            VK.AcquireNextImageKHR(device, swapchain, timeout, semaphore, fence, imageIndex);
        }
        
        #endregion
        
        #region Queue
        
        public static void QueueSubmit(this Queue queue, UInt32 submitCount, SubmitInfo submits, Fence fence)
        {
            VK.QueueSubmit(queue, submitCount, submits, fence);
        }
        
        public static void QueueWaitIdle(this Queue queue)
        {
            VK.QueueWaitIdle(queue);
        }
        
        public static void QueueBindSparse(this Queue queue, UInt32 bindInfoCount, BindSparseInfo bindInfo, Fence fence)
        {
            VK.QueueBindSparse(queue, bindInfoCount, bindInfo, fence);
        }
        
        public static void QueuePresentKHR(this Queue queue, PresentInfoKHR presentInfo)
        {
            VK.QueuePresentKHR(queue, presentInfo);
        }
        
        #endregion
        
        #region CommandBuffer
        
        public static void BeginCommandBuffer(this CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            VK.BeginCommandBuffer(commandBuffer, beginInfo);
        }
        
        public static void EndCommandBuffer(this CommandBuffer commandBuffer)
        {
            VK.EndCommandBuffer(commandBuffer);
        }
        
        public static void ResetCommandBuffer(this CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            VK.ResetCommandBuffer(commandBuffer, flags);
        }
        
        public static void CmdBindPipeline(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            VK.CmdBindPipeline(commandBuffer, pipelineBindPoint, pipeline);
        }
        
        public static void CmdSetViewport(this CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport viewports)
        {
            VK.CmdSetViewport(commandBuffer, firstViewport, viewportCount, viewports);
        }
        
        public static void CmdSetScissor(this CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D scissors)
        {
            VK.CmdSetScissor(commandBuffer, firstScissor, scissorCount, scissors);
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
        
        public static void CmdBindDescriptorSets(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, DescriptorSet descriptorSets, UInt32 dynamicOffsetCount, UInt32 dynamicOffsets)
        {
            VK.CmdBindDescriptorSets(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSetCount, descriptorSets, dynamicOffsetCount, dynamicOffsets);
        }
        
        public static void CmdBindIndexBuffer(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            VK.CmdBindIndexBuffer(commandBuffer, buffer, offset, indexType);
        }
        
        public static void CmdBindVertexBuffers(this CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, Buffer buffers, DeviceSize offsets)
        {
            VK.CmdBindVertexBuffers(commandBuffer, firstBinding, bindingCount, buffers, offsets);
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
        
        public static void CmdCopyBuffer(this CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy regions)
        {
            VK.CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, regionCount, regions);
        }
        
        public static void CmdCopyImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy regions)
        {
            VK.CmdCopyImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, regions);
        }
        
        public static void CmdBlitImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit regions, Filter filter)
        {
            VK.CmdBlitImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, regions, filter);
        }
        
        public static void CmdCopyBufferToImage(this CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy regions)
        {
            VK.CmdCopyBufferToImage(commandBuffer, srcBuffer, dstImage, dstImageLayout, regionCount, regions);
        }
        
        public static void CmdCopyImageToBuffer(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy regions)
        {
            VK.CmdCopyImageToBuffer(commandBuffer, srcImage, srcImageLayout, dstBuffer, regionCount, regions);
        }
        
        public static void CmdUpdateBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32 data)
        {
            VK.CmdUpdateBuffer(commandBuffer, dstBuffer, dstOffset, dataSize, data);
        }
        
        public static void CmdFillBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            VK.CmdFillBuffer(commandBuffer, dstBuffer, dstOffset, size, data);
        }
        
        public static void CmdClearColorImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            VK.CmdClearColorImage(commandBuffer, image, imageLayout, color, rangeCount, ranges);
        }
        
        public static void CmdClearDepthStencilImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            VK.CmdClearDepthStencilImage(commandBuffer, image, imageLayout, depthStencil, rangeCount, ranges);
        }
        
        public static void CmdClearAttachments(this CommandBuffer commandBuffer, UInt32 attachmentCount, ClearAttachment attachments, UInt32 rectCount, ClearRect rects)
        {
            VK.CmdClearAttachments(commandBuffer, attachmentCount, attachments, rectCount, rects);
        }
        
        public static void CmdResolveImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve regions)
        {
            VK.CmdResolveImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regionCount, regions);
        }
        
        public static void CmdSetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            VK.CmdSetEvent(commandBuffer, @event, stageMask);
        }
        
        public static void CmdResetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            VK.CmdResetEvent(commandBuffer, @event, stageMask);
        }
        
        public static void CmdWaitEvents(this CommandBuffer commandBuffer, UInt32 eventCount, Event events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            VK.CmdWaitEvents(commandBuffer, eventCount, events, srcStageMask, dstStageMask, memoryBarrierCount, memoryBarriers, bufferMemoryBarrierCount, bufferMemoryBarriers, imageMemoryBarrierCount, imageMemoryBarriers);
        }
        
        public static void CmdPipelineBarrier(this CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            VK.CmdPipelineBarrier(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, memoryBarriers, bufferMemoryBarrierCount, bufferMemoryBarriers, imageMemoryBarrierCount, imageMemoryBarriers);
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
        
        public static void CmdPushConstants(this CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr values)
        {
            VK.CmdPushConstants(commandBuffer, layout, stageFlags, offset, size, values);
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
        
        public static void CmdExecuteCommands(this CommandBuffer commandBuffer, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            VK.CmdExecuteCommands(commandBuffer, commandBufferCount, commandBuffers);
        }
        
        #endregion
        
    }
}
