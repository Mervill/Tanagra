using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceSparseProperties
    {
        /// <summary>
        /// Sparse resources support: GPU will access all 2D (single sample) sparse resources using the standard sparse image block shapes (based on pixel format)
        /// </summary>
        public Bool32 ResidencyStandard2DBlockShape;
        /// <summary>
        /// Sparse resources support: GPU will access all 2D (multisample) sparse resources using the standard sparse image block shapes (based on pixel format)
        /// </summary>
        public Bool32 ResidencyStandard2DMultisampleBlockShape;
        /// <summary>
        /// Sparse resources support: GPU will access all 3D sparse resources using the standard sparse image block shapes (based on pixel format)
        /// </summary>
        public Bool32 ResidencyStandard3DBlockShape;
        /// <summary>
        /// Sparse resources support: Images with mip-level dimensions that are NOT a multiple of the sparse image block dimensions will be placed in the mip tail
        /// </summary>
        public Bool32 ResidencyAlignedMipSize;
        /// <summary>
        /// Sparse resources support: GPU can consistently access non-resident regions of a resource, all reads return as if data is 0, writes are discarded
        /// </summary>
        public Bool32 ResidencyNonResidentStrict;
    }
}
