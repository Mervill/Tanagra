using System;

namespace Vulkan
{
    [Flags]
    public enum QueueFlags
    {
        /// <summary>
        /// Queue supports graphics operations
        /// </summary>
        Graphics = 1 << 0,
        /// <summary>
        /// Queue supports compute operations
        /// </summary>
        Compute = 1 << 1,
        /// <summary>
        /// Queue supports transfer operations
        /// </summary>
        Transfer = 1 << 2,
        /// <summary>
        /// Queue supports sparse resource memory management operations
        /// </summary>
        SparseBinding = 1 << 3,
    }
}
