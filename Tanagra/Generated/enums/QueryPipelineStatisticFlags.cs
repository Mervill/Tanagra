using System;

namespace Vulkan
{
    [Flags]
    public enum QueryPipelineStatisticFlags
    {
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_INPUT_ASSEMBLY_VERTICES_BIT = 0,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_INPUT_ASSEMBLY_PRIMITIVES_BIT = 1,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_VERTEX_SHADER_INVOCATIONS_BIT = 2,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_GEOMETRY_SHADER_INVOCATIONS_BIT = 3,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_GEOMETRY_SHADER_PRIMITIVES_BIT = 4,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_CLIPPING_INVOCATIONS_BIT = 5,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_CLIPPING_PRIMITIVES_BIT = 6,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_FRAGMENT_SHADER_INVOCATIONS_BIT = 7,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_TESSELLATION_CONTROL_SHADER_PATCHES_BIT = 8,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_TESSELLATION_EVALUATION_SHADER_INVOCATIONS_BIT = 9,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_PIPELINE_STATISTIC_COMPUTE_SHADER_INVOCATIONS_BIT = 10,
    }
}
