using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineShaderStageCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineShaderStageCreateFlags flags;
        public ShaderStageFlags stage;
        public ShaderModule module;
        public Char[] Name; // len:null-terminated
        public SpecializationInfo SpecializationInfo;
    }
}
