using System;

namespace Vulkan
{
    [Flags]
    public enum QueryControlFlags
    {
        /// <summary>
        /// Require precise results to be collected by the query
        /// </summary>
        QUERY_CONTROL_PRECISE_BIT = 1 << 0,
    }
}
