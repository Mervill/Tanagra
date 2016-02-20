using System;

namespace Vulkan
{
    [Flags]
    public enum CommandPoolCreateFlags
    {
        COMMAND_POOL_CREATE_TRANSIENT_BIT = 0,
        COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT = 1,
    }
}
