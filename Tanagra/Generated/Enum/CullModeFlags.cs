using System;

namespace Vulkan
{
    [Flags]
    public enum CullModeFlags
    {
        CULL_MODE_NONE = 1 << 0,
        CULL_MODE_FRONT_BIT = 1 << 0,
        CULL_MODE_BACK_BIT = 1 << 1,
        CULL_MODE_FRONT_AND_BACK = 1 << 0x00000003,
    }
}
