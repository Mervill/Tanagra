using System;

namespace Vulkan
{
    [Flags]
    public enum ImageUsageFlags
    {
        /// <summary>
        /// Can be used as a source of transfer operations
        /// </summary>
        TransferSrc = 1 << 0,
        /// <summary>
        /// Can be used as a destination of transfer operations
        /// </summary>
        TransferDst = 1 << 1,
        /// <summary>
        /// Can be sampled from (SAMPLED_IMAGE and COMBINED_IMAGE_SAMPLER descriptor types)
        /// </summary>
        Sampled = 1 << 2,
        /// <summary>
        /// Can be used as storage image (STORAGE_IMAGE descriptor type)
        /// </summary>
        Storage = 1 << 3,
        /// <summary>
        /// Can be used as framebuffer color attachment
        /// </summary>
        ColorAttachment = 1 << 4,
        /// <summary>
        /// Can be used as framebuffer depth/stencil attachment
        /// </summary>
        DepthStencilAttachment = 1 << 5,
        /// <summary>
        /// Image data not needed outside of rendering
        /// </summary>
        TransientAttachment = 1 << 6,
        /// <summary>
        /// Can be used as framebuffer input attachment
        /// </summary>
        InputAttachment = 1 << 7,
    }
}
