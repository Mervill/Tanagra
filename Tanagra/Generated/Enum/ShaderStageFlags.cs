using System;

namespace Vulkan
{
    [Flags]
    public enum ShaderStageFlags
    {
        SHADER_STAGE_VERTEX_BIT = 1 << 0,
        SHADER_STAGE_TESSELLATION_CONTROL_BIT = 1 << 1,
        SHADER_STAGE_TESSELLATION_EVALUATION_BIT = 1 << 2,
        SHADER_STAGE_GEOMETRY_BIT = 1 << 3,
        SHADER_STAGE_FRAGMENT_BIT = 1 << 4,
        SHADER_STAGE_COMPUTE_BIT = 1 << 5,
        SHADER_STAGE_ALL_GRAPHICS = 1 << 0x0000001F,
        SHADER_STAGE_ALL = 1 << 0x7FFFFFFF,
    }
}
