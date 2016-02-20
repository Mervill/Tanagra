using System;

namespace Vulkan
{
    [Flags]
    public enum StencilFaceFlags
    {
        STENCIL_FACE_FRONT_BIT = 0,
        STENCIL_FACE_BACK_BIT = 1,
        STENCIL_FRONT_AND_BACK = 0x3,
    }
}
