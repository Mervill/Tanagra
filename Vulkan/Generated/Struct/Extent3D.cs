using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Extent3D
    {
        public UInt32 Width;
        public UInt32 Height;
        public UInt32 Depth;
        
        public Extent3D(UInt32 Width, UInt32 Height, UInt32 Depth)
        {
            this.Width = Width;
            this.Height = Height;
            this.Depth = Depth;
        }
    }
}
