using System;

namespace Vulkan
{
    public enum SamplerMipmapMode
    {
        /// <summary>
        /// Choose nearest mip level
        /// </summary>
        NEAREST = 0,
        /// <summary>
        /// Linear filter between mip levels
        /// </summary>
        LINEAR = 1,
    }
}
