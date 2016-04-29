using System;

namespace Vulkan
{
    [Flags]
    public enum SparseMemoryBindFlags
    {
        /// <summary>
        /// Operation binds resource metadata to memory
        /// </summary>
        Metadata = 1 << 0,
    }
}
