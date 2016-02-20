using System;

namespace Vulkan
{
    [Flags]
    public enum QueueFlags
    {
        QUEUE_GRAPHICS_BIT = 0,
        QUEUE_COMPUTE_BIT = 1,
        QUEUE_TRANSFER_BIT = 2,
        QUEUE_SPARSE_BINDING_BIT = 3,
    }
}
