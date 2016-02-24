using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GraphicsPipelineCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineCreateFlags flags;
        public UInt32 stageCount;
        public PipelineShaderStageCreateInfo[] Stages; // len:stageCount
        public PipelineVertexInputStateCreateInfo VertexInputState;
        public PipelineInputAssemblyStateCreateInfo InputAssemblyState;
        public PipelineTessellationStateCreateInfo TessellationState;
        public PipelineViewportStateCreateInfo ViewportState;
        public PipelineRasterizationStateCreateInfo RasterizationState;
        public PipelineMultisampleStateCreateInfo MultisampleState;
        public PipelineDepthStencilStateCreateInfo DepthStencilState;
        public PipelineColorBlendStateCreateInfo ColorBlendState;
        public PipelineDynamicStateCreateInfo DynamicState;
        public PipelineLayout layout;
        public RenderPass renderPass;
        public UInt32 subpass;
        public Pipeline basePipelineHandle;
        public Int32 basePipelineIndex;
    }
}
