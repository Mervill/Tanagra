using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayPlaneCapabilitiesKHR
    {
        /// <summary>
        /// Types of alpha blending supported, if any. (Optional)
        /// </summary>
        public DisplayPlaneAlphaFlagsKHR SupportedAlpha;
        /// <summary>
        /// Does the plane have any position and extent restrictions?
        /// </summary>
        public Offset2D MinSrcPosition;
        public Offset2D MaxSrcPosition;
        public Extent2D MinSrcExtent;
        public Extent2D MaxSrcExtent;
        public Offset2D MinDstPosition;
        public Offset2D MaxDstPosition;
        public Extent2D MinDstExtent;
        public Extent2D MaxDstExtent;
        
        /// <param name="MinSrcPosition">Does the plane have any position and extent restrictions?</param>
        public DisplayPlaneCapabilitiesKHR(Offset2D MinSrcPosition, Offset2D MaxSrcPosition, Extent2D MinSrcExtent, Extent2D MaxSrcExtent, Offset2D MinDstPosition, Offset2D MaxDstPosition, Extent2D MinDstExtent, Extent2D MaxDstExtent)
        {
            this.MinSrcPosition = MinSrcPosition;
            this.MaxSrcPosition = MaxSrcPosition;
            this.MinSrcExtent = MinSrcExtent;
            this.MaxSrcExtent = MaxSrcExtent;
            this.MinDstPosition = MinDstPosition;
            this.MaxDstPosition = MaxDstPosition;
            this.MinDstExtent = MinDstExtent;
            this.MaxDstExtent = MaxDstExtent;
            SupportedAlpha = default(DisplayPlaneAlphaFlagsKHR);
        }
    }
}
