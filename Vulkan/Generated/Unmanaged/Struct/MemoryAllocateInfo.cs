using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryAllocateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Size of memory allocation
        /// </summary>
        public DeviceSize AllocationSize;
        /// <summary>
        /// Index of the of the memory type to allocate from
        /// </summary>
        public UInt32 MemoryTypeIndex;
    }
}
