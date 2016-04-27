using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryHeap
    {
        internal Interop.MemoryHeap* NativeHandle;
        
        DeviceSize _Size;
        public DeviceSize Size
        {
            get { return _Size; }
            set { _Size = value; NativeHandle->Size = (IntPtr)value.NativeHandle; }
        }
        
        public MemoryHeapFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public MemoryHeap()
        {
            NativeHandle = (Interop.MemoryHeap*)Interop.Structure.Allocate(typeof(Interop.MemoryHeap));
        }
    }
}
