using System;

namespace Vulkan
{
    [Flags]
    public enum MemoryPropertyFlags
    {
        MEMORY_PROPERTY_DEVICE_LOCAL_BIT = 0,
        MEMORY_PROPERTY_HOST_VISIBLE_BIT = 1,
        MEMORY_PROPERTY_HOST_COHERENT_BIT = 2,
        MEMORY_PROPERTY_HOST_CACHED_BIT = 3,
        MEMORY_PROPERTY_LAZILY_ALLOCATED_BIT = 4,
    }
}
