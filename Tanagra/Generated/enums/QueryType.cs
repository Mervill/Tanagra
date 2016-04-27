using System;

namespace Vulkan
{
    public enum QueryType
    {
        QUERY_TYPE_OCCLUSION = 0,
        /// <summary>
        /// Optional
        /// </summary>
        QUERY_TYPE_PIPELINE_STATISTICS = 1,
        QUERY_TYPE_TIMESTAMP = 2,
    }
}
