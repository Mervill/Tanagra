using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineLayoutCreateInfo
    {
        internal Interop.PipelineLayoutCreateInfo* NativeHandle;
        
        public PipelineLayoutCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 SetLayoutCount
        {
            get { return NativeHandle->SetLayoutCount; }
            set { NativeHandle->SetLayoutCount = value; }
        }
        
        DescriptorSetLayout _SetLayouts;
        public DescriptorSetLayout SetLayouts
        {
            get { return _SetLayouts; }
            set { _SetLayouts = value; NativeHandle->SetLayouts = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 PushConstantRangeCount
        {
            get { return NativeHandle->PushConstantRangeCount; }
            set { NativeHandle->PushConstantRangeCount = value; }
        }
        
        PushConstantRange _PushConstantRanges;
        public PushConstantRange PushConstantRanges
        {
            get { return _PushConstantRanges; }
            set { _PushConstantRanges = value; NativeHandle->PushConstantRanges = (IntPtr)value.NativeHandle; }
        }
        
        public PipelineLayoutCreateInfo()
        {
            NativeHandle = (Interop.PipelineLayoutCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineLayoutCreateInfo));
            //NativeHandle->SType = StructureType.PipelineLayoutCreateInfo;
        }
    }
}
