using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SwapchainCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public SwapchainCreateFlagsKHR Flags;
        /// <summary>
        /// The swapchain's target surface
        /// </summary>
        public UInt64 Surface;
        /// <summary>
        /// Minimum number of presentation images the application needs
        /// </summary>
        public UInt32 MinImageCount;
        /// <summary>
        /// Format of the presentation images
        /// </summary>
        public Format ImageFormat;
        /// <summary>
        /// Colorspace of the presentation images
        /// </summary>
        public ColorSpaceKHR ImageColorSpace;
        /// <summary>
        /// Dimensions of the presentation images
        /// </summary>
        public Extent2D ImageExtent;
        /// <summary>
        /// Determines the number of views for multiview/stereo presentation
        /// </summary>
        public UInt32 ImageArrayLayers;
        /// <summary>
        /// Bits indicating how the presentation images will be used
        /// </summary>
        public ImageUsageFlags ImageUsage;
        /// <summary>
        /// Sharing mode used for the presentation images
        /// </summary>
        public SharingMode ImageSharingMode;
        /// <summary>
        /// Number of queue families having access to the images in case of concurrent sharing mode (Optional)
        /// </summary>
        public UInt32 QueueFamilyIndexCount;
        /// <summary>
        /// Array of queue family indices having access to the images in case of concurrent sharing mode
        /// </summary>
        public IntPtr QueueFamilyIndices;
        /// <summary>
        /// The transform, relative to the device's natural orientation, applied to the image content prior to presentation
        /// </summary>
        public SurfaceTransformFlagsKHR PreTransform;
        /// <summary>
        /// The alpha blending mode used when compositing this surface with other surfaces in the window system
        /// </summary>
        public CompositeAlphaFlagsKHR CompositeAlpha;
        /// <summary>
        /// Which presentation mode to use for presents on this swap chain
        /// </summary>
        public PresentModeKHR PresentMode;
        /// <summary>
        /// Specifies whether presentable images may be affected by window clip regions
        /// </summary>
        public Bool32 Clipped;
        /// <summary>
        /// Existing swap chain to replace, if any (Optional)
        /// </summary>
        public UInt64 OldSwapchain;
    }
}
