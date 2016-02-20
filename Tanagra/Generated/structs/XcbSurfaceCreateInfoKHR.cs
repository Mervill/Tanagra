using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XcbSurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr pNext;
        public XcbSurfaceCreateFlagsKHR flags;
        public xcb_connection_t connection;
        public xcb_window_t window;
    }
}
