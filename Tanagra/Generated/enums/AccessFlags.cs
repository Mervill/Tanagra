using System;

namespace Vulkan
{
    [Flags]
    public enum AccessFlags
    {
        /// <summary>
        /// Controls coherency of indirect command reads
        /// </summary>
        ACCESS_INDIRECT_COMMAND_READ_BIT = 1 << 0,
        /// <summary>
        /// Controls coherency of index reads
        /// </summary>
        ACCESS_INDEX_READ_BIT = 1 << 1,
        /// <summary>
        /// Controls coherency of vertex attribute reads
        /// </summary>
        ACCESS_VERTEX_ATTRIBUTE_READ_BIT = 1 << 2,
        /// <summary>
        /// Controls coherency of uniform buffer reads
        /// </summary>
        ACCESS_UNIFORM_READ_BIT = 1 << 3,
        /// <summary>
        /// Controls coherency of input attachment reads
        /// </summary>
        ACCESS_INPUT_ATTACHMENT_READ_BIT = 1 << 4,
        /// <summary>
        /// Controls coherency of shader reads
        /// </summary>
        ACCESS_SHADER_READ_BIT = 1 << 5,
        /// <summary>
        /// Controls coherency of shader writes
        /// </summary>
        ACCESS_SHADER_WRITE_BIT = 1 << 6,
        /// <summary>
        /// Controls coherency of color attachment reads
        /// </summary>
        ACCESS_COLOR_ATTACHMENT_READ_BIT = 1 << 7,
        /// <summary>
        /// Controls coherency of color attachment writes
        /// </summary>
        ACCESS_COLOR_ATTACHMENT_WRITE_BIT = 1 << 8,
        /// <summary>
        /// Controls coherency of depth/stencil attachment reads
        /// </summary>
        ACCESS_DEPTH_STENCIL_ATTACHMENT_READ_BIT = 1 << 9,
        /// <summary>
        /// Controls coherency of depth/stencil attachment writes
        /// </summary>
        ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT = 1 << 10,
        /// <summary>
        /// Controls coherency of transfer reads
        /// </summary>
        ACCESS_TRANSFER_READ_BIT = 1 << 11,
        /// <summary>
        /// Controls coherency of transfer writes
        /// </summary>
        ACCESS_TRANSFER_WRITE_BIT = 1 << 12,
        /// <summary>
        /// Controls coherency of host reads
        /// </summary>
        ACCESS_HOST_READ_BIT = 1 << 13,
        /// <summary>
        /// Controls coherency of host writes
        /// </summary>
        ACCESS_HOST_WRITE_BIT = 1 << 14,
        /// <summary>
        /// Controls coherency of memory reads
        /// </summary>
        ACCESS_MEMORY_READ_BIT = 1 << 15,
        /// <summary>
        /// Controls coherency of memory writes
        /// </summary>
        ACCESS_MEMORY_WRITE_BIT = 1 << 16,
    }
}
