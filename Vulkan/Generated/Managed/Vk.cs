using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Vulkan.Managed
{
    using static Unmanaged.VulkanBinding;
    
    public unsafe static class Vk
    {
        /// <param name="allocator">Optional</param>
        public static Instance CreateInstance(InstanceCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="instance">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyInstance(Instance instance, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyInstance((instance != null) ? instance.NativePointer : IntPtr.Zero, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static List<PhysicalDevice> EnumeratePhysicalDevices(Instance instance)
        {
            UInt32 listLength;
            var result = vkEnumeratePhysicalDevices(instance.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            var arrayPhysicalDevice = new IntPtr[listLength];
            fixed(IntPtr* resultPtr = &arrayPhysicalDevice[0])
                result = vkEnumeratePhysicalDevices(instance.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumeratePhysicalDevices), result);
            
            var list = new List<PhysicalDevice>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new PhysicalDevice();
                item.NativePointer = arrayPhysicalDevice[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static IntPtr GetDeviceProcAddr(Device device, String name)
        {
            var result = vkGetDeviceProcAddr(device.NativePointer, name);
            return result;
        }
        
        /// <param name="instance">Optional</param>
        public static IntPtr GetInstanceProcAddr(Instance instance, String name)
        {
            var result = vkGetInstanceProcAddr((instance != null) ? instance.NativePointer : IntPtr.Zero, name);
            return result;
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
            
            var arrayQueueFamilyProperties = new QueueFamilyProperties[listLength];
            fixed(QueueFamilyProperties* resultPtr = &arrayQueueFamilyProperties[0])
                vkGetPhysicalDeviceQueueFamilyProperties(physicalDevice.NativePointer, &listLength, resultPtr);
            
            var list = new List<QueueFamilyProperties>();
            for(var x = 0; x < listLength; x++)
            {
                list.Add(arrayQueueFamilyProperties[x]);
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
            vkGetPhysicalDeviceFeatures(physicalDevice.NativePointer, &features);
            return features;
        }
        
        public static FormatProperties GetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format)
        {
            var formatProperties = new FormatProperties();
            vkGetPhysicalDeviceFormatProperties(physicalDevice.NativePointer, format, &formatProperties);
            return formatProperties;
        }
        
        /// <param name="flags">Optional</param>
        public static ImageFormatProperties GetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags = default(ImageCreateFlags))
        {
            var imageFormatProperties = new ImageFormatProperties();
            var result = vkGetPhysicalDeviceImageFormatProperties(physicalDevice.NativePointer, format, type, tiling, usage, flags, &imageFormatProperties);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceImageFormatProperties), result);
            return imageFormatProperties;
        }
        
        /// <param name="allocator">Optional</param>
        public static Device CreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="device">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDevice(Device device, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyDevice((device != null) ? device.NativePointer : IntPtr.Zero, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static List<LayerProperties> EnumerateInstanceLayerProperties()
        {
            UInt32 listLength;
            var result = vkEnumerateInstanceLayerProperties(&listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            var arrayLayerProperties = new Unmanaged.LayerProperties[listLength];
            fixed(Unmanaged.LayerProperties* resultPtr = &arrayLayerProperties[0])
                result = vkEnumerateInstanceLayerProperties(&listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new LayerProperties();
                fixed(Unmanaged.LayerProperties* itemPtr = &arrayLayerProperties[x])
                    item.NativePointer = itemPtr;
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="layerName">Optional</param>
        public static List<ExtensionProperties> EnumerateInstanceExtensionProperties(String layerName)
        {
            UInt32 listLength;
            var result = vkEnumerateInstanceExtensionProperties(layerName, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            var arrayExtensionProperties = new Unmanaged.ExtensionProperties[listLength];
            fixed(Unmanaged.ExtensionProperties* resultPtr = &arrayExtensionProperties[0])
                result = vkEnumerateInstanceExtensionProperties(layerName, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateInstanceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new ExtensionProperties();
                fixed(Unmanaged.ExtensionProperties* itemPtr = &arrayExtensionProperties[x])
                    item.NativePointer = itemPtr;
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="physicalDevice">Optional</param>
        public static List<LayerProperties> EnumerateDeviceLayerProperties(PhysicalDevice physicalDevice)
        {
            UInt32 listLength;
            var result = vkEnumerateDeviceLayerProperties(physicalDevice.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            var arrayLayerProperties = new Unmanaged.LayerProperties[listLength];
            fixed(Unmanaged.LayerProperties* resultPtr = &arrayLayerProperties[0])
                result = vkEnumerateDeviceLayerProperties(physicalDevice.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceLayerProperties), result);
            
            var list = new List<LayerProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new LayerProperties();
                fixed(Unmanaged.LayerProperties* itemPtr = &arrayLayerProperties[x])
                    item.NativePointer = itemPtr;
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="layerName">Optional</param>
        public static List<ExtensionProperties> EnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, String layerName = default(String))
        {
            UInt32 listLength;
            var result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativePointer, layerName, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            var arrayExtensionProperties = new Unmanaged.ExtensionProperties[listLength];
            fixed(Unmanaged.ExtensionProperties* resultPtr = &arrayExtensionProperties[0])
                result = vkEnumerateDeviceExtensionProperties(physicalDevice.NativePointer, layerName, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEnumerateDeviceExtensionProperties), result);
            
            var list = new List<ExtensionProperties>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new ExtensionProperties();
                fixed(Unmanaged.ExtensionProperties* itemPtr = &arrayExtensionProperties[x])
                    item.NativePointer = itemPtr;
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
        
        /// <param name="queue">ExternSync</param>
        /// <param name="fence">ExternSync</param>
        public static void QueueSubmit(Queue queue, SubmitInfo[] submits, Fence fence = default(Fence))
        {
            var submitCount = (submits != null) ? (UInt32)submits.Length : 0;
            Unmanaged.SubmitInfo[] submitsArray = (submits != null) ? submits.Select(x => *x.NativePointer).ToArray() : null;
            var result = vkQueueSubmit(queue.NativePointer, submitCount, submitsArray, (fence != null) ? fence.NativePointer : 0);
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
        
        /// <param name="allocator">Optional</param>
        public static DeviceMemory AllocateMemory(Device device, MemoryAllocateInfo allocateInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="memory">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void FreeMemory(Device device, DeviceMemory memory = default(DeviceMemory), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkFreeMemory(device.NativePointer, (memory != null) ? memory.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="memory">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static IntPtr MapMemory(Device device, DeviceMemory memory, DeviceSize offset, DeviceSize size, MemoryMapFlags flags = default(MemoryMapFlags))
        {
            var data = new IntPtr();
            var result = vkMapMemory(device.NativePointer, memory.NativePointer, offset, size, flags, &data);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkMapMemory), result);
            return data;
        }
        
        /// <param name="memory">ExternSync</param>
        public static void UnmapMemory(Device device, DeviceMemory memory)
        {
            vkUnmapMemory(device.NativePointer, memory.NativePointer);
        }
        
        public static void FlushMappedMemoryRanges(Device device, MappedMemoryRange[] memoryRanges)
        {
            var memoryRangeCount = (memoryRanges != null) ? (UInt32)memoryRanges.Length : 0;
            Unmanaged.MappedMemoryRange[] memoryRangesArray = (memoryRanges != null) ? memoryRanges.Select(x => *x.NativePointer).ToArray() : null;
            var result = vkFlushMappedMemoryRanges(device.NativePointer, memoryRangeCount, memoryRangesArray);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkFlushMappedMemoryRanges), result);
        }
        
        public static void InvalidateMappedMemoryRanges(Device device, MappedMemoryRange[] memoryRanges)
        {
            var memoryRangeCount = (memoryRanges != null) ? (UInt32)memoryRanges.Length : 0;
            Unmanaged.MappedMemoryRange[] memoryRangesArray = (memoryRanges != null) ? memoryRanges.Select(x => *x.NativePointer).ToArray() : null;
            var result = vkInvalidateMappedMemoryRanges(device.NativePointer, memoryRangeCount, memoryRangesArray);
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
            vkGetBufferMemoryRequirements(device.NativePointer, buffer.NativePointer, &memoryRequirements);
            return memoryRequirements;
        }
        
        /// <param name="buffer">ExternSync</param>
        public static void BindBufferMemory(Device device, Buffer buffer, DeviceMemory memory, DeviceSize memoryOffset)
        {
            var result = vkBindBufferMemory(device.NativePointer, buffer.NativePointer, memory.NativePointer, memoryOffset);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkBindBufferMemory), result);
        }
        
        public static MemoryRequirements GetImageMemoryRequirements(Device device, Image image)
        {
            var memoryRequirements = new MemoryRequirements();
            vkGetImageMemoryRequirements(device.NativePointer, image.NativePointer, &memoryRequirements);
            return memoryRequirements;
        }
        
        /// <param name="image">ExternSync</param>
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
            
            var arraySparseImageMemoryRequirements = new SparseImageMemoryRequirements[listLength];
            fixed(SparseImageMemoryRequirements* resultPtr = &arraySparseImageMemoryRequirements[0])
                vkGetImageSparseMemoryRequirements(device.NativePointer, image.NativePointer, &listLength, resultPtr);
            
            var list = new List<SparseImageMemoryRequirements>();
            for(var x = 0; x < listLength; x++)
            {
                list.Add(arraySparseImageMemoryRequirements[x]);
            }
            
            return list;
        }
        
        public static List<SparseImageFormatProperties> GetPhysicalDeviceSparseImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
        {
            UInt32 listLength;
            vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativePointer, format, type, samples, usage, tiling, &listLength, null);
            
            var arraySparseImageFormatProperties = new SparseImageFormatProperties[listLength];
            fixed(SparseImageFormatProperties* resultPtr = &arraySparseImageFormatProperties[0])
                vkGetPhysicalDeviceSparseImageFormatProperties(physicalDevice.NativePointer, format, type, samples, usage, tiling, &listLength, resultPtr);
            
            var list = new List<SparseImageFormatProperties>();
            for(var x = 0; x < listLength; x++)
            {
                list.Add(arraySparseImageFormatProperties[x]);
            }
            
            return list;
        }
        
        /// <summary>
        /// [<see cref="QueueFlags"/>: Sparse_binding] 
        /// </summary>
        /// <param name="queue">ExternSync</param>
        /// <param name="fence">ExternSync</param>
        public static void QueueBindSparse(Queue queue, BindSparseInfo[] bindInfo, Fence fence = default(Fence))
        {
            var bindInfoCount = (bindInfo != null) ? (UInt32)bindInfo.Length : 0;
            Unmanaged.BindSparseInfo[] bindInfoArray = (bindInfo != null) ? bindInfo.Select(x => *x.NativePointer).ToArray() : null;
            var result = vkQueueBindSparse(queue.NativePointer, bindInfoCount, bindInfoArray, (fence != null) ? fence.NativePointer : 0);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkQueueBindSparse), result);
        }
        
        /// <param name="allocator">Optional</param>
        public static Fence CreateFence(Device device, FenceCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="fence">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyFence(Device device, Fence fence = default(Fence), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyFence(device.NativePointer, (fence != null) ? fence.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="fences">ExternSync</param>
        public static void ResetFences(Device device, Fence[] fences)
        {
            var fenceCount = (fences != null) ? (UInt32)fences.Length : 0;
            UInt64[] fencesArray = (fences != null) ? fences.Select(x => x.NativePointer).ToArray() : null;
            var result = vkResetFences(device.NativePointer, fenceCount, fencesArray);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetFences), result);
        }
        
        public static void GetFenceStatus(Device device, Fence fence)
        {
            var result = vkGetFenceStatus(device.NativePointer, fence.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetFenceStatus), result);
        }
        
        public static void WaitForFences(Device device, Fence[] fences, Bool32 waitAll, UInt64 timeout)
        {
            var fenceCount = (fences != null) ? (UInt32)fences.Length : 0;
            UInt64[] fencesArray = (fences != null) ? fences.Select(x => x.NativePointer).ToArray() : null;
            var result = vkWaitForFences(device.NativePointer, fenceCount, fencesArray, waitAll, timeout);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkWaitForFences), result);
        }
        
        /// <param name="allocator">Optional</param>
        public static Semaphore CreateSemaphore(Device device, SemaphoreCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="semaphore">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySemaphore(Device device, Semaphore semaphore = default(Semaphore), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroySemaphore(device.NativePointer, (semaphore != null) ? semaphore.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static Event CreateEvent(Device device, EventCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="@event">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyEvent(Device device, Event @event = default(Event), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyEvent(device.NativePointer, (@event != null) ? @event.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void GetEventStatus(Device device, Event @event)
        {
            var result = vkGetEventStatus(device.NativePointer, @event.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetEventStatus), result);
        }
        
        /// <param name="@event">ExternSync</param>
        public static void SetEvent(Device device, Event @event)
        {
            var result = vkSetEvent(device.NativePointer, @event.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkSetEvent), result);
        }
        
        /// <param name="@event">ExternSync</param>
        public static void ResetEvent(Device device, Event @event)
        {
            var result = vkResetEvent(device.NativePointer, @event.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetEvent), result);
        }
        
        /// <param name="allocator">Optional</param>
        public static QueryPool CreateQueryPool(Device device, QueryPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="queryPool">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyQueryPool(Device device, QueryPool queryPool = default(QueryPool), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyQueryPool(device.NativePointer, (queryPool != null) ? queryPool.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="flags">Optional</param>
        public static void GetQueryPoolResults(Device device, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, IntPtr[] data, DeviceSize stride, QueryResultFlags flags = default(QueryResultFlags))
        {
            var dataSize = (data != null) ? (UInt32)data.Length : 0;
            IntPtr[] dataArray = (data != null) ? data.ToArray() : null;
            var result = vkGetQueryPoolResults(device.NativePointer, queryPool.NativePointer, firstQuery, queryCount, dataSize, dataArray, stride, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetQueryPoolResults), result);
        }
        
        /// <param name="allocator">Optional</param>
        public static Buffer CreateBuffer(Device device, BufferCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="buffer">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyBuffer(Device device, Buffer buffer = default(Buffer), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyBuffer(device.NativePointer, (buffer != null) ? buffer.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static BufferView CreateBufferView(Device device, BufferViewCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="bufferView">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyBufferView(Device device, BufferView bufferView = default(BufferView), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyBufferView(device.NativePointer, (bufferView != null) ? bufferView.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static Image CreateImage(Device device, ImageCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="image">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyImage(Device device, Image image = default(Image), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyImage(device.NativePointer, (image != null) ? image.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static SubresourceLayout GetImageSubresourceLayout(Device device, Image image, ImageSubresource subresource)
        {
            var layout = new SubresourceLayout();
            vkGetImageSubresourceLayout(device.NativePointer, image.NativePointer, &subresource, &layout);
            return layout;
        }
        
        /// <param name="allocator">Optional</param>
        public static ImageView CreateImageView(Device device, ImageViewCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="imageView">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyImageView(Device device, ImageView imageView = default(ImageView), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyImageView(device.NativePointer, (imageView != null) ? imageView.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static ShaderModule CreateShaderModule(Device device, ShaderModuleCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="shaderModule">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyShaderModule(Device device, ShaderModule shaderModule = default(ShaderModule), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyShaderModule(device.NativePointer, (shaderModule != null) ? shaderModule.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static PipelineCache CreatePipelineCache(Device device, PipelineCacheCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="pipelineCache">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipelineCache(Device device, PipelineCache pipelineCache = default(PipelineCache), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyPipelineCache(device.NativePointer, (pipelineCache != null) ? pipelineCache.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static List<IntPtr> GetPipelineCacheData(Device device, PipelineCache pipelineCache)
        {
            UInt32 listLength;
            var result = vkGetPipelineCacheData(device.NativePointer, pipelineCache.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPipelineCacheData), result);
            
            var arrayIntPtr = new IntPtr[listLength];
            fixed(IntPtr* resultPtr = &arrayIntPtr[0])
                result = vkGetPipelineCacheData(device.NativePointer, pipelineCache.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPipelineCacheData), result);
            
            var list = new List<IntPtr>();
            for(var x = 0; x < listLength; x++)
            {
                list.Add(arrayIntPtr[x]);
            }
            
            return list;
        }
        
        /// <param name="dstCache">ExternSync</param>
        public static void MergePipelineCaches(Device device, PipelineCache dstCache, PipelineCache[] srcCaches)
        {
            var srcCacheCount = (srcCaches != null) ? (UInt32)srcCaches.Length : 0;
            UInt64[] srcCachesArray = (srcCaches != null) ? srcCaches.Select(x => x.NativePointer).ToArray() : null;
            var result = vkMergePipelineCaches(device.NativePointer, dstCache.NativePointer, srcCacheCount, srcCachesArray);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkMergePipelineCaches), result);
        }
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        public static List<Pipeline> CreateGraphicsPipelines(Device device, PipelineCache pipelineCache, GraphicsPipelineCreateInfo[] createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            var createInfoCount = (createInfos != null) ? (UInt32)createInfos.Length : 0;
            Unmanaged.GraphicsPipelineCreateInfo[] createInfosArray = (createInfos != null) ? createInfos.Select(x => *x.NativePointer).ToArray() : null;
            var listLength = createInfoCount;
            Result result;
            
            var arrayPipeline = new UInt64[listLength];
            fixed(UInt64* resultPtr = &arrayPipeline[0])
                result = vkCreateGraphicsPipelines(device.NativePointer, (pipelineCache != null) ? pipelineCache.NativePointer : 0, listLength, createInfosArray, (allocator != null) ? allocator.NativePointer : null, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkCreateGraphicsPipelines), result);
            
            var list = new List<Pipeline>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new Pipeline();
                item.NativePointer = arrayPipeline[x];
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="pipelineCache">Optional</param>
        /// <param name="allocator">Optional</param>
        public static List<Pipeline> CreateComputePipelines(Device device, PipelineCache pipelineCache, ComputePipelineCreateInfo[] createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            var createInfoCount = (createInfos != null) ? (UInt32)createInfos.Length : 0;
            Unmanaged.ComputePipelineCreateInfo[] createInfosArray = (createInfos != null) ? createInfos.Select(x => *x.NativePointer).ToArray() : null;
            var listLength = createInfoCount;
            Result result;
            
            var arrayPipeline = new UInt64[listLength];
            fixed(UInt64* resultPtr = &arrayPipeline[0])
                result = vkCreateComputePipelines(device.NativePointer, (pipelineCache != null) ? pipelineCache.NativePointer : 0, listLength, createInfosArray, (allocator != null) ? allocator.NativePointer : null, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkCreateComputePipelines), result);
            
            var list = new List<Pipeline>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new Pipeline();
                item.NativePointer = arrayPipeline[x];
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="pipeline">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipeline(Device device, Pipeline pipeline = default(Pipeline), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyPipeline(device.NativePointer, (pipeline != null) ? pipeline.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static PipelineLayout CreatePipelineLayout(Device device, PipelineLayoutCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="pipelineLayout">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyPipelineLayout(Device device, PipelineLayout pipelineLayout = default(PipelineLayout), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyPipelineLayout(device.NativePointer, (pipelineLayout != null) ? pipelineLayout.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static Sampler CreateSampler(Device device, SamplerCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="sampler">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySampler(Device device, Sampler sampler = default(Sampler), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroySampler(device.NativePointer, (sampler != null) ? sampler.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static DescriptorSetLayout CreateDescriptorSetLayout(Device device, DescriptorSetLayoutCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="descriptorSetLayout">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDescriptorSetLayout(Device device, DescriptorSetLayout descriptorSetLayout = default(DescriptorSetLayout), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyDescriptorSetLayout(device.NativePointer, (descriptorSetLayout != null) ? descriptorSetLayout.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static DescriptorPool CreateDescriptorPool(Device device, DescriptorPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDescriptorPool(Device device, DescriptorPool descriptorPool = default(DescriptorPool), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyDescriptorPool(device.NativePointer, (descriptorPool != null) ? descriptorPool.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void ResetDescriptorPool(Device device, DescriptorPool descriptorPool, DescriptorPoolResetFlags flags = default(DescriptorPoolResetFlags))
        {
            var result = vkResetDescriptorPool(device.NativePointer, descriptorPool.NativePointer, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetDescriptorPool), result);
        }
        
        public static List<DescriptorSet> AllocateDescriptorSets(Device device, DescriptorSetAllocateInfo allocateInfo)
        {
            var listLength = allocateInfo.NativePointer->DescriptorSetCount;
            Result result;
            
            var arrayDescriptorSet = new UInt64[listLength];
            fixed(UInt64* resultPtr = &arrayDescriptorSet[0])
                result = vkAllocateDescriptorSets(device.NativePointer, allocateInfo.NativePointer, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkAllocateDescriptorSets), result);
            
            var list = new List<DescriptorSet>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DescriptorSet();
                item.NativePointer = arrayDescriptorSet[x];
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="descriptorPool">ExternSync</param>
        /// <param name="descriptorSets">No Auto Validity</param>
        public static void FreeDescriptorSets(Device device, DescriptorPool descriptorPool, DescriptorSet[] descriptorSets)
        {
            var descriptorSetCount = (descriptorSets != null) ? (UInt32)descriptorSets.Length : 0;
            UInt64[] descriptorSetsArray = (descriptorSets != null) ? descriptorSets.Select(x => x.NativePointer).ToArray() : null;
            var result = vkFreeDescriptorSets(device.NativePointer, descriptorPool.NativePointer, descriptorSetCount, descriptorSetsArray);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkFreeDescriptorSets), result);
        }
        
        public static void UpdateDescriptorSets(Device device, WriteDescriptorSet[] descriptorWrites, CopyDescriptorSet[] descriptorCopies)
        {
            var descriptorWriteCount = (descriptorWrites != null) ? (UInt32)descriptorWrites.Length : 0;
            Unmanaged.WriteDescriptorSet[] descriptorWritesArray = (descriptorWrites != null) ? descriptorWrites.Select(x => *x.NativePointer).ToArray() : null;
            var descriptorCopyCount = (descriptorCopies != null) ? (UInt32)descriptorCopies.Length : 0;
            Unmanaged.CopyDescriptorSet[] descriptorCopiesArray = (descriptorCopies != null) ? descriptorCopies.Select(x => *x.NativePointer).ToArray() : null;
            vkUpdateDescriptorSets(device.NativePointer, descriptorWriteCount, descriptorWritesArray, descriptorCopyCount, descriptorCopiesArray);
        }
        
        /// <param name="allocator">Optional</param>
        public static Framebuffer CreateFramebuffer(Device device, FramebufferCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="framebuffer">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyFramebuffer(Device device, Framebuffer framebuffer = default(Framebuffer), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyFramebuffer(device.NativePointer, (framebuffer != null) ? framebuffer.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="allocator">Optional</param>
        public static RenderPass CreateRenderPass(Device device, RenderPassCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="renderPass">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyRenderPass(Device device, RenderPass renderPass = default(RenderPass), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyRenderPass(device.NativePointer, (renderPass != null) ? renderPass.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static Extent2D GetRenderAreaGranularity(Device device, RenderPass renderPass)
        {
            var granularity = new Extent2D();
            vkGetRenderAreaGranularity(device.NativePointer, renderPass.NativePointer, &granularity);
            return granularity;
        }
        
        /// <param name="allocator">Optional</param>
        public static CommandPool CreateCommandPool(Device device, CommandPoolCreateInfo createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyCommandPool(Device device, CommandPool commandPool = default(CommandPool), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyCommandPool(device.NativePointer, (commandPool != null) ? commandPool.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void ResetCommandPool(Device device, CommandPool commandPool, CommandPoolResetFlags flags = default(CommandPoolResetFlags))
        {
            var result = vkResetCommandPool(device.NativePointer, commandPool.NativePointer, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetCommandPool), result);
        }
        
        public static List<CommandBuffer> AllocateCommandBuffers(Device device, CommandBufferAllocateInfo allocateInfo)
        {
            var listLength = allocateInfo.NativePointer->CommandBufferCount;
            Result result;
            
            var arrayCommandBuffer = new IntPtr[listLength];
            fixed(IntPtr* resultPtr = &arrayCommandBuffer[0])
                result = vkAllocateCommandBuffers(device.NativePointer, allocateInfo.NativePointer, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkAllocateCommandBuffers), result);
            
            var list = new List<CommandBuffer>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new CommandBuffer();
                item.NativePointer = arrayCommandBuffer[x];
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="commandPool">ExternSync</param>
        /// <param name="commandBuffers">No Auto Validity</param>
        public static void FreeCommandBuffers(Device device, CommandPool commandPool, CommandBuffer[] commandBuffers)
        {
            var commandBufferCount = (commandBuffers != null) ? (UInt32)commandBuffers.Length : 0;
            IntPtr[] commandBuffersArray = (commandBuffers != null) ? commandBuffers.Select(x => x.NativePointer).ToArray() : null;
            vkFreeCommandBuffers(device.NativePointer, commandPool.NativePointer, commandBufferCount, commandBuffersArray);
        }
        
        /// <param name="commandBuffer">ExternSync</param>
        public static void BeginCommandBuffer(CommandBuffer commandBuffer, CommandBufferBeginInfo beginInfo)
        {
            var result = vkBeginCommandBuffer(commandBuffer.NativePointer, beginInfo.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkBeginCommandBuffer), result);
        }
        
        /// <param name="commandBuffer">ExternSync</param>
        public static void EndCommandBuffer(CommandBuffer commandBuffer)
        {
            var result = vkEndCommandBuffer(commandBuffer.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkEndCommandBuffer), result);
        }
        
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void ResetCommandBuffer(CommandBuffer commandBuffer, CommandBufferResetFlags flags = default(CommandBufferResetFlags))
        {
            var result = vkResetCommandBuffer(commandBuffer.NativePointer, flags);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkResetCommandBuffer), result);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindPipeline(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, Pipeline pipeline)
        {
            vkCmdBindPipeline(commandBuffer.NativePointer, pipelineBindPoint, pipeline.NativePointer);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetViewport(CommandBuffer commandBuffer, UInt32 firstViewport, Viewport[] viewports)
        {
            var viewportCount = (viewports != null) ? (UInt32)viewports.Length : 0;
            Viewport[] viewportsArray = (viewports != null) ? viewports.ToArray() : null;
            vkCmdSetViewport(commandBuffer.NativePointer, firstViewport, viewportCount, viewportsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetScissor(CommandBuffer commandBuffer, UInt32 firstScissor, Rect2D[] scissors)
        {
            var scissorCount = (scissors != null) ? (UInt32)scissors.Length : 0;
            Rect2D[] scissorsArray = (scissors != null) ? scissors.ToArray() : null;
            vkCmdSetScissor(commandBuffer.NativePointer, firstScissor, scissorCount, scissorsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetLineWidth(CommandBuffer commandBuffer, Single lineWidth)
        {
            vkCmdSetLineWidth(commandBuffer.NativePointer, lineWidth);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetDepthBias(CommandBuffer commandBuffer, Single depthBiasConstantFactor, Single depthBiasClamp, Single depthBiasSlopeFactor)
        {
            vkCmdSetDepthBias(commandBuffer.NativePointer, depthBiasConstantFactor, depthBiasClamp, depthBiasSlopeFactor);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetBlendConstants(CommandBuffer commandBuffer, Single blendConstants)
        {
            vkCmdSetBlendConstants(commandBuffer.NativePointer, blendConstants);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetDepthBounds(CommandBuffer commandBuffer, Single minDepthBounds, Single maxDepthBounds)
        {
            vkCmdSetDepthBounds(commandBuffer.NativePointer, minDepthBounds, maxDepthBounds);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetStencilCompareMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 compareMask)
        {
            vkCmdSetStencilCompareMask(commandBuffer.NativePointer, faceMask, compareMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetStencilWriteMask(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 writeMask)
        {
            vkCmdSetStencilWriteMask(commandBuffer.NativePointer, faceMask, writeMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetStencilReference(CommandBuffer commandBuffer, StencilFaceFlags faceMask, UInt32 reference)
        {
            vkCmdSetStencilReference(commandBuffer.NativePointer, faceMask, reference);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindDescriptorSets(CommandBuffer commandBuffer, PipelineBindPoint pipelineBindPoint, PipelineLayout layout, UInt32 firstSet, DescriptorSet[] descriptorSets, UInt32[] dynamicOffsets)
        {
            var descriptorSetCount = (descriptorSets != null) ? (UInt32)descriptorSets.Length : 0;
            UInt64[] descriptorSetsArray = (descriptorSets != null) ? descriptorSets.Select(x => x.NativePointer).ToArray() : null;
            var dynamicOffsetCount = (dynamicOffsets != null) ? (UInt32)dynamicOffsets.Length : 0;
            UInt32[] dynamicOffsetsArray = (dynamicOffsets != null) ? dynamicOffsets.ToArray() : null;
            vkCmdBindDescriptorSets(commandBuffer.NativePointer, pipelineBindPoint, layout.NativePointer, firstSet, descriptorSetCount, descriptorSetsArray, dynamicOffsetCount, dynamicOffsetsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindIndexBuffer(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, IndexType indexType)
        {
            vkCmdBindIndexBuffer(commandBuffer.NativePointer, buffer.NativePointer, offset, indexType);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBindVertexBuffers(CommandBuffer commandBuffer, UInt32 firstBinding, Buffer[] buffers, DeviceSize[] offsets)
        {
            var bindingCount = (buffers != null) ? (UInt32)buffers.Length : 0;
            UInt64[] buffersArray = (buffers != null) ? buffers.Select(x => x.NativePointer).ToArray() : null;
            DeviceSize[] offsetsArray = (offsets != null) ? offsets.ToArray() : null;
            vkCmdBindVertexBuffers(commandBuffer.NativePointer, firstBinding, bindingCount, buffersArray, offsetsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDraw(CommandBuffer commandBuffer, UInt32 vertexCount, UInt32 instanceCount, UInt32 firstVertex, UInt32 firstInstance)
        {
            vkCmdDraw(commandBuffer.NativePointer, vertexCount, instanceCount, firstVertex, firstInstance);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDrawIndexed(CommandBuffer commandBuffer, UInt32 indexCount, UInt32 instanceCount, UInt32 firstIndex, Int32 vertexOffset, UInt32 firstInstance)
        {
            vkCmdDrawIndexed(commandBuffer.NativePointer, indexCount, instanceCount, firstIndex, vertexOffset, firstInstance);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDrawIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            vkCmdDrawIndirect(commandBuffer.NativePointer, buffer.NativePointer, offset, drawCount, stride);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDrawIndexedIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset, UInt32 drawCount, UInt32 stride)
        {
            vkCmdDrawIndexedIndirect(commandBuffer.NativePointer, buffer.NativePointer, offset, drawCount, stride);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDispatch(CommandBuffer commandBuffer, UInt32 x, UInt32 y, UInt32 z)
        {
            vkCmdDispatch(commandBuffer.NativePointer, x, y, z);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdDispatchIndirect(CommandBuffer commandBuffer, Buffer buffer, DeviceSize offset)
        {
            vkCmdDispatchIndirect(commandBuffer.NativePointer, buffer.NativePointer, offset);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyBuffer(CommandBuffer commandBuffer, Buffer srcBuffer, Buffer dstBuffer, BufferCopy[] regions)
        {
            var regionCount = (regions != null) ? (UInt32)regions.Length : 0;
            BufferCopy[] regionsArray = (regions != null) ? regions.ToArray() : null;
            vkCmdCopyBuffer(commandBuffer.NativePointer, srcBuffer.NativePointer, dstBuffer.NativePointer, regionCount, regionsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, ImageCopy[] regions)
        {
            var regionCount = (regions != null) ? (UInt32)regions.Length : 0;
            ImageCopy[] regionsArray = (regions != null) ? regions.ToArray() : null;
            vkCmdCopyImage(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstImage.NativePointer, dstImageLayout, regionCount, regionsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBlitImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, ImageBlit[] regions, Filter filter)
        {
            var regionCount = (regions != null) ? (UInt32)regions.Length : 0;
            Unmanaged.ImageBlit[] regionsArray = (regions != null) ? regions.Select(x => *x.NativePointer).ToArray() : null;
            vkCmdBlitImage(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstImage.NativePointer, dstImageLayout, regionCount, regionsArray, filter);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyBufferToImage(CommandBuffer commandBuffer, Buffer srcBuffer, Image dstImage, ImageLayout dstImageLayout, BufferImageCopy[] regions)
        {
            var regionCount = (regions != null) ? (UInt32)regions.Length : 0;
            BufferImageCopy[] regionsArray = (regions != null) ? regions.ToArray() : null;
            vkCmdCopyBufferToImage(commandBuffer.NativePointer, srcBuffer.NativePointer, dstImage.NativePointer, dstImageLayout, regionCount, regionsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdCopyImageToBuffer(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Buffer dstBuffer, BufferImageCopy[] regions)
        {
            var regionCount = (regions != null) ? (UInt32)regions.Length : 0;
            BufferImageCopy[] regionsArray = (regions != null) ? regions.ToArray() : null;
            vkCmdCopyImageToBuffer(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstBuffer.NativePointer, regionCount, regionsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdUpdateBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, Byte[] data)
        {
            var dataSize = (data != null) ? (UInt32)data.Length : 0;
            Byte[] dataArray = (data != null) ? data.ToArray() : null;
            vkCmdUpdateBuffer(commandBuffer.NativePointer, dstBuffer.NativePointer, dstOffset, dataSize, dataArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdFillBuffer(CommandBuffer commandBuffer, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize size, UInt32 data)
        {
            vkCmdFillBuffer(commandBuffer.NativePointer, dstBuffer.NativePointer, dstOffset, size, data);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdClearColorImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearColorValue color, ImageSubresourceRange[] ranges)
        {
            var rangeCount = (ranges != null) ? (UInt32)ranges.Length : 0;
            ImageSubresourceRange[] rangesArray = (ranges != null) ? ranges.ToArray() : null;
            vkCmdClearColorImage(commandBuffer.NativePointer, image.NativePointer, imageLayout, &color, rangeCount, rangesArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdClearDepthStencilImage(CommandBuffer commandBuffer, Image image, ImageLayout imageLayout, ClearDepthStencilValue depthStencil, ImageSubresourceRange[] ranges)
        {
            var rangeCount = (ranges != null) ? (UInt32)ranges.Length : 0;
            ImageSubresourceRange[] rangesArray = (ranges != null) ? ranges.ToArray() : null;
            vkCmdClearDepthStencilImage(commandBuffer.NativePointer, image.NativePointer, imageLayout, &depthStencil, rangeCount, rangesArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdClearAttachments(CommandBuffer commandBuffer, ClearAttachment[] attachments, ClearRect[] rects)
        {
            var attachmentCount = (attachments != null) ? (UInt32)attachments.Length : 0;
            ClearAttachment[] attachmentsArray = (attachments != null) ? attachments.ToArray() : null;
            var rectCount = (rects != null) ? (UInt32)rects.Length : 0;
            ClearRect[] rectsArray = (rects != null) ? rects.ToArray() : null;
            vkCmdClearAttachments(commandBuffer.NativePointer, attachmentCount, attachmentsArray, rectCount, rectsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdResolveImage(CommandBuffer commandBuffer, Image srcImage, ImageLayout srcImageLayout, Image dstImage, ImageLayout dstImageLayout, ImageResolve[] regions)
        {
            var regionCount = (regions != null) ? (UInt32)regions.Length : 0;
            ImageResolve[] regionsArray = (regions != null) ? regions.ToArray() : null;
            vkCmdResolveImage(commandBuffer.NativePointer, srcImage.NativePointer, srcImageLayout, dstImage.NativePointer, dstImageLayout, regionCount, regionsArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdSetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdSetEvent(commandBuffer.NativePointer, @event.NativePointer, stageMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdResetEvent(CommandBuffer commandBuffer, Event @event, PipelineStageFlags stageMask)
        {
            vkCmdResetEvent(commandBuffer.NativePointer, @event.NativePointer, stageMask);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdWaitEvents(CommandBuffer commandBuffer, Event[] events, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, MemoryBarrier[] memoryBarriers, BufferMemoryBarrier[] bufferMemoryBarriers, ImageMemoryBarrier[] imageMemoryBarriers)
        {
            var eventCount = (events != null) ? (UInt32)events.Length : 0;
            UInt64[] eventsArray = (events != null) ? events.Select(x => x.NativePointer).ToArray() : null;
            var memoryBarrierCount = (memoryBarriers != null) ? (UInt32)memoryBarriers.Length : 0;
            Unmanaged.MemoryBarrier[] memoryBarriersArray = (memoryBarriers != null) ? memoryBarriers.Select(x => *x.NativePointer).ToArray() : null;
            var bufferMemoryBarrierCount = (bufferMemoryBarriers != null) ? (UInt32)bufferMemoryBarriers.Length : 0;
            Unmanaged.BufferMemoryBarrier[] bufferMemoryBarriersArray = (bufferMemoryBarriers != null) ? bufferMemoryBarriers.Select(x => *x.NativePointer).ToArray() : null;
            var imageMemoryBarrierCount = (imageMemoryBarriers != null) ? (UInt32)imageMemoryBarriers.Length : 0;
            Unmanaged.ImageMemoryBarrier[] imageMemoryBarriersArray = (imageMemoryBarriers != null) ? imageMemoryBarriers.Select(x => *x.NativePointer).ToArray() : null;
            vkCmdWaitEvents(commandBuffer.NativePointer, eventCount, eventsArray, srcStageMask, dstStageMask, memoryBarrierCount, memoryBarriersArray, bufferMemoryBarrierCount, bufferMemoryBarriersArray, imageMemoryBarrierCount, imageMemoryBarriersArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="dependencyFlags">Optional</param>
        public static void CmdPipelineBarrier(CommandBuffer commandBuffer, PipelineStageFlags srcStageMask, PipelineStageFlags dstStageMask, DependencyFlags dependencyFlags, MemoryBarrier[] memoryBarriers, BufferMemoryBarrier[] bufferMemoryBarriers, ImageMemoryBarrier[] imageMemoryBarriers)
        {
            var memoryBarrierCount = (memoryBarriers != null) ? (UInt32)memoryBarriers.Length : 0;
            Unmanaged.MemoryBarrier[] memoryBarriersArray = (memoryBarriers != null) ? memoryBarriers.Select(x => *x.NativePointer).ToArray() : null;
            var bufferMemoryBarrierCount = (bufferMemoryBarriers != null) ? (UInt32)bufferMemoryBarriers.Length : 0;
            Unmanaged.BufferMemoryBarrier[] bufferMemoryBarriersArray = (bufferMemoryBarriers != null) ? bufferMemoryBarriers.Select(x => *x.NativePointer).ToArray() : null;
            var imageMemoryBarrierCount = (imageMemoryBarriers != null) ? (UInt32)imageMemoryBarriers.Length : 0;
            Unmanaged.ImageMemoryBarrier[] imageMemoryBarriersArray = (imageMemoryBarriers != null) ? imageMemoryBarriers.Select(x => *x.NativePointer).ToArray() : null;
            vkCmdPipelineBarrier(commandBuffer.NativePointer, srcStageMask, dstStageMask, dependencyFlags, memoryBarrierCount, memoryBarriersArray, bufferMemoryBarrierCount, bufferMemoryBarriersArray, imageMemoryBarrierCount, imageMemoryBarriersArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void CmdBeginQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query, QueryControlFlags flags = default(QueryControlFlags))
        {
            vkCmdBeginQuery(commandBuffer.NativePointer, queryPool.NativePointer, query, flags);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdEndQuery(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 query)
        {
            vkCmdEndQuery(commandBuffer.NativePointer, queryPool.NativePointer, query);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdResetQueryPool(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount)
        {
            vkCmdResetQueryPool(commandBuffer.NativePointer, queryPool.NativePointer, firstQuery, queryCount);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdWriteTimestamp(CommandBuffer commandBuffer, PipelineStageFlags pipelineStage, QueryPool queryPool, UInt32 query)
        {
            vkCmdWriteTimestamp(commandBuffer.NativePointer, pipelineStage, queryPool.NativePointer, query);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        /// <param name="flags">Optional</param>
        public static void CmdCopyQueryPoolResults(CommandBuffer commandBuffer, QueryPool queryPool, UInt32 firstQuery, UInt32 queryCount, Buffer dstBuffer, DeviceSize dstOffset, DeviceSize stride, QueryResultFlags flags = default(QueryResultFlags))
        {
            vkCmdCopyQueryPoolResults(commandBuffer.NativePointer, queryPool.NativePointer, firstQuery, queryCount, dstBuffer.NativePointer, dstOffset, stride, flags);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdPushConstants(CommandBuffer commandBuffer, PipelineLayout layout, ShaderStageFlags stageFlags, UInt32 offset, IntPtr[] values)
        {
            var size = (values != null) ? (UInt32)values.Length : 0;
            IntPtr[] valuesArray = (values != null) ? values.ToArray() : null;
            vkCmdPushConstants(commandBuffer.NativePointer, layout.NativePointer, stageFlags, offset, size, valuesArray);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Outside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdBeginRenderPass(CommandBuffer commandBuffer, RenderPassBeginInfo renderPassBegin, SubpassContents contents)
        {
            vkCmdBeginRenderPass(commandBuffer.NativePointer, renderPassBegin.NativePointer, contents);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdNextSubpass(CommandBuffer commandBuffer, SubpassContents contents)
        {
            vkCmdNextSubpass(commandBuffer.NativePointer, contents);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Inside] [<see cref="QueueFlags"/>: Graphics] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdEndRenderPass(CommandBuffer commandBuffer)
        {
            vkCmdEndRenderPass(commandBuffer.NativePointer);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary] [Render Pass: Both] [<see cref="QueueFlags"/>: Transfer, Graphics, Compute] 
        /// </summary>
        /// <param name="commandBuffer">ExternSync</param>
        public static void CmdExecuteCommands(CommandBuffer commandBuffer, CommandBuffer[] commandBuffers)
        {
            var commandBufferCount = (commandBuffers != null) ? (UInt32)commandBuffers.Length : 0;
            IntPtr[] commandBuffersArray = (commandBuffers != null) ? commandBuffers.Select(x => x.NativePointer).ToArray() : null;
            vkCmdExecuteCommands(commandBuffer.NativePointer, commandBufferCount, commandBuffersArray);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateAndroidSurfaceKHR(Instance instance, AndroidSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
            
            var arrayDisplayPropertiesKHR = new Unmanaged.DisplayPropertiesKHR[listLength];
            fixed(Unmanaged.DisplayPropertiesKHR* resultPtr = &arrayDisplayPropertiesKHR[0])
                result = vkGetPhysicalDeviceDisplayPropertiesKHR(physicalDevice.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPropertiesKHR), result);
            
            var list = new List<DisplayPropertiesKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DisplayPropertiesKHR();
                fixed(Unmanaged.DisplayPropertiesKHR* itemPtr = &arrayDisplayPropertiesKHR[x])
                    item.NativePointer = itemPtr;
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
            
            var arrayDisplayPlanePropertiesKHR = new Unmanaged.DisplayPlanePropertiesKHR[listLength];
            fixed(Unmanaged.DisplayPlanePropertiesKHR* resultPtr = &arrayDisplayPlanePropertiesKHR[0])
                result = vkGetPhysicalDeviceDisplayPlanePropertiesKHR(physicalDevice.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceDisplayPlanePropertiesKHR), result);
            
            var list = new List<DisplayPlanePropertiesKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DisplayPlanePropertiesKHR();
                fixed(Unmanaged.DisplayPlanePropertiesKHR* itemPtr = &arrayDisplayPlanePropertiesKHR[x])
                    item.NativePointer = itemPtr;
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayKHR> GetDisplayPlaneSupportedDisplaysKHR(PhysicalDevice physicalDevice, UInt32 planeIndex)
        {
            UInt32 listLength;
            var result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativePointer, planeIndex, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            var arrayDisplayKHR = new UInt64[listLength];
            fixed(UInt64* resultPtr = &arrayDisplayKHR[0])
                result = vkGetDisplayPlaneSupportedDisplaysKHR(physicalDevice.NativePointer, planeIndex, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneSupportedDisplaysKHR), result);
            
            var list = new List<DisplayKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DisplayKHR();
                item.NativePointer = arrayDisplayKHR[x];
                list.Add(item);
            }
            
            return list;
        }
        
        public static List<DisplayModePropertiesKHR> GetDisplayModePropertiesKHR(PhysicalDevice physicalDevice, DisplayKHR display)
        {
            UInt32 listLength;
            var result = vkGetDisplayModePropertiesKHR(physicalDevice.NativePointer, display.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            var arrayDisplayModePropertiesKHR = new Unmanaged.DisplayModePropertiesKHR[listLength];
            fixed(Unmanaged.DisplayModePropertiesKHR* resultPtr = &arrayDisplayModePropertiesKHR[0])
                result = vkGetDisplayModePropertiesKHR(physicalDevice.NativePointer, display.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayModePropertiesKHR), result);
            
            var list = new List<DisplayModePropertiesKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new DisplayModePropertiesKHR();
                fixed(Unmanaged.DisplayModePropertiesKHR* itemPtr = &arrayDisplayModePropertiesKHR[x])
                    item.NativePointer = itemPtr;
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="display">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static DisplayModeKHR CreateDisplayModeKHR(PhysicalDevice physicalDevice, DisplayKHR display, DisplayModeCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="mode">ExternSync</param>
        public static DisplayPlaneCapabilitiesKHR GetDisplayPlaneCapabilitiesKHR(PhysicalDevice physicalDevice, DisplayModeKHR mode, UInt32 planeIndex)
        {
            var capabilities = new DisplayPlaneCapabilitiesKHR();
            var result = vkGetDisplayPlaneCapabilitiesKHR(physicalDevice.NativePointer, mode.NativePointer, planeIndex, &capabilities);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetDisplayPlaneCapabilitiesKHR), result);
            return capabilities;
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateDisplayPlaneSurfaceKHR(Instance instance, DisplaySurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="allocator">Optional</param>
        public static List<SwapchainKHR> CreateSharedSwapchainsKHR(Device device, SwapchainCreateInfoKHR[] createInfos, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            var swapchainCount = (createInfos != null) ? (UInt32)createInfos.Length : 0;
            Unmanaged.SwapchainCreateInfoKHR[] createInfosArray = (createInfos != null) ? createInfos.Select(x => *x.NativePointer).ToArray() : null;
            var listLength = swapchainCount;
            Result result;
            
            var arraySwapchainKHR = new UInt64[listLength];
            fixed(UInt64* resultPtr = &arraySwapchainKHR[0])
                result = vkCreateSharedSwapchainsKHR(device.NativePointer, listLength, createInfosArray, (allocator != null) ? allocator.NativePointer : null, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkCreateSharedSwapchainsKHR), result);
            
            var list = new List<SwapchainKHR>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new SwapchainKHR();
                item.NativePointer = arraySwapchainKHR[x];
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateMirSurfaceKHR(Instance instance, MirSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="surface">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySurfaceKHR(Instance instance, SurfaceKHR surface = default(SurfaceKHR), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroySurfaceKHR(instance.NativePointer, (surface != null) ? surface.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static Bool32 GetPhysicalDeviceSurfaceSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, SurfaceKHR surface)
        {
            var supported = new Bool32();
            var result = vkGetPhysicalDeviceSurfaceSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, surface.NativePointer, &supported);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceSupportKHR), result);
            return supported;
        }
        
        public static SurfaceCapabilitiesKHR GetPhysicalDeviceSurfaceCapabilitiesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            var surfaceCapabilities = new SurfaceCapabilitiesKHR();
            var result = vkGetPhysicalDeviceSurfaceCapabilitiesKHR(physicalDevice.NativePointer, surface.NativePointer, &surfaceCapabilities);
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
            
            var arraySurfaceFormatKHR = new SurfaceFormatKHR[listLength];
            fixed(SurfaceFormatKHR* resultPtr = &arraySurfaceFormatKHR[0])
                result = vkGetPhysicalDeviceSurfaceFormatsKHR(physicalDevice.NativePointer, surface.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfaceFormatsKHR), result);
            
            var list = new List<SurfaceFormatKHR>();
            for(var x = 0; x < listLength; x++)
            {
                list.Add(arraySurfaceFormatKHR[x]);
            }
            
            return list;
        }
        
        public static List<PresentModeKHR> GetPhysicalDeviceSurfacePresentModesKHR(PhysicalDevice physicalDevice, SurfaceKHR surface)
        {
            UInt32 listLength;
            var result = vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice.NativePointer, surface.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfacePresentModesKHR), result);
            
            var arrayPresentModeKHR = new PresentModeKHR[listLength];
            fixed(PresentModeKHR* resultPtr = &arrayPresentModeKHR[0])
                result = vkGetPhysicalDeviceSurfacePresentModesKHR(physicalDevice.NativePointer, surface.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetPhysicalDeviceSurfacePresentModesKHR), result);
            
            var list = new List<PresentModeKHR>();
            for(var x = 0; x < listLength; x++)
            {
                list.Add(arrayPresentModeKHR[x]);
            }
            
            return list;
        }
        
        /// <param name="allocator">Optional</param>
        public static SwapchainKHR CreateSwapchainKHR(Device device, SwapchainCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            var swapchain = new SwapchainKHR();
            fixed(UInt64* ptrSwapchainKHR = &swapchain.NativePointer)
            {
                var result = vkCreateSwapchainKHR(device.NativePointer, createInfo.NativePointer, (allocator != null) ? allocator.NativePointer : null, ptrSwapchainKHR);
                if(result != Result.Success)
                    throw new VulkanCommandException(nameof(vkCreateSwapchainKHR), result);
            }
            return swapchain;
        }
        
        /// <param name="swapchain">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroySwapchainKHR(Device device, SwapchainKHR swapchain = default(SwapchainKHR), AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroySwapchainKHR(device.NativePointer, (swapchain != null) ? swapchain.NativePointer : 0, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static List<Image> GetSwapchainImagesKHR(Device device, SwapchainKHR swapchain)
        {
            UInt32 listLength;
            var result = vkGetSwapchainImagesKHR(device.NativePointer, swapchain.NativePointer, &listLength, null);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            var arrayImage = new UInt64[listLength];
            fixed(UInt64* resultPtr = &arrayImage[0])
                result = vkGetSwapchainImagesKHR(device.NativePointer, swapchain.NativePointer, &listLength, resultPtr);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkGetSwapchainImagesKHR), result);
            
            var list = new List<Image>();
            for(var x = 0; x < listLength; x++)
            {
                var item = new Image();
                item.NativePointer = arrayImage[x];
                list.Add(item);
            }
            
            return list;
        }
        
        /// <param name="swapchain">ExternSync</param>
        /// <param name="semaphore">ExternSync</param>
        /// <param name="fence">ExternSync</param>
        public static UInt32 AcquireNextImageKHR(Device device, SwapchainKHR swapchain, UInt64 timeout, Semaphore semaphore = default(Semaphore), Fence fence = default(Fence))
        {
            var imageIndex = new UInt32();
            var result = vkAcquireNextImageKHR(device.NativePointer, swapchain.NativePointer, timeout, (semaphore != null) ? semaphore.NativePointer : 0, (fence != null) ? fence.NativePointer : 0, &imageIndex);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkAcquireNextImageKHR), result);
            return imageIndex;
        }
        
        /// <param name="queue">ExternSync</param>
        public static void QueuePresentKHR(Queue queue, PresentInfoKHR presentInfo)
        {
            var result = vkQueuePresentKHR(queue.NativePointer, presentInfo.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkQueuePresentKHR), result);
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateWaylandSurfaceKHR(Instance instance, WaylandSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateWin32SurfaceKHR(Instance instance, Win32SurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        public static Bool32 GetPhysicalDeviceWin32PresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex)
        {
            var result = vkGetPhysicalDeviceWin32PresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex);
            return result;
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateXlibSurfaceKHR(Instance instance, XlibSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        public static Bool32 GetPhysicalDeviceXlibPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr dpy, IntPtr visualID)
        {
            var result = vkGetPhysicalDeviceXlibPresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, &dpy, visualID);
            return result;
        }
        
        /// <param name="allocator">Optional</param>
        public static SurfaceKHR CreateXcbSurfaceKHR(Instance instance, XcbSurfaceCreateInfoKHR createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        public static Bool32 GetPhysicalDeviceXcbPresentationSupportKHR(PhysicalDevice physicalDevice, UInt32 queueFamilyIndex, IntPtr connection, IntPtr visual_id)
        {
            var result = vkGetPhysicalDeviceXcbPresentationSupportKHR(physicalDevice.NativePointer, queueFamilyIndex, &connection, visual_id);
            return result;
        }
        
        /// <param name="allocator">Optional</param>
        public static DebugReportCallbackEXT CreateDebugReportCallbackEXT(Instance instance, DebugReportCallbackCreateInfoEXT createInfo, AllocationCallbacks allocator = default(AllocationCallbacks))
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
        
        /// <param name="callback">ExternSync</param>
        /// <param name="allocator">Optional</param>
        public static void DestroyDebugReportCallbackEXT(Instance instance, DebugReportCallbackEXT callback, AllocationCallbacks allocator = default(AllocationCallbacks))
        {
            vkDestroyDebugReportCallbackEXT(instance.NativePointer, callback.NativePointer, (allocator != null) ? allocator.NativePointer : null);
        }
        
        public static void DebugReportMessageEXT(Instance instance, DebugReportFlagsEXT flags, DebugReportObjectTypeEXT objectType, UInt64 @object, UInt32 location, Int32 messageCode, String layerPrefix, String message)
        {
            vkDebugReportMessageEXT(instance.NativePointer, flags, objectType, @object, location, messageCode, layerPrefix, message);
        }
        
        public static DebugMarkerObjectNameInfoEXT DebugMarkerSetObjectNameEXT(Device device)
        {
            var nameInfo = new DebugMarkerObjectNameInfoEXT();
            var result = vkDebugMarkerSetObjectNameEXT(device.NativePointer, nameInfo.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkDebugMarkerSetObjectNameEXT), result);
            return nameInfo;
        }
        
        public static DebugMarkerObjectTagInfoEXT DebugMarkerSetObjectTagEXT(Device device)
        {
            var tagInfo = new DebugMarkerObjectTagInfoEXT();
            var result = vkDebugMarkerSetObjectTagEXT(device.NativePointer, tagInfo.NativePointer);
            if(result != Result.Success)
                throw new VulkanCommandException(nameof(vkDebugMarkerSetObjectTagEXT), result);
            return tagInfo;
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerBeginEXT(CommandBuffer commandBuffer)
        {
            var markerInfo = new DebugMarkerMarkerInfoEXT();
            vkCmdDebugMarkerBeginEXT(commandBuffer.NativePointer, markerInfo.NativePointer);
            return markerInfo;
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static void CmdDebugMarkerEndEXT(CommandBuffer commandBuffer)
        {
            vkCmdDebugMarkerEndEXT(commandBuffer.NativePointer);
        }
        
        /// <summary>
        /// [<see cref="CommandBufferLevel"/>: Primary, Secondary] [Render Pass: Both] [<see cref="QueueFlags"/>: Graphics, Compute] 
        /// </summary>
        public static DebugMarkerMarkerInfoEXT CmdDebugMarkerInsertEXT(CommandBuffer commandBuffer)
        {
            var markerInfo = new DebugMarkerMarkerInfoEXT();
            vkCmdDebugMarkerInsertEXT(commandBuffer.NativePointer, markerInfo.NativePointer);
            return markerInfo;
        }
        
    }
}
