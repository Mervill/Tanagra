using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryType
    {
        internal Interop.MemoryType* NativeHandle;
        
        public MemoryPropertyFlags PropertyFlags
        {
            get { return NativeHandle->PropertyFlags; }
            set { NativeHandle->PropertyFlags = value; }
        }
        
        public UInt32 HeapIndex
        {
            get { return NativeHandle->HeapIndex; }
            set { NativeHandle->HeapIndex = value; }
        }
        
        public MemoryType()
        {
            NativeHandle = (Interop.MemoryType*)Interop.Structure.Allocate(typeof(Interop.MemoryType));
        }
    }
}
