using System;

namespace Vulkan
{
    [Flags]
    public enum CompositeAlphaFlagsKHR
    {
        Opaque = 1 << 0,
        PreMultiplied = 1 << 1,
        PostMultiplied = 1 << 2,
        Inherit = 1 << 3,
    }
}
