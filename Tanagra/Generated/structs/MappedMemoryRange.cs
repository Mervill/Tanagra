using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MappedMemoryRange
    {
        public StructureType sType;
        public IntPtr Next;
        public DeviceMemory memory;
        public DeviceSize offset;
        public DeviceSize size;
    }
}
