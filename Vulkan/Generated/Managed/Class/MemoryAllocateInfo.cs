using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class MemoryAllocateInfo : IDisposable
    {
        internal Unmanaged.MemoryAllocateInfo* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.MemoryAllocateInfo*)MemUtil.Alloc(typeof(Unmanaged.MemoryAllocateInfo));
            NativePointer->SType = StructureType.MemoryAllocateInfo;
        }
        
        internal MemoryAllocateInfo(Unmanaged.MemoryAllocateInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.MemoryAllocateInfo));
        }
        
        /// <param name="AllocationSize">Size of memory allocation</param>
        /// <param name="MemoryTypeIndex">Index of the of the memory type to allocate from</param>
        public MemoryAllocateInfo(DeviceSize AllocationSize, UInt32 MemoryTypeIndex) : this()
        {
            this.AllocationSize = AllocationSize;
            this.MemoryTypeIndex = MemoryTypeIndex;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~MemoryAllocateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
