using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseMemoryBind
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize ResourceOffset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        public UInt64 Memory;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize MemoryOffset;
        /// <summary>
        /// Reserved for future (Optional)
        /// </summary>
        public SparseMemoryBindFlags Flags;
    }
}
