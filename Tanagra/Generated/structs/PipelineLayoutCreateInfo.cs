using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineLayoutCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineLayoutCreateFlags flags;
        public UInt32 setLayoutCount;
        public DescriptorSetLayout pSetLayouts;
        public UInt32 pushConstantRangeCount;
        public PushConstantRange pPushConstantRanges;
    }
}
