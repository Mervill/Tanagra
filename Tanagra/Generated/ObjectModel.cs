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
        
        public static Result EnumeratePhysicalDevices(this Instance instance, UInt32 physicalDeviceCount, PhysicalDevice physicalDevices)
        {
            return VK.EnumeratePhysicalDevices(instance, physicalDeviceCount, physicalDevices);
        }
        
        public static PFN_vkVoidFunction GetInstanceProcAddr(this Instance instance, Char name)
        {
            return VK.GetInstanceProcAddr(instance, name);
        }
        
        public static Result CreateAndroidSurfaceKHR(this Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            return VK.CreateAndroidSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static Result CreateDisplayPlaneSurfaceKHR(this Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            return VK.CreateDisplayPlaneSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static Result CreateMirSurfaceKHR(this Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            return VK.CreateMirSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static void DestroySurfaceKHR(this Instance instance, SurfaceKHR surface, AllocationCallbacks allocator)
        {
            VK.DestroySurfaceKHR(instance, surface, allocator);
        }
        
        public static Result CreateWaylandSurfaceKHR(this Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            return VK.CreateWaylandSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static Result CreateWin32SurfaceKHR(this Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            return VK.CreateWin32SurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static Result CreateXlibSurfaceKHR(this Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            return VK.CreateXlibSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static Result CreateXcbSurfaceKHR(this Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator, SurfaceKHR surface)
        {
            return VK.CreateXcbSurfaceKHR(instance, createInfo, allocator, surface);
        }
        
        public static Result CreateDebugReportCallbackEXT(this Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator, DebugReportCallbackEXT callback)
        {
            return VK.CreateDebugReportCallbackEXT(instance, createInfo, allocator, callback);
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
        
        public static Result GetPhysicalDeviceImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties imageFormatProperties)
        {
            return VK.GetPhysicalDeviceImageFormatProperties(physicalDevice, format, type, tiling, usage, flags, imageFormatProperties);
        }
        
        public static Result CreateDevice(this PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator, Device device)
        {
            return VK.CreateDevice(physicalDevice, createInfo, allocator, device);
        }
        
        public static Result EnumerateDeviceLayerProperties(this PhysicalDevice physicalDevice, UInt32 propertyCount, LayerProperties properties)
        {
            return VK.EnumerateDeviceLayerProperties(physicalDevice, propertyCount, properties);
        }
        
        public static Result EnumerateDeviceExtensionProperties(this PhysicalDevice physicalDevice, Char layerName, UInt32 propertyCount, ExtensionProperties properties)
        {
            return VK.EnumerateDeviceExtensionProperties(physicalDevice, layerName, propertyCount, properties);
        }
        
        public static void GetPhysicalDeviceSparseImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling, UInt32 propertyCount, SparseImageFormatProperties properties)
        {
            VK.GetPhysicalDeviceSparseImageFormatProperties(physicalDevice, format, type, samples, usage, tiling, propertyCount, properties);
        }
        
        public static Result GetPhysicalDeviceDisplayPropertiesKHR(this PhysicalDevice physicalDevice, UInt32 propertyCount, DisplayPropertiesKHR properties)
        {
            return VK.GetPhysicalDeviceDisplayPropertiesKHR(physicalDevice, propertyCount, properties);
        }
        
        public static Result GetPhysicalDeviceDisplayPlanePropertiesKHR(this PhysicalDevice physicalDevice, UInt32 propertyCount, DisplayPlanePropertiesKHR properties)
        {
            return VK.GetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice, propertyCount, properties);
        }
        
        public static Result GetDisplayPlaneSupportedDisplaysKHR(this PhysicalDevice physicalDevice, UInt32 planeIndex, UInt32 displayCount, DisplayKHR displays)
        {
            return VK.GetDisplayPlaneSupportedDisplaysKHR(physicalDevice, planeIndex, displayCount, displays);
        }
        
        public static Result GetDisplayModePropertiesKHR(this PhysicalDevice physicalDevice, DisplayKHR display, UInt32 propertyCount, DisplayModePropertiesKHR properties)
        {
            return VK.GetDisplayModePropertiesKHR(physicalDevice, display, propertyCount, properties);
        }
        
        public static Result CreateDisplayModeKHR(this PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator, DisplayModeKHR mode)
        {
            return VK.CreateDisplayModeKHR(physicalDevice, display, createInfo, allocator, mode);
        }
        
        public static Result GetDisplayPlaneCapabilitiesKHR(this PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR capabilities)
        {
            return VK.GetDisplayPlaneCapabilitiesKHR(physicalDevice, mode, planeIndex, capabilities);
        }
        
        public static Boolean GetPhysicalDeviceMirPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, MirConnection connection)
        {
            return VK.GetPhysicalDeviceMirPresentationSupportKHR(physicalDevice, queueFamilyIndex, connection);
        }
        
        public static Result GetPhysicalDeviceSurfaceSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, Boolean supported)
        {
            return VK.GetPhysicalDeviceSurfaceSupportKHR(physicalDevice, queueFamilyIndex, surface, supported);
        }
        
        public static Result GetPhysicalDeviceSurfaceCapabilitiesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface, SurfaceCapabilitiesKHR surfaceCapabilities)
        {
            return VK.GetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface, surfaceCapabilities);
        }
        
        public static Result GetPhysicalDeviceSurfaceFormatsKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32 surfaceFormatCount, SurfaceFormatKHR surfaceFormats)
        {
            return VK.GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface, surfaceFormatCount, surfaceFormats);
        }
        
        public static Result GetPhysicalDeviceSurfacePresentModesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface, UInt32 presentModeCount, PresentModeKHR presentModes)
        {
            return VK.GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface, presentModeCount, presentModes);
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
        
        public static Result DeviceWaitIdle(this Device device)
        {
            return VK.DeviceWaitIdle(device);
        }
        
        public static Result AllocateMemory(this Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator, DeviceMemory memory)
        {
            return VK.AllocateMemory(device, allocateInfo, allocator, memory);
        }
        
        public static void FreeMemory(this Device device, DeviceMemory memory, AllocationCallbacks allocator)
        {
            VK.FreeMemory(device, memory, allocator);
        }
        
        public static Result MapMemory(this Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr data)
        {
            return VK.MapMemory(device, memory, offset, size, flags, data);
        }
        
        public static void UnmapMemory(this Device device, DeviceMemory memory)
        {
            VK.UnmapMemory(device, memory);
        }
        
        public static Result FlushMappedMemoryRanges(this Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            return VK.FlushMappedMemoryRanges(device, memoryRangeCount, memoryRanges);
        }
        
        public static Result InvalidateMappedMemoryRanges(this Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            return VK.InvalidateMappedMemoryRanges(device, memoryRangeCount, memoryRanges);
        }
        
        public static void GetDeviceMemoryCommitment(this Device device, DeviceMemory memory, DeviceSize committedMemoryInBytes)
        {
            VK.GetDeviceMemoryCommitment(device, memory, committedMemoryInBytes);
        }
        
        public static void GetBufferMemoryRequirements(this Device device, Buffer buffer, MemoryRequirements memoryRequirements)
        {
            VK.GetBufferMemoryRequirements(device, buffer, memoryRequirements);
        }
        
        public static Result BindBufferMemory(this Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            return VK.BindBufferMemory(device, buffer, memory, memoryOffset);
        }
        
        public static void GetImageMemoryRequirements(this Device device, Image image, MemoryRequirements memoryRequirements)
        {
            VK.GetImageMemoryRequirements(device, image, memoryRequirements);
        }
        
        public static Result BindImageMemory(this Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            return VK.BindImageMemory(device, image, memory, memoryOffset);
        }
        
        public static void GetImageSparseMemoryRequirements(this Device device, Image image, UInt32 sparseMemoryRequirementCount, SparseImageMemoryRequirements sparseMemoryRequirements)
        {
            VK.GetImageSparseMemoryRequirements(device, image, sparseMemoryRequirementCount, sparseMemoryRequirements);
        }
        
        public static Result CreateFence(this Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator, Fence fence)
        {
            return VK.CreateFence(device, createInfo, allocator, fence);
        }
        
        public static void DestroyFence(this Device device, Fence fence, AllocationCallbacks allocator)
        {
            VK.DestroyFence(device, fence, allocator);
        }
        
        public static Result ResetFences(this Device device, UInt32 fenceCount, Fence fences)
        {
            return VK.ResetFences(device, fenceCount, fences);
        }
        
        public static Result GetFenceStatus(this Device device, Fence fence)
        {
            return VK.GetFenceStatus(device, fence);
        }
        
        public static Result WaitForFences(this Device device, UInt32 fenceCount, Fence fences, Boolean waitAll, UInt64 timeout)
        {
            return VK.WaitForFences(device, fenceCount, fences, waitAll, timeout);
        }
        
        public static Result CreateSemaphore(this Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator, Semaphore semaphore)
        {
            return VK.CreateSemaphore(device, createInfo, allocator, semaphore);
        }
        
        public static void DestroySemaphore(this Device device, Semaphore semaphore, AllocationCallbacks allocator)
        {
            VK.DestroySemaphore(device, semaphore, allocator);
        }
        
        public static Result CreateEvent(this Device device, EventCreateInfo createInfo, AllocationCallbacks allocator, Event @event)
        {
            return VK.CreateEvent(device, createInfo, allocator, @event);
        }
        
        public static void DestroyEvent(this Device device, Event @event, AllocationCallbacks allocator)
        {
            VK.DestroyEvent(device, @event, allocator);
        }
        
        public static Result GetEventStatus(this Device device, Event @event)
        {
            return VK.GetEventStatus(device, @event);
        }
        
        public static Result SetEvent(this Device device, Event @event)
        {
            return VK.SetEvent(device, @event);
        }
        
        public static Result ResetEvent(this Device device, Event @event)
        {
            return VK.ResetEvent(device, @event);
        }
        
        public static Result CreateQueryPool(this Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator, QueryPool queryPool)
        {
            return VK.CreateQueryPool(device, createInfo, allocator, queryPool);
        }
        
        public static void DestroyQueryPool(this Device device, QueryPool queryPool, AllocationCallbacks allocator)
        {
            VK.DestroyQueryPool(device, queryPool, allocator);
        }
        
        public static Result GetQueryPoolResults(this Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr data, DeviceSize stride, QueryResultFlags flags)
        {
            return VK.GetQueryPoolResults(device, queryPool, firstQuery, queryCount, dataSize, data, stride, flags);
        }
        
        public static Result CreateBuffer(this Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator, Buffer buffer)
        {
            return VK.CreateBuffer(device, createInfo, allocator, buffer);
        }
        
        public static void DestroyBuffer(this Device device, Buffer buffer, AllocationCallbacks allocator)
        {
            VK.DestroyBuffer(device, buffer, allocator);
        }
        
        public static Result CreateBufferView(this Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator, BufferView view)
        {
            return VK.CreateBufferView(device, createInfo, allocator, view);
        }
        
        public static void DestroyBufferView(this Device device, BufferView bufferView, AllocationCallbacks allocator)
        {
            VK.DestroyBufferView(device, bufferView, allocator);
        }
        
        public static Result CreateImage(this Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator, Image image)
        {
            return VK.CreateImage(device, createInfo, allocator, image);
        }
        
        public static void DestroyImage(this Device device, Image image, AllocationCallbacks allocator)
        {
            VK.DestroyImage(device, image, allocator);
        }
        
        public static void GetImageSubresourceLayout(this Device device, Image image, ImageSubresource subresource, SubresourceLayout layout)
        {
            VK.GetImageSubresourceLayout(device, image, subresource, layout);
        }
        
        public static Result CreateImageView(this Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator, ImageView view)
        {
            return VK.CreateImageView(device, createInfo, allocator, view);
        }
        
        public static void DestroyImageView(this Device device, ImageView imageView, AllocationCallbacks allocator)
        {
            VK.DestroyImageView(device, imageView, allocator);
        }
        
        public static Result CreateShaderModule(this Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator, ShaderModule shaderModule)
        {
            return VK.CreateShaderModule(device, createInfo, allocator, shaderModule);
        }
        
        public static void DestroyShaderModule(this Device device, ShaderModule shaderModule, AllocationCallbacks allocator)
        {
            VK.DestroyShaderModule(device, shaderModule, allocator);
        }
        
        public static Result CreatePipelineCache(this Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator, PipelineCache pipelineCache)
        {
            return VK.CreatePipelineCache(device, createInfo, allocator, pipelineCache);
        }
        
        public static void DestroyPipelineCache(this Device device, PipelineCache pipelineCache, AllocationCallbacks allocator)
        {
            VK.DestroyPipelineCache(device, pipelineCache, allocator);
        }
        
        public static Result GetPipelineCacheData(this Device device, PipelineCache pipelineCache, UIntPtr dataSize, IntPtr data)
        {
            return VK.GetPipelineCacheData(device, pipelineCache, dataSize, data);
        }
        
        public static Result MergePipelineCaches(this Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache srcCaches)
        {
            return VK.MergePipelineCaches(device, dstCache, srcCacheCount, srcCaches);
        }
        
        public static Result CreateGraphicsPipelines(this Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            return VK.CreateGraphicsPipelines(device, pipelineCache, createInfoCount, createInfos, allocator, pipelines);
        }
        
        public static Result CreateComputePipelines(this Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            return VK.CreateComputePipelines(device, pipelineCache, createInfoCount, createInfos, allocator, pipelines);
        }
        
        public static void DestroyPipeline(this Device device, Pipeline pipeline, AllocationCallbacks allocator)
        {
            VK.DestroyPipeline(device, pipeline, allocator);
        }
        
        public static Result CreatePipelineLayout(this Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator, PipelineLayout pipelineLayout)
        {
            return VK.CreatePipelineLayout(device, createInfo, allocator, pipelineLayout);
        }
        
        public static void DestroyPipelineLayout(this Device device, PipelineLayout pipelineLayout, AllocationCallbacks allocator)
        {
            VK.DestroyPipelineLayout(device, pipelineLayout, allocator);
        }
        
        public static Result CreateSampler(this Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator, Sampler sampler)
        {
            return VK.CreateSampler(device, createInfo, allocator, sampler);
        }
        
        public static void DestroySampler(this Device device, Sampler sampler, AllocationCallbacks allocator)
        {
            VK.DestroySampler(device, sampler, allocator);
        }
        
        public static Result CreateDescriptorSetLayout(this Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator, DescriptorSetLayout setLayout)
        {
            return VK.CreateDescriptorSetLayout(device, createInfo, allocator, setLayout);
        }
        
        public static void DestroyDescriptorSetLayout(this Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks allocator)
        {
            VK.DestroyDescriptorSetLayout(device, descriptorSetLayout, allocator);
        }
        
        public static Result CreateDescriptorPool(this Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator, DescriptorPool descriptorPool)
        {
            return VK.CreateDescriptorPool(device, createInfo, allocator, descriptorPool);
        }
        
        public static void DestroyDescriptorPool(this Device device, DescriptorPool descriptorPool, AllocationCallbacks allocator)
        {
            VK.DestroyDescriptorPool(device, descriptorPool, allocator);
        }
        
        public static Result ResetDescriptorPool(this Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            return VK.ResetDescriptorPool(device, descriptorPool, flags);
        }
        
        public static Result AllocateDescriptorSets(this Device device, DescriptorSetAllocateInfo allocateInfo, DescriptorSet descriptorSets)
        {
            return VK.AllocateDescriptorSets(device, allocateInfo, descriptorSets);
        }
        
        public static Result FreeDescriptorSets(this Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet descriptorSets)
        {
            return VK.FreeDescriptorSets(device, descriptorPool, descriptorSetCount, descriptorSets);
        }
        
        public static void UpdateDescriptorSets(this Device device, UInt32 descriptorWriteCount, WriteDescriptorSet descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet descriptorCopies)
        {
            VK.UpdateDescriptorSets(device, descriptorWriteCount, descriptorWrites, descriptorCopyCount, descriptorCopies);
        }
        
        public static Result CreateFramebuffer(this Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator, Framebuffer framebuffer)
        {
            return VK.CreateFramebuffer(device, createInfo, allocator, framebuffer);
        }
        
        public static void DestroyFramebuffer(this Device device, Framebuffer framebuffer, AllocationCallbacks allocator)
        {
            VK.DestroyFramebuffer(device, framebuffer, allocator);
        }
        
        public static Result CreateRenderPass(this Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator, RenderPass renderPass)
        {
            return VK.CreateRenderPass(device, createInfo, allocator, renderPass);
        }
        
        public static void DestroyRenderPass(this Device device, RenderPass renderPass, AllocationCallbacks allocator)
        {
            VK.DestroyRenderPass(device, renderPass, allocator);
        }
        
        public static void GetRenderAreaGranularity(this Device device, RenderPass renderPass, Extent2D granularity)
        {
            VK.GetRenderAreaGranularity(device, renderPass, granularity);
        }
        
        public static Result CreateCommandPool(this Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator, CommandPool commandPool)
        {
            return VK.CreateCommandPool(device, createInfo, allocator, commandPool);
        }
        
        public static void DestroyCommandPool(this Device device, CommandPool commandPool, AllocationCallbacks allocator)
        {
            VK.DestroyCommandPool(device, commandPool, allocator);
        }
        
        public static Result ResetCommandPool(this Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            return VK.ResetCommandPool(device, commandPool, flags);
        }
        
        public static Result AllocateCommandBuffers(this Device device, CommandBufferAllocateInfo allocateInfo, CommandBuffer commandBuffers)
        {
            return VK.AllocateCommandBuffers(device, allocateInfo, commandBuffers);
        }
        
        public static void FreeCommandBuffers(this Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            VK.FreeCommandBuffers(device, commandPool, commandBufferCount, commandBuffers);
        }
        
        public static Result CreateSharedSwapchainsKHR(this Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR createInfos, AllocationCallbacks allocator, SwapchainKHR swapchains)
        {
            return VK.CreateSharedSwapchainsKHR(device, swapchainCount, createInfos, allocator, swapchains);
        }
        
        public static Result CreateSwapchainKHR(this Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator, SwapchainKHR swapchain)
        {
            return VK.CreateSwapchainKHR(device, createInfo, allocator, swapchain);
        }
        
        public static void DestroySwapchainKHR(this Device device, SwapchainKHR swapchain, AllocationCallbacks allocator)
        {
            VK.DestroySwapchainKHR(device, swapchain, allocator);
        }
        
        public static Result GetSwapchainImagesKHR(this Device device, SwapchainKHR swapchain, UInt32 swapchainImageCount, Image swapchainImages)
        {
            return VK.GetSwapchainImagesKHR(device, swapchain, swapchainImageCount, swapchainImages);
        }
        
        public static Result AcquireNextImageKHR(this Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, UInt32 imageIndex)
        {
            return VK.AcquireNextImageKHR(device, swapchain, timeout, semaphore, fence, imageIndex);
        }
        
        #endregion
        
        #region Queue
        
        public static Result QueueSubmit(this Queue queue, UInt32 submitCount, SubmitInfo submits, Fence fence)
        {
            return VK.QueueSubmit(queue, submitCount, submits, fence);
        }
        
        public static Result QueueWaitIdle(this Queue queue)
        {
            return VK.QueueWaitIdle(queue);
        }
        
        public static Result QueueBindSparse(this Queue queue, UInt32 bindInfoCount, BindSparseInfo bindInfo, Fence fence)
        {
            return VK.QueueBindSparse(queue, bindInfoCount, bindInfo, fence);
        }
        
        public static Result QueuePresentKHR(this Queue queue, PresentInfoKHR presentInfo)
        {
            return VK.QueuePresentKHR(queue, presentInfo);
        }
        
        #endregion
        
        #region CommandBuffer
        
        public static Result BeginCommandBuffer(this CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            return VK.BeginCommandBuffer(commandBuffer, beginInfo);
        }
        
        public static Result EndCommandBuffer(this CommandBuffer commandBuffer)
        {
            return VK.EndCommandBuffer(commandBuffer);
        }
        
        public static Result ResetCommandBuffer(this CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            return VK.ResetCommandBuffer(commandBuffer, flags);
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
