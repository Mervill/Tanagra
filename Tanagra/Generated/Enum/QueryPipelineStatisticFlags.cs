using System;

namespace Vulkan
{
    [Flags]
    public enum QueryPipelineStatisticFlags
    {
        /// <summary>
        /// Optional
        /// </summary>
        InputAssemblyVertices = 1 << 0,
        /// <summary>
        /// Optional
        /// </summary>
        InputAssemblyPrimitives = 1 << 1,
        /// <summary>
        /// Optional
        /// </summary>
        VertexShaderInvocations = 1 << 2,
        /// <summary>
        /// Optional
        /// </summary>
        GeometryShaderInvocations = 1 << 3,
        /// <summary>
        /// Optional
        /// </summary>
        GeometryShaderPrimitives = 1 << 4,
        /// <summary>
        /// Optional
        /// </summary>
        ClippingInvocations = 1 << 5,
        /// <summary>
        /// Optional
        /// </summary>
        ClippingPrimitives = 1 << 6,
        /// <summary>
        /// Optional
        /// </summary>
        FragmentShaderInvocations = 1 << 7,
        /// <summary>
        /// Optional
        /// </summary>
        TessellationControlShaderPatches = 1 << 8,
        /// <summary>
        /// Optional
        /// </summary>
        TessellationEvaluationShaderInvocations = 1 << 9,
        /// <summary>
        /// Optional
        /// </summary>
        ComputeShaderInvocations = 1 << 10,
    }
}
