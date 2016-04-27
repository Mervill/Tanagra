using System;

namespace Vulkan
{
    [Flags]
    public enum CommandBufferResetFlags
    {
        /// <summary>
        /// Release resources owned by the buffer
        /// </summary>
        COMMAND_BUFFER_RESET_RELEASE_RESOURCES_BIT = 1 << 0,
    }
}
