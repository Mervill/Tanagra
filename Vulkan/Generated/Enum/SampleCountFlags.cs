using System;

namespace Vulkan
{
    [Flags]
    public enum SampleCountFlags
    {
        None = 0,
        /// <summary>
        /// Sample count 1 supported
        /// </summary>
        SampleCountFlags1 = 1 << 0,
        /// <summary>
        /// Sample count 2 supported
        /// </summary>
        SampleCountFlags2 = 1 << 1,
        /// <summary>
        /// Sample count 4 supported
        /// </summary>
        SampleCountFlags4 = 1 << 2,
        /// <summary>
        /// Sample count 8 supported
        /// </summary>
        SampleCountFlags8 = 1 << 3,
        /// <summary>
        /// Sample count 16 supported
        /// </summary>
        SampleCountFlags16 = 1 << 4,
        /// <summary>
        /// Sample count 32 supported
        /// </summary>
        SampleCountFlags32 = 1 << 5,
        /// <summary>
        /// Sample count 64 supported
        /// </summary>
        SampleCountFlags64 = 1 << 6,
    }
}
