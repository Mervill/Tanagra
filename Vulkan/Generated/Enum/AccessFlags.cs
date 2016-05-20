using System;

namespace Vulkan
{
    [Flags]
    public enum AccessFlags
    {
        None = 0,
        /// <summary>
        /// Controls coherency of indirect command reads
        /// </summary>
        IndirectCommandRead = 1 << 0,
        /// <summary>
        /// Controls coherency of index reads
        /// </summary>
        IndexRead = 1 << 1,
        /// <summary>
        /// Controls coherency of vertex attribute reads
        /// </summary>
        VertexAttributeRead = 1 << 2,
        /// <summary>
        /// Controls coherency of uniform buffer reads
        /// </summary>
        UniformRead = 1 << 3,
        /// <summary>
        /// Controls coherency of input attachment reads
        /// </summary>
        InputAttachmentRead = 1 << 4,
        /// <summary>
        /// Controls coherency of shader reads
        /// </summary>
        ShaderRead = 1 << 5,
        /// <summary>
        /// Controls coherency of shader writes
        /// </summary>
        ShaderWrite = 1 << 6,
        /// <summary>
        /// Controls coherency of color attachment reads
        /// </summary>
        ColorAttachmentRead = 1 << 7,
        /// <summary>
        /// Controls coherency of color attachment writes
        /// </summary>
        ColorAttachmentWrite = 1 << 8,
        /// <summary>
        /// Controls coherency of depth/stencil attachment reads
        /// </summary>
        DepthStencilAttachmentRead = 1 << 9,
        /// <summary>
        /// Controls coherency of depth/stencil attachment writes
        /// </summary>
        DepthStencilAttachmentWrite = 1 << 10,
        /// <summary>
        /// Controls coherency of transfer reads
        /// </summary>
        TransferRead = 1 << 11,
        /// <summary>
        /// Controls coherency of transfer writes
        /// </summary>
        TransferWrite = 1 << 12,
        /// <summary>
        /// Controls coherency of host reads
        /// </summary>
        HostRead = 1 << 13,
        /// <summary>
        /// Controls coherency of host writes
        /// </summary>
        HostWrite = 1 << 14,
        /// <summary>
        /// Controls coherency of memory reads
        /// </summary>
        MemoryRead = 1 << 15,
        /// <summary>
        /// Controls coherency of memory writes
        /// </summary>
        MemoryWrite = 1 << 16,
    }
}
