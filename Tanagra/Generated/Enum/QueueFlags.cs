using System;

namespace Vulkan
{
    [Flags]
    public enum QueueFlags
    {
        /// <summary>
        /// Queue supports graphics operations
        /// </summary>
        QUEUE_GRAPHICS_BIT = 1 << 0,
        /// <summary>
        /// Queue supports compute operations
        /// </summary>
        QUEUE_COMPUTE_BIT = 1 << 1,
        /// <summary>
        /// Queue supports transfer operations
        /// </summary>
        QUEUE_TRANSFER_BIT = 1 << 2,
        /// <summary>
        /// Queue supports sparse resource memory management operations
        /// </summary>
        QUEUE_SPARSE_BINDING_BIT = 1 << 3,
    }
}
