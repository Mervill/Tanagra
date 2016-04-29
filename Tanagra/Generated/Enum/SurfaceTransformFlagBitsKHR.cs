using System;

namespace Vulkan
{
    [Flags]
    public enum SurfaceTransformFlagBitsKHR
    {
        SurfaceTransformIdentityBitKhr = 1 << 0,
        SurfaceTransformRotate90BitKhr = 1 << 1,
        SurfaceTransformRotate180BitKhr = 1 << 2,
        SurfaceTransformRotate270BitKhr = 1 << 3,
        SurfaceTransformHorizontalMirrorBitKhr = 1 << 4,
        SurfaceTransformHorizontalMirrorRotate90BitKhr = 1 << 5,
        SurfaceTransformHorizontalMirrorRotate180BitKhr = 1 << 6,
        SurfaceTransformHorizontalMirrorRotate270BitKhr = 1 << 7,
        SurfaceTransformInheritBitKhr = 1 << 8,
    }
}
