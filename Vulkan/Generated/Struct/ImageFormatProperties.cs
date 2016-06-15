using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageFormatProperties
    {
        /// <summary>
        /// Max image dimensions for this resource type
        /// </summary>
        public Extent3D MaxExtent;
        /// <summary>
        /// Max number of mipmap levels for this resource type
        /// </summary>
        public UInt32 MaxMipLevels;
        /// <summary>
        /// Max array size for this resource type
        /// </summary>
        public UInt32 MaxArrayLayers;
        /// <summary>
        /// Supported sample counts for this resource type (Optional)
        /// </summary>
        public SampleCountFlags SampleCounts;
        /// <summary>
        /// Max size (in bytes) of this resource type
        /// </summary>
        public DeviceSize MaxResourceSize;
    }
}
