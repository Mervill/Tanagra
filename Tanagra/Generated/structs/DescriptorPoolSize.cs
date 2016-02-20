using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorPoolSize
    {
        public DescriptorType type;
        public UInt32 descriptorCount;
    }
}
