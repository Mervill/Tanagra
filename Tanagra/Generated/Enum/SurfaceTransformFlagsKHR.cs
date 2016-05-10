using System;

namespace Vulkan
{
    [Flags]
    public enum SurfaceTransformFlagsKHR
    {
        Identity = 1 << 0,
        Rotate90 = 1 << 1,
        Rotate180 = 1 << 2,
        Rotate270 = 1 << 3,
        HorizontalMirror = 1 << 4,
        HorizontalMirrorRotate90 = 1 << 5,
        HorizontalMirrorRotate180 = 1 << 6,
        HorizontalMirrorRotate270 = 1 << 7,
        Inherit = 1 << 8,
    }
}
