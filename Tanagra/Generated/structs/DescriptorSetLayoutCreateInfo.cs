using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSetLayoutCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public DescriptorSetLayoutCreateFlags flags;
        public UInt32 bindingCount;
        public DescriptorSetLayoutBinding pBindings;
    }
}
