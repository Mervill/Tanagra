using System;

namespace Vulkan
{
    public enum ImageLayout
    {
        /// <summary>
        /// Implicit layout an image is when its contents are undefined due to various reasons (e.g. right after creation)
        /// </summary>
        UNDEFINED = 0,
        /// <summary>
        /// General layout when image can be used for any kind of access
        /// </summary>
        GENERAL = 1,
        /// <summary>
        /// Optimal layout when image is only used for color attachment read/write
        /// </summary>
        COLOR_ATTACHMENT_OPTIMAL = 2,
        /// <summary>
        /// Optimal layout when image is only used for depth/stencil attachment read/write
        /// </summary>
        DEPTH_STENCIL_ATTACHMENT_OPTIMAL = 3,
        /// <summary>
        /// Optimal layout when image is used for read only depth/stencil attachment and shader access
        /// </summary>
        DEPTH_STENCIL_READ_ONLY_OPTIMAL = 4,
        /// <summary>
        /// Optimal layout when image is used for read only shader access
        /// </summary>
        SHADER_READ_ONLY_OPTIMAL = 5,
        /// <summary>
        /// Optimal layout when image is used only as source of transfer operations
        /// </summary>
        TRANSFER_SRC_OPTIMAL = 6,
        /// <summary>
        /// Optimal layout when image is used only as destination of transfer operations
        /// </summary>
        TRANSFER_DST_OPTIMAL = 7,
        /// <summary>
        /// Initial layout used when the data is populated by the CPU
        /// </summary>
        PREINITIALIZED = 8,
    }
}
