using System;

namespace Vulkan
{
    [Flags]
    public enum SurfaceTransformFlagBitsKHR
    {
        SURFACE_TRANSFORM_IDENTITY_BIT_KHR = 1 << 0,
        SURFACE_TRANSFORM_ROTATE_90_BIT_KHR = 1 << 1,
        SURFACE_TRANSFORM_ROTATE_180_BIT_KHR = 1 << 2,
        SURFACE_TRANSFORM_ROTATE_270_BIT_KHR = 1 << 3,
        SURFACE_TRANSFORM_HORIZONTAL_MIRROR_BIT_KHR = 1 << 4,
        SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_90_BIT_KHR = 1 << 5,
        SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_180_BIT_KHR = 1 << 6,
        SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_270_BIT_KHR = 1 << 7,
        SURFACE_TRANSFORM_INHERIT_BIT_KHR = 1 << 8,
    }
}
