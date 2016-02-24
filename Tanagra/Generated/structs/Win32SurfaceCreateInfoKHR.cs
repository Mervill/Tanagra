using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Win32SurfaceCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr Next;
        public Win32SurfaceCreateFlagsKHR flags;
        public HINSTANCE hinstance;
        public HWND hwnd;
    }
}
