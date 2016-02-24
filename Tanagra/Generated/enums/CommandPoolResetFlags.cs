using System;

namespace Vulkan
{
    [Flags]
    public enum CommandPoolResetFlags
    {
        /// <summary>
        /// Release resources owned by the pool
        /// </summary>
        COMMAND_POOL_RESET_RELEASE_RESOURCES_BIT = 0,
    }
}
