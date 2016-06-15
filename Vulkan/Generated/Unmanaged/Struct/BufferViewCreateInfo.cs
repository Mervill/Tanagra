using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferViewCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BUFFER_VIEW_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public BufferViewCreateFlags Flags;
        public UInt64 Buffer;
        /// <summary>
        /// Optionally specifies format of elements
        /// </summary>
        public Format Format;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// View size specified in bytes
        /// </summary>
        public DeviceSize Range;
    }
}
