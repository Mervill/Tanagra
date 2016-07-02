using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorPoolSize
    {
        public DescriptorType Type;
        public UInt32 DescriptorCount;
        
        public DescriptorPoolSize(DescriptorType Type, UInt32 DescriptorCount)
        {
            this.Type = Type;
            this.DescriptorCount = DescriptorCount;
        }
    }
}
