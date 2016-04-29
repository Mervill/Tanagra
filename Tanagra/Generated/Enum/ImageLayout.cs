using System;

namespace Vulkan
{
    public enum ImageLayout
    {
        /// <summary>
        /// Implicit layout an image is when its contents are undefined due to various reasons (e.g. right after creation)
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// General layout when image can be used for any kind of access
        /// </summary>
        General = 1,
        /// <summary>
        /// Optimal layout when image is only used for color attachment read/write
        /// </summary>
        ColorAttachmentOptimal = 2,
        /// <summary>
        /// Optimal layout when image is only used for depth/stencil attachment read/write
        /// </summary>
        DepthStencilAttachmentOptimal = 3,
        /// <summary>
        /// Optimal layout when image is used for read only depth/stencil attachment and shader access
        /// </summary>
        DepthStencilReadOnlyOptimal = 4,
        /// <summary>
        /// Optimal layout when image is used for read only shader access
        /// </summary>
        ShaderReadOnlyOptimal = 5,
        /// <summary>
        /// Optimal layout when image is used only as source of transfer operations
        /// </summary>
        TransferSrcOptimal = 6,
        /// <summary>
        /// Optimal layout when image is used only as destination of transfer operations
        /// </summary>
        TransferDstOptimal = 7,
        /// <summary>
        /// Initial layout used when the data is populated by the CPU
        /// </summary>
        Preinitialized = 8,
    }
}
