using System;

namespace Vulkan
{
    [Flags]
    public enum MemoryHeapFlags
    {
        None = 0,
        /// <summary>
        /// If set, heap represents device memory
        /// </summary>
        DeviceLocal = 1 << 0,
    }
}
