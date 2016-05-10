using System;

namespace Vulkan
{
    [Flags]
    public enum QueryControlFlags
    {
        None = 0,
        /// <summary>
        /// Require precise results to be collected by the query
        /// </summary>
        Precise = 1 << 0,
    }
}
