using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class GraphicsPipelineCreateInfo
    {
        internal Interop.GraphicsPipelineCreateInfo* NativePointer;
        
        /// <summary>
        /// Pipeline creation flags (Optional)
        /// </summary>
        public PipelineCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// One entry for each active shader stage
        /// </summary>
        public PipelineShaderStageCreateInfo[] Stages
        {
            get
            {
                if(NativePointer->Stages == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->StageCount;
                var valueArray = new PipelineShaderStageCreateInfo[valueCount];
                var ptr = (Interop.PipelineShaderStageCreateInfo*)NativePointer->Stages;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new PipelineShaderStageCreateInfo { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Interop.PipelineShaderStageCreateInfo>() * valueCount;
                    if(NativePointer->Stages != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Stages, (IntPtr)typeSize);
                    
                    if(NativePointer->Stages == IntPtr.Zero)
                        NativePointer->Stages = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->StageCount = (UInt32)valueCount;
                    var ptr = (Interop.PipelineShaderStageCreateInfo*)NativePointer->Stages;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->Stages != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Stages);
                    
                    NativePointer->Stages = IntPtr.Zero;
                    NativePointer->StageCount = 0;
                }
            }
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
        /// <summary>
        /// Interface layout of the pipeline
        /// </summary>
        public PipelineLayout Layout
        {
            get { return _Layout; }
            set { _Layout = value; NativePointer->Layout = value.NativePointer; }
        }
        
        RenderPass _RenderPass;
        public RenderPass RenderPass
        {
            get { return _RenderPass; }
            set { _RenderPass = value; NativePointer->RenderPass = value.NativePointer; }
        }
        
        public UInt32 Subpass
        {
            get { return NativePointer->Subpass; }
            set { NativePointer->Subpass = value; }
        }
        
        Pipeline _BasePipelineHandle;
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is nonzero, it specifies the handle of the base pipeline this is a derivative of (Optional)
        /// </summary>
        public Pipeline BasePipelineHandle
        {
            get { return _BasePipelineHandle; }
            set { _BasePipelineHandle = value; NativePointer->BasePipelineHandle = value.NativePointer; }
        }
        
        /// <summary>
        /// If VK_PIPELINE_CREATE_DERIVATIVE_BIT is set and this value is not -1, it specifies an index into pCreateInfos of the base pipeline this is a derivative of
        /// </summary>
        public Int32 BasePipelineIndex
        {
            get { return NativePointer->BasePipelineIndex; }
            set { NativePointer->BasePipelineIndex = value; }
        }
        
        public GraphicsPipelineCreateInfo()
        {
            NativePointer = (Interop.GraphicsPipelineCreateInfo*)MemoryUtils.Allocate(typeof(Interop.GraphicsPipelineCreateInfo));
            NativePointer->SType = StructureType.GraphicsPipelineCreateInfo;
        }
        
        public GraphicsPipelineCreateInfo(PipelineShaderStageCreateInfo[] Stages, PipelineVertexInputStateCreateInfo VertexInputState, PipelineInputAssemblyStateCreateInfo InputAssemblyState, PipelineRasterizationStateCreateInfo RasterizationState, PipelineLayout Layout, RenderPass RenderPass, UInt32 Subpass, Int32 BasePipelineIndex) : this()
        {
            this.Stages = Stages;
            this.VertexInputState = VertexInputState;
            this.InputAssemblyState = InputAssemblyState;
            this.RasterizationState = RasterizationState;
            this.Layout = Layout;
            this.RenderPass = RenderPass;
            this.Subpass = Subpass;
            this.BasePipelineIndex = BasePipelineIndex;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.GraphicsPipelineCreateInfo*)IntPtr.Zero;
        }
    }
}
