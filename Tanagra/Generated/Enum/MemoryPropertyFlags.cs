using System;

namespace Vulkan
{
    [Flags]
    public enum MemoryPropertyFlags
    {
        /// <summary>
        /// If otherwise stated, then allocate memory on device
        /// </summary>
        DeviceLocal = 1 << 0,
        /// <summary>
        /// Memory is mappable by host
        /// </summary>
        HostVisible = 1 << 1,
        /// <summary>
        /// Memory will have i/o coherency. If not set, application may need to use vkFlushMappedMemoryRanges and vkInvalidateMappedMemoryRanges to flush/invalidate host cache
        /// </summary>
        HostCoherent = 1 << 2,
        /// <summary>
        /// Memory will be cached by the host
        /// </summary>
        HostCached = 1 << 3,
        /// <summary>
        /// Memory may be allocated by the driver when it is required
        /// </summary>
        LazilyAllocated = 1 << 4,
    }
}
