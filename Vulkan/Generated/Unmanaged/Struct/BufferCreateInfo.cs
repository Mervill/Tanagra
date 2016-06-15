using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Buffer creation flags (Optional)
        /// </summary>
        public BufferCreateFlags Flags;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Buffer usage flags
        /// </summary>
        public BufferUsageFlags Usage;
        public SharingMode SharingMode;
        public UInt32 QueueFamilyIndexCount;
        public IntPtr QueueFamilyIndices;
    }
}
