using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseImageMemoryRequirements
    {
        public SparseImageFormatProperties FormatProperties;
        public UInt32 ImageMipTailFirstLod;
        /// <summary>
        /// Specified in bytes, must be a multiple of sparse block size in bytes / alignment
        /// </summary>
        public DeviceSize ImageMipTailSize;
        /// <summary>
        /// Specified in bytes, must be a multiple of sparse block size in bytes / alignment
        /// </summary>
        public DeviceSize ImageMipTailOffset;
        /// <summary>
        /// Specified in bytes, must be a multiple of sparse block size in bytes / alignment
        /// </summary>
        public DeviceSize ImageMipTailStride;
    }
}
