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
        
        public DescriptorSetLayout[] SetLayouts
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public UInt32 PushConstantRangeCount
        {
            get { return NativePointer->PushConstantRangeCount; }
            set { NativePointer->PushConstantRangeCount = value; }
        }
        
        public PushConstantRange[] PushConstantRanges
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
        
        public PipelineLayoutCreateInfo()
        {
            NativePointer = (Interop.PipelineLayoutCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineLayoutCreateInfo));
            NativePointer->SType = StructureType.PipelineLayoutCreateInfo;
        }
    }
}
