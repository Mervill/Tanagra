using System;

namespace Vulkan
{
    [Flags]
    public enum DescriptorPoolCreateFlags
    {
        /// <summary>
        /// Descriptor sets may be freed individually
        /// </summary>
        DESCRIPTOR_POOL_CREATE_FREE_DESCRIPTOR_SET_BIT = 1 << 0,
    }
}
