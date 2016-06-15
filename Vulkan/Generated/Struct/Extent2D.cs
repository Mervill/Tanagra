using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Extent2D
    {
        public UInt32 Width;
        public UInt32 Height;
        
        public Extent2D(UInt32 Width, UInt32 Height)
        {
            this.Width = Width;
            this.Height = Height;
        }
    }
}
