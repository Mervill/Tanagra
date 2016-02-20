using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommandBufferAllocateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public CommandPool commandPool;
        public CommandBufferLevel level;
        public UInt32 commandBufferCount;
    }
}
