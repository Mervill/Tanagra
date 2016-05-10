using System;

namespace Vulkan
{
    [Flags]
    public enum BufferCreateFlags
    {
        None = 0,
        /// <summary>
        /// Buffer should support sparse backing
        /// </summary>
        SparseBinding = 1 << 0,
        /// <summary>
        /// Buffer should support sparse backing with partial residency
        /// </summary>
        SparseResidency = 1 << 1,
        /// <summary>
        /// Buffer should support constent data access to physical memory ranges mapped into multiple locations of sparse buffers
        /// </summary>
        SparseAliased = 1 << 2,
    }
}
