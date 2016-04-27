using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineDynamicStateCreateInfo
    {
        internal Interop.PipelineDynamicStateCreateInfo* NativeHandle;
        
        public PipelineDynamicStateCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public UInt32 DynamicStateCount
        {
            get { return NativeHandle->DynamicStateCount; }
            set { NativeHandle->DynamicStateCount = value; }
        }
        
        public DynamicState DynamicStates
        {
            get { return NativeHandle->DynamicStates; }
            set { NativeHandle->DynamicStates = value; }
        }
        
        public PipelineDynamicStateCreateInfo()
        {
            NativeHandle = (Interop.PipelineDynamicStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineDynamicStateCreateInfo));
            //NativeHandle->SType = StructureType.PipelineDynamicStateCreateInfo;
        }
    }
}
