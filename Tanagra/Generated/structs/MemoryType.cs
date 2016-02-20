using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryType
    {
        public MemoryPropertyFlags propertyFlags;
        public UInt32 heapIndex;
    }
}
