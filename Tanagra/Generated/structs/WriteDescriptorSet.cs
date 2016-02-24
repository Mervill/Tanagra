using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WriteDescriptorSet
    {
        public StructureType sType;
        public IntPtr Next;
        public DescriptorSet dstSet;
        public UInt32 dstBinding;
        public UInt32 dstArrayElement;
        public UInt32 descriptorCount;
        public DescriptorType descriptorType;
        public DescriptorImageInfo[] ImageInfo; // len:descriptorCount
        public DescriptorBufferInfo[] BufferInfo; // len:descriptorCount
        public BufferView[] TexelBufferView; // len:descriptorCount
    }
}
