using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    unsafe public class PhysicalDeviceMemoryProperties
    {
        internal Interop.PhysicalDeviceMemoryProperties* NativePointer;
        
        public UInt32 MemoryTypeCount
        {
            get { return NativePointer->MemoryTypeCount; }
        }
        
        public MemoryType[] MemoryTypes
        {
            get
            {
                throw new System.NotImplementedException();
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
                throw new System.NotImplementedException();
            }
        }
        
        internal PhysicalDeviceMemoryProperties()
        {
            NativePointer = (Interop.PhysicalDeviceMemoryProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceMemoryProperties));
        }
    }
}
