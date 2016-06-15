using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SubresourceLayout
    {
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Offset;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize RowPitch;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize ArrayPitch;
        /// <summary>
        /// Specified in bytes
        /// </summary>
        public DeviceSize DepthPitch;
    }
}
