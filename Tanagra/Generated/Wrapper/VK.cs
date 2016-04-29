using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
    using static Interop.VK;
    
    public unsafe static class VK
    {
        public static Instance CreateInstance(InstanceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var instance = new Instance();
            fixed(IntPtr* ptrInstance = &instance.NativePointer)
            {
                var result = vkCreateInstance(createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrInstance);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateInstance), result);
            }
            return instance;
        }
        
        public static void DestroyInstance(Instance instance, AllocationCallbacks allocator = null)
        {
            vkDestroyInstance(instance.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static List<PhysicalDevice> EnumeratePhysicalDevices(Instance instance)
        {
            UInt32 physicalDeviceCount;
            var result = vkEnumeratePhysicalDevices(instance.NativePointer, &physicalDeviceCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            int size = Marshal.SizeOf(typeof(IntPtr));
            var ptrPhysicalDevice = Marshal.AllocHGlobal((int)(size * physicalDeviceCount));
            result = vkEnumeratePhysicalDevices(instance.NativePointer, &physicalDeviceCount, (IntPtr*)ptrPhysicalDevice);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            var list = new List<PhysicalDevice>();
            for(var x = 0; x < physicalDeviceCount; x++)
            {
                var item = new PhysicalDevice();
                item.NativePointer = ((IntPtr*)ptrPhysicalDevice)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static PhysicalDeviceProperties GetPhysicalDeviceProperties(PhysicalDevice physicalDevice)
        {
            var properties = new PhysicalDeviceProperties();
            vkGetPhysicalDeviceProperties(physicalDevice.NativePointer, properties.NativePointer);
            return properties;
        }
        
        public static List<QueueFamilyProperties> GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice)
        {
            UInt32 queueFamilyPropertyCount;
            vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice.NativePointer, &queueFamilyPropertyCount, null);
            
            int size = Marshal.SizeOf(typeof(Interop.QueueFamilyProperties));
            var ptrQueueFamilyProperties = Marshal.AllocHGlobal((int)(size * queueFamilyPropertyCount));
            vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice.NativePointer, &queueFamilyPropertyCount, (Interop.QueueFamilyProperties*)ptrQueueFamilyProperties);
            
            var list = new List<QueueFamilyProperties>();
            for(var x = 0; x < queueFamilyPropertyCount; x++)
            {
                var item = new QueueFamilyProperties();
                item.NativePointer = &((Interop.QueueFamilyProperties*)ptrQueueFamilyProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static PhysicalDeviceMemoryProperties GetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice)
        {
            var memoryProperties = new PhysicalDeviceMemoryProperties();
            vkGetPhysicalDeviceMemoryProperties(physicalDevice.NativePointer, memoryProperties.NativePointer);
            return memoryProperties;
        }
        
        public static PhysicalDeviceFeatures GetPhysicalDeviceFeatures(PhysicalDevice physicalDevice)
        {
            var features = new PhysicalDeviceFeatures();
            vkGetPhysicalDeviceFeatures(physicalDevice.NativePointer, features.NativePointer);
            return features;
        }
        
        public static FormatProperties GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format)
        {
            var formatProperties = new FormatProperties();
            vkGetPhysicalDeviceFormatProperties(physicalDevice.NativePointer, format, formatProperties.NativePointer);
            return formatProperties;
        }
        
        public static ImageFormatProperties GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags)
        {
            var imageFormatProperties = new ImageFormatProperties();
            var result = vkGetPhysicalDeviceImageFormatProperties(physicalDevice.NativePointer, format, type, tiling, usage, flags, imageFormatProperties.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceImageFormatProperties), result);
            return imageFormatProperties;
        }
        
        public static Device CreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var device = new Device();
            fixed(IntPtr* ptrDevice = &device.NativePointer)
            {
                var result = vkCreateDevice(physicalDevice.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrDevice);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateDevice), result);
            }
            return device;
        }
        
        public static void DestroyDevice(Device device, AllocationCallbacks allocator = null)
        {
            vkDestroyDevice(device.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static List<LayerProperties> EnumerateInstanceLayerProperties()
        {
            UInt32 propertyCount;
            var result = vkEnumerateInstanceLayerProperties(&propertyCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.LayerProperties));
            var ptrLayerProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateInstanceLayerProperties(&propertyCount, (Interop.LayerProperties*)ptrLayerProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new LayerProperties();
                item.NativePointer = &((Interop.LayerProperties*)ptrLayerProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<ExtensionProperties> EnumerateInstanceExtensionProperties(String layerName)
        {
            UInt32 propertyCount;
            var result = vkEnumerateInstanceExtensionProperties(layerName, &propertyCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
            var ptrExtensionProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateInstanceExtensionProperties(layerName, &propertyCount, (Interop.ExtensionProperties*)ptrExtensionProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new ExtensionProperties();
                item.NativePointer = &((Interop.ExtensionProperties*)ptrExtensionProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<LayerProperties> EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice)
        {
            UInt32 propertyCount;
            var result = vkEnumerateDeviceLayerProperties(physicalDevice.NativePointer, &propertyCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.LayerProperties));
            var ptrLayerProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateDeviceLayerProperties(physicalDevice.NativePointer, &propertyCount, (Interop.LayerProperties*)ptrLayerProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new LayerProperties();
                item.NativePointer = &((Interop.LayerProperties*)ptrLayerProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<ExtensionProperties> EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, String layerName)
        {
            UInt32 propertyCount;
            var result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativePointer, layerName, &propertyCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
            var ptrExtensionProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativePointer, layerName, &propertyCount, (Interop.ExtensionProperties*)ptrExtensionProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new ExtensionProperties();
                item.NativePointer = &((Interop.ExtensionProperties*)ptrExtensionProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static Queue GetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex)
        {
            var queue = new Queue();
            fixed(IntPtr* ptrQueue = &queue.NativePointer)
            {
                vkGetDeviceQueue(device.NativePointer, queueFamilyIndex, queueIndex, ptrQueue);
            }
            return queue;
        }
        
        public static void QueueSubmit(Queue queue, UInt32 submitCount, SubmitInfo submits, Fence fence)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void QueueWaitIdle(Queue queue)
        {
            var result = vkQueueWaitIdle(queue.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkQueueWaitIdle), result);
        }
        
        public static void DeviceWaitIdle(Device device)
        {
            var result = vkDeviceWaitIdle(device.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkDeviceWaitIdle), result);
        }
        
        public static DeviceMemory AllocateMemory(Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator = null)
        {
            var memory = new DeviceMemory();
            fixed(IntPtr* ptrDeviceMemory = &memory.NativePointer)
            {
                var result = vkAllocateMemory(device.NativePointer, allocateInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrDeviceMemory);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkAllocateMemory), result);
            }
            return memory;
        }
        
        public static void FreeMemory(Device device, DeviceMemory memory, AllocationCallbacks allocator = null)
        {
            vkFreeMemory(device.NativePointer, memory.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static IntPtr MapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags)
        {
            var data = new IntPtr();
            var result = vkMapMemory(device.NativePointer, memory.NativePointer, offset, size, flags, &data);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkMapMemory), result);
            return data;
        }
        
        public static void UnmapMemory(Device device, DeviceMemory memory)
        {
            vkUnmapMemory(device.NativePointer, memory.NativePointer);
        }
        
        public static void FlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void InvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static DeviceSize GetDeviceMemoryCommitment(Device device, DeviceMemory memory)
        {
            var committedMemoryInBytes = new DeviceSize();
            vkGetDeviceMemoryCommitment(device.NativePointer, memory.NativePointer, &committedMemoryInBytes);
            return committedMemoryInBytes;
        }
        
        public static MemoryRequirements GetBufferMemoryRequirements(Device device, Buffer buffer)
        {
            var memoryRequirements = new MemoryRequirements();
            vkGetBufferMemoryRequirements(device.NativePointer, buffer.NativePointer, memoryRequirements.NativePointer);
            return memoryRequirements;
        }
        
        public static void BindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            var result = vkBindBufferMemory(device.NativePointer, buffer.NativePointer, memory.NativePointer, memoryOffset);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkBindBufferMemory), result);
        }
        
        public static MemoryRequirements GetImageMemoryRequirements(Device device, Image image)
        {
            var memoryRequirements = new MemoryRequirements();
            vkGetImageMemoryRequirements(device.NativePointer, image.NativePointer, memoryRequirements.NativePointer);
            return memoryRequirements;
        }
        
        public static void BindImageMemory(Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            var result = vkBindImageMemory(device.NativePointer, image.NativePointer, memory.NativePointer, memoryOffset);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkBindImageMemory), result);
        }
        
        public static List<SparseImageMemoryRequirements> GetImageSparseMemoryRequirements(Device device, Image image)
        {
            UInt32 sparseMemoryRequirementCount;
            vkGetImageSparseMemoryRequirements(device.NativePointer, image.NativePointer, &sparseMemoryRequirementCount, null);
            
            int size = Marshal.SizeOf(typeof(Interop.SparseImageMemoryRequirements));
            var ptrSparseImageMemoryRequirements = Marshal.AllocHGlobal((int)(size * sparseMemoryRequirementCount));
            vkGetImageSparseMemoryRequirements(device.NativePointer, image.NativePointer, &sparseMemoryRequirementCount, (Interop.SparseImageMemoryRequirements*)ptrSparseImageMemoryRequirements);
            
            var list = new List<SparseImageMemoryRequirements>();
            for(var x = 0; x < sparseMemoryRequirementCount; x++)
            {
                var item = new SparseImageMemoryRequirements();
                item.NativePointer = &((Interop.SparseImageMemoryRequirements*)ptrSparseImageMemoryRequirements)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<SparseImageFormatProperties> GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
        {
            UInt32 propertyCount;
            vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativePointer, format, type, samples, usage, tiling, &propertyCount, null);
            
            int size = Marshal.SizeOf(typeof(Interop.SparseImageFormatProperties));
            var ptrSparseImageFormatProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativePointer, format, type, samples, usage, tiling, &propertyCount, (Interop.SparseImageFormatProperties*)ptrSparseImageFormatProperties);
            
            var list = new List<SparseImageFormatProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new SparseImageFormatProperties();
                item.NativePointer = &((Interop.SparseImageFormatProperties*)ptrSparseImageFormatProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static void QueueBindSparse(Queue queue, UInt32 bindInfoCount, BindSparseInfo bindInfo, Fence fence)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static Fence CreateFence(Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var fence = new Fence();
            fixed(IntPtr* ptrFence = &fence.NativePointer)
            {
                var result = vkCreateFence(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrFence);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateFence), result);
            }
            return fence;
        }
        
        public static void DestroyFence(Device device, Fence fence, AllocationCallbacks allocator = null)
        {
            vkDestroyFence(device.NativePointer, fence.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void ResetFences(Device device, UInt32 fenceCount, Fence fences)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void GetFenceStatus(Device device, Fence fence)
        {
            var result = vkGetFenceStatus(device.NativePointer, fence.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetFenceStatus), result);
        }
        
        public static void WaitForFences(Device device, UInt32 fenceCount, Fence fences, Boolean waitAll, UInt64 timeout)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static Semaphore CreateSemaphore(Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var semaphore = new Semaphore();
            fixed(IntPtr* ptrSemaphore = &semaphore.NativePointer)
            {
                var result = vkCreateSemaphore(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSemaphore);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateSemaphore), result);
            }
            return semaphore;
        }
        
        public static void DestroySemaphore(Device device, Semaphore semaphore, AllocationCallbacks allocator = null)
        {
            vkDestroySemaphore(device.NativePointer, semaphore.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static Event CreateEvent(Device device, EventCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var @event = new Event();
            fixed(IntPtr* ptrEvent = &@event.NativePointer)
            {
                var result = vkCreateEvent(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrEvent);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateEvent), result);
            }
            return @event;
        }
        
        public static void DestroyEvent(Device device, Event @event, AllocationCallbacks allocator = null)
        {
            vkDestroyEvent(device.NativePointer, @event.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void GetEventStatus(Device device, Event @event)
        {
            var result = vkGetEventStatus(device.NativePointer, @event.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetEventStatus), result);
        }
        
        public static void SetEvent(Device device, Event @event)
        {
            var result = vkSetEvent(device.NativePointer, @event.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkSetEvent), result);
        }
        
        public static void ResetEvent(Device device, Event @event)
        {
            var result = vkResetEvent(device.NativePointer, @event.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetEvent), result);
        }
        
        public static QueryPool CreateQueryPool(Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var queryPool = new QueryPool();
            fixed(IntPtr* ptrQueryPool = &queryPool.NativePointer)
            {
                var result = vkCreateQueryPool(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrQueryPool);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateQueryPool), result);
            }
            return queryPool;
        }
        
        public static void DestroyQueryPool(Device device, QueryPool queryPool, AllocationCallbacks allocator = null)
        {
            vkDestroyQueryPool(device.NativePointer, queryPool.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr data, DeviceSize stride, QueryResultFlags flags)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static Buffer CreateBuffer(Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var buffer = new Buffer();
            fixed(IntPtr* ptrBuffer = &buffer.NativePointer)
            {
                var result = vkCreateBuffer(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrBuffer);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateBuffer), result);
            }
            return buffer;
        }
        
        public static void DestroyBuffer(Device device, Buffer buffer, AllocationCallbacks allocator = null)
        {
            vkDestroyBuffer(device.NativePointer, buffer.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static BufferView CreateBufferView(Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var view = new BufferView();
            fixed(IntPtr* ptrBufferView = &view.NativePointer)
            {
                var result = vkCreateBufferView(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrBufferView);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateBufferView), result);
            }
            return view;
        }
        
        public static void DestroyBufferView(Device device, BufferView bufferView, AllocationCallbacks allocator = null)
        {
            vkDestroyBufferView(device.NativePointer, bufferView.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static Image CreateImage(Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var image = new Image();
            fixed(IntPtr* ptrImage = &image.NativePointer)
            {
                var result = vkCreateImage(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrImage);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateImage), result);
            }
            return image;
        }
        
        public static void DestroyImage(Device device, Image image, AllocationCallbacks allocator = null)
        {
            vkDestroyImage(device.NativePointer, image.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static SubresourceLayout GetImageSubresourceLayout(Device device, Image image, ImageSubresource subresource)
        {
            var layout = new SubresourceLayout();
            vkGetImageSubresourceLayout(device.NativePointer, image.NativePointer, subresource.NativePointer, layout.NativePointer);
            return layout;
        }
        
        public static ImageView CreateImageView(Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var view = new ImageView();
            fixed(IntPtr* ptrImageView = &view.NativePointer)
            {
                var result = vkCreateImageView(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrImageView);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateImageView), result);
            }
            return view;
        }
        
        public static void DestroyImageView(Device device, ImageView imageView, AllocationCallbacks allocator = null)
        {
            vkDestroyImageView(device.NativePointer, imageView.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static ShaderModule CreateShaderModule(Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var shaderModule = new ShaderModule();
            fixed(IntPtr* ptrShaderModule = &shaderModule.NativePointer)
            {
                var result = vkCreateShaderModule(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrShaderModule);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateShaderModule), result);
            }
            return shaderModule;
        }
        
        public static void DestroyShaderModule(Device device, ShaderModule shaderModule, AllocationCallbacks allocator = null)
        {
            vkDestroyShaderModule(device.NativePointer, shaderModule.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static PipelineCache CreatePipelineCache(Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var pipelineCache = new PipelineCache();
            fixed(IntPtr* ptrPipelineCache = &pipelineCache.NativePointer)
            {
                var result = vkCreatePipelineCache(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrPipelineCache);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreatePipelineCache), result);
            }
            return pipelineCache;
        }
        
        public static void DestroyPipelineCache(Device device, PipelineCache pipelineCache, AllocationCallbacks allocator = null)
        {
            vkDestroyPipelineCache(device.NativePointer, pipelineCache.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache srcCaches)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void DestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks allocator = null)
        {
            vkDestroyPipeline(device.NativePointer, pipeline.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static PipelineLayout CreatePipelineLayout(Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var pipelineLayout = new PipelineLayout();
            fixed(IntPtr* ptrPipelineLayout = &pipelineLayout.NativePointer)
            {
                var result = vkCreatePipelineLayout(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrPipelineLayout);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreatePipelineLayout), result);
            }
            return pipelineLayout;
        }
        
        public static void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, AllocationCallbacks allocator = null)
        {
            vkDestroyPipelineLayout(device.NativePointer, pipelineLayout.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static Sampler CreateSampler(Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var sampler = new Sampler();
            fixed(IntPtr* ptrSampler = &sampler.NativePointer)
            {
                var result = vkCreateSampler(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSampler);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateSampler), result);
            }
            return sampler;
        }
        
        public static void DestroySampler(Device device, Sampler sampler, AllocationCallbacks allocator = null)
        {
            vkDestroySampler(device.NativePointer, sampler.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static DescriptorSetLayout CreateDescriptorSetLayout(Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var setLayout = new DescriptorSetLayout();
            fixed(IntPtr* ptrDescriptorSetLayout = &setLayout.NativePointer)
            {
                var result = vkCreateDescriptorSetLayout(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrDescriptorSetLayout);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateDescriptorSetLayout), result);
            }
            return setLayout;
        }
        
        public static void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks allocator = null)
        {
            vkDestroyDescriptorSetLayout(device.NativePointer, descriptorSetLayout.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static DescriptorPool CreateDescriptorPool(Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var descriptorPool = new DescriptorPool();
            fixed(IntPtr* ptrDescriptorPool = &descriptorPool.NativePointer)
            {
                var result = vkCreateDescriptorPool(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrDescriptorPool);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateDescriptorPool), result);
            }
            return descriptorPool;
        }
        
        public static void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool, AllocationCallbacks allocator = null)
        {
            vkDestroyDescriptorPool(device.NativePointer, descriptorPool.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void ResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            var result = vkResetDescriptorPool(device.NativePointer, descriptorPool.NativePointer, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetDescriptorPool), result);
        }
        
        public static void AllocateDescriptorSets(Device device, DescriptorSetAllocateInfo allocateInfo, DescriptorSet descriptorSets)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet descriptorSets)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, WriteDescriptorSet descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet descriptorCopies)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static Framebuffer CreateFramebuffer(Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var framebuffer = new Framebuffer();
            fixed(IntPtr* ptrFramebuffer = &framebuffer.NativePointer)
            {
                var result = vkCreateFramebuffer(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrFramebuffer);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateFramebuffer), result);
            }
            return framebuffer;
        }
        
        public static void DestroyFramebuffer(Device device, Framebuffer framebuffer, AllocationCallbacks allocator = null)
        {
            vkDestroyFramebuffer(device.NativePointer, framebuffer.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static RenderPass CreateRenderPass(Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var renderPass = new RenderPass();
            fixed(IntPtr* ptrRenderPass = &renderPass.NativePointer)
            {
                var result = vkCreateRenderPass(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrRenderPass);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateRenderPass), result);
            }
            return renderPass;
        }
        
        public static void DestroyRenderPass(Device device, RenderPass renderPass, AllocationCallbacks allocator = null)
        {
            vkDestroyRenderPass(device.NativePointer, renderPass.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static Extent2D GetRenderAreaGranularity(Device device, RenderPass renderPass)
        {
            var granularity = new Extent2D();
            vkGetRenderAreaGranularity(device.NativePointer, renderPass.NativePointer, granularity.NativePointer);
            return granularity;
        }
        
        public static CommandPool CreateCommandPool(Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var commandPool = new CommandPool();
            fixed(IntPtr* ptrCommandPool = &commandPool.NativePointer)
            {
                var result = vkCreateCommandPool(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrCommandPool);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateCommandPool), result);
            }
            return commandPool;
        }
        
        public static void DestroyCommandPool(Device device, CommandPool commandPool, AllocationCallbacks allocator = null)
        {
            vkDestroyCommandPool(device.NativePointer, commandPool.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            var result = vkResetCommandPool(device.NativePointer, commandPool.NativePointer, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetCommandPool), result);
        }
        
        public static CommandBuffer AllocateCommandBuffers(Device device, CommandBufferAllocateInfo allocateInfo)
        {
            CommandBuffer commandBuffer = new CommandBuffer();
            fixed (IntPtr* ptrCommandPool = &commandBuffer.NativePointer)
            {
                var result = vkAllocateCommandBuffers(device.NativePointer, allocateInfo.NativePointer, ptrCommandPool);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateCommandPool), result);
            }
            return commandBuffer;
        }
        
        public static void FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void BeginCommandBuffer(CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            var result = vkBeginCommandBuffer(commandBuffer.NativePointer, beginInfo.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkBeginCommandBuffer), result);
        }
        
        public static void EndCommandBuffer(CommandBuffer commandBuffer)
        {
            var result = vkEndCommandBuffer(commandBuffer.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEndCommandBuffer), result);
        }
        
        public static void ResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            var result = vkResetCommandBuffer(commandBuffer.NativePointer, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetCommandBuffer), result);
        }
        
        public static void CmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            vkCmdBindPipeline(commandBuffer.NativePointer, pipelineBindPoint, pipeline.NativePointer);
        }
        
        public static void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport viewports)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D scissors)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdSetLineWidth(CommandBuffer commandBuffer, Single lineWidth)
        {
            vkCmdSetLineWidth(commandBuffer.NativePointer, lineWidth);
        }
        
        public static void CmdSetDepthBias(CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            vkCmdSetDepthBias(commandBuffer.NativePointer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        }
        
        public static void CmdSetBlendConstants(CommandBuffer commandBuffer, Single blendConstants)
        {
            vkCmdSetBlendConstants(commandBuffer.NativePointer, blendConstants);
        }
        
        public static void CmdSetDepthBounds(CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            vkCmdSetDepthBounds(commandBuffer.NativePointer, minDepthBounds, maxDepthBounds);
        }
        
        public static void CmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            vkCmdSetStencilCompareMask(commandBuffer.NativePointer, faceMask, compareMask);
        }
        
        public static void CmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            vkCmdSetStencilWriteMask(commandBuffer.NativePointer, faceMask, writeMask);
        }
        
        public static void CmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            vkCmdSetStencilReference(commandBuffer.NativePointer, faceMask, reference);
        }
        
        public static void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, DescriptorSet descriptorSets, UInt32 dynamicOffsetCount, UInt32 dynamicOffsets)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            vkCmdBindIndexBuffer(commandBuffer.NativePointer, buffer.NativePointer, offset, indexType);
        }
        
        public static void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, Buffer buffers, DeviceSize offsets)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            vkCmdDraw(commandBuffer.NativePointer, vertexCount, instanceCount, firstVertex, firstInstance);
        }
        
        public static void CmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            vkCmdDrawIndexed(commandBuffer.NativePointer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        }
        
        public static void CmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            vkCmdDrawIndirect(commandBuffer.NativePointer, buffer.NativePointer, offset, drawCount, stride);
        }
        
        public static void CmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            vkCmdDrawIndexedIndirect(commandBuffer.NativePointer, buffer.NativePointer, offset, drawCount, stride);
        }
        
        public static void CmdDispatch(CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            vkCmdDispatch(commandBuffer.NativePointer, x, y, z);
        }
        
        public static void CmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            vkCmdDispatchIndirect(commandBuffer.NativePointer, buffer.NativePointer, offset);
        }
        
        public static void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy regions)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy regions)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit regions, Filter filter)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy regions)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy regions)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32 data)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            vkCmdFillBuffer(commandBuffer.NativePointer, dstBuffer.NativePointer, dstOffset, size, data);
        }
        
        public static void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ClearAttachment attachments, UInt32 rectCount, ClearRect rects)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve regions)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdSetEvent(commandBuffer.NativePointer, @event.NativePointer, stageMask);
        }
        
        public static void CmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdResetEvent(commandBuffer.NativePointer, @event.NativePointer, stageMask);
        }
        
        public static void CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, Event events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags)
        {
            vkCmdBeginQuery(commandBuffer.NativePointer, queryPool.NativePointer, query, flags);
        }
        
        public static void CmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            vkCmdEndQuery(commandBuffer.NativePointer, queryPool.NativePointer, query);
        }
        
        public static void CmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            vkCmdResetQueryPool(commandBuffer.NativePointer, queryPool.NativePointer, firstQuery, queryCount);
        }
        
        public static void CmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            vkCmdWriteTimestamp(commandBuffer.NativePointer, pipelineStage, queryPool.NativePointer, query);
        }
        
        public static void CmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
        {
            vkCmdCopyQueryPoolResults(commandBuffer.NativePointer, queryPool.NativePointer, firstQuery, queryCount, dstBuffer.NativePointer, dstOffset, stride, flags);
        }
        
        public static void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr values)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static void CmdBeginRenderPass(CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
        {
            vkCmdBeginRenderPass(commandBuffer.NativePointer, renderPassBegin.NativePointer, contents);
        }
        
        public static void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents)
        {
            vkCmdNextSubpass(commandBuffer.NativePointer, contents);
        }
        
        public static void CmdEndRenderPass(CommandBuffer commandBuffer)
        {
            vkCmdEndRenderPass(commandBuffer.NativePointer);
        }
        
        public static void CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static SurfaceKHR CreateAndroidSurfaceKHR(Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateAndroidSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateAndroidSurfaceKHR), result);
            }
            return surface;
        }
        
        public static List<DisplayPropertiesKHR> GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice)
        {
            UInt32 propertyCount;
            var result = vkGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice.NativePointer, &propertyCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPropertiesKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.DisplayPropertiesKHR));
            var ptrDisplayPropertiesKHR = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice.NativePointer, &propertyCount, (Interop.DisplayPropertiesKHR*)ptrDisplayPropertiesKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPropertiesKHR), result);
            
            var list = new List<DisplayPropertiesKHR>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new DisplayPropertiesKHR();
                item.NativePointer = &((Interop.DisplayPropertiesKHR*)ptrDisplayPropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayPlanePropertiesKHR> GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice)
        {
            UInt32 propertyCount;
            var result = vkGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice.NativePointer, &propertyCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPlanePropertiesKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.DisplayPlanePropertiesKHR));
            var ptrDisplayPlanePropertiesKHR = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice.NativePointer, &propertyCount, (Interop.DisplayPlanePropertiesKHR*)ptrDisplayPlanePropertiesKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPlanePropertiesKHR), result);
            
            var list = new List<DisplayPlanePropertiesKHR>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new DisplayPlanePropertiesKHR();
                item.NativePointer = &((Interop.DisplayPlanePropertiesKHR*)ptrDisplayPlanePropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayKHR> GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex)
        {
            UInt32 displayCount;
            var result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativePointer, planeIndex, &displayCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            int size = Marshal.SizeOf(typeof(IntPtr));
            var ptrDisplayKHR = Marshal.AllocHGlobal((int)(size * displayCount));
            result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativePointer, planeIndex, &displayCount, (IntPtr*)ptrDisplayKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            var list = new List<DisplayKHR>();
            for(var x = 0; x < displayCount; x++)
            {
                var item = new DisplayKHR();
                item.NativePointer = ((IntPtr*)ptrDisplayKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayModePropertiesKHR> GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display)
        {
            UInt32 propertyCount;
            var result = vkGetDisplayModePropertiesKHR(physicalDevice.NativePointer, display.NativePointer, &propertyCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.DisplayModePropertiesKHR));
            var ptrDisplayModePropertiesKHR = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkGetDisplayModePropertiesKHR(physicalDevice.NativePointer, display.NativePointer, &propertyCount, (Interop.DisplayModePropertiesKHR*)ptrDisplayModePropertiesKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            var list = new List<DisplayModePropertiesKHR>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new DisplayModePropertiesKHR();
                item.NativePointer = &((Interop.DisplayModePropertiesKHR*)ptrDisplayModePropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static DisplayModeKHR CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var mode = new DisplayModeKHR();
            fixed(IntPtr* ptrDisplayModeKHR = &mode.NativePointer)
            {
                var result = vkCreateDisplayModeKHR(physicalDevice.NativePointer, display.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrDisplayModeKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateDisplayModeKHR), result);
            }
            return mode;
        }
        
        public static DisplayPlaneCapabilitiesKHR GetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex)
        {
            var capabilities = new DisplayPlaneCapabilitiesKHR();
            var result = vkGetDisplayPlaneCapabilitiesKHR(physicalDevice.NativePointer, mode.NativePointer, planeIndex, capabilities.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneCapabilitiesKHR), result);
            return capabilities;
        }
        
        public static SurfaceKHR CreateDisplayPlaneSurfaceKHR(Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateDisplayPlaneSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateDisplayPlaneSurfaceKHR), result);
            }
            return surface;
        }
        
        public static void CreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR createInfos, AllocationCallbacks allocator, SwapchainKHR swapchains)
        {
            // hasArrayArguments
            throw new NotImplementedException();
        }
        
        public static SurfaceKHR CreateMirSurfaceKHR(Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateMirSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateMirSurfaceKHR), result);
            }
            return surface;
        }
        
        public static IntPtr GetPhysicalDeviceMirPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            var connection = new IntPtr();
            vkGetPhysicalDeviceMirPresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, &connection);
            return connection;
        }
        
        public static void DestroySurfaceKHR(Instance instance, SurfaceKHR surface, AllocationCallbacks allocator = null)
        {
            vkDestroySurfaceKHR(instance.NativePointer, surface.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static Boolean GetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface)
        {
            var supported = new Boolean();
            var result = vkGetPhysicalDeviceSurfaceSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, surface.NativePointer, &supported);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceSupportKHR), result);
            return supported;
        }
        
        public static SurfaceCapabilitiesKHR GetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            var surfaceCapabilities = new SurfaceCapabilitiesKHR();
            var result = vkGetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice.NativePointer, surface.NativePointer, surfaceCapabilities.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceCapabilitiesKHR), result);
            return surfaceCapabilities;
        }
        
        public static List<SurfaceFormatKHR> GetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            UInt32 surfaceFormatCount;
            var result = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice.NativePointer, surface.NativePointer, &surfaceFormatCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceFormatsKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.SurfaceFormatKHR));
            var ptrSurfaceFormatKHR = Marshal.AllocHGlobal((int)(size * surfaceFormatCount));
            result = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice.NativePointer, surface.NativePointer, &surfaceFormatCount, (Interop.SurfaceFormatKHR*)ptrSurfaceFormatKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceFormatsKHR), result);
            
            var list = new List<SurfaceFormatKHR>();
            for(var x = 0; x < surfaceFormatCount; x++)
            {
                var item = new SurfaceFormatKHR();
                item.NativePointer = &((Interop.SurfaceFormatKHR*)ptrSurfaceFormatKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static SwapchainKHR CreateSwapchainKHR(Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var swapchain = new SwapchainKHR();
            fixed(IntPtr* ptrSwapchainKHR = &swapchain.NativePointer)
            {
                var result = vkCreateSwapchainKHR(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSwapchainKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateSwapchainKHR), result);
            }
            return swapchain;
        }
        
        public static void DestroySwapchainKHR(Device device, SwapchainKHR swapchain, AllocationCallbacks allocator = null)
        {
            vkDestroySwapchainKHR(device.NativePointer, swapchain.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static List<Image> GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain)
        {
            UInt32 swapchainImageCount;
            var result = vkGetSwapchainImagesKHR(device.NativePointer, swapchain.NativePointer, &swapchainImageCount, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            int size = Marshal.SizeOf(typeof(IntPtr));
            var ptrImage = Marshal.AllocHGlobal((int)(size * swapchainImageCount));
            result = vkGetSwapchainImagesKHR(device.NativePointer, swapchain.NativePointer, &swapchainImageCount, (IntPtr*)ptrImage);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            var list = new List<Image>();
            for(var x = 0; x < swapchainImageCount; x++)
            {
                var item = new Image();
                item.NativePointer = ((IntPtr*)ptrImage)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static UInt32 AcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence)
        {
            var imageIndex = new UInt32();
            var result = vkAcquireNextImageKHR(device.NativePointer, swapchain.NativePointer, timeout, semaphore.NativePointer, fence.NativePointer, &imageIndex);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkAcquireNextImageKHR), result);
            return imageIndex;
        }
        
        public static void QueuePresentKHR(Queue queue, PresentInfoKHR presentInfo)
        {
            var result = vkQueuePresentKHR(queue.NativePointer, presentInfo.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkQueuePresentKHR), result);
        }
        
        public static SurfaceKHR CreateWaylandSurfaceKHR(Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateWaylandSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateWaylandSurfaceKHR), result);
            }
            return surface;
        }
        
        public static IntPtr GetPhysicalDeviceWaylandPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            var display = new IntPtr();
            vkGetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, &display);
            return display;
        }
        
        public static SurfaceKHR CreateWin32SurfaceKHR(Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateWin32SurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateWin32SurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            var result = vkGetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex);
            return result;
        }
        
        public static SurfaceKHR CreateXlibSurfaceKHR(Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateXlibSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateXlibSurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceXlibPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr dpy, IntPtr visualID)
        {
            var result = vkGetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, &dpy, visualID);
            return result;
        }
        
        public static SurfaceKHR CreateXcbSurfaceKHR(Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateXcbSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateXcbSurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceXcbPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr connection, IntPtr visual_id)
        {
            var result = vkGetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, &connection, visual_id);
            return result;
        }
        
        public static DebugReportCallbackEXT CreateDebugReportCallbackEXT(Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator = null)
        {
            var callback = new DebugReportCallbackEXT();
            fixed(IntPtr* ptrDebugReportCallbackEXT = &callback.NativePointer)
            {
                var result = vkCreateDebugReportCallbackEXT(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrDebugReportCallbackEXT);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateDebugReportCallbackEXT), result);
            }
            return callback;
        }
        
        public static void DestroyDebugReportCallbackEXT(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator = null)
        {
            vkDestroyDebugReportCallbackEXT(instance.NativePointer, callback.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void DebugReportMessageEXT(Instance instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, String layerPrefix, String message)
        {
            vkDebugReportMessageEXT(instance.NativePointer, flags, objectType, @object, location, messageCode, layerPrefix, message);
        }
        
    }
}
