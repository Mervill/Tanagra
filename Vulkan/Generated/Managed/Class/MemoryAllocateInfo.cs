using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class MemoryAllocateInfo : IDisposable
    {
        internal Unmanaged.MemoryAllocateInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.MemoryAllocateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.MemoryAllocateInfo));
            NativePointer->SType = StructureType.MemoryAllocateInfo;
        }
        
        public MemoryAllocateInfo(DeviceSize AllocationSize, UInt32 MemoryTypeIndex) : this()
        {
            this.AllocationSize = AllocationSize;
            this.MemoryTypeIndex = MemoryTypeIndex;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.MemoryAllocateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~MemoryAllocateInfo()
        {
            if(NativePointer != (Unmanaged.MemoryAllocateInfo*)IntPtr.Zero)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.MemoryAllocateInfo*)IntPtr.Zero;
            }
        }
    }
}
