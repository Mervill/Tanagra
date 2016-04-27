using System;

namespace Vulkan
{
    [Flags]
    public enum ColorComponentFlags
    {
        COLOR_COMPONENT_R_BIT = 1 << 0,
        COLOR_COMPONENT_G_BIT = 1 << 1,
        COLOR_COMPONENT_B_BIT = 1 << 2,
        COLOR_COMPONENT_A_BIT = 1 << 3,
    }
}
