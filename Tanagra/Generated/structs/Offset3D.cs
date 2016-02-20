using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Offset3D
    {
        public Int32 x;
        public Int32 y;
        public Int32 z;
    }
}
