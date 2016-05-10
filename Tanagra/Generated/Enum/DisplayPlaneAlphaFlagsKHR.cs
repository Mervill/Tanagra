using System;

namespace Vulkan
{
    [Flags]
    public enum DisplayPlaneAlphaFlagsKHR
    {
        Opaque = 1 << 0,
        Global = 1 << 1,
        PerPixel = 1 << 2,
        PerPixelPremultiplied = 1 << 3,
    }
}
