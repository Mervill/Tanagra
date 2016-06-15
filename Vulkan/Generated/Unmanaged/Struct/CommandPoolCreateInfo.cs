using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandPoolCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Command pool creation flags (Optional)
        /// </summary>
        public CommandPoolCreateFlags Flags;
        public UInt32 QueueFamilyIndex;
    }
}
