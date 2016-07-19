using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DedicatedAllocationMemoryAllocateInfoNV
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_MEMORY_ALLOCATE_INFO_NV
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Image that this allocation will be bound to (Optional)
        /// </summary>
        public UInt64 Image;
        /// <summary>
        /// Buffer that this allocation will be bound to (Optional)
        /// </summary>
        public UInt64 Buffer;
    }
}
