using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ComputePipelineCreateInfo
    {
        internal Interop.ComputePipelineCreateInfo* NativePointer;
        
        /// <summary>
        /// Pipeline creation flags (Optional)
        /// </summary>
        public PipelineCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public PipelineShaderStageCreateInfo Stage
        {
            get { return new PipelineShaderStageCreateInfo { NativePointer = &NativePointer->Stage }; }
            set { NativePointer->Stage = *value.NativePointer; }
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
        
        public ComputePipelineCreateInfo()
        {
            NativePointer = (Interop.ComputePipelineCreateInfo*)MemoryUtils.Allocate(typeof(Interop.ComputePipelineCreateInfo));
            NativePointer->SType = StructureType.ComputePipelineCreateInfo;
        }
        
        public ComputePipelineCreateInfo(PipelineShaderStageCreateInfo Stage, PipelineLayout Layout, Int32 BasePipelineIndex) : this()
        {
            this.Stage = Stage;
            this.Layout = Layout;
            this.BasePipelineIndex = BasePipelineIndex;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.ComputePipelineCreateInfo*)IntPtr.Zero;
        }
    }
}
