using System;

namespace Vulkan
{
    public enum QueryType
    {
        Occlusion = 0,
        /// <summary>
        /// Optional
        /// </summary>
        PipelineStatistics = 1,
        Timestamp = 2,
    }
}
