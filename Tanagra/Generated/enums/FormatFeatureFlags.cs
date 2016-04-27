using System;

namespace Vulkan
{
    [Flags]
    public enum FormatFeatureFlags
    {
        /// <summary>
        /// Format can be used for sampled images (SAMPLED_IMAGE and COMBINED_IMAGE_SAMPLER descriptor types)
        /// </summary>
        FORMAT_FEATURE_SAMPLED_IMAGE_BIT = 1 << 0,
        /// <summary>
        /// Format can be used for storage images (STORAGE_IMAGE descriptor type)
        /// </summary>
        FORMAT_FEATURE_STORAGE_IMAGE_BIT = 1 << 1,
        /// <summary>
        /// Format supports atomic operations in case it's used for storage images
        /// </summary>
        FORMAT_FEATURE_STORAGE_IMAGE_ATOMIC_BIT = 1 << 2,
        /// <summary>
        /// Format can be used for uniform texel buffers (TBOs)
        /// </summary>
        FORMAT_FEATURE_UNIFORM_TEXEL_BUFFER_BIT = 1 << 3,
        /// <summary>
        /// Format can be used for storage texel buffers (IBOs)
        /// </summary>
        FORMAT_FEATURE_STORAGE_TEXEL_BUFFER_BIT = 1 << 4,
        /// <summary>
        /// Format supports atomic operations in case it's used for storage texel buffers
        /// </summary>
        FORMAT_FEATURE_STORAGE_TEXEL_BUFFER_ATOMIC_BIT = 1 << 5,
        /// <summary>
        /// Format can be used for vertex buffers (VBOs)
        /// </summary>
        FORMAT_FEATURE_VERTEX_BUFFER_BIT = 1 << 6,
        /// <summary>
        /// Format can be used for color attachment images
        /// </summary>
        FORMAT_FEATURE_COLOR_ATTACHMENT_BIT = 1 << 7,
        /// <summary>
        /// Format supports blending in case it's used for color attachment images
        /// </summary>
        FORMAT_FEATURE_COLOR_ATTACHMENT_BLEND_BIT = 1 << 8,
        /// <summary>
        /// Format can be used for depth/stencil attachment images
        /// </summary>
        FORMAT_FEATURE_DEPTH_STENCIL_ATTACHMENT_BIT = 1 << 9,
        /// <summary>
        /// Format can be used as the source image of blits with vkCmdBlitImage
        /// </summary>
        FORMAT_FEATURE_BLIT_SRC_BIT = 1 << 10,
        /// <summary>
        /// Format can be used as the destination image of blits with vkCmdBlitImage
        /// </summary>
        FORMAT_FEATURE_BLIT_DST_BIT = 1 << 11,
        /// <summary>
        /// Format can be filtered with VK_FILTER_LINEAR when being sampled
        /// </summary>
        FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_LINEAR_BIT = 1 << 12,
    }
}
