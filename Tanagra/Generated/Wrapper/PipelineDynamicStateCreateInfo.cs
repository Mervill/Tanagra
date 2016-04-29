using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineDynamicStateCreateInfo
    {
        internal Interop.PipelineDynamicStateCreateInfo* NativePointer;
        
        public PipelineDynamicStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public UInt32 DynamicStateCount
        {
            get { return NativePointer->DynamicStateCount; }
            set { NativePointer->DynamicStateCount = value; }
        }
        
        public DynamicState DynamicStates
        {
            get { return NativePointer->DynamicStates; }
            set { NativePointer->DynamicStates = value; }
        }
        
        public PipelineDynamicStateCreateInfo()
        {
            NativePointer = (Interop.PipelineDynamicStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineDynamicStateCreateInfo));
            NativePointer->SType = StructureType.PipelineDynamicStateCreateInfo;
        }
    }
}
