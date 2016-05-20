using System;

namespace Vulkan
{
    [Flags]
    public enum SparseImageFormatFlags
    {
        None = 0,
        /// <summary>
        /// Image uses a single miptail region for all array layers
        /// </summary>
        SingleMiptail = 1 << 0,
        /// <summary>
        /// Image requires mip level dimensions to be an integer multiple of the sparse image block dimensions for non-miptail levels.
        /// </summary>
        AlignedMipSize = 1 << 1,
        /// <summary>
        /// Image uses a non-standard sparse image block dimensions
        /// </summary>
        NonstandardBlockSize = 1 << 2,
    }
}
