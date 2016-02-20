using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GraphicsPipelineCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineCreateFlags flags;
        public UInt32 stageCount;
        public PipelineShaderStageCreateInfo pStages;
        public PipelineVertexInputStateCreateInfo pVertexInputState;
        public PipelineInputAssemblyStateCreateInfo pInputAssemblyState;
        public PipelineTessellationStateCreateInfo pTessellationState;
        public PipelineViewportStateCreateInfo pViewportState;
        public PipelineRasterizationStateCreateInfo pRasterizationState;
        public PipelineMultisampleStateCreateInfo pMultisampleState;
        public PipelineDepthStencilStateCreateInfo pDepthStencilState;
        public PipelineColorBlendStateCreateInfo pColorBlendState;
        public PipelineDynamicStateCreateInfo pDynamicState;
        public PipelineLayout layout;
        public RenderPass renderPass;
        public UInt32 subpass;
        public Pipeline basePipelineHandle;
        public Int32 basePipelineIndex;
    }
}
