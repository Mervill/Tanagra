using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WaylandSurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr pNext;
        public WaylandSurfaceCreateFlagsKHR flags;
        public wl_display display;
        public wl_surface surface;
    }
}
