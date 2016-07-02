using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GraphicsPipelineCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO
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
        public UInt32 StageCount;
        /// <summary>
        /// One entry for each active shader stage
        /// </summary>
        public IntPtr Stages;
        public IntPtr VertexInputState;
        public IntPtr InputAssemblyState;
        public IntPtr TessellationState;
        public IntPtr ViewportState;
        public IntPtr RasterizationState;
        public IntPtr MultisampleState;
        public IntPtr DepthStencilState;
        public IntPtr ColorBlendState;
        public IntPtr DynamicState;
        /// <summary>
        /// Interface layout of the pipeline
        /// </summary>
        public UInt64 Layout;
        public UInt64 RenderPass;
        public UInt32 Subpass;
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
