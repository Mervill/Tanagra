using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryType
    {
        internal Interop.MemoryType* NativePointer;
        
        public MemoryPropertyFlags PropertyFlags
        {
            get { return NativePointer->PropertyFlags; }
            set { NativePointer->PropertyFlags = value; }
        }
        
        public UInt32 HeapIndex
        {
            get { return NativePointer->HeapIndex; }
            set { NativePointer->HeapIndex = value; }
        }
        
        public MemoryType()
        {
            NativePointer = (Interop.MemoryType*)Interop.Structure.Allocate(typeof(Interop.MemoryType));
        }
    }
}
