using System;

namespace Vulkan
{
    [Flags]
    public enum SparseImageFormatFlags
    {
        /// <summary>
        /// Image uses a single miptail region for all array layers
        /// </summary>
        SPARSE_IMAGE_FORMAT_SINGLE_MIPTAIL_BIT = 1 << 0,
        /// <summary>
        /// Image requires mip level dimensions to be an integer multiple of the sparse image block dimensions for non-miptail levels.
        /// </summary>
        SPARSE_IMAGE_FORMAT_ALIGNED_MIP_SIZE_BIT = 1 << 1,
        /// <summary>
        /// Image uses a non-standard sparse image block dimensions
        /// </summary>
        SPARSE_IMAGE_FORMAT_NONSTANDARD_BLOCK_SIZE_BIT = 1 << 2,
    }
}
