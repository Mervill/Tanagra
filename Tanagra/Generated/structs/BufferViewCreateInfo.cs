using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferViewCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public BufferViewCreateFlags flags;
        public Buffer buffer;
        public Format format;
        public DeviceSize offset;
        public DeviceSize range;
    }
}
