using System;

namespace Vulkan
{
    [Flags]
    public enum CompositeAlphaFlags
    {
        OpaqueBitKhr = 1 << 0,
        PreMultipliedBitKhr = 1 << 1,
        PostMultipliedBitKhr = 1 << 2,
        InheritBitKhr = 1 << 3,
    }
}
