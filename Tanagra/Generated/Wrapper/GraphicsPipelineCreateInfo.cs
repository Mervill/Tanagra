using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class GraphicsPipelineCreateInfo
    {
        internal Interop.GraphicsPipelineCreateInfo* NativeHandle;
        
        public PipelineCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 StageCount
        {
            get { return NativeHandle->StageCount; }
            set { NativeHandle->StageCount = value; }
        }
        
        PipelineShaderStageCreateInfo _Stages;
        public PipelineShaderStageCreateInfo Stages
        {
            get { return _Stages; }
            set { _Stages = value; NativeHandle->Stages = (IntPtr)value.NativeHandle; }
        }
        
        PipelineVertexInputStateCreateInfo _VertexInputState;
        public PipelineVertexInputStateCreateInfo VertexInputState
        {
            get { return _VertexInputState; }
            set { _VertexInputState = value; NativeHandle->VertexInputState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineInputAssemblyStateCreateInfo _InputAssemblyState;
        public PipelineInputAssemblyStateCreateInfo InputAssemblyState
        {
            get { return _InputAssemblyState; }
            set { _InputAssemblyState = value; NativeHandle->InputAssemblyState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineTessellationStateCreateInfo _TessellationState;
        public PipelineTessellationStateCreateInfo TessellationState
        {
            get { return _TessellationState; }
            set { _TessellationState = value; NativeHandle->TessellationState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineViewportStateCreateInfo _ViewportState;
        public PipelineViewportStateCreateInfo ViewportState
        {
            get { return _ViewportState; }
            set { _ViewportState = value; NativeHandle->ViewportState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineRasterizationStateCreateInfo _RasterizationState;
        public PipelineRasterizationStateCreateInfo RasterizationState
        {
            get { return _RasterizationState; }
            set { _RasterizationState = value; NativeHandle->RasterizationState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineMultisampleStateCreateInfo _MultisampleState;
        public PipelineMultisampleStateCreateInfo MultisampleState
        {
            get { return _MultisampleState; }
            set { _MultisampleState = value; NativeHandle->MultisampleState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineDepthStencilStateCreateInfo _DepthStencilState;
        public PipelineDepthStencilStateCreateInfo DepthStencilState
        {
            get { return _DepthStencilState; }
            set { _DepthStencilState = value; NativeHandle->DepthStencilState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineColorBlendStateCreateInfo _ColorBlendState;
        public PipelineColorBlendStateCreateInfo ColorBlendState
        {
            get { return _ColorBlendState; }
            set { _ColorBlendState = value; NativeHandle->ColorBlendState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineDynamicStateCreateInfo _DynamicState;
        public PipelineDynamicStateCreateInfo DynamicState
        {
            get { return _DynamicState; }
            set { _DynamicState = value; NativeHandle->DynamicState = (IntPtr)value.NativeHandle; }
        }
        
        PipelineLayout _Layout;
        public PipelineLayout Layout
        {
            get { return _Layout; }
            set { _Layout = value; NativeHandle->Layout = (IntPtr)value.NativeHandle; }
        }
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativeHandle->RenderPass = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 Subpass
        {
            get { return NativeHandle->Subpass; }
            set { NativeHandle->Subpass = value; }
        }
        
        Pipeline _BasePipelineHandle;
        public Pipeline BasePipelineHandle
        {
            get { return _BasePipelineHandle; }
            set { _BasePipelineHandle = value; NativeHandle->BasePipelineHandle = (IntPtr)value.NativeHandle; }
        }
        
        public Int32 BasePipelineIndex
        {
            get { return NativeHandle->BasePipelineIndex; }
            set { NativeHandle->BasePipelineIndex = value; }
        }
        
        public GraphicsPipelineCreateInfo()
        {
            NativeHandle = (Interop.GraphicsPipelineCreateInfo*)Interop.Structure.Allocate(typeof(Interop.GraphicsPipelineCreateInfo));
            //NativeHandle->SType = StructureType.GraphicsPipelineCreateInfo;
        }
    }
}
