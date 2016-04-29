using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryAllocateInfo
    {
        internal Interop.MemoryAllocateInfo* NativePointer;
        
        public DeviceSize AllocationSize
        {
            get { return NativePointer->AllocationSize; }
            set { NativePointer->AllocationSize = value; }
        }
        
        public UInt32 MemoryTypeIndex
        {
            get { return NativePointer->MemoryTypeIndex; }
            set { NativePointer->MemoryTypeIndex = value; }
        }
        
        public MemoryAllocateInfo()
        {
            NativePointer = (Interop.MemoryAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.MemoryAllocateInfo));
            NativePointer->SType = StructureType.MemoryAllocateInfo;
        }
    }
}
