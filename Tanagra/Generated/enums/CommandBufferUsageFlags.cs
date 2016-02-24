using System;

namespace Vulkan
{
    [Flags]
    public enum CommandBufferUsageFlags
    {
        COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT = 0,
        COMMAND_BUFFER_USAGE_RENDER_PASS_CONTINUE_BIT = 1,
        /// <summary>
        /// Command buffer may be submitted/executed more than once simultaneously
        /// </summary>
        COMMAND_BUFFER_USAGE_SIMULTANEOUS_USE_BIT = 2,
    }
}
