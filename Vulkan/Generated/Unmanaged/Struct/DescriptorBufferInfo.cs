using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorBufferInfo
    {
        /// <summary>
        /// Buffer used for this descriptor slot when the descriptor is UNIFORM_BUFFER[_DYNAMIC] or STORAGE_BUFFER[_DYNAMIC]. VK_NULL_HANDLE otherwise.
        /// </summary>
        public UInt64 Buffer;
        /// <summary>
        /// Base offset from buffer start in bytes to update in the descriptor set.
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Size in bytes of the buffer resource for this descriptor update.
        /// </summary>
        public DeviceSize Range;
    }
}
