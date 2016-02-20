using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FormatProperties
    {
        public FormatFeatureFlags linearTilingFeatures;
        public FormatFeatureFlags optimalTilingFeatures;
        public FormatFeatureFlags bufferFeatures;
    }
}
