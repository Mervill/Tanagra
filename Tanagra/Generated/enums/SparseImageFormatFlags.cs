using System;

namespace Vulkan
{
    [Flags]
    public enum SparseImageFormatFlags
    {
        SPARSE_IMAGE_FORMAT_SINGLE_MIPTAIL_BIT = 0,
        SPARSE_IMAGE_FORMAT_ALIGNED_MIP_SIZE_BIT = 1,
        SPARSE_IMAGE_FORMAT_NONSTANDARD_BLOCK_SIZE_BIT = 2,
    }
}
