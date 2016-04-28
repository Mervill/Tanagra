using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class GraphicsPipelineCreateInfo
    {
        internal Interop.GraphicsPipelineCreateInfo* NativePointer;
        
        public PipelineCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 StageCount
        {
            get { return NativePointer->StageCount; }
            set { NativePointer->StageCount = value; }
        }
        
        PipelineShaderStageCreateInfo _Stages;
        public PipelineShaderStageCreateInfo Stages
        {
            get { return _Stages; }
            set { _Stages = value; NativePointer->Stages = (IntPtr)value.NativePointer; }
        }
        
        PipelineVertexInputStateCreateInfo _VertexInputState;
        public PipelineVertexInputStateCreateInfo VertexInputState
        {
            get { return _VertexInputState; }
            set { _VertexInputState = value; NativePointer->VertexInputState = (IntPtr)value.NativePointer; }
        }
        
        PipelineInputAssemblyStateCreateInfo _InputAssemblyState;
        public PipelineInputAssemblyStateCreateInfo InputAssemblyState
        {
            get { return _InputAssemblyState; }
            set { _InputAssemblyState = value; NativePointer->InputAssemblyState = (IntPtr)value.NativePointer; }
        }
        
        PipelineTessellationStateCreateInfo _TessellationState;
        public PipelineTessellationStateCreateInfo TessellationState
        {
            get { return _TessellationState; }
            set { _TessellationState = value; NativePointer->TessellationState = (IntPtr)value.NativePointer; }
        }
        
        PipelineViewportStateCreateInfo _ViewportState;
        public PipelineViewportStateCreateInfo ViewportState
        {
            get { return _ViewportState; }
            set { _ViewportState = value; NativePointer->ViewportState = (IntPtr)value.NativePointer; }
        }
        
        PipelineRasterizationStateCreateInfo _RasterizationState;
        public PipelineRasterizationStateCreateInfo RasterizationState
        {
            get { return _RasterizationState; }
            set { _RasterizationState = value; NativePointer->RasterizationState = (IntPtr)value.NativePointer; }
        }
        
        PipelineMultisampleStateCreateInfo _MultisampleState;
        public PipelineMultisampleStateCreateInfo MultisampleState
        {
            get { return _MultisampleState; }
            set { _MultisampleState = value; NativePointer->MultisampleState = (IntPtr)value.NativePointer; }
        }
        
        PipelineDepthStencilStateCreateInfo _DepthStencilState;
        public PipelineDepthStencilStateCreateInfo DepthStencilState
        {
            get { return _DepthStencilState; }
            set { _DepthStencilState = value; NativePointer->DepthStencilState = (IntPtr)value.NativePointer; }
        }
        
        PipelineColorBlendStateCreateInfo _ColorBlendState;
        public PipelineColorBlendStateCreateInfo ColorBlendState
        {
            get { return _ColorBlendState; }
            set { _ColorBlendState = value; NativePointer->ColorBlendState = (IntPtr)value.NativePointer; }
        }
        
        PipelineDynamicStateCreateInfo _DynamicState;
        public PipelineDynamicStateCreateInfo DynamicState
        {
            get { return _DynamicState; }
            set { _DynamicState = value; NativePointer->DynamicState = (IntPtr)value.NativePointer; }
        }
        
        PipelineLayout _Layout;
        public PipelineLayout Layout
        {
            get { return _Layout; }
            set { _Layout = value; NativePointer->Layout = (IntPtr)value.NativePointer; }
        }
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 Subpass
        {
            get { return NativePointer->Subpass; }
            set { NativePointer->Subpass = value; }
        }
        
        Pipeline _BasePipelineHandle;
        public Pipeline BasePipelineHandle
        {
            get { return _BasePipelineHandle; }
            set { _BasePipelineHandle = value; NativePointer->BasePipelineHandle = (IntPtr)value.NativePointer; }
        }
        
        public Int32 BasePipelineIndex
        {
            get { return NativePointer->BasePipelineIndex; }
            set { NativePointer->BasePipelineIndex = value; }
        }
        
        public GraphicsPipelineCreateInfo()
        {
            NativePointer = (Interop.GraphicsPipelineCreateInfo*)Interop.Structure.Allocate(typeof(Interop.GraphicsPipelineCreateInfo));
            //NativePointer->SType = StructureType.GraphicsPipelineCreateInfo;
        }
    }
}
