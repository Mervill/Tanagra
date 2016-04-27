using System;

namespace Vulkan
{
    public enum SamplerMipmapMode
    {
        /// <summary>
        /// Choose nearest mip level
        /// </summary>
        SAMPLER_MIPMAP_MODE_NEAREST = 0,
        /// <summary>
        /// Linear filter between mip levels
        /// </summary>
        SAMPLER_MIPMAP_MODE_LINEAR = 1,
    }
}
