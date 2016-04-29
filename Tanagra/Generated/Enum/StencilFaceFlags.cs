using System;

namespace Vulkan
{
    [Flags]
    public enum StencilFaceFlags
    {
        /// <summary>
        /// Front face
        /// </summary>
        Front = 1 << 0,
        /// <summary>
        /// Back face
        /// </summary>
        Back = 1 << 1,
        /// <summary>
        /// Front and back faces
        /// </summary>
        StencilFrontAndBack = 1 << 0x00000003,
    }
}
