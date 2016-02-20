using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AndroidSurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr pNext;
        public AndroidSurfaceCreateFlagsKHR flags;
        public ANativeWindow window;
    }
}
