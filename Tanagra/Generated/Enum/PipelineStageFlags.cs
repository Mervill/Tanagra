using System;

namespace Vulkan
{
    [Flags]
    public enum PipelineStageFlags
    {
        None = 0,
        /// <summary>
        /// Before subsequent commands are processed
        /// </summary>
        TopOfPipe = 1 << 0,
        /// <summary>
        /// Draw/DispatchIndirect command fetch
        /// </summary>
        DrawIndirect = 1 << 1,
        /// <summary>
        /// Vertex/index fetch
        /// </summary>
        VertexInput = 1 << 2,
        /// <summary>
        /// Vertex shading
        /// </summary>
        VertexShader = 1 << 3,
        /// <summary>
        /// Tessellation control shading
        /// </summary>
        TessellationControlShader = 1 << 4,
        /// <summary>
        /// Tessellation evaluation shading
        /// </summary>
        TessellationEvaluationShader = 1 << 5,
        /// <summary>
        /// Geometry shading
        /// </summary>
        GeometryShader = 1 << 6,
        /// <summary>
        /// Fragment shading
        /// </summary>
        FragmentShader = 1 << 7,
        /// <summary>
        /// Early fragment (depth and stencil) tests
        /// </summary>
        EarlyFragmentTests = 1 << 8,
        /// <summary>
        /// Late fragment (depth and stencil) tests
        /// </summary>
        LateFragmentTests = 1 << 9,
        /// <summary>
        /// Color attachment writes
        /// </summary>
        ColorAttachmentOutput = 1 << 10,
        /// <summary>
        /// Compute shading
        /// </summary>
        ComputeShader = 1 << 11,
        /// <summary>
        /// Transfer/copy operations
        /// </summary>
        Transfer = 1 << 12,
        /// <summary>
        /// After previous commands have completed
        /// </summary>
        BottomOfPipe = 1 << 13,
        /// <summary>
        /// Indicates host (CPU) is a source/sink of the dependency
        /// </summary>
        Host = 1 << 14,
        /// <summary>
        /// All stages of the graphics pipeline
        /// </summary>
        AllGraphics = 1 << 15,
        /// <summary>
        /// All stages supported on the queue
        /// </summary>
        AllCommands = 1 << 16,
    }
}
