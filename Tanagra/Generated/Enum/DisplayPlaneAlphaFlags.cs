using System;

namespace Vulkan
{
    [Flags]
    public enum DisplayPlaneAlphaFlags
    {
        OpaqueBitKhr = 1 << 0,
        GlobalBitKhr = 1 << 1,
        PerPixelBitKhr = 1 << 2,
        PerPixelPremultipliedBitKhr = 1 << 3,
    }
}
