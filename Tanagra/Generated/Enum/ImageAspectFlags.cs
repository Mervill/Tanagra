using System;

namespace Vulkan
{
    [Flags]
    public enum ImageAspectFlags
    {
        None = 0,
        Color = 1 << 0,
        Depth = 1 << 1,
        Stencil = 1 << 2,
        Metadata = 1 << 3,
    }
}
