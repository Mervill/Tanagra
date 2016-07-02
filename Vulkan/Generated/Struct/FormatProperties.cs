using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FormatProperties
    {
        /// <summary>
        /// Format features in case of linear tiling (Optional)
        /// </summary>
        public FormatFeatureFlags LinearTilingFeatures;
        /// <summary>
        /// Format features in case of optimal tiling (Optional)
        /// </summary>
        public FormatFeatureFlags OptimalTilingFeatures;
        /// <summary>
        /// Format features supported by buffers (Optional)
        /// </summary>
        public FormatFeatureFlags BufferFeatures;
    }
}
