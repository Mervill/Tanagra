using System;

namespace Vulkan
{
    public enum QueryType
    {
        OCCLUSION = 0,
        /// <summary>
        /// Optional
        /// </summary>
        PIPELINE_STATISTICS = 1,
        TIMESTAMP = 2,
    }
}
