using System;

namespace Vulkan
{
    [Flags]
    public enum BufferUsageFlags
    {
        None = 0,
        /// <summary>
        /// Can be used as a source of transfer operations
        /// </summary>
        TransferSrc = 1 << 0,
        /// <summary>
        /// Can be used as a destination of transfer operations
        /// </summary>
        TransferDst = 1 << 1,
        /// <summary>
        /// Can be used as TBO
        /// </summary>
        UniformTexelBuffer = 1 << 2,
        /// <summary>
        /// Can be used as IBO
        /// </summary>
        StorageTexelBuffer = 1 << 3,
        /// <summary>
        /// Can be used as UBO
        /// </summary>
        UniformBuffer = 1 << 4,
        /// <summary>
        /// Can be used as SSBO
        /// </summary>
        StorageBuffer = 1 << 5,
        /// <summary>
        /// Can be used as source of fixed-function index fetch (index buffer)
        /// </summary>
        IndexBuffer = 1 << 6,
        /// <summary>
        /// Can be used as source of fixed-function vertex fetch (VBO)
        /// </summary>
        VertexBuffer = 1 << 7,
        /// <summary>
        /// Can be the source of indirect parameters (e.g. indirect buffer, parameter buffer)
        /// </summary>
        IndirectBuffer = 1 << 8,
    }
}
