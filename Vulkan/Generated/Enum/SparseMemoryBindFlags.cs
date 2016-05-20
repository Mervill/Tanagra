using System;

namespace Vulkan
{
    [Flags]
    public enum SparseMemoryBindFlags
    {
        None = 0,
        /// <summary>
        /// Operation binds resource metadata to memory
        /// </summary>
        Metadata = 1 << 0,
    }
}
