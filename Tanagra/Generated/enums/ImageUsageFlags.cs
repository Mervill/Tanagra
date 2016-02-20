using System;

namespace Vulkan
{
    [Flags]
    public enum ImageUsageFlags
    {
        IMAGE_USAGE_TRANSFER_SRC_BIT = 0,
        IMAGE_USAGE_TRANSFER_DST_BIT = 1,
        IMAGE_USAGE_SAMPLED_BIT = 2,
        IMAGE_USAGE_STORAGE_BIT = 3,
        IMAGE_USAGE_COLOR_ATTACHMENT_BIT = 4,
        IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT = 5,
        IMAGE_USAGE_TRANSIENT_ATTACHMENT_BIT = 6,
        IMAGE_USAGE_INPUT_ATTACHMENT_BIT = 7,
    }
}
