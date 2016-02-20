using System;

namespace Vulkan
{
    [Flags]
    public enum DisplayPlaneAlphaFlagBitsKHR
    {
        DISPLAY_PLANE_ALPHA_OPAQUE_BIT_KHR = 0,
        DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR = 1,
        DISPLAY_PLANE_ALPHA_PER_PIXEL_BIT_KHR = 2,
        DISPLAY_PLANE_ALPHA_PER_PIXEL_PREMULTIPLIED_BIT_KHR = 3,
    }
}
