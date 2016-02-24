using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorPoolCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public DescriptorPoolCreateFlags flags;
        public UInt32 maxSets;
        public UInt32 poolSizeCount;
        public DescriptorPoolSize[] PoolSizes; // len:poolSizeCount
    }
}
