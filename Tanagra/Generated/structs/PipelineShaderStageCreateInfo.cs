using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineShaderStageCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineShaderStageCreateFlags flags;
        public ShaderStageFlags stage;
        public ShaderModule module;
        public Char pName;
        public SpecializationInfo pSpecializationInfo;
    }
}
