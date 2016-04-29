using System;

namespace Vulkan
{
    [Flags]
    public enum CommandPoolCreateFlags
    {
        /// <summary>
        /// Command buffers have a short lifetime
        /// </summary>
        Transient = 1 << 0,
        /// <summary>
        /// Command buffers may release their memory individually
        /// </summary>
        ResetCommandBuffer = 1 << 1,
    }
}
