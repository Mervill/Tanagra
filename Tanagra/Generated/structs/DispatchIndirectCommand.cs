using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DispatchIndirectCommand
    {
        public UInt32 x;
        public UInt32 y;
        public UInt32 z;
    }
}
