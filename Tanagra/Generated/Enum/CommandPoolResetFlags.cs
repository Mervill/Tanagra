using System;

namespace Vulkan
{
    [Flags]
    public enum CommandPoolResetFlags
    {
        None = 0,
        /// <summary>
        /// Release resources owned by the pool
        /// </summary>
        ReleaseResources = 1 << 0,
    }
}
