using System;

namespace Vulkan
{
    [Flags]
    public enum ImageUsageFlags
    {
        /// <summary>
        /// Can be used as a source of transfer operations
        /// </summary>
        IMAGE_USAGE_TRANSFER_SRC_BIT = 0,
        /// <summary>
        /// Can be used as a destination of transfer operations
        /// </summary>
        IMAGE_USAGE_TRANSFER_DST_BIT = 1,
        /// <summary>
        /// Can be sampled from (SAMPLED_IMAGE and COMBINED_IMAGE_SAMPLER descriptor types)
        /// </summary>
        IMAGE_USAGE_SAMPLED_BIT = 2,
        /// <summary>
        /// Can be used as storage image (STORAGE_IMAGE descriptor type)
        /// </summary>
        IMAGE_USAGE_STORAGE_BIT = 3,
        /// <summary>
        /// Can be used as framebuffer color attachment
        /// </summary>
        IMAGE_USAGE_COLOR_ATTACHMENT_BIT = 4,
        /// <summary>
        /// Can be used as framebuffer depth/stencil attachment
        /// </summary>
        IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT = 5,
        /// <summary>
        /// Image data not needed outside of rendering
        /// </summary>
        IMAGE_USAGE_TRANSIENT_ATTACHMENT_BIT = 6,
        /// <summary>
        /// Can be used as framebuffer input attachment
        /// </summary>
        IMAGE_USAGE_INPUT_ATTACHMENT_BIT = 7,
    }
}
