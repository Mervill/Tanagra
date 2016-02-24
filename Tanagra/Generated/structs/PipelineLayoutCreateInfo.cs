using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineLayoutCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineLayoutCreateFlags flags;
        public UInt32 setLayoutCount;
        public DescriptorSetLayout[] SetLayouts; // len:setLayoutCount
        public UInt32 pushConstantRangeCount;
        public PushConstantRange[] PushConstantRanges; // len:pushConstantRangeCount
    }
}
