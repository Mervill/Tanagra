using System;

namespace Vulkan
{
    [Flags]
    public enum ColorComponentFlags
    {
        R = 1 << 0,
        G = 1 << 1,
        B = 1 << 2,
        A = 1 << 3,
    }
}
