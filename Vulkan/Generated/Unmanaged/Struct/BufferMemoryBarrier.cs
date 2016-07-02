using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferMemoryBarrier
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask;
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask;
        /// <summary>
        /// Queue family to transition ownership from
        /// </summary>
        public UInt32 SrcQueueFamilyIndex;
        /// <summary>
        /// Queue family to transition ownership to
        /// </summary>
        public UInt32 DstQueueFamilyIndex;
        /// <summary>
        /// Buffer to sync
        /// </summary>
        public UInt64 Buffer;
        /// <summary>
        /// Offset within the buffer to sync
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Amount of bytes to sync
        /// </summary>
        public DeviceSize Size;
    }
}
