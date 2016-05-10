using System;

namespace Vulkan
{
    [Flags]
    public enum CommandBufferUsageFlags
    {
        None = 0,
        OneTimeSubmit = 1 << 0,
        RenderPassContinue = 1 << 1,
        /// <summary>
        /// Command buffer may be submitted/executed more than once simultaneously
        /// </summary>
        SimultaneousUse = 1 << 2,
    }
}
