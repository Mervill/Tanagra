using System;

namespace Vulkan
{
    [Flags]
    public enum BufferUsageFlags
    {
        /// <summary>
        /// Can be used as a source of transfer operations
        /// </summary>
        BUFFER_USAGE_TRANSFER_SRC_BIT = 0,
        /// <summary>
        /// Can be used as a destination of transfer operations
        /// </summary>
        BUFFER_USAGE_TRANSFER_DST_BIT = 1,
        /// <summary>
        /// Can be used as TBO
        /// </summary>
        BUFFER_USAGE_UNIFORM_TEXEL_BUFFER_BIT = 2,
        /// <summary>
        /// Can be used as IBO
        /// </summary>
        BUFFER_USAGE_STORAGE_TEXEL_BUFFER_BIT = 3,
        /// <summary>
        /// Can be used as UBO
        /// </summary>
        BUFFER_USAGE_UNIFORM_BUFFER_BIT = 4,
        /// <summary>
        /// Can be used as SSBO
        /// </summary>
        BUFFER_USAGE_STORAGE_BUFFER_BIT = 5,
        /// <summary>
        /// Can be used as source of fixed-function index fetch (index buffer)
        /// </summary>
        BUFFER_USAGE_INDEX_BUFFER_BIT = 6,
        /// <summary>
        /// Can be used as source of fixed-function vertex fetch (VBO)
        /// </summary>
        BUFFER_USAGE_VERTEX_BUFFER_BIT = 7,
        /// <summary>
        /// Can be the source of indirect parameters (e.g. indirect buffer, parameter buffer)
        /// </summary>
        BUFFER_USAGE_INDIRECT_BUFFER_BIT = 8,
    }
}
