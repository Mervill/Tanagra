using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Extent2D
    {
        public UInt32 width;
        public UInt32 height;
    }
}
