using System;

namespace Vulkan
{
    public enum ImageLayout
    {
        /// <summary>
        /// Implicit layout an image is when its contents are undefined due to various reasons (e.g. right after creation)
        /// </summary>
        IMAGE_LAYOUT_UNDEFINED = 0,
        /// <summary>
        /// General layout when image can be used for any kind of access
        /// </summary>
        IMAGE_LAYOUT_GENERAL = 1,
        /// <summary>
        /// Optimal layout when image is only used for color attachment read/write
        /// </summary>
        IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL = 2,
        /// <summary>
        /// Optimal layout when image is only used for depth/stencil attachment read/write
        /// </summary>
        IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL = 3,
        /// <summary>
        /// Optimal layout when image is used for read only depth/stencil attachment and shader access
        /// </summary>
        IMAGE_LAYOUT_DEPTH_STENCIL_READ_ONLY_OPTIMAL = 4,
        /// <summary>
        /// Optimal layout when image is used for read only shader access
        /// </summary>
        IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL = 5,
        /// <summary>
        /// Optimal layout when image is used only as source of transfer operations
        /// </summary>
        IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL = 6,
        /// <summary>
        /// Optimal layout when image is used only as destination of transfer operations
        /// </summary>
        IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL = 7,
        /// <summary>
        /// Initial layout used when the data is populated by the CPU
        /// </summary>
        IMAGE_LAYOUT_PREINITIALIZED = 8,
    }
}
