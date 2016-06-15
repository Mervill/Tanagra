using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayPropertiesKHR
    {
        /// <summary>
        /// Handle of the display object
        /// </summary>
        public UInt64 Display;
        /// <summary>
        /// Name of the display
        /// </summary>
        public IntPtr DisplayName;
        /// <summary>
        /// In millimeters?
        /// </summary>
        public Extent2D PhysicalDimensions;
        /// <summary>
        /// Max resolution for CRT?
        /// </summary>
        public Extent2D PhysicalResolution;
        /// <summary>
        /// One or more bits from VkSurfaceTransformFlagsKHR (Optional)
        /// </summary>
        public SurfaceTransformFlagsKHR SupportedTransforms;
        /// <summary>
        /// VK_TRUE if the overlay plane's z-order can be changed on this display.
        /// </summary>
        public Bool32 PlaneReorderPossible;
        /// <summary>
        /// VK_TRUE if this is a "smart" display that supports self-refresh/internal buffering.
        /// </summary>
        public Bool32 PersistentContent;
    }
}
