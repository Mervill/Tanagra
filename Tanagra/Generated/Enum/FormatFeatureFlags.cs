using System;

namespace Vulkan
{
    [Flags]
    public enum FormatFeatureFlags
    {
        /// <summary>
        /// Format can be used for sampled images (SAMPLED_IMAGE and COMBINED_IMAGE_SAMPLER descriptor types)
        /// </summary>
        SampledImage = 1 << 0,
        /// <summary>
        /// Format can be used for storage images (STORAGE_IMAGE descriptor type)
        /// </summary>
        StorageImage = 1 << 1,
        /// <summary>
        /// Format supports atomic operations in case it's used for storage images
        /// </summary>
        StorageImageAtomic = 1 << 2,
        /// <summary>
        /// Format can be used for uniform texel buffers (TBOs)
        /// </summary>
        UniformTexelBuffer = 1 << 3,
        /// <summary>
        /// Format can be used for storage texel buffers (IBOs)
        /// </summary>
        StorageTexelBuffer = 1 << 4,
        /// <summary>
        /// Format supports atomic operations in case it's used for storage texel buffers
        /// </summary>
        StorageTexelBufferAtomic = 1 << 5,
        /// <summary>
        /// Format can be used for vertex buffers (VBOs)
        /// </summary>
        VertexBuffer = 1 << 6,
        /// <summary>
        /// Format can be used for color attachment images
        /// </summary>
        ColorAttachment = 1 << 7,
        /// <summary>
        /// Format supports blending in case it's used for color attachment images
        /// </summary>
        ColorAttachmentBlend = 1 << 8,
        /// <summary>
        /// Format can be used for depth/stencil attachment images
        /// </summary>
        DepthStencilAttachment = 1 << 9,
        /// <summary>
        /// Format can be used as the source image of blits with vkCmdBlitImage
        /// </summary>
        BlitSrc = 1 << 10,
        /// <summary>
        /// Format can be used as the destination image of blits with vkCmdBlitImage
        /// </summary>
        BlitDst = 1 << 11,
        /// <summary>
        /// Format can be filtered with VK_FILTER_LINEAR when being sampled
        /// </summary>
        SampledImageFilterLinear = 1 << 12,
    }
}
