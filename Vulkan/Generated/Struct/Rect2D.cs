using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect2D
    {
        public Offset2D Offset;
        public Extent2D Extent;
        
        public Rect2D(Offset2D Offset, Extent2D Extent)
        {
            this.Offset = Offset;
            this.Extent = Extent;
        }
    }
}
