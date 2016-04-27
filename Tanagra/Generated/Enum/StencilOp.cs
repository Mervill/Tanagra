using System;

namespace Vulkan
{
    public enum StencilOp
    {
        STENCIL_OP_KEEP = 0,
        STENCIL_OP_ZERO = 1,
        STENCIL_OP_REPLACE = 2,
        STENCIL_OP_INCREMENT_AND_CLAMP = 3,
        STENCIL_OP_DECREMENT_AND_CLAMP = 4,
        STENCIL_OP_INVERT = 5,
        STENCIL_OP_INCREMENT_AND_WRAP = 6,
        STENCIL_OP_DECREMENT_AND_WRAP = 7,
    }
}
