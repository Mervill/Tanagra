using System;

namespace Vulkan
{
    [Flags]
    public enum FenceCreateFlags
    {
        None = 0,
        Signaled = 1 << 0,
    }
}
