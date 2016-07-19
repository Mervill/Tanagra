using System;

namespace Vulkan.Managed.ObjectModel
{
    public static class HandleExtensions
    {
        #region Instance
        
        /// <param name="instance">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void Destroy(this Instance instance, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyInstance(instance, allocator);
        
        public static PhysicalDevice[] EnumeratePhysicalDevices(this Instance instance)
            => Vk.EnumeratePhysicalDevices(instance);
        
        /// <param name="instance">Optional</param>
        public static IntPtr GetProcAddr(this Instance instance, String name)
            => Vk.GetInstanceProcAddr(instance, name);
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateAndroidSurfaceKHR(this Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateAndroidSurfaceKHR(instance, createInfo, allocator);
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateDisplayPlaneSurfaceKHR(this Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateDisplayPlaneSurfaceKHR(instance, createInfo, allocator);
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateMirSurfaceKHR(this Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateMirSurfaceKHR(instance, createInfo, allocator);
        
        /// <param name="surface">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySurfaceKHR(this Instance instance, SurfaceKHR surface = default(SurfaceKHR), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroySurfaceKHR(instance, surface, allocator);
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateWaylandSurfaceKHR(this Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateWaylandSurfaceKHR(instance, createInfo, allocator);
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateWin32SurfaceKHR(this Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateWin32SurfaceKHR(instance, createInfo, allocator);
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateXlibSurfaceKHR(this Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateXlibSurfaceKHR(instance, createInfo, allocator);
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateXcbSurfaceKHR(this Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateXcbSurfaceKHR(instance, createInfo, allocator);
        
        /// <param name="allocator">Optional</param>
        public static DebugReportCallbackEXT CreateDebugReportCallbackEXT(this Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateDebugReportCallbackEXT(instance, createInfo, allocator);
        
        /// <param name="callback">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDebugReportCallbackEXT(this Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyDebugReportCallbackEXT(instance, callback, allocator);
        
        public static void DebugReportMessageEXT(this Instance instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, Size location, Int32 messageCode, String layerPrefix, String message)
            => Vk.DebugReportMessageEXT(instance, flags, objectType, @object, location, messageCode, layerPrefix, message);
        
        #endregion
        
        #region PhysicalDevice
        
        public static PhysicalDeviceProperties GetProperties(this PhysicalDevice physicalDevice)
            => Vk.GetPhysicalDeviceProperties(physicalDevice);
        
        public static QueueFamilyProperties[] GetQueueFamilyProperties(this PhysicalDevice physicalDevice)
            => Vk.GetPhysicalDeviceQueueFamilyProperties(physicalDevice);
        
        public static PhysicalDeviceMemoryProperties GetMemoryProperties(this PhysicalDevice physicalDevice)
            => Vk.GetPhysicalDeviceMemoryProperties(physicalDevice);
        
        public static PhysicalDeviceFeatures GetFeatures(this PhysicalDevice physicalDevice)
            => Vk.GetPhysicalDeviceFeatures(physicalDevice);
        
        public static FormatProperties GetFormatProperties(this PhysicalDevice physicalDevice, Format format)
            => Vk.GetPhysicalDeviceFormatProperties(physicalDevice, format);
        
        /// <param name="flags">Optional</param>
        public static ImageFormatProperties GetImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags = default(ImageCreateFlags))
            => Vk.GetPhysicalDeviceImageFormatProperties(physicalDevice, format, type, tiling, usage, flags);
        
        /// <param name="allocator">Optional</param>
        public static Device CreateDevice(this PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateDevice(physicalDevice, createInfo, allocator);
        
        public static LayerProperties[] EnumerateDeviceLayerProperties(this PhysicalDevice physicalDevice)
            => Vk.EnumerateDeviceLayerProperties(physicalDevice);
        
        /// <param name="layerName">Optional</param>
        public static ExtensionProperties[] EnumerateDeviceExtensionProperties(this PhysicalDevice physicalDevice, String layerName = default(String))
            => Vk.EnumerateDeviceExtensionProperties(physicalDevice, layerName);
        
        public static SparseImageFormatProperties[] GetSparseImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
            => Vk.GetPhysicalDeviceSparseImageFormatProperties(physicalDevice, format, type, samples, usage, tiling);
        
        public static DisplayPropertiesKHR[] GetDisplayPropertiesKHR(this PhysicalDevice physicalDevice)
            => Vk.GetPhysicalDeviceDisplayPropertiesKHR(physicalDevice);
        
        public static DisplayPlanePropertiesKHR[] GetDisplayPlanePropertiesKHR(this PhysicalDevice physicalDevice)
            => Vk.GetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice);
        
        public static DisplayKHR[] GetDisplayPlaneSupportedDisplaysKHR(this PhysicalDevice physicalDevice, UInt32 planeIndex)
            => Vk.GetDisplayPlaneSupportedDisplaysKHR(physicalDevice, planeIndex);
        
        public static DisplayModePropertiesKHR[] GetDisplayModePropertiesKHR(this PhysicalDevice physicalDevice, DisplayKHR display)
            => Vk.GetDisplayModePropertiesKHR(physicalDevice, display);
        
        /// <param name="display">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static DisplayModeKHR CreateDisplayModeKHR(this PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateDisplayModeKHR(physicalDevice, display, createInfo, allocator);
        
        /// <param name="mode">ExternSync</param>
        public static DisplayPlaneCapabilitiesKHR GetDisplayPlaneCapabilitiesKHR(this PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex)
            => Vk.GetDisplayPlaneCapabilitiesKHR(physicalDevice, mode, planeIndex);
        
        public static IntPtr GetMirPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
            => Vk.GetPhysicalDeviceMirPresentationSupportKHR(physicalDevice, queueFamilyIndex);
        
        public static Bool32 GetSurfaceSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface)
            => Vk.GetPhysicalDeviceSurfaceSupportKHR(physicalDevice, queueFamilyIndex, surface);
        
        public static SurfaceCapabilitiesKHR GetSurfaceCapabilitiesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
            => Vk.GetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice, surface);
        
        public static SurfaceFormatKHR[] GetSurfaceFormatsKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
            => Vk.GetPhysicalDeviceSurfaceFormatsKHR(physicalDevice, surface);
        
        public static PresentModeKHR[] GetSurfacePresentModesKHR(this PhysicalDevice physicalDevice, SurfaceKHR surface)
            => Vk.GetPhysicalDeviceSurfacePresentModesKHR(physicalDevice, surface);
        
        public static IntPtr GetWaylandPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
            => Vk.GetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice, queueFamilyIndex);
        
        public static Bool32 GetWin32PresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
            => Vk.GetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice, queueFamilyIndex);
        
        public static Bool32 GetXlibPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr dpy, IntPtr visualID)
            => Vk.GetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice, queueFamilyIndex, dpy, visualID);
        
        public static Bool32 GetXcbPresentationSupportKHR(this PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr connection, IntPtr visual_id)
            => Vk.GetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice, queueFamilyIndex, connection, visual_id);
        
        #endregion
        
        #region Device
        
        public static IntPtr GetProcAddr(this Device device, String name)
            => Vk.GetDeviceProcAddr(device, name);
        
        /// <param name="device">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void Destroy(this Device device, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyDevice(device, allocator);
        
        public static Queue GetQueue(this Device device, UInt32 queueFamilyIndex, UInt32 queueIndex)
            => Vk.GetDeviceQueue(device, queueFamilyIndex, queueIndex);
        
        public static void WaitIdle(this Device device)
            => Vk.DeviceWaitIdle(device);
        
        /// <param name="allocator">Optional</param>
        public static DeviceMemory AllocateMemory(this Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.AllocateMemory(device, allocateInfo, allocator);
        
        /// <param name="memory">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void FreeMemory(this Device device, DeviceMemory memory = default(DeviceMemory), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.FreeMemory(device, memory, allocator);
        
        /// <param name="memory">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static IntPtr MapMemory(this Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags = default(MemoryMapFlags))
            => Vk.MapMemory(device, memory, offset, size, flags);
        
        /// <param name="memory">ExternSync</param>
        public static void UnmapMemory(this Device device, DeviceMemory memory)
            => Vk.UnmapMemory(device, memory);
        
        public static void FlushMappedMemoryRanges(this Device device, params MappedMemoryRange[] memoryRanges)
            => Vk.FlushMappedMemoryRanges(device, memoryRanges);
        
        public static void InvalidateMappedMemoryRanges(this Device device, params MappedMemoryRange[] memoryRanges)
            => Vk.InvalidateMappedMemoryRanges(device, memoryRanges);
        
        public static DeviceSize GetMemoryCommitment(this Device device, DeviceMemory memory)
            => Vk.GetDeviceMemoryCommitment(device, memory);
        
        public static MemoryRequirements GetBufferMemoryRequirements(this Device device, Buffer buffer)
            => Vk.GetBufferMemoryRequirements(device, buffer);
        
        /// <param name="buffer">ExternSync</param>
        public static void BindBufferMemory(this Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
            => Vk.BindBufferMemory(device, buffer, memory, memoryOffset);
        
        public static MemoryRequirements GetImageMemoryRequirements(this Device device, Image image)
            => Vk.GetImageMemoryRequirements(device, image);
        
        /// <param name="image">ExternSync</param>
        public static void BindImageMemory(this Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
            => Vk.BindImageMemory(device, image, memory, memoryOffset);
        
        public static SparseImageMemoryRequirements[] GetImageSparseMemoryRequirements(this Device device, Image image)
            => Vk.GetImageSparseMemoryRequirements(device, image);
        
        /// <param name="allocator">Optional</param>
        public static Fence CreateFence(this Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateFence(device, createInfo, allocator);
        
        /// <param name="fence">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyFence(this Device device, Fence fence = default(Fence), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyFence(device, fence, allocator);
        
        /// <param name="fences">ExternSync</param>
        public static void ResetFences(this Device device, params Fence[] fences)
            => Vk.ResetFences(device, fences);
        
        public static Result GetFenceStatus(this Device device, Fence fence)
            => Vk.GetFenceStatus(device, fence);
        
        public static Result WaitForFences(this Device device, Fence[] fences, Bool32 waitAll, UInt64 timeout)
            => Vk.WaitForFences(device, fences, waitAll, timeout);
        
        /// <param name="allocator">Optional</param>
        public static Semaphore CreateSemaphore(this Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateSemaphore(device, createInfo, allocator);
        
        /// <param name="semaphore">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySemaphore(this Device device, Semaphore semaphore = default(Semaphore), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroySemaphore(device, semaphore, allocator);
        
        /// <param name="allocator">Optional</param>
        public static Event CreateEvent(this Device device, EventCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateEvent(device, createInfo, allocator);
        
        /// <param name="@event">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyEvent(this Device device, Event @event = default(Event), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyEvent(device, @event, allocator);
        
        public static Result GetEventStatus(this Device device, Event @event)
            => Vk.GetEventStatus(device, @event);
        
        /// <param name="@event">ExternSync</param>
        public static void SetEvent(this Device device, Event @event)
            => Vk.SetEvent(device, @event);
        
        /// <param name="@event">ExternSync</param>
        public static void ResetEvent(this Device device, Event @event)
            => Vk.ResetEvent(device, @event);
        
        /// <param name="allocator">Optional</param>
        public static QueryPool CreateQueryPool(this Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateQueryPool(device, createInfo, allocator);
        
        /// <param name="queryPool">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyQueryPool(this Device device, QueryPool queryPool = default(QueryPool), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyQueryPool(device, queryPool, allocator);
        
        /// <param name="flags">Optional</param>
        public static Result GetQueryPoolResults(this Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Byte[] data, DeviceSize stride, QueryResultFlags flags = default(QueryResultFlags))
            => Vk.GetQueryPoolResults(device, queryPool, firstQuery, queryCount, data, stride, flags);
        
        /// <param name="allocator">Optional</param>
        public static Buffer CreateBuffer(this Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateBuffer(device, createInfo, allocator);
        
        /// <param name="buffer">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyBuffer(this Device device, Buffer buffer = default(Buffer), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyBuffer(device, buffer, allocator);
        
        /// <param name="allocator">Optional</param>
        public static BufferView CreateBufferView(this Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateBufferView(device, createInfo, allocator);
        
        /// <param name="bufferView">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyBufferView(this Device device, BufferView bufferView = default(BufferView), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyBufferView(device, bufferView, allocator);
        
        /// <param name="allocator">Optional</param>
        public static Image CreateImage(this Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateImage(device, createInfo, allocator);
        
        /// <param name="image">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyImage(this Device device, Image image = default(Image), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyImage(device, image, allocator);
        
        public static SubresourceLayout GetImageSubresourceLayout(this Device device, Image image, ImageSubresource subresource)
            => Vk.GetImageSubresourceLayout(device, image, subresource);
        
        /// <param name="allocator">Optional</param>
        public static ImageView CreateImageView(this Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateImageView(device, createInfo, allocator);
        
        /// <param name="imageView">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyImageView(this Device device, ImageView imageView = default(ImageView), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyImageView(device, imageView, allocator);
        
        /// <param name="allocator">Optional</param>
        public static ShaderModule CreateShaderModule(this Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateShaderModule(device, createInfo, allocator);
        
        /// <param name="shaderModule">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyShaderModule(this Device device, ShaderModule shaderModule = default(ShaderModule), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyShaderModule(device, shaderModule, allocator);
        
        /// <param name="allocator">Optional</param>
        public static PipelineCache CreatePipelineCache(this Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreatePipelineCache(device, createInfo, allocator);
        
        /// <param name="pipelineCache">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipelineCache(this Device device, PipelineCache pipelineCache = default(PipelineCache), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyPipelineCache(device, pipelineCache, allocator);
        
        public static Byte[] GetPipelineCacheData(this Device device, PipelineCache pipelineCache)
            => Vk.GetPipelineCacheData(device, pipelineCache);
        
        /// <param name="dstCache">ExternSync</param>
        public static void MergePipelineCaches(this Device device, PipelineCache dstCache, params PipelineCache[] srcCaches)
            => Vk.MergePipelineCaches(device, dstCache, srcCaches);
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        public static Pipeline[] CreateGraphicsPipelines(this Device device, PipelineCache pipelineCache, GraphicsPipelineCreateInfo[] createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateGraphicsPipelines(device, pipelineCache, createInfos, allocator);
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        public static Pipeline[] CreateComputePipelines(this Device device, PipelineCache pipelineCache, ComputePipelineCreateInfo[] createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateComputePipelines(device, pipelineCache, createInfos, allocator);
        
        /// <param name="pipeline">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipeline(this Device device, Pipeline pipeline = default(Pipeline), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyPipeline(device, pipeline, allocator);
        
        /// <param name="allocator">Optional</param>
        public static PipelineLayout CreatePipelineLayout(this Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreatePipelineLayout(device, createInfo, allocator);
        
        /// <param name="pipelineLayout">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipelineLayout(this Device device, PipelineLayout pipelineLayout = default(PipelineLayout), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyPipelineLayout(device, pipelineLayout, allocator);
        
        /// <param name="allocator">Optional</param>
        public static Sampler CreateSampler(this Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateSampler(device, createInfo, allocator);
        
        /// <param name="sampler">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySampler(this Device device, Sampler sampler = default(Sampler), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroySampler(device, sampler, allocator);
        
        /// <param name="allocator">Optional</param>
        public static DescriptorSetLayout CreateDescriptorSetLayout(this Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateDescriptorSetLayout(device, createInfo, allocator);
        
        /// <param name="descriptorSetLayout">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDescriptorSetLayout(this Device device, DescriptorSetLayout descriptorSetLayout = default(DescriptorSetLayout), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyDescriptorSetLayout(device, descriptorSetLayout, allocator);
        
        /// <param name="allocator">Optional</param>
        public static DescriptorPool CreateDescriptorPool(this Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateDescriptorPool(device, createInfo, allocator);
        
        /// <param name="descriptorPool">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDescriptorPool(this Device device, DescriptorPool descriptorPool = default(DescriptorPool), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyDescriptorPool(device, descriptorPool, allocator);
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void ResetDescriptorPool(this Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags = default(DescriptorPoolResetFlags))
            => Vk.ResetDescriptorPool(device, descriptorPool, flags);
        
        public static DescriptorSet[] AllocateDescriptorSets(this Device device, DescriptorSetAllocateInfo allocateInfo)
            => Vk.AllocateDescriptorSets(device, allocateInfo);
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="descriptorSets">ExternSync, No Auto Validity</param>
        public static void FreeDescriptorSets(this Device device, DescriptorPool descriptorPool, params DescriptorSet[] descriptorSets)
            => Vk.FreeDescriptorSets(device, descriptorPool, descriptorSets);
        
        public static void UpdateDescriptorSets(this Device device, WriteDescriptorSet[] descriptorWrites, params CopyDescriptorSet[] descriptorCopies)
            => Vk.UpdateDescriptorSets(device, descriptorWrites, descriptorCopies);
        
        /// <param name="allocator">Optional</param>
        public static Framebuffer CreateFramebuffer(this Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateFramebuffer(device, createInfo, allocator);
        
        /// <param name="framebuffer">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyFramebuffer(this Device device, Framebuffer framebuffer = default(Framebuffer), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyFramebuffer(device, framebuffer, allocator);
        
        /// <param name="allocator">Optional</param>
        public static RenderPass CreateRenderPass(this Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateRenderPass(device, createInfo, allocator);
        
        /// <param name="renderPass">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyRenderPass(this Device device, RenderPass renderPass = default(RenderPass), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyRenderPass(device, renderPass, allocator);
        
        public static Extent2D GetRenderAreaGranularity(this Device device, RenderPass renderPass)
            => Vk.GetRenderAreaGranularity(device, renderPass);
        
        /// <param name="allocator">Optional</param>
        public static CommandPool CreateCommandPool(this Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateCommandPool(device, createInfo, allocator);
        
        /// <param name="commandPool">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyCommandPool(this Device device, CommandPool commandPool = default(CommandPool), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroyCommandPool(device, commandPool, allocator);
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void ResetCommandPool(this Device device, CommandPool commandPool, CommandPoolResetFlags flags = default(CommandPoolResetFlags))
            => Vk.ResetCommandPool(device, commandPool, flags);
        
        public static CommandBuffer[] AllocateCommandBuffers(this Device device, CommandBufferAllocateInfo allocateInfo)
            => Vk.AllocateCommandBuffers(device, allocateInfo);
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="commandBuffers">ExternSync, No Auto Validity</param>
        public static void FreeCommandBuffers(this Device device, CommandPool commandPool, params CommandBuffer[] commandBuffers)
            => Vk.FreeCommandBuffers(device, commandPool, commandBuffers);
        
        /// <param name="allocator">Optional</param>
        public static SwapchainKHR[] CreateSharedSwapchainsKHR(this Device device, SwapchainCreateInfoKHR[] createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateSharedSwapchainsKHR(device, createInfos, allocator);
        
        /// <param name="allocator">Optional</param>
        public static SwapchainKHR CreateSwapchainKHR(this Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.CreateSwapchainKHR(device, createInfo, allocator);
        
        /// <param name="swapchain">ExternSync, Optional</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySwapchainKHR(this Device device, SwapchainKHR swapchain = default(SwapchainKHR), AllocationCallbacks allocator = default(AllocationCallbacks))
            => Vk.DestroySwapchainKHR(device, swapchain, allocator);
        
        public static Image[] GetSwapchainImagesKHR(this Device device, SwapchainKHR swapchain)
            => Vk.GetSwapchainImagesKHR(device, swapchain);
        
        /// <param name="swapchain">ExternSync</param>
        /// <param name="semaphore">ExternSync, Optional</param>
        /// <param name="fence">ExternSync, Optional</param>
        public static UInt32 AcquireNextImageKHR(this Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore = default(Semaphore), Fence fence = default(Fence))
            => Vk.AcquireNextImageKHR(device, swapchain, timeout, semaphore, fence);
        
        public static DebugMarkerObjectNameInfoEXT DebugMarkerSetObjectNameEXT(this Device device)
            => Vk.DebugMarkerSetObjectNameEXT(device);
        
        public static DebugMarkerObjectTagInfoEXT DebugMarkerSetObjectTagEXT(this Device device)
            => Vk.DebugMarkerSetObjectTagEXT(device);
        
        #endregion
        
        #region Queue
        
        /// <param name="queue">ExternSync</param>
        /// <param name="fence">ExternSync, Optional</param>
        public static void Submit(this Queue queue, SubmitInfo[] submits, Fence fence = default(Fence))
            => Vk.QueueSubmit(queue, submits, fence);
        
        public static void WaitIdle(this Queue queue)
            => Vk.QueueWaitIdle(queue);
        
        /// <summary>
        /// [<see cref="QueueFlags"/>: Sparse_binding] 
        /// </summary>
        /// <param name="queue">ExternSync</param>
        /// <param name="fence">ExternSync, Optional</param>
        public static void BindSparse(this Queue queue, BindSparseInfo[] bindInfo, Fence fence = default(Fence))
            => Vk.QueueBindSparse(queue, bindInfo, fence);
        
        /// <param name="queue">ExternSync</param>
        public static Result PresentKHR(this Queue queue, PresentInfoKHR presentInfo)
            => Vk.QueuePresentKHR(queue, presentInfo);
        
        #endregion
        
        #region CommandBuffer
        
        /// <param name="commandBuffer">ExternSync</param>
        public static void Begin(this CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
            => Vk.BeginCommandBuffer(commandBuffer, beginInfo);
        
        /// <param name="commandBuffer">ExternSync</param>
        public static void End(this CommandBuffer commandBuffer)
            => Vk.EndCommandBuffer(commandBuffer);
        
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void Reset(this CommandBuffer commandBuffer, CommandBufferResetFlags flags = default(CommandBufferResetFlags))
            => Vk.ResetCommandBuffer(commandBuffer, flags);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void BindPipeline(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
            => Vk.CmdBindPipeline(commandBuffer, pipelineBindPoint, pipeline);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetViewport(this CommandBuffer commandBuffer, UInt32 firstViewport, params Viewport[] viewports)
            => Vk.CmdSetViewport(commandBuffer, firstViewport, viewports);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetScissor(this CommandBuffer commandBuffer, UInt32 firstScissor, params Rect2D[] scissors)
            => Vk.CmdSetScissor(commandBuffer, firstScissor, scissors);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetLineWidth(this CommandBuffer commandBuffer, Single lineWidth)
            => Vk.CmdSetLineWidth(commandBuffer, lineWidth);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetDepthBias(this CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
            => Vk.CmdSetDepthBias(commandBuffer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetBlendConstants(this CommandBuffer commandBuffer, Single blendConstants)
            => Vk.CmdSetBlendConstants(commandBuffer, blendConstants);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetDepthBounds(this CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
            => Vk.CmdSetDepthBounds(commandBuffer, minDepthBounds, maxDepthBounds);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetStencilCompareMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
            => Vk.CmdSetStencilCompareMask(commandBuffer, faceMask, compareMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetStencilWriteMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
            => Vk.CmdSetStencilWriteMask(commandBuffer, faceMask, writeMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetStencilReference(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
            => Vk.CmdSetStencilReference(commandBuffer, faceMask, reference);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void BindDescriptorSets(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, DescriptorSet[] descriptorSets, params UInt32[] dynamicOffsets)
            => Vk.CmdBindDescriptorSets(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSets, dynamicOffsets);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void BindIndexBuffer(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
            => Vk.CmdBindIndexBuffer(commandBuffer, buffer, offset, indexType);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void BindVertexBuffers(this CommandBuffer commandBuffer, UInt32 firstBinding, Buffer[] buffers, params DeviceSize[] offsets)
            => Vk.CmdBindVertexBuffers(commandBuffer, firstBinding, buffers, offsets);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void Draw(this CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
            => Vk.CmdDraw(commandBuffer, vertexCount, instanceCount, firstVertex, firstInstance);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void DrawIndexed(this CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
            => Vk.CmdDrawIndexed(commandBuffer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void DrawIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
            => Vk.CmdDrawIndirect(commandBuffer, buffer, offset, drawCount, stride);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void DrawIndexedIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
            => Vk.CmdDrawIndexedIndirect(commandBuffer, buffer, offset, drawCount, stride);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void Dispatch(this CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
            => Vk.CmdDispatch(commandBuffer, x, y, z);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void DispatchIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
            => Vk.CmdDispatchIndirect(commandBuffer, buffer, offset);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CopyBuffer(this CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, params BufferCopy[] regions)
            => Vk.CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CopyImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, params ImageCopy[] regions)
            => Vk.CmdCopyImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void BlitImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, ImageBlit[] regions, Filter filter)
            => Vk.CmdBlitImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions, filter);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CopyBufferToImage(this CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, params BufferImageCopy[] regions)
            => Vk.CmdCopyBufferToImage(commandBuffer, srcBuffer, dstImage, dstImageLayout, regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CopyImageToBuffer(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, params BufferImageCopy[] regions)
            => Vk.CmdCopyImageToBuffer(commandBuffer, srcImage, srcImageLayout, dstBuffer, regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void UpdateBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, params Byte[] data)
            => Vk.CmdUpdateBuffer(commandBuffer, dstBuffer, dstOffset, data);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void FillBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
            => Vk.CmdFillBuffer(commandBuffer, dstBuffer, dstOffset, size, data);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void ClearColorImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, params ImageSubresourceRange[] ranges)
            => Vk.CmdClearColorImage(commandBuffer, image, imageLayout, color, ranges);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void ClearDepthStencilImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, params ImageSubresourceRange[] ranges)
            => Vk.CmdClearDepthStencilImage(commandBuffer, image, imageLayout, depthStencil, ranges);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void ClearAttachments(this CommandBuffer commandBuffer, ClearAttachment[] attachments, params ClearRect[] rects)
            => Vk.CmdClearAttachments(commandBuffer, attachments, rects);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void ResolveImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, params ImageResolve[] regions)
            => Vk.CmdResolveImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void SetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
            => Vk.CmdSetEvent(commandBuffer, @event, stageMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void ResetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
            => Vk.CmdResetEvent(commandBuffer, @event, stageMask);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void WaitEvents(this CommandBuffer commandBuffer, Event[] events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, MemoryBarrier[] memoryBarriers, BufferMemoryBarrier[] bufferMemoryBarriers, params ImageMemoryBarrier[] imageMemoryBarriers)
            => Vk.CmdWaitEvents(commandBuffer, events, srcStageMask, dstStageMask, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="dependencyFlags">Optional</param>
        public static void PipelineBarrier(this CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, MemoryBarrier[] memoryBarriers, BufferMemoryBarrier[] bufferMemoryBarriers, params ImageMemoryBarrier[] imageMemoryBarriers)
            => Vk.CmdPipelineBarrier(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void BeginQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags = default(QueryControlFlags))
            => Vk.CmdBeginQuery(commandBuffer, queryPool, query, flags);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void EndQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
            => Vk.CmdEndQuery(commandBuffer, queryPool, query);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void ResetQueryPool(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
            => Vk.CmdResetQueryPool(commandBuffer, queryPool, firstQuery, queryCount);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void WriteTimestamp(this CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
            => Vk.CmdWriteTimestamp(commandBuffer, pipelineStage, queryPool, query);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void CopyQueryPoolResults(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags = default(QueryResultFlags))
            => Vk.CmdCopyQueryPoolResults(commandBuffer, queryPool, firstQuery, queryCount, dstBuffer, dstOffset, stride, flags);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void PushConstants(this CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, params Byte[] values)
            => Vk.CmdPushConstants(commandBuffer, layout, stageFlags, offset, values);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void BeginRenderPass(this CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
            => Vk.CmdBeginRenderPass(commandBuffer, renderPassBegin, contents);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void NextSubpass(this CommandBuffer commandBuffer, SubpassContents contents)
            => Vk.CmdNextSubpass(commandBuffer, contents);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void EndRenderPass(this CommandBuffer commandBuffer)
            => Vk.CmdEndRenderPass(commandBuffer);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void ExecuteCommands(this CommandBuffer commandBuffer, params CommandBuffer[] commandBuffers)
            => Vk.CmdExecuteCommands(commandBuffer, commandBuffers);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static DebugMarkerMarkerInfoEXT DebugMarkerBeginEXT(this CommandBuffer commandBuffer)
            => Vk.CmdDebugMarkerBeginEXT(commandBuffer);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static void DebugMarkerEndEXT(this CommandBuffer commandBuffer)
            => Vk.CmdDebugMarkerEndEXT(commandBuffer);
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static DebugMarkerMarkerInfoEXT DebugMarkerInsertEXT(this CommandBuffer commandBuffer)
            => Vk.CmdDebugMarkerInsertEXT(commandBuffer);
        
        #endregion
        
    }
}
