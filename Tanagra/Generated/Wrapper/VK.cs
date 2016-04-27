using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Vulkan
{
    using static Interop.VK;
    
    public unsafe static class VK
    {
        public static Instance CreateInstance(InstanceCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Instance instance = new Instance();
            fixed(IntPtr* ptrInstance = &instance.NativeHandle)
            {
                var result = vkCreateInstance(createInfo.NativeHandle, allocator.NativeHandle, ptrInstance);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateInstance), result);
            }
            return instance;
        }
        
        public static void DestroyInstance(Instance instance, AllocationCallbacks allocator)
        {
            vkDestroyInstance(instance.NativeHandle, allocator.NativeHandle);
        }
        
        public static List<PhysicalDevice> EnumeratePhysicalDevices(Instance instance)
        {
            UInt32 physicalDeviceCount;
            var result = vkEnumeratePhysicalDevices(instance.NativeHandle, &physicalDeviceCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            int size = Marshal.SizeOf(typeof(IntPtr));
            var ptrPhysicalDevice = Marshal.AllocHGlobal((int)(size * physicalDeviceCount));
            result = vkEnumeratePhysicalDevices(instance.NativeHandle, &physicalDeviceCount, (IntPtr*)ptrPhysicalDevice);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            var list = new List<PhysicalDevice>();
            for(var x = 0; x < physicalDeviceCount; x++)
            {
                var item = new PhysicalDevice();
                item.NativeHandle = ((IntPtr*)ptrPhysicalDevice)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static PFN_vkVoidFunction GetDeviceProcAddr(Device device, String name)
        {
            vkGetDeviceProcAddr(device.NativeHandle, name);
            throw new NotImplementedException();
        }
        
        public static PFN_vkVoidFunction GetInstanceProcAddr(Instance instance, String name)
        {
            vkGetInstanceProcAddr(instance.NativeHandle, name);
            throw new NotImplementedException();
        }
        
        public static void GetPhysicalDeviceProperties(PhysicalDevice physicalDevice, PhysicalDeviceProperties properties)
        {
            vkGetPhysicalDeviceProperties(physicalDevice.NativeHandle, properties.NativeHandle);
        }
        
        public static List<QueueFamilyProperties> GetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice)
        {
            UInt32 queueFamilyPropertyCount;
            vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice.NativeHandle, &queueFamilyPropertyCount, null);
            
            int size = Marshal.SizeOf(typeof(Interop.QueueFamilyProperties));
            var ptrQueueFamilyProperties = Marshal.AllocHGlobal((int)(size * queueFamilyPropertyCount));
            vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice.NativeHandle, &queueFamilyPropertyCount, (Interop.QueueFamilyProperties*)ptrQueueFamilyProperties);
            
            var list = new List<QueueFamilyProperties>();
            for(var x = 0; x < queueFamilyPropertyCount; x++)
            {
                var item = new QueueFamilyProperties();
                item.NativeHandle = &((Interop.QueueFamilyProperties*)ptrQueueFamilyProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static void GetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, PhysicalDeviceMemoryProperties memoryProperties)
        {
            vkGetPhysicalDeviceMemoryProperties(physicalDevice.NativeHandle, memoryProperties.NativeHandle);
        }
        
        public static void GetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, PhysicalDeviceFeatures features)
        {
            vkGetPhysicalDeviceFeatures(physicalDevice.NativeHandle, features.NativeHandle);
        }
        
        public static void GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, FormatProperties formatProperties)
        {
            vkGetPhysicalDeviceFormatProperties(physicalDevice.NativeHandle, format, formatProperties.NativeHandle);
        }
        
        public static void GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties imageFormatProperties)
        {
            var result = vkGetPhysicalDeviceImageFormatProperties(physicalDevice.NativeHandle, format, type, tiling, usage, flags, imageFormatProperties.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceImageFormatProperties), result);
        }
        
        public static Device CreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Device device = new Device();
            fixed(IntPtr* ptrDevice = &device.NativeHandle)
            {
                var result = vkCreateDevice(physicalDevice.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrDevice);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateDevice), result);
            }
            return device;
        }
        
        public static void DestroyDevice(Device device, AllocationCallbacks allocator)
        {
            vkDestroyDevice(device.NativeHandle, allocator.NativeHandle);
        }
        
        public static List<LayerProperties> EnumerateInstanceLayerProperties()
        {
            UInt32 propertyCount;
            var result = vkEnumerateInstanceLayerProperties(&propertyCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.LayerProperties));
            var ptrLayerProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateInstanceLayerProperties(&propertyCount, (Interop.LayerProperties*)ptrLayerProperties);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new LayerProperties();
                item.NativeHandle = &((Interop.LayerProperties*)ptrLayerProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<ExtensionProperties> EnumerateInstanceExtensionProperties(String layerName)
        {
            UInt32 propertyCount;
            var result = vkEnumerateInstanceExtensionProperties(layerName, &propertyCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
            var ptrExtensionProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateInstanceExtensionProperties(layerName, &propertyCount, (Interop.ExtensionProperties*)ptrExtensionProperties);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new ExtensionProperties();
                item.NativeHandle = &((Interop.ExtensionProperties*)ptrExtensionProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<LayerProperties> EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice)
        {
            UInt32 propertyCount;
            var result = vkEnumerateDeviceLayerProperties(physicalDevice.NativeHandle, &propertyCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.LayerProperties));
            var ptrLayerProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateDeviceLayerProperties(physicalDevice.NativeHandle, &propertyCount, (Interop.LayerProperties*)ptrLayerProperties);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new LayerProperties();
                item.NativeHandle = &((Interop.LayerProperties*)ptrLayerProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<ExtensionProperties> EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, String layerName)
        {
            UInt32 propertyCount;
            var result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativeHandle, layerName, &propertyCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            int size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
            var ptrExtensionProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativeHandle, layerName, &propertyCount, (Interop.ExtensionProperties*)ptrExtensionProperties);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new ExtensionProperties();
                item.NativeHandle = &((Interop.ExtensionProperties*)ptrExtensionProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static Queue GetDeviceQueue(Device device, UInt32 queueFamilyIndex, UInt32 queueIndex)
        {
            Queue queue = new Queue();
            fixed(IntPtr* ptrQueue = &queue.NativeHandle)
            {
                vkGetDeviceQueue(device.NativeHandle, queueFamilyIndex, queueIndex, ptrQueue);
            }
            return queue;
        }
        
        public static void QueueSubmit(Queue queue, UInt32 submitCount, SubmitInfo submits, Fence fence)
        {
            var result = vkQueueSubmit(queue.NativeHandle, submitCount, submits.NativeHandle, fence.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkQueueSubmit), result);
        }
        
        public static void QueueWaitIdle(Queue queue)
        {
            var result = vkQueueWaitIdle(queue.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkQueueWaitIdle), result);
        }
        
        public static void DeviceWaitIdle(Device device)
        {
            var result = vkDeviceWaitIdle(device.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkDeviceWaitIdle), result);
        }
        
        public static DeviceMemory AllocateMemory(Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator)
        {
            DeviceMemory memory = new DeviceMemory();
            fixed(IntPtr* ptrDeviceMemory = &memory.NativeHandle)
            {
                var result = vkAllocateMemory(device.NativeHandle, allocateInfo.NativeHandle, allocator.NativeHandle, ptrDeviceMemory);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkAllocateMemory), result);
            }
            return memory;
        }
        
        public static void FreeMemory(Device device, DeviceMemory memory, AllocationCallbacks allocator)
        {
            vkFreeMemory(device.NativeHandle, memory.NativeHandle, allocator.NativeHandle);
        }
        
        public static void MapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags, IntPtr data)
        {
            var result = vkMapMemory(device.NativeHandle, memory.NativeHandle, offset.NativeHandle, size.NativeHandle, flags, data);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkMapMemory), result);
        }
        
        public static void UnmapMemory(Device device, DeviceMemory memory)
        {
            vkUnmapMemory(device.NativeHandle, memory.NativeHandle);
        }
        
        public static void FlushMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            var result = vkFlushMappedMemoryRanges(device.NativeHandle, memoryRangeCount, memoryRanges.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkFlushMappedMemoryRanges), result);
        }
        
        public static void InvalidateMappedMemoryRanges(Device device, UInt32 memoryRangeCount, MappedMemoryRange memoryRanges)
        {
            var result = vkInvalidateMappedMemoryRanges(device.NativeHandle, memoryRangeCount, memoryRanges.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkInvalidateMappedMemoryRanges), result);
        }
        
        public static void GetDeviceMemoryCommitment(Device device, DeviceMemory memory, DeviceSize committedMemoryInBytes)
        {
            vkGetDeviceMemoryCommitment(device.NativeHandle, memory.NativeHandle, committedMemoryInBytes.NativeHandle);
        }
        
        public static void GetBufferMemoryRequirements(Device device, Buffer buffer, MemoryRequirements memoryRequirements)
        {
            vkGetBufferMemoryRequirements(device.NativeHandle, buffer.NativeHandle, memoryRequirements.NativeHandle);
        }
        
        public static void BindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            var result = vkBindBufferMemory(device.NativeHandle, buffer.NativeHandle, memory.NativeHandle, memoryOffset.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkBindBufferMemory), result);
        }
        
        public static void GetImageMemoryRequirements(Device device, Image image, MemoryRequirements memoryRequirements)
        {
            vkGetImageMemoryRequirements(device.NativeHandle, image.NativeHandle, memoryRequirements.NativeHandle);
        }
        
        public static void BindImageMemory(Device device, Image image, DeviceMemory memory, DeviceSize memoryOffset)
        {
            var result = vkBindImageMemory(device.NativeHandle, image.NativeHandle, memory.NativeHandle, memoryOffset.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkBindImageMemory), result);
        }
        
        public static List<SparseImageMemoryRequirements> GetImageSparseMemoryRequirements(Device device, Image image)
        {
            UInt32 sparseMemoryRequirementCount;
            vkGetImageSparseMemoryRequirements(device.NativeHandle, image.NativeHandle, &sparseMemoryRequirementCount, null);
            
            int size = Marshal.SizeOf(typeof(Interop.SparseImageMemoryRequirements));
            var ptrSparseImageMemoryRequirements = Marshal.AllocHGlobal((int)(size * sparseMemoryRequirementCount));
            vkGetImageSparseMemoryRequirements(device.NativeHandle, image.NativeHandle, &sparseMemoryRequirementCount, (Interop.SparseImageMemoryRequirements*)ptrSparseImageMemoryRequirements);
            
            var list = new List<SparseImageMemoryRequirements>();
            for(var x = 0; x < sparseMemoryRequirementCount; x++)
            {
                var item = new SparseImageMemoryRequirements();
                item.NativeHandle = &((Interop.SparseImageMemoryRequirements*)ptrSparseImageMemoryRequirements)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<SparseImageFormatProperties> GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
        {
            UInt32 propertyCount;
            vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativeHandle, format, type, samples, usage, tiling, &propertyCount, null);
            
            int size = Marshal.SizeOf(typeof(Interop.SparseImageFormatProperties));
            var ptrSparseImageFormatProperties = Marshal.AllocHGlobal((int)(size * propertyCount));
            vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativeHandle, format, type, samples, usage, tiling, &propertyCount, (Interop.SparseImageFormatProperties*)ptrSparseImageFormatProperties);
            
            var list = new List<SparseImageFormatProperties>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new SparseImageFormatProperties();
                item.NativeHandle = &((Interop.SparseImageFormatProperties*)ptrSparseImageFormatProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static void QueueBindSparse(Queue queue, UInt32 bindInfoCount, BindSparseInfo bindInfo, Fence fence)
        {
            var result = vkQueueBindSparse(queue.NativeHandle, bindInfoCount, bindInfo.NativeHandle, fence.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkQueueBindSparse), result);
        }
        
        public static Fence CreateFence(Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Fence fence = new Fence();
            fixed(IntPtr* ptrFence = &fence.NativeHandle)
            {
                var result = vkCreateFence(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrFence);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateFence), result);
            }
            return fence;
        }
        
        public static void DestroyFence(Device device, Fence fence, AllocationCallbacks allocator)
        {
            vkDestroyFence(device.NativeHandle, fence.NativeHandle, allocator.NativeHandle);
        }
        
        public static void ResetFences(Device device, UInt32 fenceCount, Fence fences)
        {
            var result = vkResetFences(device.NativeHandle, fenceCount, fences.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkResetFences), result);
        }
        
        public static void GetFenceStatus(Device device, Fence fence)
        {
            var result = vkGetFenceStatus(device.NativeHandle, fence.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetFenceStatus), result);
        }
        
        public static void WaitForFences(Device device, UInt32 fenceCount, Fence fences, Boolean waitAll, UInt64 timeout)
        {
            var result = vkWaitForFences(device.NativeHandle, fenceCount, fences.NativeHandle, waitAll, timeout);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkWaitForFences), result);
        }
        
        public static Semaphore CreateSemaphore(Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Semaphore semaphore = new Semaphore();
            fixed(IntPtr* ptrSemaphore = &semaphore.NativeHandle)
            {
                var result = vkCreateSemaphore(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSemaphore);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateSemaphore), result);
            }
            return semaphore;
        }
        
        public static void DestroySemaphore(Device device, Semaphore semaphore, AllocationCallbacks allocator)
        {
            vkDestroySemaphore(device.NativeHandle, semaphore.NativeHandle, allocator.NativeHandle);
        }
        
        public static Event CreateEvent(Device device, EventCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Event @event = new Event();
            fixed(IntPtr* ptrEvent = &@event.NativeHandle)
            {
                var result = vkCreateEvent(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrEvent);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateEvent), result);
            }
            return @event;
        }
        
        public static void DestroyEvent(Device device, Event @event, AllocationCallbacks allocator)
        {
            vkDestroyEvent(device.NativeHandle, @event.NativeHandle, allocator.NativeHandle);
        }
        
        public static void GetEventStatus(Device device, Event @event)
        {
            var result = vkGetEventStatus(device.NativeHandle, @event.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetEventStatus), result);
        }
        
        public static void SetEvent(Device device, Event @event)
        {
            var result = vkSetEvent(device.NativeHandle, @event.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkSetEvent), result);
        }
        
        public static void ResetEvent(Device device, Event @event)
        {
            var result = vkResetEvent(device.NativeHandle, @event.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkResetEvent), result);
        }
        
        public static QueryPool CreateQueryPool(Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator)
        {
            QueryPool queryPool = new QueryPool();
            fixed(IntPtr* ptrQueryPool = &queryPool.NativeHandle)
            {
                var result = vkCreateQueryPool(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrQueryPool);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateQueryPool), result);
            }
            return queryPool;
        }
        
        public static void DestroyQueryPool(Device device, QueryPool queryPool, AllocationCallbacks allocator)
        {
            vkDestroyQueryPool(device.NativeHandle, queryPool.NativeHandle, allocator.NativeHandle);
        }
        
        public static void GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, UIntPtr dataSize, IntPtr data, DeviceSize stride, QueryResultFlags flags)
        {
            var result = vkGetQueryPoolResults(device.NativeHandle, queryPool.NativeHandle, firstQuery, queryCount, dataSize, data, stride.NativeHandle, flags);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetQueryPoolResults), result);
        }
        
        public static Buffer CreateBuffer(Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Buffer buffer = new Buffer();
            fixed(IntPtr* ptrBuffer = &buffer.NativeHandle)
            {
                var result = vkCreateBuffer(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrBuffer);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateBuffer), result);
            }
            return buffer;
        }
        
        public static void DestroyBuffer(Device device, Buffer buffer, AllocationCallbacks allocator)
        {
            vkDestroyBuffer(device.NativeHandle, buffer.NativeHandle, allocator.NativeHandle);
        }
        
        public static BufferView CreateBufferView(Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator)
        {
            BufferView view = new BufferView();
            fixed(IntPtr* ptrBufferView = &view.NativeHandle)
            {
                var result = vkCreateBufferView(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrBufferView);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateBufferView), result);
            }
            return view;
        }
        
        public static void DestroyBufferView(Device device, BufferView bufferView, AllocationCallbacks allocator)
        {
            vkDestroyBufferView(device.NativeHandle, bufferView.NativeHandle, allocator.NativeHandle);
        }
        
        public static Image CreateImage(Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Image image = new Image();
            fixed(IntPtr* ptrImage = &image.NativeHandle)
            {
                var result = vkCreateImage(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrImage);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateImage), result);
            }
            return image;
        }
        
        public static void DestroyImage(Device device, Image image, AllocationCallbacks allocator)
        {
            vkDestroyImage(device.NativeHandle, image.NativeHandle, allocator.NativeHandle);
        }
        
        public static void GetImageSubresourceLayout(Device device, Image image, ImageSubresource subresource, SubresourceLayout layout)
        {
            vkGetImageSubresourceLayout(device.NativeHandle, image.NativeHandle, subresource.NativeHandle, layout.NativeHandle);
        }
        
        public static ImageView CreateImageView(Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator)
        {
            ImageView view = new ImageView();
            fixed(IntPtr* ptrImageView = &view.NativeHandle)
            {
                var result = vkCreateImageView(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrImageView);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateImageView), result);
            }
            return view;
        }
        
        public static void DestroyImageView(Device device, ImageView imageView, AllocationCallbacks allocator)
        {
            vkDestroyImageView(device.NativeHandle, imageView.NativeHandle, allocator.NativeHandle);
        }
        
        public static ShaderModule CreateShaderModule(Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator)
        {
            ShaderModule shaderModule = new ShaderModule();
            fixed(IntPtr* ptrShaderModule = &shaderModule.NativeHandle)
            {
                var result = vkCreateShaderModule(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrShaderModule);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateShaderModule), result);
            }
            return shaderModule;
        }
        
        public static void DestroyShaderModule(Device device, ShaderModule shaderModule, AllocationCallbacks allocator)
        {
            vkDestroyShaderModule(device.NativeHandle, shaderModule.NativeHandle, allocator.NativeHandle);
        }
        
        public static PipelineCache CreatePipelineCache(Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator)
        {
            PipelineCache pipelineCache = new PipelineCache();
            fixed(IntPtr* ptrPipelineCache = &pipelineCache.NativeHandle)
            {
                var result = vkCreatePipelineCache(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrPipelineCache);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreatePipelineCache), result);
            }
            return pipelineCache;
        }
        
        public static void DestroyPipelineCache(Device device, PipelineCache pipelineCache, AllocationCallbacks allocator)
        {
            vkDestroyPipelineCache(device.NativeHandle, pipelineCache.NativeHandle, allocator.NativeHandle);
        }
        
        public static List<IntPtr> GetPipelineCacheData(Device device, PipelineCache pipelineCache)
        {
            UIntPtr dataSize;
            var result = vkGetPipelineCacheData(device.NativeHandle, pipelineCache.NativeHandle, &dataSize, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPipelineCacheData), result);
            
            int size = Marshal.SizeOf(typeof(Interop.IntPtr));
            var ptrIntPtr = Marshal.AllocHGlobal((int)(size * dataSize));
            result = vkGetPipelineCacheData(device.NativeHandle, pipelineCache.NativeHandle, &dataSize, (Interop.IntPtr*)ptrIntPtr);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPipelineCacheData), result);
            
            var list = new List<IntPtr>();
            for(var x = 0; x < dataSize; x++)
            {
                var item = new IntPtr();
                item.NativeHandle = &((Interop.IntPtr*)ptrIntPtr)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static void MergePipelineCaches(Device device, PipelineCache dstCache, UInt32 srcCacheCount, PipelineCache srcCaches)
        {
            var result = vkMergePipelineCaches(device.NativeHandle, dstCache.NativeHandle, srcCacheCount, srcCaches.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkMergePipelineCaches), result);
        }
        
        public static void CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, GraphicsPipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            var result = vkCreateGraphicsPipelines(device.NativeHandle, pipelineCache.NativeHandle, createInfoCount, createInfos.NativeHandle, allocator.NativeHandle, pipelines.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkCreateGraphicsPipelines), result);
        }
        
        public static void CreateComputePipelines(Device device, PipelineCache pipelineCache, UInt32 createInfoCount, ComputePipelineCreateInfo createInfos, AllocationCallbacks allocator, Pipeline pipelines)
        {
            var result = vkCreateComputePipelines(device.NativeHandle, pipelineCache.NativeHandle, createInfoCount, createInfos.NativeHandle, allocator.NativeHandle, pipelines.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkCreateComputePipelines), result);
        }
        
        public static void DestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks allocator)
        {
            vkDestroyPipeline(device.NativeHandle, pipeline.NativeHandle, allocator.NativeHandle);
        }
        
        public static PipelineLayout CreatePipelineLayout(Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator)
        {
            PipelineLayout pipelineLayout = new PipelineLayout();
            fixed(IntPtr* ptrPipelineLayout = &pipelineLayout.NativeHandle)
            {
                var result = vkCreatePipelineLayout(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrPipelineLayout);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreatePipelineLayout), result);
            }
            return pipelineLayout;
        }
        
        public static void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout, AllocationCallbacks allocator)
        {
            vkDestroyPipelineLayout(device.NativeHandle, pipelineLayout.NativeHandle, allocator.NativeHandle);
        }
        
        public static Sampler CreateSampler(Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Sampler sampler = new Sampler();
            fixed(IntPtr* ptrSampler = &sampler.NativeHandle)
            {
                var result = vkCreateSampler(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSampler);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateSampler), result);
            }
            return sampler;
        }
        
        public static void DestroySampler(Device device, Sampler sampler, AllocationCallbacks allocator)
        {
            vkDestroySampler(device.NativeHandle, sampler.NativeHandle, allocator.NativeHandle);
        }
        
        public static DescriptorSetLayout CreateDescriptorSetLayout(Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator)
        {
            DescriptorSetLayout setLayout = new DescriptorSetLayout();
            fixed(IntPtr* ptrDescriptorSetLayout = &setLayout.NativeHandle)
            {
                var result = vkCreateDescriptorSetLayout(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrDescriptorSetLayout);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateDescriptorSetLayout), result);
            }
            return setLayout;
        }
        
        public static void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout, AllocationCallbacks allocator)
        {
            vkDestroyDescriptorSetLayout(device.NativeHandle, descriptorSetLayout.NativeHandle, allocator.NativeHandle);
        }
        
        public static DescriptorPool CreateDescriptorPool(Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator)
        {
            DescriptorPool descriptorPool = new DescriptorPool();
            fixed(IntPtr* ptrDescriptorPool = &descriptorPool.NativeHandle)
            {
                var result = vkCreateDescriptorPool(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrDescriptorPool);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateDescriptorPool), result);
            }
            return descriptorPool;
        }
        
        public static void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool, AllocationCallbacks allocator)
        {
            vkDestroyDescriptorPool(device.NativeHandle, descriptorPool.NativeHandle, allocator.NativeHandle);
        }
        
        public static void ResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags)
        {
            var result = vkResetDescriptorPool(device.NativeHandle, descriptorPool.NativeHandle, flags);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkResetDescriptorPool), result);
        }
        
        public static void AllocateDescriptorSets(Device device, DescriptorSetAllocateInfo allocateInfo, DescriptorSet descriptorSets)
        {
            var result = vkAllocateDescriptorSets(device.NativeHandle, allocateInfo.NativeHandle, descriptorSets.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkAllocateDescriptorSets), result);
        }
        
        public static void FreeDescriptorSets(Device device, DescriptorPool descriptorPool, UInt32 descriptorSetCount, DescriptorSet descriptorSets)
        {
            var result = vkFreeDescriptorSets(device.NativeHandle, descriptorPool.NativeHandle, descriptorSetCount, descriptorSets.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkFreeDescriptorSets), result);
        }
        
        public static void UpdateDescriptorSets(Device device, UInt32 descriptorWriteCount, WriteDescriptorSet descriptorWrites, UInt32 descriptorCopyCount, CopyDescriptorSet descriptorCopies)
        {
            vkUpdateDescriptorSets(device.NativeHandle, descriptorWriteCount, descriptorWrites.NativeHandle, descriptorCopyCount, descriptorCopies.NativeHandle);
        }
        
        public static Framebuffer CreateFramebuffer(Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator)
        {
            Framebuffer framebuffer = new Framebuffer();
            fixed(IntPtr* ptrFramebuffer = &framebuffer.NativeHandle)
            {
                var result = vkCreateFramebuffer(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrFramebuffer);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateFramebuffer), result);
            }
            return framebuffer;
        }
        
        public static void DestroyFramebuffer(Device device, Framebuffer framebuffer, AllocationCallbacks allocator)
        {
            vkDestroyFramebuffer(device.NativeHandle, framebuffer.NativeHandle, allocator.NativeHandle);
        }
        
        public static RenderPass CreateRenderPass(Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator)
        {
            RenderPass renderPass = new RenderPass();
            fixed(IntPtr* ptrRenderPass = &renderPass.NativeHandle)
            {
                var result = vkCreateRenderPass(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrRenderPass);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateRenderPass), result);
            }
            return renderPass;
        }
        
        public static void DestroyRenderPass(Device device, RenderPass renderPass, AllocationCallbacks allocator)
        {
            vkDestroyRenderPass(device.NativeHandle, renderPass.NativeHandle, allocator.NativeHandle);
        }
        
        public static void GetRenderAreaGranularity(Device device, RenderPass renderPass, Extent2D granularity)
        {
            vkGetRenderAreaGranularity(device.NativeHandle, renderPass.NativeHandle, granularity.NativeHandle);
        }
        
        public static CommandPool CreateCommandPool(Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator)
        {
            CommandPool commandPool = new CommandPool();
            fixed(IntPtr* ptrCommandPool = &commandPool.NativeHandle)
            {
                var result = vkCreateCommandPool(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrCommandPool);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateCommandPool), result);
            }
            return commandPool;
        }
        
        public static void DestroyCommandPool(Device device, CommandPool commandPool, AllocationCallbacks allocator)
        {
            vkDestroyCommandPool(device.NativeHandle, commandPool.NativeHandle, allocator.NativeHandle);
        }
        
        public static void ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags)
        {
            var result = vkResetCommandPool(device.NativeHandle, commandPool.NativeHandle, flags);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkResetCommandPool), result);
        }
        
        public static void AllocateCommandBuffers(Device device, CommandBufferAllocateInfo allocateInfo, CommandBuffer commandBuffers)
        {
            var result = vkAllocateCommandBuffers(device.NativeHandle, allocateInfo.NativeHandle, commandBuffers.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkAllocateCommandBuffers), result);
        }
        
        public static void FreeCommandBuffers(Device device, CommandPool commandPool, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            vkFreeCommandBuffers(device.NativeHandle, commandPool.NativeHandle, commandBufferCount, commandBuffers.NativeHandle);
        }
        
        public static void BeginCommandBuffer(CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            var result = vkBeginCommandBuffer(commandBuffer.NativeHandle, beginInfo.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkBeginCommandBuffer), result);
        }
        
        public static void EndCommandBuffer(CommandBuffer commandBuffer)
        {
            var result = vkEndCommandBuffer(commandBuffer.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkEndCommandBuffer), result);
        }
        
        public static void ResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags)
        {
            var result = vkResetCommandBuffer(commandBuffer.NativeHandle, flags);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkResetCommandBuffer), result);
        }
        
        public static void CmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            vkCmdBindPipeline(commandBuffer.NativeHandle, pipelineBindPoint, pipeline.NativeHandle);
        }
        
        public static void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, UInt32 viewportCount, Viewport viewports)
        {
            vkCmdSetViewport(commandBuffer.NativeHandle, firstViewport, viewportCount, viewports.NativeHandle);
        }
        
        public static void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, UInt32 scissorCount, Rect2D scissors)
        {
            vkCmdSetScissor(commandBuffer.NativeHandle, firstScissor, scissorCount, scissors.NativeHandle);
        }
        
        public static void CmdSetLineWidth(CommandBuffer commandBuffer, Single lineWidth)
        {
            vkCmdSetLineWidth(commandBuffer.NativeHandle, lineWidth);
        }
        
        public static void CmdSetDepthBias(CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            vkCmdSetDepthBias(commandBuffer.NativeHandle, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        }
        
        public static void CmdSetBlendConstants(CommandBuffer commandBuffer, Single blendConstants)
        {
            vkCmdSetBlendConstants(commandBuffer.NativeHandle, blendConstants);
        }
        
        public static void CmdSetDepthBounds(CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            vkCmdSetDepthBounds(commandBuffer.NativeHandle, minDepthBounds, maxDepthBounds);
        }
        
        public static void CmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            vkCmdSetStencilCompareMask(commandBuffer.NativeHandle, faceMask, compareMask);
        }
        
        public static void CmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            vkCmdSetStencilWriteMask(commandBuffer.NativeHandle, faceMask, writeMask);
        }
        
        public static void CmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            vkCmdSetStencilReference(commandBuffer.NativeHandle, faceMask, reference);
        }
        
        public static void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, UInt32 descriptorSetCount, DescriptorSet descriptorSets, UInt32 dynamicOffsetCount, UInt32 dynamicOffsets)
        {
            vkCmdBindDescriptorSets(commandBuffer.NativeHandle, pipelineBindPoint, layout.NativeHandle, firstSet, descriptorSetCount, descriptorSets.NativeHandle, dynamicOffsetCount, dynamicOffsets);
        }
        
        public static void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            vkCmdBindIndexBuffer(commandBuffer.NativeHandle, buffer.NativeHandle, offset.NativeHandle, indexType);
        }
        
        public static void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, UInt32 bindingCount, Buffer buffers, DeviceSize offsets)
        {
            vkCmdBindVertexBuffers(commandBuffer.NativeHandle, firstBinding, bindingCount, buffers.NativeHandle, offsets.NativeHandle);
        }
        
        public static void CmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            vkCmdDraw(commandBuffer.NativeHandle, vertexCount, instanceCount, firstVertex, firstInstance);
        }
        
        public static void CmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            vkCmdDrawIndexed(commandBuffer.NativeHandle, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        }
        
        public static void CmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            vkCmdDrawIndirect(commandBuffer.NativeHandle, buffer.NativeHandle, offset.NativeHandle, drawCount, stride);
        }
        
        public static void CmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            vkCmdDrawIndexedIndirect(commandBuffer.NativeHandle, buffer.NativeHandle, offset.NativeHandle, drawCount, stride);
        }
        
        public static void CmdDispatch(CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            vkCmdDispatch(commandBuffer.NativeHandle, x, y, z);
        }
        
        public static void CmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            vkCmdDispatchIndirect(commandBuffer.NativeHandle, buffer.NativeHandle, offset.NativeHandle);
        }
        
        public static void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, UInt32 regionCount, BufferCopy regions)
        {
            vkCmdCopyBuffer(commandBuffer.NativeHandle, srcBuffer.NativeHandle, dstBuffer.NativeHandle, regionCount, regions.NativeHandle);
        }
        
        public static void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageCopy regions)
        {
            vkCmdCopyImage(commandBuffer.NativeHandle, srcImage.NativeHandle, srcImageLayout, dstImage.NativeHandle, dstImageLayout, regionCount, regions.NativeHandle);
        }
        
        public static void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageBlit regions, Filter filter)
        {
            vkCmdBlitImage(commandBuffer.NativeHandle, srcImage.NativeHandle, srcImageLayout, dstImage.NativeHandle, dstImageLayout, regionCount, regions.NativeHandle, filter);
        }
        
        public static void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, BufferImageCopy regions)
        {
            vkCmdCopyBufferToImage(commandBuffer.NativeHandle, srcBuffer.NativeHandle, dstImage.NativeHandle, dstImageLayout, regionCount, regions.NativeHandle);
        }
        
        public static void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, UInt32 regionCount, BufferImageCopy regions)
        {
            vkCmdCopyImageToBuffer(commandBuffer.NativeHandle, srcImage.NativeHandle, srcImageLayout, dstBuffer.NativeHandle, regionCount, regions.NativeHandle);
        }
        
        public static void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, UInt32 data)
        {
            vkCmdUpdateBuffer(commandBuffer.NativeHandle, dstBuffer.NativeHandle, dstOffset.NativeHandle, dataSize.NativeHandle, data);
        }
        
        public static void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            vkCmdFillBuffer(commandBuffer.NativeHandle, dstBuffer.NativeHandle, dstOffset.NativeHandle, size.NativeHandle, data);
        }
        
        public static void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            vkCmdClearColorImage(commandBuffer.NativeHandle, image.NativeHandle, imageLayout, color.NativeHandle, rangeCount, ranges.NativeHandle);
        }
        
        public static void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, UInt32 rangeCount, ImageSubresourceRange ranges)
        {
            vkCmdClearDepthStencilImage(commandBuffer.NativeHandle, image.NativeHandle, imageLayout, depthStencil.NativeHandle, rangeCount, ranges.NativeHandle);
        }
        
        public static void CmdClearAttachments(CommandBuffer commandBuffer, UInt32 attachmentCount, ClearAttachment attachments, UInt32 rectCount, ClearRect rects)
        {
            vkCmdClearAttachments(commandBuffer.NativeHandle, attachmentCount, attachments.NativeHandle, rectCount, rects.NativeHandle);
        }
        
        public static void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, UInt32 regionCount, ImageResolve regions)
        {
            vkCmdResolveImage(commandBuffer.NativeHandle, srcImage.NativeHandle, srcImageLayout, dstImage.NativeHandle, dstImageLayout, regionCount, regions.NativeHandle);
        }
        
        public static void CmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdSetEvent(commandBuffer.NativeHandle, @event.NativeHandle, stageMask);
        }
        
        public static void CmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdResetEvent(commandBuffer.NativeHandle, @event.NativeHandle, stageMask);
        }
        
        public static void CmdWaitEvents(CommandBuffer commandBuffer, UInt32 eventCount, Event events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            vkCmdWaitEvents(commandBuffer.NativeHandle, eventCount, events.NativeHandle, srcStageMask, dstStageMask, memoryBarrierCount, memoryBarriers.NativeHandle, bufferMemoryBarrierCount, bufferMemoryBarriers.NativeHandle, imageMemoryBarrierCount, imageMemoryBarriers.NativeHandle);
        }
        
        public static void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, UInt32 memoryBarrierCount, MemoryBarrier memoryBarriers, UInt32 bufferMemoryBarrierCount, BufferMemoryBarrier bufferMemoryBarriers, UInt32 imageMemoryBarrierCount, ImageMemoryBarrier imageMemoryBarriers)
        {
            vkCmdPipelineBarrier(commandBuffer.NativeHandle, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, memoryBarriers.NativeHandle, bufferMemoryBarrierCount, bufferMemoryBarriers.NativeHandle, imageMemoryBarrierCount, imageMemoryBarriers.NativeHandle);
        }
        
        public static void CmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags)
        {
            vkCmdBeginQuery(commandBuffer.NativeHandle, queryPool.NativeHandle, query, flags);
        }
        
        public static void CmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            vkCmdEndQuery(commandBuffer.NativeHandle, queryPool.NativeHandle, query);
        }
        
        public static void CmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            vkCmdResetQueryPool(commandBuffer.NativeHandle, queryPool.NativeHandle, firstQuery, queryCount);
        }
        
        public static void CmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            vkCmdWriteTimestamp(commandBuffer.NativeHandle, pipelineStage, queryPool.NativeHandle, query);
        }
        
        public static void CmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags)
        {
            vkCmdCopyQueryPoolResults(commandBuffer.NativeHandle, queryPool.NativeHandle, firstQuery, queryCount, dstBuffer.NativeHandle, dstOffset.NativeHandle, stride.NativeHandle, flags);
        }
        
        public static void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, UInt32 size, IntPtr values)
        {
            vkCmdPushConstants(commandBuffer.NativeHandle, layout.NativeHandle, stageFlags, offset, size, values);
        }
        
        public static void CmdBeginRenderPass(CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
        {
            vkCmdBeginRenderPass(commandBuffer.NativeHandle, renderPassBegin.NativeHandle, contents);
        }
        
        public static void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents)
        {
            vkCmdNextSubpass(commandBuffer.NativeHandle, contents);
        }
        
        public static void CmdEndRenderPass(CommandBuffer commandBuffer)
        {
            vkCmdEndRenderPass(commandBuffer.NativeHandle);
        }
        
        public static void CmdExecuteCommands(CommandBuffer commandBuffer, UInt32 commandBufferCount, CommandBuffer commandBuffers)
        {
            vkCmdExecuteCommands(commandBuffer.NativeHandle, commandBufferCount, commandBuffers.NativeHandle);
        }
        
        public static SurfaceKHR CreateAndroidSurfaceKHR(Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SurfaceKHR surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativeHandle)
            {
                var result = vkCreateAndroidSurfaceKHR(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSurfaceKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateAndroidSurfaceKHR), result);
            }
            return surface;
        }
        
        public static List<DisplayPropertiesKHR> GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice)
        {
            UInt32 propertyCount;
            var result = vkGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice.NativeHandle, &propertyCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPropertiesKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.DisplayPropertiesKHR));
            var ptrDisplayPropertiesKHR = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice.NativeHandle, &propertyCount, (Interop.DisplayPropertiesKHR*)ptrDisplayPropertiesKHR);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPropertiesKHR), result);
            
            var list = new List<DisplayPropertiesKHR>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new DisplayPropertiesKHR();
                item.NativeHandle = &((Interop.DisplayPropertiesKHR*)ptrDisplayPropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayPlanePropertiesKHR> GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice)
        {
            UInt32 propertyCount;
            var result = vkGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice.NativeHandle, &propertyCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPlanePropertiesKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.DisplayPlanePropertiesKHR));
            var ptrDisplayPlanePropertiesKHR = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice.NativeHandle, &propertyCount, (Interop.DisplayPlanePropertiesKHR*)ptrDisplayPlanePropertiesKHR);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPlanePropertiesKHR), result);
            
            var list = new List<DisplayPlanePropertiesKHR>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new DisplayPlanePropertiesKHR();
                item.NativeHandle = &((Interop.DisplayPlanePropertiesKHR*)ptrDisplayPlanePropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayKHR> GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex)
        {
            UInt32 displayCount;
            var result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativeHandle, planeIndex, &displayCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            int size = Marshal.SizeOf(typeof(IntPtr));
            var ptrDisplayKHR = Marshal.AllocHGlobal((int)(size * displayCount));
            result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativeHandle, planeIndex, &displayCount, (IntPtr*)ptrDisplayKHR);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            var list = new List<DisplayKHR>();
            for(var x = 0; x < displayCount; x++)
            {
                var item = new DisplayKHR();
                item.NativeHandle = ((IntPtr*)ptrDisplayKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayModePropertiesKHR> GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display)
        {
            UInt32 propertyCount;
            var result = vkGetDisplayModePropertiesKHR(physicalDevice.NativeHandle, display.NativeHandle, &propertyCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.DisplayModePropertiesKHR));
            var ptrDisplayModePropertiesKHR = Marshal.AllocHGlobal((int)(size * propertyCount));
            result = vkGetDisplayModePropertiesKHR(physicalDevice.NativeHandle, display.NativeHandle, &propertyCount, (Interop.DisplayModePropertiesKHR*)ptrDisplayModePropertiesKHR);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            var list = new List<DisplayModePropertiesKHR>();
            for(var x = 0; x < propertyCount; x++)
            {
                var item = new DisplayModePropertiesKHR();
                item.NativeHandle = &((Interop.DisplayModePropertiesKHR*)ptrDisplayModePropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static DisplayModeKHR CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            DisplayModeKHR mode = new DisplayModeKHR();
            fixed(IntPtr* ptrDisplayModeKHR = &mode.NativeHandle)
            {
                var result = vkCreateDisplayModeKHR(physicalDevice.NativeHandle, display.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrDisplayModeKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateDisplayModeKHR), result);
            }
            return mode;
        }
        
        public static void GetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex, DisplayPlaneCapabilitiesKHR capabilities)
        {
            var result = vkGetDisplayPlaneCapabilitiesKHR(physicalDevice.NativeHandle, mode.NativeHandle, planeIndex, capabilities.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneCapabilitiesKHR), result);
        }
        
        public static SurfaceKHR CreateDisplayPlaneSurfaceKHR(Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SurfaceKHR surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativeHandle)
            {
                var result = vkCreateDisplayPlaneSurfaceKHR(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSurfaceKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateDisplayPlaneSurfaceKHR), result);
            }
            return surface;
        }
        
        public static void CreateSharedSwapchainsKHR(Device device, UInt32 swapchainCount, SwapchainCreateInfoKHR createInfos, AllocationCallbacks allocator, SwapchainKHR swapchains)
        {
            var result = vkCreateSharedSwapchainsKHR(device.NativeHandle, swapchainCount, createInfos.NativeHandle, allocator.NativeHandle, swapchains.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkCreateSharedSwapchainsKHR), result);
        }
        
        public static SurfaceKHR CreateMirSurfaceKHR(Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SurfaceKHR surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativeHandle)
            {
                var result = vkCreateMirSurfaceKHR(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSurfaceKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateMirSurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceMirPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, MirConnection connection)
        {
            vkGetPhysicalDeviceMirPresentationSupportKHR(physicalDevice.NativeHandle, queueFamilyIndex, connection.NativeHandle);
            throw new NotImplementedException();
        }
        
        public static void DestroySurfaceKHR(Instance instance, SurfaceKHR surface, AllocationCallbacks allocator)
        {
            vkDestroySurfaceKHR(instance.NativeHandle, surface.NativeHandle, allocator.NativeHandle);
        }
        
        public static void GetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface, Boolean supported)
        {
            var result = vkGetPhysicalDeviceSurfaceSupportKHR(physicalDevice.NativeHandle, queueFamilyIndex, surface.NativeHandle, supported);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceSupportKHR), result);
        }
        
        public static void GetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface, SurfaceCapabilitiesKHR surfaceCapabilities)
        {
            var result = vkGetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice.NativeHandle, surface.NativeHandle, surfaceCapabilities.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceCapabilitiesKHR), result);
        }
        
        public static List<SurfaceFormatKHR> GetPhysicalDeviceSurfaceFormatsKHR(PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            UInt32 surfaceFormatCount;
            var result = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice.NativeHandle, surface.NativeHandle, &surfaceFormatCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceFormatsKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.SurfaceFormatKHR));
            var ptrSurfaceFormatKHR = Marshal.AllocHGlobal((int)(size * surfaceFormatCount));
            result = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice.NativeHandle, surface.NativeHandle, &surfaceFormatCount, (Interop.SurfaceFormatKHR*)ptrSurfaceFormatKHR);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceFormatsKHR), result);
            
            var list = new List<SurfaceFormatKHR>();
            for(var x = 0; x < surfaceFormatCount; x++)
            {
                var item = new SurfaceFormatKHR();
                item.NativeHandle = &((Interop.SurfaceFormatKHR*)ptrSurfaceFormatKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<PresentModeKHR> GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            UInt32 presentModeCount;
            var result = vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice.NativeHandle, surface.NativeHandle, &presentModeCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfacePresentModesKHR), result);
            
            int size = Marshal.SizeOf(typeof(Interop.PresentModeKHR));
            var ptrPresentModeKHR = Marshal.AllocHGlobal((int)(size * presentModeCount));
            result = vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice.NativeHandle, surface.NativeHandle, &presentModeCount, (Interop.PresentModeKHR*)ptrPresentModeKHR);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfacePresentModesKHR), result);
            
            var list = new List<PresentModeKHR>();
            for(var x = 0; x < presentModeCount; x++)
            {
                var item = new PresentModeKHR();
                item.NativeHandle = &((Interop.PresentModeKHR*)ptrPresentModeKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static SwapchainKHR CreateSwapchainKHR(Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SwapchainKHR swapchain = new SwapchainKHR();
            fixed(IntPtr* ptrSwapchainKHR = &swapchain.NativeHandle)
            {
                var result = vkCreateSwapchainKHR(device.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSwapchainKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateSwapchainKHR), result);
            }
            return swapchain;
        }
        
        public static void DestroySwapchainKHR(Device device, SwapchainKHR swapchain, AllocationCallbacks allocator)
        {
            vkDestroySwapchainKHR(device.NativeHandle, swapchain.NativeHandle, allocator.NativeHandle);
        }
        
        public static List<Image> GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain)
        {
            UInt32 swapchainImageCount;
            var result = vkGetSwapchainImagesKHR(device.NativeHandle, swapchain.NativeHandle, &swapchainImageCount, null);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            int size = Marshal.SizeOf(typeof(IntPtr));
            var ptrImage = Marshal.AllocHGlobal((int)(size * swapchainImageCount));
            result = vkGetSwapchainImagesKHR(device.NativeHandle, swapchain.NativeHandle, &swapchainImageCount, (IntPtr*)ptrImage);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            var list = new List<Image>();
            for(var x = 0; x < swapchainImageCount; x++)
            {
                var item = new Image();
                item.NativeHandle = ((IntPtr*)ptrImage)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static void AcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore, Fence fence, UInt32 imageIndex)
        {
            var result = vkAcquireNextImageKHR(device.NativeHandle, swapchain.NativeHandle, timeout, semaphore.NativeHandle, fence.NativeHandle, imageIndex);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkAcquireNextImageKHR), result);
        }
        
        public static void QueuePresentKHR(Queue queue, PresentInfoKHR presentInfo)
        {
            var result = vkQueuePresentKHR(queue.NativeHandle, presentInfo.NativeHandle);
            if(result != Result.SUCCESS)
                throw new VulkanCommandException(nameof(vkQueuePresentKHR), result);
        }
        
        public static SurfaceKHR CreateWaylandSurfaceKHR(Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SurfaceKHR surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativeHandle)
            {
                var result = vkCreateWaylandSurfaceKHR(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSurfaceKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateWaylandSurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceWaylandPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, wl_display display)
        {
            vkGetPhysicalDeviceWaylandPresentationSupportKHR(physicalDevice.NativeHandle, queueFamilyIndex, display.NativeHandle);
            throw new NotImplementedException();
        }
        
        public static SurfaceKHR CreateWin32SurfaceKHR(Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SurfaceKHR surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativeHandle)
            {
                var result = vkCreateWin32SurfaceKHR(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSurfaceKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateWin32SurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            vkGetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice.NativeHandle, queueFamilyIndex);
            throw new NotImplementedException();
        }
        
        public static SurfaceKHR CreateXlibSurfaceKHR(Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SurfaceKHR surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativeHandle)
            {
                var result = vkCreateXlibSurfaceKHR(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSurfaceKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateXlibSurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceXlibPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, Display dpy, VisualID visualID)
        {
            vkGetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice.NativeHandle, queueFamilyIndex, dpy.NativeHandle, visualID.NativeHandle);
            throw new NotImplementedException();
        }
        
        public static SurfaceKHR CreateXcbSurfaceKHR(Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator)
        {
            SurfaceKHR surface = new SurfaceKHR();
            fixed(IntPtr* ptrSurfaceKHR = &surface.NativeHandle)
            {
                var result = vkCreateXcbSurfaceKHR(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrSurfaceKHR);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateXcbSurfaceKHR), result);
            }
            return surface;
        }
        
        public static Boolean GetPhysicalDeviceXcbPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, xcb_connection_t connection, xcb_visualid_t visual_id)
        {
            vkGetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice.NativeHandle, queueFamilyIndex, connection.NativeHandle, visual_id.NativeHandle);
            throw new NotImplementedException();
        }
        
        public static DebugReportCallbackEXT CreateDebugReportCallbackEXT(Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator)
        {
            DebugReportCallbackEXT callback = new DebugReportCallbackEXT();
            fixed(IntPtr* ptrDebugReportCallbackEXT = &callback.NativeHandle)
            {
                var result = vkCreateDebugReportCallbackEXT(instance.NativeHandle, createInfo.NativeHandle, allocator.NativeHandle, ptrDebugReportCallbackEXT);
                if(result != Result.SUCCESS)
                    throw new VulkanCommandException(nameof(vkCreateDebugReportCallbackEXT), result);
            }
            return callback;
        }
        
        public static void DestroyDebugReportCallbackEXT(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator)
        {
            vkDestroyDebugReportCallbackEXT(instance.NativeHandle, callback.NativeHandle, allocator.NativeHandle);
        }
        
        public static void DebugReportMessageEXT(Instance instance, VkDebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UIntPtr location, Int32 messageCode, String layerPrefix, String message)
        {
            vkDebugReportMessageEXT(instance.NativeHandle, flags, objectType, @object, location, messageCode, layerPrefix, message);
        }
        
    }
}
