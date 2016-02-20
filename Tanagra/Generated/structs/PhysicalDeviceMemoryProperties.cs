using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDeviceMemoryProperties
    {
        public UInt32 memoryTypeCount;
        public MemoryType memoryTypes;
        public UInt32 memoryHeapCount;
        public MemoryHeap memoryHeaps;
    }
}
