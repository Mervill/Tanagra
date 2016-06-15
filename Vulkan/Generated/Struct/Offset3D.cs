using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Offset3D
    {
        public Int32 X;
        public Int32 Y;
        public Int32 Z;
        
        public Offset3D(Int32 X, Int32 Y, Int32 Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
}
