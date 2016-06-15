using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineLayoutCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineLayoutCreateFlags Flags;
        /// <summary>
        /// Number of descriptor sets interfaced by the pipeline (Optional)
        /// </summary>
        public UInt32 SetLayoutCount;
        /// <summary>
        /// Array of setCount number of descriptor set layout objects defining the layout of the
        /// </summary>
        public IntPtr SetLayouts;
        /// <summary>
        /// Number of push-constant ranges used by the pipeline (Optional)
        /// </summary>
        public UInt32 PushConstantRangeCount;
        /// <summary>
        /// Array of pushConstantRangeCount number of ranges used by various shader stages
        /// </summary>
        public IntPtr PushConstantRanges;
    }
}
