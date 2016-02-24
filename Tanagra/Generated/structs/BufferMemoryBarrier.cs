using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferMemoryBarrier
    {
        public StructureType sType;
        public IntPtr Next;
        public AccessFlags srcAccessMask;
        public AccessFlags dstAccessMask;
        public UInt32 srcQueueFamilyIndex;
        public UInt32 dstQueueFamilyIndex;
        public Buffer buffer;
        public DeviceSize offset;
        public DeviceSize size;
    }
}
