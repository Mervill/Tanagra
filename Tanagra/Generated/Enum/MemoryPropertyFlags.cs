using System;

namespace Vulkan
{
    [Flags]
    public enum MemoryPropertyFlags
    {
        /// <summary>
        /// If otherwise stated, then allocate memory on device
        /// </summary>
        MEMORY_PROPERTY_DEVICE_LOCAL_BIT = 1 << 0,
        /// <summary>
        /// Memory is mappable by host
        /// </summary>
        MEMORY_PROPERTY_HOST_VISIBLE_BIT = 1 << 1,
        /// <summary>
        /// Memory will have i/o coherency. If not set, application may need to use vkFlushMappedMemoryRanges and vkInvalidateMappedMemoryRanges to flush/invalidate host cache
        /// </summary>
        MEMORY_PROPERTY_HOST_COHERENT_BIT = 1 << 2,
        /// <summary>
        /// Memory will be cached by the host
        /// </summary>
        MEMORY_PROPERTY_HOST_CACHED_BIT = 1 << 3,
        /// <summary>
        /// Memory may be allocated by the driver when it is required
        /// </summary>
        MEMORY_PROPERTY_LAZILY_ALLOCATED_BIT = 1 << 4,
    }
}
