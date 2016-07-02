using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SurfaceCapabilitiesKHR
    {
        /// <summary>
        /// Supported minimum number of images for the surface
        /// </summary>
        public UInt32 MinImageCount;
        /// <summary>
        /// Supported maximum number of images for the surface, 0 for unlimited
        /// </summary>
        public UInt32 MaxImageCount;
        /// <summary>
        /// Current image width and height for the surface, (0, 0) if undefined
        /// </summary>
        public Extent2D CurrentExtent;
        /// <summary>
        /// Supported minimum image width and height for the surface
        /// </summary>
        public Extent2D MinImageExtent;
        /// <summary>
        /// Supported maximum image width and height for the surface
        /// </summary>
        public Extent2D MaxImageExtent;
        /// <summary>
        /// Supported maximum number of image layers for the surface
        /// </summary>
        public UInt32 MaxImageArrayLayers;
        /// <summary>
        /// 1 or more bits representing the transforms supported (Optional)
        /// </summary>
        public SurfaceTransformFlagsKHR SupportedTransforms;
        /// <summary>
        /// The surface's current transform relative to the device's natural orientation
        /// </summary>
        public SurfaceTransformFlagsKHR CurrentTransform;
        /// <summary>
        /// 1 or more bits representing the alpha compositing modes supported (Optional)
        /// </summary>
        public CompositeAlphaFlagsKHR SupportedCompositeAlpha;
        /// <summary>
        /// Supported image usage flags for the surface (Optional)
        /// </summary>
        public ImageUsageFlags SupportedUsageFlags;
        
        /// <param name="MinImageCount">Supported minimum number of images for the surface</param>
        /// <param name="MaxImageCount">Supported maximum number of images for the surface, 0 for unlimited</param>
        /// <param name="CurrentExtent">Current image width and height for the surface, (0, 0) if undefined</param>
        /// <param name="MinImageExtent">Supported minimum image width and height for the surface</param>
        /// <param name="MaxImageExtent">Supported maximum image width and height for the surface</param>
        /// <param name="MaxImageArrayLayers">Supported maximum number of image layers for the surface</param>
        /// <param name="CurrentTransform">The surface's current transform relative to the device's natural orientation</param>
        public SurfaceCapabilitiesKHR(UInt32 MinImageCount, UInt32 MaxImageCount, Extent2D CurrentExtent, Extent2D MinImageExtent, Extent2D MaxImageExtent, UInt32 MaxImageArrayLayers, SurfaceTransformFlagsKHR CurrentTransform)
        {
            this.MinImageCount = MinImageCount;
            this.MaxImageCount = MaxImageCount;
            this.CurrentExtent = CurrentExtent;
            this.MinImageExtent = MinImageExtent;
            this.MaxImageExtent = MaxImageExtent;
            this.MaxImageArrayLayers = MaxImageArrayLayers;
            this.CurrentTransform = CurrentTransform;
            SupportedTransforms = default(SurfaceTransformFlagsKHR);
            SupportedCompositeAlpha = default(CompositeAlphaFlagsKHR);
            SupportedUsageFlags = default(ImageUsageFlags);
        }
    }
}
