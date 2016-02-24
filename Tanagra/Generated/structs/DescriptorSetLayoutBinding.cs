using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSetLayoutBinding
    {
        public UInt32 binding;
        public DescriptorType descriptorType;
        public UInt32 descriptorCount;
        public ShaderStageFlags stageFlags;
        public Sampler[] ImmutableSamplers; // len:descriptorCount
    }
}
