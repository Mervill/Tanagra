using System;

namespace Vulkan
{
    [Flags]
    public enum SparseMemoryBindFlags
    {
        /// <summary>
        /// Operation binds resource metadata to memory
        /// </summary>
        SPARSE_MEMORY_BIND_METADATA_BIT = 1 << 0,
    }
}
