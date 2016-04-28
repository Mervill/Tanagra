using System;

namespace Vulkan
{
    [Flags]
    public enum CompositeAlphaFlagBitsKHR
    {
        COMPOSITE_ALPHA_OPAQUE_BIT_KHR = 1 << 0,
        COMPOSITE_ALPHA_PRE_MULTIPLIED_BIT_KHR = 1 << 1,
        COMPOSITE_ALPHA_POST_MULTIPLIED_BIT_KHR = 1 << 2,
        COMPOSITE_ALPHA_INHERIT_BIT_KHR = 1 << 3,
    }
}