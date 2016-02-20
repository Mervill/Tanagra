using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayPlaneCapabilitiesKHR
    {
        public VkDisplayPlaneAlphaFlagsKHR supportedAlpha;
        public Offset2D minSrcPosition;
        public Offset2D maxSrcPosition;
        public Extent2D minSrcExtent;
        public Extent2D maxSrcExtent;
        public Offset2D minDstPosition;
        public Offset2D maxDstPosition;
        public Extent2D minDstExtent;
        public Extent2D maxDstExtent;
    }
}
