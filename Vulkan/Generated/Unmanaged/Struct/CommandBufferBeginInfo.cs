using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBufferBeginInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Command buffer usage flags (Optional)
        /// </summary>
        public CommandBufferUsageFlags Flags;
        /// <summary>
        /// Pointer to inheritance info for secondary command buffers (Optional)
        /// </summary>
        public IntPtr InheritanceInfo;
    }
}
