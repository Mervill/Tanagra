using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WriteDescriptorSet
    {
        public StructureType sType;
        public IntPtr pNext;
        public DescriptorSet dstSet;
        public UInt32 dstBinding;
        public UInt32 dstArrayElement;
        public UInt32 descriptorCount;
        public DescriptorType descriptorType;
        public DescriptorImageInfo pImageInfo;
        public DescriptorBufferInfo pBufferInfo;
        public BufferView pTexelBufferView;
    }
}
