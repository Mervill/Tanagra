using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MappedMemoryRange
    {
        public StructureType sType;
        public IntPtr pNext;
        public DeviceMemory memory;
        public DeviceSize offset;
        public DeviceSize size;
    }
}
