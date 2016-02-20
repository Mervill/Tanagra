using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSetAllocateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public DescriptorPool descriptorPool;
        public UInt32 descriptorSetCount;
        public DescriptorSetLayout pSetLayouts;
    }
}
