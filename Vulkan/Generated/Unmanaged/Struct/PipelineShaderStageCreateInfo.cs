using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineShaderStageCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineShaderStageCreateFlags Flags;
        /// <summary>
        /// Shader stage
        /// </summary>
        public ShaderStageFlags Stage;
        /// <summary>
        /// Module containing entry point
        /// </summary>
        public UInt64 Module;
        /// <summary>
        /// Null-terminated entry point name
        /// </summary>
        public IntPtr Name;
        public IntPtr SpecializationInfo;
    }
}
