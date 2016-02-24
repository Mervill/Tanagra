using System;

namespace Vulkan
{
    [Flags]
    public enum SampleCountFlags
    {
        /// <summary>
        /// Sample count 1 supported
        /// </summary>
        SAMPLE_COUNT_1_BIT = 0,
        /// <summary>
        /// Sample count 2 supported
        /// </summary>
        SAMPLE_COUNT_2_BIT = 1,
        /// <summary>
        /// Sample count 4 supported
        /// </summary>
        SAMPLE_COUNT_4_BIT = 2,
        /// <summary>
        /// Sample count 8 supported
        /// </summary>
        SAMPLE_COUNT_8_BIT = 3,
        /// <summary>
        /// Sample count 16 supported
        /// </summary>
        SAMPLE_COUNT_16_BIT = 4,
        /// <summary>
        /// Sample count 32 supported
        /// </summary>
        SAMPLE_COUNT_32_BIT = 5,
        /// <summary>
        /// Sample count 64 supported
        /// </summary>
        SAMPLE_COUNT_64_BIT = 6,
    }
}
