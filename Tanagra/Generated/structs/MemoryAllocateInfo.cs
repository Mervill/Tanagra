using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryAllocateInfo
    {
        internal Interop.MemoryAllocateInfo* NativeHandle;
        
        DeviceSize _AllocationSize;
        public DeviceSize AllocationSize
        {
            get { return _AllocationSize; }
            set { _AllocationSize = value; NativeHandle->AllocationSize = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MemoryTypeIndex
        {
            get { return NativeHandle->MemoryTypeIndex; }
            set { NativeHandle->MemoryTypeIndex = value; }
        }
        
        public MemoryAllocateInfo()
        {
            NativeHandle = (Interop.MemoryAllocateInfo*)Interop.Structure.Allocate(typeof(Interop.MemoryAllocateInfo));
            //NativeHandle->SType = StructureType.MemoryAllocateInfo;
        }
    }
}
