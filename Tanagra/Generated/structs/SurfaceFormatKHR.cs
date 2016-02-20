using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SurfaceFormatKHR
    {
        public Format format;
        public ColorSpaceKHR colorSpace;
    }
}
