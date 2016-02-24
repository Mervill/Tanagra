using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryBarrier
    {
        public StructureType sType;
        public IntPtr Next;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
    }
}
