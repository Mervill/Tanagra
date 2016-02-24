using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct AndroidSurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr Next;
        public AndroidSurfaceCreateFlagsKHR flags;
        public ANativeWindow window;
    }
}
