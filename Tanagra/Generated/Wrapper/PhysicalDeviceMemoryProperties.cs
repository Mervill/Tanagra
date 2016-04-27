using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceMemoryProperties
    {
        internal Interop.PhysicalDeviceMemoryProperties* NativeHandle;
        
        public UInt32 MemoryTypeCount
        {
            get { return NativeHandle->MemoryTypeCount; }
            set { NativeHandle->MemoryTypeCount = value; }
        }
        
        MemoryType _MemoryTypes;
        public MemoryType MemoryTypes
        {
            get { return _MemoryTypes; }
            set { _MemoryTypes = value; NativeHandle->MemoryTypes = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MemoryHeapCount
        {
            get { return NativeHandle->MemoryHeapCount; }
            set { NativeHandle->MemoryHeapCount = value; }
        }
        
        MemoryHeap _MemoryHeaps;
        public MemoryHeap MemoryHeaps
        {
            get { return _MemoryHeaps; }
            set { _MemoryHeaps = value; NativeHandle->MemoryHeaps = (IntPtr)value.NativeHandle; }
        }
        
        public PhysicalDeviceMemoryProperties()
        {
            NativeHandle = (Interop.PhysicalDeviceMemoryProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceMemoryProperties));
        }
    }
}
