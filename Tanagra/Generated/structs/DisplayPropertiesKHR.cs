using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayPropertiesKHR
    {
        public DisplayKHR display;
        public Char displayName;
        public Extent2D physicalDimensions;
        public Extent2D physicalResolution;
        public VkSurfaceTransformFlagsKHR supportedTransforms;
        public Boolean planeReorderPossible;
        public Boolean persistentContent;
    }
}
