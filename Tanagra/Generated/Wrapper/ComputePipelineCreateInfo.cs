using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ComputePipelineCreateInfo
    {
        internal Interop.ComputePipelineCreateInfo* NativePointer;
        
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
        public PipelineLayout Layout
        {
            get { return _Layout; }
            set { _Layout = value; NativePointer->Layout = value.NativePointer; }
        }
        
        Pipeline _BasePipelineHandle;
        public Pipeline BasePipelineHandle
        {
            get { return _BasePipelineHandle; }
            set { _BasePipelineHandle = value; NativePointer->BasePipelineHandle = value.NativePointer; }
        }
        
        public Int32 BasePipelineIndex
        {
            get { return NativePointer->BasePipelineIndex; }
            set { NativePointer->BasePipelineIndex = value; }
        }
        
        public ComputePipelineCreateInfo()
        {
            NativePointer = (Interop.ComputePipelineCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ComputePipelineCreateInfo));
            NativePointer->SType = StructureType.ComputePipelineCreateInfo;
        }
        
        public ComputePipelineCreateInfo(PipelineShaderStageCreateInfo Stage, PipelineLayout Layout, Int32 BasePipelineIndex) : this()
        {
            this.Stage = Stage;
            this.Layout = Layout;
            this.BasePipelineIndex = BasePipelineIndex;
        }
    }
}
