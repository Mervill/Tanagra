using System;
using System.Collections.Generic;

namespace Vulkan.Managed.ObjectModel
{
    public static class HandleExtensions
    {
        #region Instance
        
        /// <param name="instance">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void Destroy(this Instance instance, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyInstance(instance, allocator);
        }
        
        public static List<PhysicalDevice> EnumeratePhysicalDevices(this Instance instance)
        {
            return Vk.EnumeratePhysicalDevices(instance);
        }
        
        /// <param name="instance">Optional</param>
        public static IntPtr GetProcAddr(this Instance instance, String name)
        {
            return Vk.GetInstanceProcAddr(instance, name);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateAndroidSurfaceKHR(this Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateAndroidSurfaceKHR(instance, createInfo, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateDisplayPlaneSurfaceKHR(this Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateDisplayPlaneSurfaceKHR(instance, createInfo, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateMirSurfaceKHR(this Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateMirSurfaceKHR(instance, createInfo, allocator);
        }
        
        /// <param name="surface">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySurfaceKHR(this Instance instance, SurfaceKHR surface = default(SurfaceKHR), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroySurfaceKHR(instance, surface, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateWaylandSurfaceKHR(this Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateWaylandSurfaceKHR(instance, createInfo, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateWin32SurfaceKHR(this Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateWin32SurfaceKHR(instance, createInfo, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateXlibSurfaceKHR(this Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateXlibSurfaceKHR(instance, createInfo, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateXcbSurfaceKHR(this Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateXcbSurfaceKHR(instance, createInfo, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static DebugReportCallbackEXT CreateDebugReportCallbackEXT(this Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateDebugReportCallbackEXT(instance, createInfo, allocator);
        }
        
        /// <param name="callback">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDebugReportCallbackEXT(this Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="flags">Optional</param>
        public static ImageFormatProperties GetImageFormatProperties(this PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags = default(ImageCreateFlags))
        {
            return Vk.GetPhysicalDeviceImageFormatProperties(physicalDevice, format, type, tiling, usage, flags);
        }
        
        /// <param name="allocator">Optional</param>
        public static Device CreateDevice(this PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateDevice(physicalDevice, createInfo, allocator);
        }
        
        /// <param name="physicalDevice">Optional</param>
        public static List<LayerProperties> EnumerateDeviceLayerProperties(this PhysicalDevice physicalDevice)
        {
            return Vk.EnumerateDeviceLayerProperties(physicalDevice);
        }
        
        /// <param name="layerName">Optional</param>
        public static List<ExtensionProperties> EnumerateDeviceExtensionProperties(this PhysicalDevice physicalDevice, String layerName = default(String))
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
        
        /// <param name="display">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static DisplayModeKHR CreateDisplayModeKHR(this PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateDisplayModeKHR(physicalDevice, display, createInfo, allocator);
        }
        
        /// <param name="mode">ExternSync</param>
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
        
        /// <param name="device">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void Destroy(this Device device, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="allocator">Optional</param>
        public static DeviceMemory AllocateMemory(this Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.AllocateMemory(device, allocateInfo, allocator);
        }
        
        /// <param name="memory">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void FreeMemory(this Device device, DeviceMemory memory = default(DeviceMemory), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.FreeMemory(device, memory, allocator);
        }
        
        /// <param name="memory">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static IntPtr MapMemory(this Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags = default(MemoryMapFlags))
        {
            return Vk.MapMemory(device, memory, offset, size, flags);
        }
        
        /// <param name="memory">ExternSync</param>
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
        
        /// <param name="buffer">ExternSync</param>
        public static void BindBufferMemory(this Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            Vk.BindBufferMemory(device, buffer, memory, memoryOffset);
        }
        
        public static MemoryRequirements GetImageMemoryRequirements(this Device device, Image image)
        {
            return Vk.GetImageMemoryRequirements(device, image);
        }
        
        /// <param name="image">ExternSync</param>
        public static void BindImageMemory(this Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            Vk.BindImageMemory(device, image, memory, memoryOffset);
        }
        
        public static List<SparseImageMemoryRequirements> GetImageSparseMemoryRequirements(this Device device, Image image)
        {
            return Vk.GetImageSparseMemoryRequirements(device, image);
        }
        
        /// <param name="allocator">Optional</param>
        public static Fence CreateFence(this Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateFence(device, createInfo, allocator);
        }
        
        /// <param name="fence">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyFence(this Device device, Fence fence = default(Fence), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyFence(device, fence, allocator);
        }
        
        /// <param name="fences">ExternSync</param>
        public static void ResetFences(this Device device, List<Fence> fences)
        {
            Vk.ResetFences(device, fences);
        }
        
        public static Result GetFenceStatus(this Device device, Fence fence)
        {
            return Vk.GetFenceStatus(device, fence);
        }
        
        public static Result WaitForFences(this Device device, List<Fence> fences, Bool32 waitAll, UInt64 timeout)
        {
            return Vk.WaitForFences(device, fences, waitAll, timeout);
        }
        
        /// <param name="allocator">Optional</param>
        public static Semaphore CreateSemaphore(this Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateSemaphore(device, createInfo, allocator);
        }
        
        /// <param name="semaphore">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySemaphore(this Device device, Semaphore semaphore = default(Semaphore), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroySemaphore(device, semaphore, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static Event CreateEvent(this Device device, EventCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateEvent(device, createInfo, allocator);
        }
        
        /// <param name="@event">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyEvent(this Device device, Event @event = default(Event), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyEvent(device, @event, allocator);
        }
        
        public static Result GetEventStatus(this Device device, Event @event)
        {
            return Vk.GetEventStatus(device, @event);
        }
        
        /// <param name="@event">ExternSync</param>
        public static void SetEvent(this Device device, Event @event)
        {
            Vk.SetEvent(device, @event);
        }
        
        /// <param name="@event">ExternSync</param>
        public static void ResetEvent(this Device device, Event @event)
        {
            Vk.ResetEvent(device, @event);
        }
        
        /// <param name="allocator">Optional</param>
        public static QueryPool CreateQueryPool(this Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateQueryPool(device, createInfo, allocator);
        }
        
        /// <param name="queryPool">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyQueryPool(this Device device, QueryPool queryPool = default(QueryPool), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyQueryPool(device, queryPool, allocator);
        }
        
        /// <param name="flags">Optional</param>
        public static Result GetQueryPoolResults(this Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, List<IntPtr> data, DeviceSize stride, QueryResultFlags flags = default(QueryResultFlags))
        {
            return Vk.GetQueryPoolResults(device, queryPool, firstQuery, queryCount, data, stride, flags);
        }
        
        /// <param name="allocator">Optional</param>
        public static Buffer CreateBuffer(this Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateBuffer(device, createInfo, allocator);
        }
        
        /// <param name="buffer">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyBuffer(this Device device, Buffer buffer = default(Buffer), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyBuffer(device, buffer, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static BufferView CreateBufferView(this Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateBufferView(device, createInfo, allocator);
        }
        
        /// <param name="bufferView">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyBufferView(this Device device, BufferView bufferView = default(BufferView), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyBufferView(device, bufferView, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static Image CreateImage(this Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateImage(device, createInfo, allocator);
        }
        
        /// <param name="image">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyImage(this Device device, Image image = default(Image), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyImage(device, image, allocator);
        }
        
        public static SubresourceLayout GetImageSubresourceLayout(this Device device, Image image, ImageSubresource subresource)
        {
            return Vk.GetImageSubresourceLayout(device, image, subresource);
        }
        
        /// <param name="allocator">Optional</param>
        public static ImageView CreateImageView(this Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateImageView(device, createInfo, allocator);
        }
        
        /// <param name="imageView">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyImageView(this Device device, ImageView imageView = default(ImageView), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyImageView(device, imageView, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static ShaderModule CreateShaderModule(this Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateShaderModule(device, createInfo, allocator);
        }
        
        /// <param name="shaderModule">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyShaderModule(this Device device, ShaderModule shaderModule = default(ShaderModule), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyShaderModule(device, shaderModule, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static PipelineCache CreatePipelineCache(this Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreatePipelineCache(device, createInfo, allocator);
        }
        
        /// <param name="pipelineCache">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipelineCache(this Device device, PipelineCache pipelineCache = default(PipelineCache), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyPipelineCache(device, pipelineCache, allocator);
        }
        
        public static List<IntPtr> GetPipelineCacheData(this Device device, PipelineCache pipelineCache)
        {
            return Vk.GetPipelineCacheData(device, pipelineCache);
        }
        
        /// <param name="dstCache">ExternSync</param>
        public static void MergePipelineCaches(this Device device, PipelineCache dstCache, List<PipelineCache> srcCaches)
        {
            Vk.MergePipelineCaches(device, dstCache, srcCaches);
        }
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        public static List<Pipeline> CreateGraphicsPipelines(this Device device, PipelineCache pipelineCache, List<GraphicsPipelineCreateInfo> createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateGraphicsPipelines(device, pipelineCache, createInfos, allocator);
        }
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        public static List<Pipeline> CreateComputePipelines(this Device device, PipelineCache pipelineCache, List<ComputePipelineCreateInfo> createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateComputePipelines(device, pipelineCache, createInfos, allocator);
        }
        
        /// <param name="pipeline">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipeline(this Device device, Pipeline pipeline = default(Pipeline), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyPipeline(device, pipeline, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static PipelineLayout CreatePipelineLayout(this Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreatePipelineLayout(device, createInfo, allocator);
        }
        
        /// <param name="pipelineLayout">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipelineLayout(this Device device, PipelineLayout pipelineLayout = default(PipelineLayout), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyPipelineLayout(device, pipelineLayout, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static Sampler CreateSampler(this Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateSampler(device, createInfo, allocator);
        }
        
        /// <param name="sampler">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySampler(this Device device, Sampler sampler = default(Sampler), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroySampler(device, sampler, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static DescriptorSetLayout CreateDescriptorSetLayout(this Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateDescriptorSetLayout(device, createInfo, allocator);
        }
        
        /// <param name="descriptorSetLayout">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDescriptorSetLayout(this Device device, DescriptorSetLayout descriptorSetLayout = default(DescriptorSetLayout), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyDescriptorSetLayout(device, descriptorSetLayout, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static DescriptorPool CreateDescriptorPool(this Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateDescriptorPool(device, createInfo, allocator);
        }
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDescriptorPool(this Device device, DescriptorPool descriptorPool = default(DescriptorPool), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyDescriptorPool(device, descriptorPool, allocator);
        }
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void ResetDescriptorPool(this Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags = default(DescriptorPoolResetFlags))
        {
            Vk.ResetDescriptorPool(device, descriptorPool, flags);
        }
        
        public static List<DescriptorSet> AllocateDescriptorSets(this Device device, DescriptorSetAllocateInfo allocateInfo)
        {
            return Vk.AllocateDescriptorSets(device, allocateInfo);
        }
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="descriptorSets">No Auto Validity</param>
        public static void FreeDescriptorSets(this Device device, DescriptorPool descriptorPool, List<DescriptorSet> descriptorSets)
        {
            Vk.FreeDescriptorSets(device, descriptorPool, descriptorSets);
        }
        
        public static void UpdateDescriptorSets(this Device device, List<WriteDescriptorSet> descriptorWrites, List<CopyDescriptorSet> descriptorCopies)
        {
            Vk.UpdateDescriptorSets(device, descriptorWrites, descriptorCopies);
        }
        
        /// <param name="allocator">Optional</param>
        public static Framebuffer CreateFramebuffer(this Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateFramebuffer(device, createInfo, allocator);
        }
        
        /// <param name="framebuffer">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyFramebuffer(this Device device, Framebuffer framebuffer = default(Framebuffer), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyFramebuffer(device, framebuffer, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static RenderPass CreateRenderPass(this Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateRenderPass(device, createInfo, allocator);
        }
        
        /// <param name="renderPass">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyRenderPass(this Device device, RenderPass renderPass = default(RenderPass), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyRenderPass(device, renderPass, allocator);
        }
        
        public static Extent2D GetRenderAreaGranularity(this Device device, RenderPass renderPass)
        {
            return Vk.GetRenderAreaGranularity(device, renderPass);
        }
        
        /// <param name="allocator">Optional</param>
        public static CommandPool CreateCommandPool(this Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateCommandPool(device, createInfo, allocator);
        }
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyCommandPool(this Device device, CommandPool commandPool = default(CommandPool), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroyCommandPool(device, commandPool, allocator);
        }
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void ResetCommandPool(this Device device, CommandPool commandPool, CommandPoolResetFlags flags = default(CommandPoolResetFlags))
        {
            Vk.ResetCommandPool(device, commandPool, flags);
        }
        
        public static List<CommandBuffer> AllocateCommandBuffers(this Device device, CommandBufferAllocateInfo allocateInfo)
        {
            return Vk.AllocateCommandBuffers(device, allocateInfo);
        }
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="commandBuffers">No Auto Validity</param>
        public static void FreeCommandBuffers(this Device device, CommandPool commandPool, List<CommandBuffer> commandBuffers)
        {
            Vk.FreeCommandBuffers(device, commandPool, commandBuffers);
        }
        
        /// <param name="allocator">Optional</param>
        public static List<SwapchainKHR> CreateSharedSwapchainsKHR(this Device device, List<SwapchainCreateInfoKHR> createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateSharedSwapchainsKHR(device, createInfos, allocator);
        }
        
        /// <param name="allocator">Optional</param>
        public static SwapchainKHR CreateSwapchainKHR(this Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            return Vk.CreateSwapchainKHR(device, createInfo, allocator);
        }
        
        /// <param name="swapchain">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySwapchainKHR(this Device device, SwapchainKHR swapchain = default(SwapchainKHR), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            Vk.DestroySwapchainKHR(device, swapchain, allocator);
        }
        
        public static List<Image> GetSwapchainImagesKHR(this Device device, SwapchainKHR swapchain)
        {
            return Vk.GetSwapchainImagesKHR(device, swapchain);
        }
        
        /// <param name="swapchain">ExternSync</param>
        /// <param name="semaphore">ExternSync</param>
        /// <param name="fence">ExternSync</param>
        public static UInt32 AcquireNextImageKHR(this Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore = default(Semaphore), Fence fence = default(Fence))
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
        
        /// <param name="queue">ExternSync</param>
        /// <param name="fence">ExternSync</param>
        public static void Submit(this Queue queue, List<SubmitInfo> submits, Fence fence = default(Fence))
        {
            Vk.QueueSubmit(queue, submits, fence);
        }
        
        public static void WaitIdle(this Queue queue)
        {
            Vk.QueueWaitIdle(queue);
        }
        
        /// <summary>
        /// [<see cref="QueueFlags"/>: Sparse_binding] 
        /// </summary>
        /// <param name="queue">ExternSync</param>
        /// <param name="fence">ExternSync</param>
        public static void BindSparse(this Queue queue, List<BindSparseInfo> bindInfo, Fence fence = default(Fence))
        {
            Vk.QueueBindSparse(queue, bindInfo, fence);
        }
        
        /// <param name="queue">ExternSync</param>
        public static Result PresentKHR(this Queue queue, PresentInfoKHR presentInfo)
        {
            return Vk.QueuePresentKHR(queue, presentInfo);
        }
        
        #endregion
        
        #region CommandBuffer
        
        /// <param name="commandBuffer">ExternSync</param>
        public static void Begin(this CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            Vk.BeginCommandBuffer(commandBuffer, beginInfo);
        }
        
        /// <param name="commandBuffer">ExternSync</param>
        public static void End(this CommandBuffer commandBuffer)
        {
            Vk.EndCommandBuffer(commandBuffer);
        }
        
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void Reset(this CommandBuffer commandBuffer, CommandBufferResetFlags flags = default(CommandBufferResetFlags))
        {
            Vk.ResetCommandBuffer(commandBuffer, flags);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindPipeline(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            Vk.CmdBindPipeline(commandBuffer, pipelineBindPoint, pipeline);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetViewport(this CommandBuffer commandBuffer, UInt32 firstViewport, List<Viewport> viewports)
        {
            Vk.CmdSetViewport(commandBuffer, firstViewport, viewports);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetScissor(this CommandBuffer commandBuffer, UInt32 firstScissor, List<Rect2D> scissors)
        {
            Vk.CmdSetScissor(commandBuffer, firstScissor, scissors);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetLineWidth(this CommandBuffer commandBuffer, Single lineWidth)
        {
            Vk.CmdSetLineWidth(commandBuffer, lineWidth);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetDepthBias(this CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            Vk.CmdSetDepthBias(commandBuffer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetBlendConstants(this CommandBuffer commandBuffer, Single blendConstants)
        {
            Vk.CmdSetBlendConstants(commandBuffer, blendConstants);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetDepthBounds(this CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            Vk.CmdSetDepthBounds(commandBuffer, minDepthBounds, maxDepthBounds);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetStencilCompareMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            Vk.CmdSetStencilCompareMask(commandBuffer, faceMask, compareMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetStencilWriteMask(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            Vk.CmdSetStencilWriteMask(commandBuffer, faceMask, writeMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetStencilReference(this CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            Vk.CmdSetStencilReference(commandBuffer, faceMask, reference);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindDescriptorSets(this CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, List<DescriptorSet> descriptorSets, List<UInt32> dynamicOffsets)
        {
            Vk.CmdBindDescriptorSets(commandBuffer, pipelineBindPoint, layout, firstSet, descriptorSets, dynamicOffsets);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindIndexBuffer(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            Vk.CmdBindIndexBuffer(commandBuffer, buffer, offset, indexType);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindVertexBuffers(this CommandBuffer commandBuffer, UInt32 firstBinding, List<Buffer> buffers, List<DeviceSize> offsets)
        {
            Vk.CmdBindVertexBuffers(commandBuffer, firstBinding, buffers, offsets);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDraw(this CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            Vk.CmdDraw(commandBuffer, vertexCount, instanceCount, firstVertex, firstInstance);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDrawIndexed(this CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            Vk.CmdDrawIndexed(commandBuffer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDrawIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            Vk.CmdDrawIndirect(commandBuffer, buffer, offset, drawCount, stride);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDrawIndexedIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            Vk.CmdDrawIndexedIndirect(commandBuffer, buffer, offset, drawCount, stride);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDispatch(this CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            Vk.CmdDispatch(commandBuffer, x, y, z);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDispatchIndirect(this CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            Vk.CmdDispatchIndirect(commandBuffer, buffer, offset);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyBuffer(this CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, List<BufferCopy> regions)
        {
            Vk.CmdCopyBuffer(commandBuffer, srcBuffer, dstBuffer, regions);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageCopy> regions)
        {
            Vk.CmdCopyImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBlitImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageBlit> regions, Filter filter)
        {
            Vk.CmdBlitImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions, filter);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyBufferToImage(this CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, List<BufferImageCopy> regions)
        {
            Vk.CmdCopyBufferToImage(commandBuffer, srcBuffer, dstImage, dstImageLayout, regions);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyImageToBuffer(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, List<BufferImageCopy> regions)
        {
            Vk.CmdCopyImageToBuffer(commandBuffer, srcImage, srcImageLayout, dstBuffer, regions);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdUpdateBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, List<Byte> data)
        {
            Vk.CmdUpdateBuffer(commandBuffer, dstBuffer, dstOffset, data);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdFillBuffer(this CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            Vk.CmdFillBuffer(commandBuffer, dstBuffer, dstOffset, size, data);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdClearColorImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, List<ImageSubresourceRange> ranges)
        {
            Vk.CmdClearColorImage(commandBuffer, image, imageLayout, color, ranges);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdClearDepthStencilImage(this CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, List<ImageSubresourceRange> ranges)
        {
            Vk.CmdClearDepthStencilImage(commandBuffer, image, imageLayout, depthStencil, ranges);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdClearAttachments(this CommandBuffer commandBuffer, List<ClearAttachment> attachments, List<ClearRect> rects)
        {
            Vk.CmdClearAttachments(commandBuffer, attachments, rects);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdResolveImage(this CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageResolve> regions)
        {
            Vk.CmdResolveImage(commandBuffer, srcImage, srcImageLayout, dstImage, dstImageLayout, regions);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            Vk.CmdSetEvent(commandBuffer, @event, stageMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdResetEvent(this CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            Vk.CmdResetEvent(commandBuffer, @event, stageMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdWaitEvents(this CommandBuffer commandBuffer, List<Event> events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            Vk.CmdWaitEvents(commandBuffer, events, srcStageMask, dstStageMask, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="dependencyFlags">Optional</param>
        public static void CmdPipelineBarrier(this CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            Vk.CmdPipelineBarrier(commandBuffer, srcStageMask, dstStageMask, dependencyFlags, memoryBarriers, bufferMemoryBarriers, imageMemoryBarriers);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void CmdBeginQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags = default(QueryControlFlags))
        {
            Vk.CmdBeginQuery(commandBuffer, queryPool, query, flags);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdEndQuery(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            Vk.CmdEndQuery(commandBuffer, queryPool, query);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdResetQueryPool(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            Vk.CmdResetQueryPool(commandBuffer, queryPool, firstQuery, queryCount);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdWriteTimestamp(this CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            Vk.CmdWriteTimestamp(commandBuffer, pipelineStage, queryPool, query);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void CmdCopyQueryPoolResults(this CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags = default(QueryResultFlags))
        {
            Vk.CmdCopyQueryPoolResults(commandBuffer, queryPool, firstQuery, queryCount, dstBuffer, dstOffset, stride, flags);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdPushConstants(this CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, List<IntPtr> values)
        {
            Vk.CmdPushConstants(commandBuffer, layout, stageFlags, offset, values);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBeginRenderPass(this CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
        {
            Vk.CmdBeginRenderPass(commandBuffer, renderPassBegin, contents);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdNextSubpass(this CommandBuffer commandBuffer, SubpassContents contents)
        {
            Vk.CmdNextSubpass(commandBuffer, contents);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdEndRenderPass(this CommandBuffer commandBuffer)
        {
            Vk.CmdEndRenderPass(commandBuffer);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdExecuteCommands(this CommandBuffer commandBuffer, List<CommandBuffer> commandBuffers)
        {
            Vk.CmdExecuteCommands(commandBuffer, commandBuffers);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerBeginEXT(this CommandBuffer commandBuffer)
        {
            return Vk.CmdDebugMarkerBeginEXT(commandBuffer);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static void CmdDebugMarkerEndEXT(this CommandBuffer commandBuffer)
        {
            Vk.CmdDebugMarkerEndEXT(commandBuffer);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerInsertEXT(this CommandBuffer commandBuffer)
        {
            return Vk.CmdDebugMarkerInsertEXT(commandBuffer);
        }
        
        #endregion
        
    }
}
