using System;

namespace Vulkan
{
    [Flags]
    public enum CommandPoolCreateFlags
    {
        /// <summary>
        /// Command buffers have a short lifetime
        /// </summary>
        COMMAND_POOL_CREATE_TRANSIENT_BIT = 1 << 0,
        /// <summary>
        /// Command buffers may release their memory individually
        /// </summary>
        COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT = 1 << 1,
    }
}
