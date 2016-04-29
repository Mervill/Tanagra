using System;

namespace Vulkan
{
    [Flags]
    public enum MemoryHeapFlags
    {
        /// <summary>
        /// If set, heap represents device memory
        /// </summary>
        DeviceLocal = 1 << 0,
    }
}
