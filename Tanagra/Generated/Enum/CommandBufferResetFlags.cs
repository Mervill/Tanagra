using System;

namespace Vulkan
{
    [Flags]
    public enum CommandBufferResetFlags
    {
        None = 0,
        /// <summary>
        /// Release resources owned by the buffer
        /// </summary>
        ReleaseResources = 1 << 0,
    }
}
