using System;

namespace Vulkan
{
    public enum SamplerAddressMode
    {
        SAMPLER_ADDRESS_MODE_REPEAT = 0,
        SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT = 1,
        SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE = 2,
        SAMPLER_ADDRESS_MODE_CLAMP_TO_BORDER = 3,
    }
}
