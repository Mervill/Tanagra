using System;

namespace Vulkan
{
    [Flags]
    public enum MemoryHeapFlags
    {
        /// <summary>
        /// If set, heap represents device memory
        /// </summary>
        MEMORY_HEAP_DEVICE_LOCAL_BIT = 1 << 0,
    }
}
