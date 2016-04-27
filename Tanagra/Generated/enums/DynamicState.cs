using System;

namespace Vulkan
{
    public enum DynamicState
    {
        DYNAMIC_STATE_VIEWPORT = 0,
        DYNAMIC_STATE_SCISSOR = 1,
        DYNAMIC_STATE_LINE_WIDTH = 2,
        DYNAMIC_STATE_DEPTH_BIAS = 3,
        DYNAMIC_STATE_BLEND_CONSTANTS = 4,
        DYNAMIC_STATE_DEPTH_BOUNDS = 5,
        DYNAMIC_STATE_STENCIL_COMPARE_MASK = 6,
        DYNAMIC_STATE_STENCIL_WRITE_MASK = 7,
        DYNAMIC_STATE_STENCIL_REFERENCE = 8,
    }
}
