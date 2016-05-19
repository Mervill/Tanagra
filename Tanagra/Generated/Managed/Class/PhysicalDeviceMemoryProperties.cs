using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class PhysicalDeviceMemoryProperties
    {
        internal Unmanaged.PhysicalDeviceMemoryProperties* NativePointer;
        
        public UInt32 MemoryTypeCount
        {
            get { return NativePointer->MemoryTypeCount; }
        }
        
        public MemoryType[] MemoryTypes
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        public UInt32 MemoryHeapCount
        {
            get { return NativePointer->MemoryHeapCount; }
        }
        
        public MemoryHeap[] MemoryHeaps
        {
            get
            {
                throw new System.NotImplementedException("IsFixedSize");
            }
        }
        
        internal PhysicalDeviceMemoryProperties()
        {
            NativePointer = (Unmanaged.PhysicalDeviceMemoryProperties*)MemoryUtils.Allocate(typeof(Unmanaged.PhysicalDeviceMemoryProperties));
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.PhysicalDeviceMemoryProperties*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
