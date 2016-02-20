using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect2D
    {
        public Offset2D offset;
        public Extent2D extent;
    }
}
