using System;

namespace Vulkan
{
    [Flags]
    public enum CommandBufferResetFlags
    {
        /// <summary>
        /// Release resources owned by the buffer
        /// </summary>
        ReleaseResources = 1 << 0,
    }
}
