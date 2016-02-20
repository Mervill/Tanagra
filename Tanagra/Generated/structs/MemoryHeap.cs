using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryHeap
    {
        public DeviceSize size;
        public MemoryHeapFlags flags;
    }
}
