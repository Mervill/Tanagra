using System;

namespace Vulkan
{
    [Flags]
    public enum CullModeFlags
    {
        None = 0,
        Front = 1 << 0,
        Back = 1 << 1,
        FrontAndBack = 1 << 0x00000003,
    }
}
