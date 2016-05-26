using System;

namespace Vulkan
{
    public enum SamplerMipmapMode
    {
        /// <summary>
        /// Choose nearest mip level
        /// </summary>
        Nearest = 0,
        /// <summary>
        /// Linear filter between mip levels
        /// </summary>
        Linear = 1,
    }
}
