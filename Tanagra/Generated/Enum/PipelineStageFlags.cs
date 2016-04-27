using System;

namespace Vulkan
{
    [Flags]
    public enum PipelineStageFlags
    {
        /// <summary>
        /// Before subsequent commands are processed
        /// </summary>
        PIPELINE_STAGE_TOP_OF_PIPE_BIT = 1 << 0,
        /// <summary>
        /// Draw/DispatchIndirect command fetch
        /// </summary>
        PIPELINE_STAGE_DRAW_INDIRECT_BIT = 1 << 1,
        /// <summary>
        /// Vertex/index fetch
        /// </summary>
        PIPELINE_STAGE_VERTEX_INPUT_BIT = 1 << 2,
        /// <summary>
        /// Vertex shading
        /// </summary>
        PIPELINE_STAGE_VERTEX_SHADER_BIT = 1 << 3,
        /// <summary>
        /// Tessellation control shading
        /// </summary>
        PIPELINE_STAGE_TESSELLATION_CONTROL_SHADER_BIT = 1 << 4,
        /// <summary>
        /// Tessellation evaluation shading
        /// </summary>
        PIPELINE_STAGE_TESSELLATION_EVALUATION_SHADER_BIT = 1 << 5,
        /// <summary>
        /// Geometry shading
        /// </summary>
        PIPELINE_STAGE_GEOMETRY_SHADER_BIT = 1 << 6,
        /// <summary>
        /// Fragment shading
        /// </summary>
        PIPELINE_STAGE_FRAGMENT_SHADER_BIT = 1 << 7,
        /// <summary>
        /// Early fragment (depth and stencil) tests
        /// </summary>
        PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT = 1 << 8,
        /// <summary>
        /// Late fragment (depth and stencil) tests
        /// </summary>
        PIPELINE_STAGE_LATE_FRAGMENT_TESTS_BIT = 1 << 9,
        /// <summary>
        /// Color attachment writes
        /// </summary>
        PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT = 1 << 10,
        /// <summary>
        /// Compute shading
        /// </summary>
        PIPELINE_STAGE_COMPUTE_SHADER_BIT = 1 << 11,
        /// <summary>
        /// Transfer/copy operations
        /// </summary>
        PIPELINE_STAGE_TRANSFER_BIT = 1 << 12,
        /// <summary>
        /// After previous commands have completed
        /// </summary>
        PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT = 1 << 13,
        /// <summary>
        /// Indicates host (CPU) is a source/sink of the dependency
        /// </summary>
        PIPELINE_STAGE_HOST_BIT = 1 << 14,
        /// <summary>
        /// All stages of the graphics pipeline
        /// </summary>
        PIPELINE_STAGE_ALL_GRAPHICS_BIT = 1 << 15,
        /// <summary>
        /// All stages supported on the queue
        /// </summary>
        PIPELINE_STAGE_ALL_COMMANDS_BIT = 1 << 16,
    }
}
