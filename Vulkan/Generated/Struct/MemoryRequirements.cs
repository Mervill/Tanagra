using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryRequirements
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Alignment;
        /// <summary>
        /// Bitfield of the allowed memory type indices into memoryTypes[] for this object
        /// </summary>
        public UInt32 MemoryTypeBits;
    }
}
