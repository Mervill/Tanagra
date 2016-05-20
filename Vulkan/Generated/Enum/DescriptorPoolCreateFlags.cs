using System;

namespace Vulkan
{
    [Flags]
    public enum DescriptorPoolCreateFlags
    {
        None = 0,
        /// <summary>
        /// Descriptor sets may be freed individually
        /// </summary>
        FreeDescriptorSet = 1 << 0,
    }
}
