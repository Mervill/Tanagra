using System;

namespace Vulkan
{
    [Flags]
    public enum CompositeAlphaFlagBitsKHR
    {
        CompositeAlphaOpaqueBitKhr = 1 << 0,
        CompositeAlphaPreMultipliedBitKhr = 1 << 1,
        CompositeAlphaPostMultipliedBitKhr = 1 << 2,
        CompositeAlphaInheritBitKhr = 1 << 3,
    }
}
