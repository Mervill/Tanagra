using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct QueueFamilyProperties
    {
        /// <summary>
        /// Queue flags (Optional)
        /// </summary>
        public QueueFlags QueueFlags;
        public UInt32 QueueCount;
        public UInt32 TimestampValidBits;
        /// <summary>
        /// Minimum alignment requirement for image transfers
        /// </summary>
        public Extent3D MinImageTransferGranularity;
    }
}
