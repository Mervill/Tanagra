using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect3D
    {
        public Offset3D offset;
        public Extent3D extent;
    }
}
