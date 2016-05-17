using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PipelineDynamicStateCreateInfo
    {
        internal Interop.PipelineDynamicStateCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public PipelineDynamicStateCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public DynamicState[] DynamicStates
        {
            get
            {
                if(NativePointer->DynamicStates == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->DynamicStateCount;
                var valueArray = new DynamicState[valueCount];
                var ptr = (UInt32*)NativePointer->DynamicStates;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = (DynamicState)ptr[x];
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<UInt32>() * valueCount;
                    if(NativePointer->DynamicStates != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->DynamicStates, (IntPtr)typeSize);
                    
                    if(NativePointer->DynamicStates == IntPtr.Zero)
                        NativePointer->DynamicStates = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->DynamicStateCount = (UInt32)valueCount;
                    var ptr = (UInt32*)NativePointer->DynamicStates;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = (UInt32)value[x];
                }
                else
                {
                    if(NativePointer->DynamicStates != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->DynamicStates);
                    
                    NativePointer->DynamicStates = IntPtr.Zero;
                    NativePointer->DynamicStateCount = 0;
                }
            }
        }
        
        public PipelineDynamicStateCreateInfo()
        {
            NativePointer = (Interop.PipelineDynamicStateCreateInfo*)MemoryUtils.Allocate(typeof(Interop.PipelineDynamicStateCreateInfo));
            NativePointer->SType = StructureType.PipelineDynamicStateCreateInfo;
        }
        
        public PipelineDynamicStateCreateInfo(DynamicState[] DynamicStates) : this()
        {
            this.DynamicStates = DynamicStates;
        }
    }
}
