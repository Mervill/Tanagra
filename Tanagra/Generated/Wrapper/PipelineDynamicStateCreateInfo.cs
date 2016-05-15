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
        
        public DynamicState[] DynamicStates
        {
            get
            {
                var valueCount = NativePointer->DynamicStateCount;
                var valueArray = new DynamicState[valueCount];
                var ptr = (UInt32*)NativePointer->DynamicStates;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = (DynamicState)ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->DynamicStateCount = (UInt32)valueCount;
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
        
        public PipelineDynamicStateCreateInfo(DynamicState[] DynamicStates) : this()
        {
            this.DynamicStates = DynamicStates;
        }
    }
}
