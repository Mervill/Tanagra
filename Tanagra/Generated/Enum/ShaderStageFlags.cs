using System;

namespace Vulkan
{
    [Flags]
    public enum ShaderStageFlags
    {
        Vertex = 1 << 0,
        TessellationControl = 1 << 1,
        TessellationEvaluation = 1 << 2,
        Geometry = 1 << 3,
        Fragment = 1 << 4,
        Compute = 1 << 5,
        AllGraphics = 1 << 0x0000001F,
        All = 1 << 0x7FFFFFFF,
    }
}
