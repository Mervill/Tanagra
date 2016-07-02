using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineVertexInputStateCreateInfo
    {
        /// <summary>
        /// Should be VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineVertexInputStateCreateFlags Flags;
        /// <summary>
        /// Number of bindings (Optional)
        /// </summary>
        public UInt32 VertexBindingDescriptionCount;
        public IntPtr VertexBindingDescriptions;
        /// <summary>
        /// Number of attributes (Optional)
        /// </summary>
        public UInt32 VertexAttributeDescriptionCount;
        public IntPtr VertexAttributeDescriptions;
    }
}
