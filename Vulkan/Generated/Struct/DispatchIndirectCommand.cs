using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DispatchIndirectCommand
    {
        public UInt32 X;
        public UInt32 Y;
        public UInt32 Z;
        
        public DispatchIndirectCommand(UInt32 X, UInt32 Y, UInt32 Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
}
