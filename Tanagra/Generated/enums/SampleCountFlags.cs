using System;

namespace Vulkan
{
    [Flags]
    public enum SampleCountFlags
    {
        SAMPLE_COUNT_1_BIT = 0,
        SAMPLE_COUNT_2_BIT = 1,
        SAMPLE_COUNT_4_BIT = 2,
        SAMPLE_COUNT_8_BIT = 3,
        SAMPLE_COUNT_16_BIT = 4,
        SAMPLE_COUNT_32_BIT = 5,
        SAMPLE_COUNT_64_BIT = 6,
    }
}
