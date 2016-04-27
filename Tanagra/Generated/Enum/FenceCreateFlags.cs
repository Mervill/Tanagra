using System;

namespace Vulkan
{
    [Flags]
    public enum FenceCreateFlags
    {
        FENCE_CREATE_SIGNALED_BIT = 1 << 0,
    }
}
