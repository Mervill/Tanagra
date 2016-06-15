using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect3D
    {
        public Offset3D Offset;
        public Extent3D Extent;
        
        public Rect3D(Offset3D Offset, Extent3D Extent)
        {
            this.Offset = Offset;
            this.Extent = Extent;
        }
    }
}
