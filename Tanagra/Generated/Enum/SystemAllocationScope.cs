using System;

namespace Vulkan
{
    public enum SystemAllocationScope
    {
        SYSTEM_ALLOCATION_SCOPE_COMMAND = 0,
        SYSTEM_ALLOCATION_SCOPE_OBJECT = 1,
        SYSTEM_ALLOCATION_SCOPE_CACHE = 2,
        SYSTEM_ALLOCATION_SCOPE_DEVICE = 3,
        SYSTEM_ALLOCATION_SCOPE_INSTANCE = 4,
    }
}
