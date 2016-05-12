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
        
        public DynamicState[] DynamicStates
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DynamicStateCount = (uint)valueCount;
                NativePointer->DynamicStates = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);
                var ptr = (UInt32*)NativePointer->DynamicStates;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = (UInt32)value[x];
            }
        }
        
        public PipelineDynamicStateCreateInfo()
        {
            NativePointer = (Interop.PipelineDynamicStateCreateInfo*)Interop.Structure.Allocate(typeof(Interop.PipelineDynamicStateCreateInfo));
            NativePointer->SType = StructureType.PipelineDynamicStateCreateInfo;
        }
    }
}
