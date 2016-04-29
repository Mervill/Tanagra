using System;

namespace Vulkan
{
    [Flags]
    public enum DisplayPlaneAlphaFlagBitsKHR
    {
        DisplayPlaneAlphaOpaqueBitKhr = 1 << 0,
        DisplayPlaneAlphaGlobalBitKhr = 1 << 1,
        DisplayPlaneAlphaPerPixelBitKhr = 1 << 2,
        DisplayPlaneAlphaPerPixelPremultipliedBitKhr = 1 << 3,
    }
}
