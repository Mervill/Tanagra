using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SparseMemoryBind
    {
        public DeviceSize resourceOffset;
        public DeviceSize size;
        public DeviceMemory memory;
        public DeviceSize memoryOffset;
        public SparseMemoryBindFlags flags;
    }
}
