using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CopyDescriptorSet
    {
        public StructureType sType;
        public IntPtr Next;
        public DescriptorSet srcSet;
        public UInt32 srcBinding;
        public UInt32 srcArrayElement;
        public DescriptorSet dstSet;
        public UInt32 dstBinding;
        public UInt32 dstArrayElement;
        public UInt32 descriptorCount;
    }
}
