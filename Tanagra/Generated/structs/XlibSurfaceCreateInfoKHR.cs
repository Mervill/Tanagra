using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct XlibSurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr pNext;
        public XlibSurfaceCreateFlagsKHR flags;
        public Display dpy;
        public Window window;
    }
}
