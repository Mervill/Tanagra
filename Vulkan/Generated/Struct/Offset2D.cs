using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Offset2D
    {
        public Int32 X;
        public Int32 Y;
        
        public Offset2D(Int32 X, Int32 Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
