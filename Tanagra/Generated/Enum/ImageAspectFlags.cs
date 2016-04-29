using System;

namespace Vulkan
{
    [Flags]
    public enum ImageAspectFlags
    {
        Color = 1 << 0,
        Depth = 1 << 1,
        Stencil = 1 << 2,
        Metadata = 1 << 3,
    }
}
