using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ComputePipelineCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineCreateFlags flags;
        public PipelineShaderStageCreateInfo stage;
        public PipelineLayout layout;
        public Pipeline basePipelineHandle;
        public Int32 basePipelineIndex;
    }
}
