using System;

namespace Vulkan
{
    [Flags]
    public enum FenceCreateFlags
    {
        Signaled = 1 << 0,
    }
}
