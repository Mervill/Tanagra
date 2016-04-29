using System;

namespace Vulkan
{
    [Flags]
    public enum CommandPoolResetFlags
    {
        /// <summary>
        /// Release resources owned by the pool
        /// </summary>
        ReleaseResources = 1 << 0,
    }
}
