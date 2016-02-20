using System;

namespace Vulkan
{
    [Flags]
    public enum ShaderStageFlags
    {
        SHADER_STAGE_VERTEX_BIT = 0,
        SHADER_STAGE_TESSELLATION_CONTROL_BIT = 1,
        SHADER_STAGE_TESSELLATION_EVALUATION_BIT = 2,
        SHADER_STAGE_GEOMETRY_BIT = 3,
        SHADER_STAGE_FRAGMENT_BIT = 4,
        SHADER_STAGE_COMPUTE_BIT = 5,
        SHADER_STAGE_ALL_GRAPHICS = 0x1F,
        SHADER_STAGE_ALL = 0x7FFFFFFF,
    }
}
