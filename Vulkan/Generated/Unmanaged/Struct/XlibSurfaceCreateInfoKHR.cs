using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XlibSurfaceCreateInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public XlibSurfaceCreateFlagsKHR Flags;
        public IntPtr Dpy;
        public IntPtr Window;
    }
}
