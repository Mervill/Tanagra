using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryHeap
    {
        internal Interop.MemoryHeap* NativePointer;
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public MemoryHeapFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public MemoryHeap()
        {
            NativePointer = (Interop.MemoryHeap*)Interop.Structure.Allocate(typeof(Interop.MemoryHeap));
        }
    }
}
