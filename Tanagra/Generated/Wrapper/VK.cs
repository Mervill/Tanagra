using System;
using System.Linq;
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
            UInt32 listLength;
            var result = vkEnumeratePhysicalDevices(instance.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            var size = Marshal.SizeOf(typeof(IntPtr));
            var ptrPhysicalDevice = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkEnumeratePhysicalDevices(instance.NativePointer, &listLength, (IntPtr*)ptrPhysicalDevice);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            var list = new List<PhysicalDevice>();
            for(var x = 0; x < listLength; x++)
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
            UInt32 listLength;
            vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice.NativePointer, &listLength, null);
            
            //var size = Marshal.SizeOf(typeof(Interop.QueueFamilyProperties));
            //var ptrQueueFamilyProperties = Marshal.AllocHGlobal((int)(size * listLength));
            var listArray = new Interop.QueueFamilyProperties[listLength];
            fixed(Interop.QueueFamilyProperties* resultPointer = &listArray[0])
                vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice.NativePointer, &listLength, resultPointer);

            /*var list = new List<QueueFamilyProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new QueueFamilyProperties();
                item.NativePointer = &((Interop.QueueFamilyProperties*)ptrQueueFamilyProperties)[x];
                list.Add(item);
            }*/

            var list = new List<QueueFamilyProperties>();
            for (var x = 0; x < listLength; x++)
            {
                fixed(Interop.QueueFamilyProperties* itemPtr = &listArray[x])
                {
                    var item = new QueueFamilyProperties();
                    item.NativePointer = itemPtr;
                    list.Add(item);
                }
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
            UInt32 listLength;
            var result = vkEnumerateInstanceLayerProperties(&listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            var size = Marshal.SizeOf(typeof(Interop.LayerProperties));
            var ptrLayerProperties = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkEnumerateInstanceLayerProperties(&listLength, (Interop.LayerProperties*)ptrLayerProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new LayerProperties();
                item.NativePointer = &((Interop.LayerProperties*)ptrLayerProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<ExtensionProperties> EnumerateInstanceExtensionProperties(String layerName)
        {
            UInt32 listLength;
            var result = vkEnumerateInstanceExtensionProperties(layerName, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            var size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
            var ptrExtensionProperties = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkEnumerateInstanceExtensionProperties(layerName, &listLength, (Interop.ExtensionProperties*)ptrExtensionProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new ExtensionProperties();
                item.NativePointer = &((Interop.ExtensionProperties*)ptrExtensionProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<LayerProperties> EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice)
        {
            UInt32 listLength;
            var result = vkEnumerateDeviceLayerProperties(physicalDevice.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            var size = Marshal.SizeOf(typeof(Interop.LayerProperties));
            var ptrLayerProperties = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkEnumerateDeviceLayerProperties(physicalDevice.NativePointer, &listLength, (Interop.LayerProperties*)ptrLayerProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new LayerProperties();
                item.NativePointer = &((Interop.LayerProperties*)ptrLayerProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<ExtensionProperties> EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, String layerName)
        {
            UInt32 listLength;
            var result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativePointer, layerName, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            var size = Marshal.SizeOf(typeof(Interop.ExtensionProperties));
            var ptrExtensionProperties = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativePointer, layerName, &listLength, (Interop.ExtensionProperties*)ptrExtensionProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < listLength; x++)
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
        
        public static void QueueSubmit(Queue queue, List<SubmitInfo> submits, Fence fence)
        {
            // hasArrayArguments
            var submitCount = (UInt32)submits.Count;
            var _submitsSize = Marshal.SizeOf(typeof(Interop.SubmitInfo));
            var _submitsPtr = (void**)Marshal.AllocHGlobal((int)(_submitsSize * submitCount));
            for(var x = 0; x < submitCount; x++)
                _submitsPtr[x] = submits[x].NativePointer;
            
            var result = vkQueueSubmit(queue.NativePointer, submitCount, (Interop.SubmitInfo*)_submitsPtr, fence.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkQueueSubmit), result);
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
            fixed(UInt64* ptrDeviceMemory = &memory.NativePointer)
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
        
        public static void FlushMappedMemoryRanges(Device device, List<MappedMemoryRange> memoryRanges)
        {
            // hasArrayArguments
            var memoryRangeCount = (UInt32)memoryRanges.Count;
            var _memoryRangesSize = Marshal.SizeOf(typeof(Interop.MappedMemoryRange));
            var _memoryRangesPtr = (void**)Marshal.AllocHGlobal((int)(_memoryRangesSize * memoryRangeCount));
            for(var x = 0; x < memoryRangeCount; x++)
                _memoryRangesPtr[x] = memoryRanges[x].NativePointer;
            
            var result = vkFlushMappedMemoryRanges(device.NativePointer, memoryRangeCount, (Interop.MappedMemoryRange*)_memoryRangesPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkFlushMappedMemoryRanges), result);
        }
        
        public static void InvalidateMappedMemoryRanges(Device device, List<MappedMemoryRange> memoryRanges)
        {
            // hasArrayArguments
            var memoryRangeCount = (UInt32)memoryRanges.Count;
            var _memoryRangesSize = Marshal.SizeOf(typeof(Interop.MappedMemoryRange));
            var _memoryRangesPtr = (void**)Marshal.AllocHGlobal((int)(_memoryRangesSize * memoryRangeCount));
            for(var x = 0; x < memoryRangeCount; x++)
                _memoryRangesPtr[x] = memoryRanges[x].NativePointer;
            
            var result = vkInvalidateMappedMemoryRanges(device.NativePointer, memoryRangeCount, (Interop.MappedMemoryRange*)_memoryRangesPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkInvalidateMappedMemoryRanges), result);
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
            UInt32 listLength;
            vkGetImageSparseMemoryRequirements(device.NativePointer, image.NativePointer, &listLength, null);
            
            var size = Marshal.SizeOf(typeof(Interop.SparseImageMemoryRequirements));
            var ptrSparseImageMemoryRequirements = Marshal.AllocHGlobal((int)(size * listLength));
            vkGetImageSparseMemoryRequirements(device.NativePointer, image.NativePointer, &listLength, (Interop.SparseImageMemoryRequirements*)ptrSparseImageMemoryRequirements);
            
            var list = new List<SparseImageMemoryRequirements>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new SparseImageMemoryRequirements();
                item.NativePointer = &((Interop.SparseImageMemoryRequirements*)ptrSparseImageMemoryRequirements)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<SparseImageFormatProperties> GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
        {
            UInt32 listLength;
            vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativePointer, format, type, samples, usage, tiling, &listLength, null);
            
            var size = Marshal.SizeOf(typeof(Interop.SparseImageFormatProperties));
            var ptrSparseImageFormatProperties = Marshal.AllocHGlobal((int)(size * listLength));
            vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativePointer, format, type, samples, usage, tiling, &listLength, (Interop.SparseImageFormatProperties*)ptrSparseImageFormatProperties);
            
            var list = new List<SparseImageFormatProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new SparseImageFormatProperties();
                item.NativePointer = &((Interop.SparseImageFormatProperties*)ptrSparseImageFormatProperties)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static void QueueBindSparse(Queue queue, List<BindSparseInfo> bindInfo, Fence fence)
        {
            // hasArrayArguments
            var bindInfoCount = (UInt32)bindInfo.Count;
            var _bindInfoSize = Marshal.SizeOf(typeof(Interop.BindSparseInfo));
            var _bindInfoPtr = (void**)Marshal.AllocHGlobal((int)(_bindInfoSize * bindInfoCount));
            for(var x = 0; x < bindInfoCount; x++)
                _bindInfoPtr[x] = bindInfo[x].NativePointer;
            
            var result = vkQueueBindSparse(queue.NativePointer, bindInfoCount, (Interop.BindSparseInfo*)_bindInfoPtr, fence.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkQueueBindSparse), result);
        }
        
        public static Fence CreateFence(Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var fence = new Fence();
            fixed(UInt64* ptrFence = &fence.NativePointer)
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
        
        public static void ResetFences(Device device, List<Fence> fences)
        {
            // hasArrayArguments
            var fenceCount = (UInt32)fences.Count;
            var _fencesSize = Marshal.SizeOf(typeof(IntPtr));
            var _fencesPtr = (void**)Marshal.AllocHGlobal((int)(_fencesSize * fenceCount));
            for(var x = 0; x < fenceCount; x++)
                _fencesPtr[x] = (IntPtr*)fences[x].NativePointer;
            
            var result = vkResetFences(device.NativePointer, fenceCount, (UInt64*)_fencesPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetFences), result);
        }
        
        public static void GetFenceStatus(Device device, Fence fence)
        {
            var result = vkGetFenceStatus(device.NativePointer, fence.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetFenceStatus), result);
        }
        
        public static void WaitForFences(Device device, List<Fence> fences, Boolean waitAll, UInt64 timeout)
        {
            // hasArrayArguments
            var fenceCount = (UInt32)fences.Count;
            var _fencesSize = Marshal.SizeOf(typeof(IntPtr));
            var _fencesPtr = (void**)Marshal.AllocHGlobal((int)(_fencesSize * fenceCount));
            for(var x = 0; x < fenceCount; x++)
                _fencesPtr[x] = (IntPtr*)fences[x].NativePointer;
            
            var result = vkWaitForFences(device.NativePointer, fenceCount, (UInt64*)_fencesPtr, waitAll, timeout);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkWaitForFences), result);
        }
        
        public static Semaphore CreateSemaphore(Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var semaphore = new Semaphore();
            fixed(UInt64* ptrSemaphore = &semaphore.NativePointer)
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
            fixed(UInt64* ptrEvent = &@event.NativePointer)
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
            fixed(UInt64* ptrQueryPool = &queryPool.NativePointer)
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
        
        /*public static void GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, List<IntPtr> data, DeviceSize stride, QueryResultFlags flags)
        {
            // hasArrayArguments
            var dataSize = (UIntPtr)data.Count;
            var _dataSize = Marshal.SizeOf(typeof(IntPtr));
            var _dataPtr = (void**)Marshal.AllocHGlobal((int)(_dataSize * dataSize));
            for(var x = 0; x < dataSize; x++)
                _dataPtr[x] = (IntPtr*)data[x].NativePointer;
            
            var result = vkGetQueryPoolResults(device.NativePointer, queryPool.NativePointer, firstQuery, queryCount, dataSize, (IntPtr*)_dataPtr, stride, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetQueryPoolResults), result);
        }*/
        
        public static Buffer CreateBuffer(Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var buffer = new Buffer();
            fixed(UInt64* ptrBuffer = &buffer.NativePointer)
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
            fixed(UInt64* ptrBufferView = &view.NativePointer)
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
            fixed(UInt64* ptrImage = &image.NativePointer)
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
            fixed(UInt64* ptrImageView = &view.NativePointer)
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
            fixed(UInt64* ptrShaderModule = &shaderModule.NativePointer)
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
            fixed(UInt64* ptrPipelineCache = &pipelineCache.NativePointer)
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
        
        public static void MergePipelineCaches(Device device, PipelineCache dstCache, List<PipelineCache> srcCaches)
        {
            // hasArrayArguments
            var srcCacheCount = (UInt32)srcCaches.Count;
            var _srcCachesSize = Marshal.SizeOf(typeof(IntPtr));
            var _srcCachesPtr = (void**)Marshal.AllocHGlobal((int)(_srcCachesSize * srcCacheCount));
            for(var x = 0; x < srcCacheCount; x++)
                _srcCachesPtr[x] = (IntPtr*)srcCaches[x].NativePointer;
            
            var result = vkMergePipelineCaches(device.NativePointer, dstCache.NativePointer, srcCacheCount, (UInt64*)_srcCachesPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkMergePipelineCaches), result);
        }
        
        public static List<Pipeline> CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, List<GraphicsPipelineCreateInfo> createInfos, AllocationCallbacks allocator = null)
        {
            // hasArrayArguments
            var createInfoCount = (UInt32)createInfos.Count;
            var _createInfosSize = Marshal.SizeOf(typeof(Interop.GraphicsPipelineCreateInfo));
            var _createInfosPtr = (void**)Marshal.AllocHGlobal((int)(_createInfosSize * createInfoCount));
            for(var x = 0; x < createInfoCount; x++)
                _createInfosPtr[x] = createInfos[x].NativePointer;
            
            var result = vkCreateGraphicsPipelines(device.NativePointer, pipelineCache.NativePointer, createInfoCount, (Interop.GraphicsPipelineCreateInfo*)_createInfosPtr, (allocator != null) ? allocator.NativePointer : null, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkCreateGraphicsPipelines), result);
            throw new NotImplementedException();
        }
        
        public static List<Pipeline> CreateComputePipelines(Device device, PipelineCache pipelineCache, List<ComputePipelineCreateInfo> createInfos, AllocationCallbacks allocator = null)
        {
            // hasArrayArguments
            var createInfoCount = (UInt32)createInfos.Count;
            var _createInfosSize = Marshal.SizeOf(typeof(Interop.ComputePipelineCreateInfo));
            var _createInfosPtr = (void**)Marshal.AllocHGlobal((int)(_createInfosSize * createInfoCount));
            for(var x = 0; x < createInfoCount; x++)
                _createInfosPtr[x] = createInfos[x].NativePointer;
            
            var result = vkCreateComputePipelines(device.NativePointer, pipelineCache.NativePointer, createInfoCount, (Interop.ComputePipelineCreateInfo*)_createInfosPtr, (allocator != null) ? allocator.NativePointer : null, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkCreateComputePipelines), result);
            throw new NotImplementedException();
        }
        
        public static void DestroyPipeline(Device device, Pipeline pipeline, AllocationCallbacks allocator = null)
        {
            vkDestroyPipeline(device.NativePointer, pipeline.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static PipelineLayout CreatePipelineLayout(Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var pipelineLayout = new PipelineLayout();
            fixed(UInt64* ptrPipelineLayout = &pipelineLayout.NativePointer)
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
            fixed(UInt64* ptrSampler = &sampler.NativePointer)
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
            fixed(UInt64* ptrDescriptorSetLayout = &setLayout.NativePointer)
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
            fixed(UInt64* ptrDescriptorPool = &descriptorPool.NativePointer)
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
        
        /*public static List<DescriptorSet> AllocateDescriptorSets(Device device, DescriptorSetAllocateInfo allocateInfo)
        {
            var listLength = allocateInfo.DescriptorSetCount;
            var result = vkAllocateDescriptorSets(device.NativePointer, allocateInfo.NativePointer, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkAllocateDescriptorSets), result);
            
            var size = Marshal.SizeOf(typeof(IntPtr));
            var ptrDescriptorSet = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkAllocateDescriptorSets(device.NativePointer, allocateInfo.NativePointer, (IntPtr*)ptrDescriptorSet);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkAllocateDescriptorSets), result);
            
            var list = new List<DescriptorSet>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DescriptorSet();
                item.NativePointer = ((IntPtr*)ptrDescriptorSet)[x];
                list.Add(item);
            }
            
            return list;
        }*/
        
        public static void FreeDescriptorSets(Device device, DescriptorPool descriptorPool, List<DescriptorSet> descriptorSets)
        {
            // hasArrayArguments
            var descriptorSetCount = (UInt32)descriptorSets.Count;
            var _descriptorSetsSize = Marshal.SizeOf(typeof(IntPtr));
            var _descriptorSetsPtr = (void**)Marshal.AllocHGlobal((int)(_descriptorSetsSize * descriptorSetCount));
            for(var x = 0; x < descriptorSetCount; x++)
                _descriptorSetsPtr[x] = (IntPtr*)descriptorSets[x].NativePointer;
            
            var result = vkFreeDescriptorSets(device.NativePointer, descriptorPool.NativePointer, descriptorSetCount, (UInt64*)_descriptorSetsPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkFreeDescriptorSets), result);
        }
        
        public static void UpdateDescriptorSets(Device device, List<WriteDescriptorSet> descriptorWrites, List<CopyDescriptorSet> descriptorCopies)
        {
            // hasArrayArguments
            var descriptorWriteCount = (UInt32)descriptorWrites.Count;
            var _descriptorWritesSize = Marshal.SizeOf(typeof(Interop.WriteDescriptorSet));
            var _descriptorWritesPtr = (void**)Marshal.AllocHGlobal((int)(_descriptorWritesSize * descriptorWriteCount));
            for(var x = 0; x < descriptorWriteCount; x++)
                _descriptorWritesPtr[x] = descriptorWrites[x].NativePointer;
            
            var descriptorCopyCount = (UInt32)descriptorCopies.Count;
            var _descriptorCopiesSize = Marshal.SizeOf(typeof(Interop.CopyDescriptorSet));
            var _descriptorCopiesPtr = (void**)Marshal.AllocHGlobal((int)(_descriptorCopiesSize * descriptorCopyCount));
            for(var x = 0; x < descriptorCopyCount; x++)
                _descriptorCopiesPtr[x] = descriptorCopies[x].NativePointer;
            
            vkUpdateDescriptorSets(device.NativePointer, descriptorWriteCount, (Interop.WriteDescriptorSet*)_descriptorWritesPtr, descriptorCopyCount, (Interop.CopyDescriptorSet*)_descriptorCopiesPtr);
        }
        
        public static Framebuffer CreateFramebuffer(Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var framebuffer = new Framebuffer();
            fixed(UInt64* ptrFramebuffer = &framebuffer.NativePointer)
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
            fixed(UInt64* ptrRenderPass = &renderPass.NativePointer)
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
            vkGetRenderAreaGranularity(device.NativePointer, renderPass.NativePointer, granularity);
            return granularity;
        }
        
        public static CommandPool CreateCommandPool(Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator = null)
        {
            var commandPool = new CommandPool();
            fixed(UInt64* ptrCommandPool = &commandPool.NativePointer)
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

        public static List<CommandBuffer> AllocateCommandBuffers(Device device, CommandBufferAllocateInfo allocateInfo)
        {
            var listLength = allocateInfo.CommandBufferCount;
            //var result = vkAllocateCommandBuffers(device.NativePointer, allocateInfo.NativePointer, null);
            //if(result != Result.Success)
            //throw new VulkanCommandException(nameof(vkAllocateCommandBuffers), result);

            var size = Marshal.SizeOf(typeof(IntPtr));
            var ptrCommandBuffer = Marshal.AllocHGlobal((int)(size * listLength));
            var result = vkAllocateCommandBuffers(device.NativePointer, allocateInfo.NativePointer, (IntPtr*)ptrCommandBuffer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkAllocateCommandBuffers), result);

            var list = new List<CommandBuffer>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new CommandBuffer();
                item.NativePointer = ((IntPtr*)ptrCommandBuffer)[x];
                list.Add(item);
            }

            return list;
        }

        public static void FreeCommandBuffers(Device device, CommandPool commandPool, List<CommandBuffer> commandBuffers)
        {
            // hasArrayArguments
            var commandBufferCount = (UInt32)commandBuffers.Count;
            var _commandBuffersSize = Marshal.SizeOf(typeof(IntPtr));
            var _commandBuffersPtr = (void**)Marshal.AllocHGlobal((int)(_commandBuffersSize * commandBufferCount));
            for(var x = 0; x < commandBufferCount; x++)
                _commandBuffersPtr[x] = (IntPtr*)commandBuffers[x].NativePointer;
            
            vkFreeCommandBuffers(device.NativePointer, commandPool.NativePointer, commandBufferCount, (IntPtr*)_commandBuffersPtr);
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
        
        public static void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, List<Viewport> viewports)
        {
            // hasArrayArguments
            var viewportCount = (UInt32)viewports.Count;
            var _viewportsSize = Marshal.SizeOf(typeof(Interop.Viewport));
            var _viewportsPtr = (void**)Marshal.AllocHGlobal((int)(_viewportsSize * viewportCount));
            for(var x = 0; x < viewportCount; x++)
                _viewportsPtr[x] = viewports[x].NativePointer;
            
            vkCmdSetViewport(commandBuffer.NativePointer, firstViewport, viewportCount, (Interop.Viewport*)_viewportsPtr);
        }
        
        public static void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, List<Rect2D> scissors)
        {
            // hasArrayArguments
            var scissorCount = (UInt32)scissors.Count;
            var _scissorsSize = Marshal.SizeOf(typeof(Interop.Rect2D));
            var _scissorsPtr = (void**)Marshal.AllocHGlobal((int)(_scissorsSize * scissorCount));
            for(var x = 0; x < scissorCount; x++)
                _scissorsPtr[x] = scissors[x].NativePointer;
            
            vkCmdSetScissor(commandBuffer.NativePointer, firstScissor, scissorCount, (Interop.Rect2D*)_scissorsPtr);
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
        
        /*public static void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, List<DescriptorSet> descriptorSets, List<UInt32> dynamicOffsets)
        {
            // hasArrayArguments
            var descriptorSetCount = (UInt32)descriptorSets.Count;
            var _descriptorSetsSize = Marshal.SizeOf(typeof(IntPtr));
            var _descriptorSetsPtr = (void**)Marshal.AllocHGlobal((int)(_descriptorSetsSize * descriptorSetCount));
            for(var x = 0; x < descriptorSetCount; x++)
                _descriptorSetsPtr[x] = (IntPtr*)descriptorSets[x].NativePointer;
            
            var dynamicOffsetCount = (UInt32)dynamicOffsets.Count;
            var _dynamicOffsetsSize = Marshal.SizeOf(typeof(Interop.UInt32));
            var _dynamicOffsetsPtr = (void**)Marshal.AllocHGlobal((int)(_dynamicOffsetsSize * dynamicOffsetCount));
            for(var x = 0; x < dynamicOffsetCount; x++)
                _dynamicOffsetsPtr[x] = dynamicOffsets[x].NativePointer;
            
            vkCmdBindDescriptorSets(commandBuffer.NativePointer, pipelineBindPoint, layout.NativePointer, firstSet, descriptorSetCount, (UInt64*)_descriptorSetsPtr, dynamicOffsetCount, (Interop.UInt32*)_dynamicOffsetsPtr);
        }*/
        
        public static void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            vkCmdBindIndexBuffer(commandBuffer.NativePointer, buffer.NativePointer, offset, indexType);
        }
        
        /*public static void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, List<Buffer> buffers, List<DeviceSize> offsets)
        {
            // hasArrayArguments
            var bindingCount = (UInt32)buffers.Count;
            var _buffersSize = Marshal.SizeOf(typeof(IntPtr));
            var _buffersPtr = (void**)Marshal.AllocHGlobal((int)(_buffersSize * bindingCount));
            for(var x = 0; x < bindingCount; x++)
                _buffersPtr[x] = (IntPtr*)buffers[x].NativePointer;
            
            var bindingCount = (UInt32)offsets.Count;
            var _offsetsSize = Marshal.SizeOf(typeof(Interop.DeviceSize));
            var _offsetsPtr = (void**)Marshal.AllocHGlobal((int)(_offsetsSize * bindingCount));
            for(var x = 0; x < bindingCount; x++)
                _offsetsPtr[x] = offsets[x].NativePointer;
            
            vkCmdBindVertexBuffers(commandBuffer.NativePointer, firstBinding, bindingCount, (UInt64*)_buffersPtr, (Interop.DeviceSize*)_offsetsPtr);
        }*/
        
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
        
        public static void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, List<BufferCopy> regions)
        {
            // hasArrayArguments
            var regionCount = (UInt32)regions.Count;
            var _regionsSize = Marshal.SizeOf(typeof(Interop.BufferCopy));
            var _regionsPtr = (void**)Marshal.AllocHGlobal((int)(_regionsSize * regionCount));
            for(var x = 0; x < regionCount; x++)
                _regionsPtr[x] = regions[x].NativePointer;
            
            vkCmdCopyBuffer(commandBuffer.NativePointer, srcBuffer.NativePointer, dstBuffer.NativePointer, regionCount, (Interop.BufferCopy*)_regionsPtr);
        }
        
        public static void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageCopy> regions)
        {
            // hasArrayArguments
            var regionCount = (UInt32)regions.Count;
            var _regionsSize = Marshal.SizeOf(typeof(Interop.ImageCopy));
            var _regionsPtr = (void**)Marshal.AllocHGlobal((int)(_regionsSize * regionCount));
            for(var x = 0; x < regionCount; x++)
                _regionsPtr[x] = regions[x].NativePointer;
            
            vkCmdCopyImage(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstImage.NativePointer, dstImageLayout, regionCount, (Interop.ImageCopy*)_regionsPtr);
        }
        
        public static void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageBlit> regions, Filter filter)
        {
            // hasArrayArguments
            var regionCount = (UInt32)regions.Count;
            var _regionsSize = Marshal.SizeOf(typeof(Interop.ImageBlit));
            var _regionsPtr = (void**)Marshal.AllocHGlobal((int)(_regionsSize * regionCount));
            for(var x = 0; x < regionCount; x++)
                _regionsPtr[x] = regions[x].NativePointer;
            
            vkCmdBlitImage(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstImage.NativePointer, dstImageLayout, regionCount, (Interop.ImageBlit*)_regionsPtr, filter);
        }
        
        public static void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, List<BufferImageCopy> regions)
        {
            // hasArrayArguments
            var regionCount = (UInt32)regions.Count;
            var _regionsSize = Marshal.SizeOf(typeof(Interop.BufferImageCopy));
            var _regionsPtr = (void**)Marshal.AllocHGlobal((int)(_regionsSize * regionCount));
            for(var x = 0; x < regionCount; x++)
                _regionsPtr[x] = regions[x].NativePointer;
            
            vkCmdCopyBufferToImage(commandBuffer.NativePointer, srcBuffer.NativePointer, dstImage.NativePointer, dstImageLayout, regionCount, (Interop.BufferImageCopy*)_regionsPtr);
        }
        
        public static void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, List<BufferImageCopy> regions)
        {
            // hasArrayArguments
            var regionCount = (UInt32)regions.Count;
            var _regionsSize = Marshal.SizeOf(typeof(Interop.BufferImageCopy));
            var _regionsPtr = (void**)Marshal.AllocHGlobal((int)(_regionsSize * regionCount));
            for(var x = 0; x < regionCount; x++)
                _regionsPtr[x] = regions[x].NativePointer;
            
            vkCmdCopyImageToBuffer(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstBuffer.NativePointer, regionCount, (Interop.BufferImageCopy*)_regionsPtr);
        }
        
        /*public static void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize dataSize, List<UInt32> data)
        {
            // hasArrayArguments
            // (no arrayLengthParams)
            vkCmdUpdateBuffer(commandBuffer.NativePointer, dstBuffer.NativePointer, dstOffset, dataSize, (Interop.UInt32*)_dataPtr);
        }*/
        
        public static void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            vkCmdFillBuffer(commandBuffer.NativePointer, dstBuffer.NativePointer, dstOffset, size, data);
        }
        
        public static void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, List<ImageSubresourceRange> ranges)
        {
            // hasArrayArguments
            var rangeCount = (UInt32)ranges.Count;
            var _rangesSize = Marshal.SizeOf(typeof(Interop.ImageSubresourceRange));
            var _rangesPtr = (void**)Marshal.AllocHGlobal((int)(_rangesSize * rangeCount));
            for(var x = 0; x < rangeCount; x++)
                _rangesPtr[x] = ranges[x].NativePointer;
            
            vkCmdClearColorImage(commandBuffer.NativePointer, image.NativePointer, imageLayout, color.NativePointer, rangeCount, (Interop.ImageSubresourceRange*)_rangesPtr);
        }
        
        public static void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, List<ImageSubresourceRange> ranges)
        {
            // hasArrayArguments
            var rangeCount = (UInt32)ranges.Count;
            var _rangesSize = Marshal.SizeOf(typeof(Interop.ImageSubresourceRange));
            var _rangesPtr = (void**)Marshal.AllocHGlobal((int)(_rangesSize * rangeCount));
            for(var x = 0; x < rangeCount; x++)
                _rangesPtr[x] = ranges[x].NativePointer;
            
            vkCmdClearDepthStencilImage(commandBuffer.NativePointer, image.NativePointer, imageLayout, depthStencil.NativePointer, rangeCount, (Interop.ImageSubresourceRange*)_rangesPtr);
        }
        
        public static void CmdClearAttachments(CommandBuffer commandBuffer, List<ClearAttachment> attachments, List<ClearRect> rects)
        {
            // hasArrayArguments
            var attachmentCount = (UInt32)attachments.Count;
            var _attachmentsSize = Marshal.SizeOf(typeof(Interop.ClearAttachment));
            var _attachmentsPtr = (void**)Marshal.AllocHGlobal((int)(_attachmentsSize * attachmentCount));
            for(var x = 0; x < attachmentCount; x++)
                _attachmentsPtr[x] = attachments[x].NativePointer;
            
            var rectCount = (UInt32)rects.Count;
            var _rectsSize = Marshal.SizeOf(typeof(Interop.ClearRect));
            var _rectsPtr = (void**)Marshal.AllocHGlobal((int)(_rectsSize * rectCount));
            for(var x = 0; x < rectCount; x++)
                _rectsPtr[x] = rects[x].NativePointer;
            
            vkCmdClearAttachments(commandBuffer.NativePointer, attachmentCount, (Interop.ClearAttachment*)_attachmentsPtr, rectCount, (Interop.ClearRect*)_rectsPtr);
        }
        
        public static void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, List<ImageResolve> regions)
        {
            // hasArrayArguments
            var regionCount = (UInt32)regions.Count;
            var _regionsSize = Marshal.SizeOf(typeof(Interop.ImageResolve));
            var _regionsPtr = (void**)Marshal.AllocHGlobal((int)(_regionsSize * regionCount));
            for(var x = 0; x < regionCount; x++)
                _regionsPtr[x] = regions[x].NativePointer;
            
            vkCmdResolveImage(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstImage.NativePointer, dstImageLayout, regionCount, (Interop.ImageResolve*)_regionsPtr);
        }
        
        public static void CmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdSetEvent(commandBuffer.NativePointer, @event.NativePointer, stageMask);
        }
        
        public static void CmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdResetEvent(commandBuffer.NativePointer, @event.NativePointer, stageMask);
        }
        
        public static void CmdWaitEvents(CommandBuffer commandBuffer, List<Event> events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            // hasArrayArguments
            var eventCount = (UInt32)events.Count;
            var _eventsSize = Marshal.SizeOf(typeof(IntPtr));
            var _eventsPtr = (void**)Marshal.AllocHGlobal((int)(_eventsSize * eventCount));
            for(var x = 0; x < eventCount; x++)
                _eventsPtr[x] = (IntPtr*)events[x].NativePointer;
            
            var memoryBarrierCount = (UInt32)memoryBarriers.Count;
            var _memoryBarriersSize = Marshal.SizeOf(typeof(Interop.MemoryBarrier));
            var _memoryBarriersPtr = (void**)Marshal.AllocHGlobal((int)(_memoryBarriersSize * memoryBarrierCount));
            for(var x = 0; x < memoryBarrierCount; x++)
                _memoryBarriersPtr[x] = memoryBarriers[x].NativePointer;
            
            var bufferMemoryBarrierCount = (UInt32)bufferMemoryBarriers.Count;
            var _bufferMemoryBarriersSize = Marshal.SizeOf(typeof(Interop.BufferMemoryBarrier));
            var _bufferMemoryBarriersPtr = (void**)Marshal.AllocHGlobal((int)(_bufferMemoryBarriersSize * bufferMemoryBarrierCount));
            for(var x = 0; x < bufferMemoryBarrierCount; x++)
                _bufferMemoryBarriersPtr[x] = bufferMemoryBarriers[x].NativePointer;
            
            var imageMemoryBarrierCount = (UInt32)imageMemoryBarriers.Count;
            var _imageMemoryBarriersSize = Marshal.SizeOf(typeof(Interop.ImageMemoryBarrier));
            var _imageMemoryBarriersPtr = (void**)Marshal.AllocHGlobal((int)(_imageMemoryBarriersSize * imageMemoryBarrierCount));
            for(var x = 0; x < imageMemoryBarrierCount; x++)
                _imageMemoryBarriersPtr[x] = imageMemoryBarriers[x].NativePointer;
            
            vkCmdWaitEvents(commandBuffer.NativePointer, eventCount, (UInt64*)_eventsPtr, srcStageMask, dstStageMask, memoryBarrierCount, (Interop.MemoryBarrier*)_memoryBarriersPtr, bufferMemoryBarrierCount, (Interop.BufferMemoryBarrier*)_bufferMemoryBarriersPtr, imageMemoryBarrierCount, (Interop.ImageMemoryBarrier*)_imageMemoryBarriersPtr);
        }
        
        public static void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, List<MemoryBarrier> memoryBarriers, List<BufferMemoryBarrier> bufferMemoryBarriers, List<ImageMemoryBarrier> imageMemoryBarriers)
        {
            // hasArrayArguments
            var memoryBarrierCount = (UInt32)memoryBarriers.Count;
            var _memoryBarriersSize = Marshal.SizeOf(typeof(Interop.MemoryBarrier));
            var _memoryBarriersPtr = (void**)Marshal.AllocHGlobal((int)(_memoryBarriersSize * memoryBarrierCount));
            for(var x = 0; x < memoryBarrierCount; x++)
                _memoryBarriersPtr[x] = memoryBarriers[x].NativePointer;
            
            var bufferMemoryBarrierCount = (UInt32)bufferMemoryBarriers.Count;
            var _bufferMemoryBarriersSize = Marshal.SizeOf(typeof(Interop.BufferMemoryBarrier));
            var _bufferMemoryBarriersPtr = (void**)Marshal.AllocHGlobal((int)(_bufferMemoryBarriersSize * bufferMemoryBarrierCount));
            for(var x = 0; x < bufferMemoryBarrierCount; x++)
                _bufferMemoryBarriersPtr[x] = bufferMemoryBarriers[x].NativePointer;
            
            var imageMemoryBarrierCount = (UInt32)imageMemoryBarriers.Count;
            var _imageMemoryBarriersSize = Marshal.SizeOf(typeof(Interop.ImageMemoryBarrier));
            var _imageMemoryBarriersPtr = (void**)Marshal.AllocHGlobal((int)(_imageMemoryBarriersSize * imageMemoryBarrierCount));
            for(var x = 0; x < imageMemoryBarrierCount; x++)
                _imageMemoryBarriersPtr[x] = imageMemoryBarriers[x].NativePointer;
            
            vkCmdPipelineBarrier(commandBuffer.NativePointer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, (Interop.MemoryBarrier*)_memoryBarriersPtr, bufferMemoryBarrierCount, (Interop.BufferMemoryBarrier*)_bufferMemoryBarriersPtr, imageMemoryBarrierCount, (Interop.ImageMemoryBarrier*)_imageMemoryBarriersPtr);
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
        
        /*public static void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, List<IntPtr> values)
        {
            // hasArrayArguments
            var size = (UInt32)values.Count;
            var _valuesSize = Marshal.SizeOf(typeof(IntPtr));
            var _valuesPtr = (void**)Marshal.AllocHGlobal((int)(_valuesSize * size));
            for(var x = 0; x < size; x++)
                _valuesPtr[x] = (IntPtr*)values[x].NativePointer;
            
            vkCmdPushConstants(commandBuffer.NativePointer, layout.NativePointer, stageFlags, offset, size, (IntPtr*)_valuesPtr);
        }*/
        
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
        
        public static void CmdExecuteCommands(CommandBuffer commandBuffer, List<CommandBuffer> commandBuffers)
        {
            // hasArrayArguments
            var commandBufferCount = (UInt32)commandBuffers.Count;
            var _commandBuffersSize = Marshal.SizeOf(typeof(IntPtr));
            var _commandBuffersPtr = (void**)Marshal.AllocHGlobal((int)(_commandBuffersSize * commandBufferCount));
            for(var x = 0; x < commandBufferCount; x++)
                _commandBuffersPtr[x] = (IntPtr*)commandBuffers[x].NativePointer;
            
            vkCmdExecuteCommands(commandBuffer.NativePointer, commandBufferCount, (IntPtr*)_commandBuffersPtr);
        }
        
        public static SurfaceKHR CreateAndroidSurfaceKHR(Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(UInt64* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateAndroidSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateAndroidSurfaceKHR), result);
            }
            return surface;
        }
        
        public static List<DisplayPropertiesKHR> GetPhysicalDeviceDisplayPropertiesKHR(PhysicalDevice physicalDevice)
        {
            UInt32 listLength;
            var result = vkGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPropertiesKHR), result);
            
            var size = Marshal.SizeOf(typeof(Interop.DisplayPropertiesKHR));
            var ptrDisplayPropertiesKHR = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice.NativePointer, &listLength, (Interop.DisplayPropertiesKHR*)ptrDisplayPropertiesKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPropertiesKHR), result);
            
            var list = new List<DisplayPropertiesKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DisplayPropertiesKHR();
                item.NativePointer = &((Interop.DisplayPropertiesKHR*)ptrDisplayPropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayPlanePropertiesKHR> GetPhysicalDeviceDisplayPlanePropertiesKHR(PhysicalDevice physicalDevice)
        {
            UInt32 listLength;
            var result = vkGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPlanePropertiesKHR), result);
            
            var size = Marshal.SizeOf(typeof(Interop.DisplayPlanePropertiesKHR));
            var ptrDisplayPlanePropertiesKHR = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice.NativePointer, &listLength, (Interop.DisplayPlanePropertiesKHR*)ptrDisplayPlanePropertiesKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPlanePropertiesKHR), result);
            
            var list = new List<DisplayPlanePropertiesKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DisplayPlanePropertiesKHR();
                item.NativePointer = &((Interop.DisplayPlanePropertiesKHR*)ptrDisplayPlanePropertiesKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        /*public static List<DisplayKHR> GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex)
        {
            UInt32 listLength;
            var result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativePointer, planeIndex, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            var size = Marshal.SizeOf(typeof(IntPtr));
            var ptrDisplayKHR = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativePointer, planeIndex, &listLength, (IntPtr*)ptrDisplayKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            var list = new List<DisplayKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DisplayKHR();
                item.NativePointer = ((IntPtr*)ptrDisplayKHR)[x];
                list.Add(item);
            }
            
            return list;
        }*/
        
        public static List<DisplayModePropertiesKHR> GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display)
        {
            UInt32 listLength;
            var result = vkGetDisplayModePropertiesKHR(physicalDevice.NativePointer, display.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            var size = Marshal.SizeOf(typeof(Interop.DisplayModePropertiesKHR));
            var ptrDisplayModePropertiesKHR = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkGetDisplayModePropertiesKHR(physicalDevice.NativePointer, display.NativePointer, &listLength, (Interop.DisplayModePropertiesKHR*)ptrDisplayModePropertiesKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            var list = new List<DisplayModePropertiesKHR>();
            for(var x = 0; x < listLength; x++)
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
            fixed(UInt64* ptrDisplayModeKHR = &mode.NativePointer)
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
            fixed(UInt64* ptrSurfaceKHR = &surface.NativePointer)
            {
                var result = vkCreateDisplayPlaneSurfaceKHR(instance.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSurfaceKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateDisplayPlaneSurfaceKHR), result);
            }
            return surface;
        }
        
        public static List<SwapchainKHR> CreateSharedSwapchainsKHR(Device device, List<SwapchainCreateInfoKHR> createInfos, AllocationCallbacks allocator = null)
        {
            // hasArrayArguments
            var swapchainCount = (UInt32)createInfos.Count;
            var _createInfosSize = Marshal.SizeOf(typeof(Interop.SwapchainCreateInfoKHR));
            var _createInfosPtr = (void**)Marshal.AllocHGlobal((int)(_createInfosSize * swapchainCount));
            for(var x = 0; x < swapchainCount; x++)
                _createInfosPtr[x] = createInfos[x].NativePointer;
            
            var result = vkCreateSharedSwapchainsKHR(device.NativePointer, swapchainCount, (Interop.SwapchainCreateInfoKHR*)_createInfosPtr, (allocator != null) ? allocator.NativePointer : null, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkCreateSharedSwapchainsKHR), result);
            throw new NotImplementedException();
        }
        
        public static SurfaceKHR CreateMirSurfaceKHR(Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var surface = new SurfaceKHR();
            fixed(UInt64* ptrSurfaceKHR = &surface.NativePointer)
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
            UInt32 listLength;
            var result = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice.NativePointer, surface.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceFormatsKHR), result);
            
            var size = Marshal.SizeOf(typeof(Interop.SurfaceFormatKHR));
            var ptrSurfaceFormatKHR = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice.NativePointer, surface.NativePointer, &listLength, (Interop.SurfaceFormatKHR*)ptrSurfaceFormatKHR);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceFormatsKHR), result);
            
            var list = new List<SurfaceFormatKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new SurfaceFormatKHR();
                item.NativePointer = &((Interop.SurfaceFormatKHR*)ptrSurfaceFormatKHR)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<PresentMode> GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            UInt32 listLength;
            var result = vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice.NativePointer, surface.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfacePresentModesKHR), result);
            
            var size = Marshal.SizeOf(typeof(Int32));
            var ptrPresentMode = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice.NativePointer, surface.NativePointer, &listLength, (PresentMode*)ptrPresentMode);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfacePresentModesKHR), result);
            
            var list = new List<PresentMode>();
            for(var x = 0; x < listLength; x++)
            {
                PresentMode item = ((PresentMode*)ptrPresentMode)[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static SwapchainKHR CreateSwapchainKHR(Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator = null)
        {
            var swapchain = new SwapchainKHR();
            //fixed(UInt64* ptrSwapchainKHR = &swapchain.NativePointer)
            //{
                var result = vkCreateSwapchainKHR(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, &swapchain);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateSwapchainKHR), result);
            //}
            return swapchain;
        }
        
        public static void DestroySwapchainKHR(Device device, SwapchainKHR swapchain, AllocationCallbacks allocator = null)
        {
            vkDestroySwapchainKHR(device.NativePointer, swapchain.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /*public static List<Image> GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain)
        {
            UInt32 listLength;
            var result = vkGetSwapchainImagesKHR(device.NativePointer, swapchain.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            var size = Marshal.SizeOf(typeof(IntPtr));
            var ptrImage = Marshal.AllocHGlobal((int)(size * listLength));
            result = vkGetSwapchainImagesKHR(device.NativePointer, swapchain.NativePointer, &listLength, (IntPtr*)ptrImage);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            var list = new List<Image>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new Image();
                item.NativePointer = ((IntPtr*)ptrImage)[x];
                list.Add(item);
            }
            
            return list;
        }*/
        
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
            fixed(UInt64* ptrSurfaceKHR = &surface.NativePointer)
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
            fixed(UInt64* ptrSurfaceKHR = &surface.NativePointer)
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
            fixed(UInt64* ptrSurfaceKHR = &surface.NativePointer)
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
            fixed(UInt64* ptrSurfaceKHR = &surface.NativePointer)
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
            fixed(UInt64* ptrDebugReportCallbackEXT = &callback.NativePointer)
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
