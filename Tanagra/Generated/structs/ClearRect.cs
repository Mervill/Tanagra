using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClearRect
    {
        public Rect2D rect;
        public UInt32 baseArrayLayer;
        public UInt32 layerCount;
    }
}
