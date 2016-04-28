using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class PhysicalDeviceMemoryProperties
    {
        internal Interop.PhysicalDeviceMemoryProperties* NativePointer;
        
        public UInt32 MemoryTypeCount
        {
            get { return NativePointer->MemoryTypeCount; }
            set { NativePointer->MemoryTypeCount = value; }
        }
        
        MemoryType _MemoryTypes;
        public MemoryType MemoryTypes
        {
            get { return _MemoryTypes; }
            set { _MemoryTypes = value; NativePointer->MemoryTypes = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 MemoryHeapCount
        {
            get { return NativePointer->MemoryHeapCount; }
            set { NativePointer->MemoryHeapCount = value; }
        }
        
        MemoryHeap _MemoryHeaps;
        public MemoryHeap MemoryHeaps
        {
            get { return _MemoryHeaps; }
            set { _MemoryHeaps = value; NativePointer->MemoryHeaps = (IntPtr)value.NativePointer; }
        }
        
        public PhysicalDeviceMemoryProperties()
        {
            NativePointer = (Interop.PhysicalDeviceMemoryProperties*)Interop.Structure.Allocate(typeof(Interop.PhysicalDeviceMemoryProperties));
        }
    }
}
