using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ComputePipelineCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_COMPUTE_PIPELINE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Pipeline creation flags (Optional)
        /// </summary>
        public PipelineCreateFlags Flags;
        public PipelineShaderStageCreateInfo Stage;
        /// <summary>
        /// Interface layout of the pipeline
        /// </summary>
        public UInt64 Layout;
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of (Optional)
        /// </summary>
        public UInt64 BasePipelineHandle;
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of
        /// </summary>
        public Int32 BasePipelineIndex;
    }
}
