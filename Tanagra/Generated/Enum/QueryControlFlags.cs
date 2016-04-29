using System;

namespace Vulkan
{
    [Flags]
    public enum QueryControlFlags
    {
        /// <summary>
        /// Require precise results to be collected by the query
        /// </summary>
        Precise = 1 << 0,
    }
}
