using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBufferAllocateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public UInt64 CommandPool;
        public CommandBufferLevel Level;
        public UInt32 CommandBufferCount;
    }
}
