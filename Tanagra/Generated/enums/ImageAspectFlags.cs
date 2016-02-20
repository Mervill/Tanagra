using System;

namespace Vulkan
{
    [Flags]
    public enum ImageAspectFlags
    {
        IMAGE_ASPECT_COLOR_BIT = 0,
        IMAGE_ASPECT_DEPTH_BIT = 1,
        IMAGE_ASPECT_STENCIL_BIT = 2,
        IMAGE_ASPECT_METADATA_BIT = 3,
    }
}
