using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SurfaceCapabilitiesKHR
    {
        public UInt32 minImageCount;
        public UInt32 maxImageCount;
        public Extent2D currentExtent;
        public Extent2D minImageExtent;
        public Extent2D maxImageExtent;
        public UInt32 maxImageArrayLayers;
        public VkSurfaceTransformFlagsKHR supportedTransforms;
        public SurfaceTransformFlagBitsKHR currentTransform;
        public VkCompositeAlphaFlagsKHR supportedCompositeAlpha;
        public ImageUsageFlags supportedUsageFlags;
    }
}
