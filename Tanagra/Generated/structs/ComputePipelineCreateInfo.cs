using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ComputePipelineCreateInfo
    {
        internal Interop.ComputePipelineCreateInfo* NativeHandle;
        
        public PipelineCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        PipelineShaderStageCreateInfo _Stage;
        public PipelineShaderStageCreateInfo Stage
        {
            get { return _Stage; }
            set { _Stage = value; NativeHandle->Stage = (IntPtr)value.NativeHandle; }
        }
        
        PipelineLayout _Layout;
        public PipelineLayout Layout
        {
            get { return _Layout; }
            set { _Layout = value; NativeHandle->Layout = (IntPtr)value.NativeHandle; }
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
        
        public ComputePipelineCreateInfo()
        {
            NativeHandle = (Interop.ComputePipelineCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ComputePipelineCreateInfo));
            //NativeHandle->SType = StructureType.ComputePipelineCreateInfo;
        }
    }
}
