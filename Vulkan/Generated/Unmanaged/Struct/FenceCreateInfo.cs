using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FenceCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_FENCE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Fence creation flags (Optional)
        /// </summary>
        public FenceCreateFlags Flags;
    }
}
