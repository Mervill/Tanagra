using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryAllocateInfo
    {
        internal Interop.MemoryAllocateInfo* NativePointer;
        
        /// <summary>
        /// Size of memory allocation
        /// </summary>
        public DeviceSize AllocationSize
        {
            get { return NativePointer->AllocationSize; }
            set { NativePointer->AllocationSize = value; }
        }
        
        /// <summary>
        /// Index of the of the memory type to allocate from
        /// </summary>
        public UInt32 MemoryTypeIndex
        {
            get { return NativePointer->MemoryTypeIndex; }
            set { NativePointer->MemoryTypeIndex = value; }
        }
        
        public MemoryAllocateInfo()
        {
            NativePointer = (Interop.MemoryAllocateInfo*)MemoryUtils.Allocate(typeof(Interop.MemoryAllocateInfo));
            NativePointer->SType = StructureType.MemoryAllocateInfo;
        }
        
        public MemoryAllocateInfo(DeviceSize AllocationSize, UInt32 MemoryTypeIndex) : this()
        {
            this.AllocationSize = AllocationSize;
            this.MemoryTypeIndex = MemoryTypeIndex;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.MemoryAllocateInfo*)IntPtr.Zero;
        }
    }
}
