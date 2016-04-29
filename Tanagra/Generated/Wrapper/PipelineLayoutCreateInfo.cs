using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineLayoutCreateInfo
    {
        internal Interop.PipelineLayoutCreateInfo* NativePointer;
        
        public PipelineLayoutCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 SetLayoutCount
        {
            get { return NativePointer->SetLayoutCount; }
            set { NativePointer->SetLayoutCount = value; }
        }
        
        DescriptorSetLayout _SetLayouts;
        public DescriptorSetLayout SetLayouts
        {
            get { return _SetLayouts; }
            set { _SetLayouts = value; NativePointer->SetLayouts = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 PushConstantRangeCount
        {
            get { return NativePointer->PushConstantRangeCount; }
            set { NativePointer->PushConstantRangeCount = value; }
        }
        
        PushConstantRange _PushConstantRanges;
        public PushConstantRange PushConstantRanges
        {
            get { return _PushConstantRanges; }
            set { _PushConstantRanges = value; NativePointer->PushConstantRanges = (IntPtr)value.NativePointer; }
        }
        
        public PipelineLayoutCreateInfo()
        {
            NativePointer = (Interop.PipelineLayoutCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineLayoutCreateInfo));
            NativePointer->SType = StructureType.PipelineLayoutCreateInfo;
        }
    }
}
