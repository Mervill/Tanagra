using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WaylandSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public WaylandSurfaceCreateFlagsKHR Flags;
        public IntPtr Display;
        public IntPtr Surface;
    }
}
