using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplaySurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_DISPLAY_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DisplaySurfaceCreateFlagsKHR Flags;
        /// <summary>
        /// The mode to use when displaying this surface
        /// </summary>
        public UInt64 DisplayMode;
        /// <summary>
        /// The plane on which this surface appears. Must be between 0 and the value returned by vkGetPhysicalDeviceDisplayPlanePropertiesKHR() in pPropertyCount.
        /// </summary>
        public UInt32 PlaneIndex;
        /// <summary>
        /// The z-order of the plane.
        /// </summary>
        public UInt32 PlaneStackIndex;
        /// <summary>
        /// Transform to apply to the images as part of the scannout operation
        /// </summary>
        public SurfaceTransformFlagsKHR Transform;
        /// <summary>
        /// Global alpha value. Must be between 0 and 1, inclusive. Ignored if alphaMode is not VK_DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR
        /// </summary>
        public Single GlobalAlpha;
        /// <summary>
        /// What type of alpha blending to use. Must be a bit from vkGetDisplayPlanePropertiesKHR::supportedAlpha.
        /// </summary>
        public DisplayPlaneAlphaFlagsKHR AlphaMode;
        /// <summary>
        /// Size of the images to use with this surface
        /// </summary>
        public Extent2D ImageExtent;
    }
}
