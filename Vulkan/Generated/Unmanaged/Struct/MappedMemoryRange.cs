using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MappedMemoryRange
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Mapped memory object
        /// </summary>
        public UInt64 Memory;
        /// <summary>
        /// Offset within the memory object where the range starts
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Size of the range within the memory object
        /// </summary>
        public DeviceSize Size;
    }
}
