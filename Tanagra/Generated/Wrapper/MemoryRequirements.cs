using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryRequirements
    {
        internal Interop.MemoryRequirements* NativePointer;
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public DeviceSize Alignment
        {
            get { return NativePointer->Alignment; }
            set { NativePointer->Alignment = value; }
        }
        
        public UInt32 MemoryTypeBits
        {
            get { return NativePointer->MemoryTypeBits; }
            set { NativePointer->MemoryTypeBits = value; }
        }
        
        public MemoryRequirements()
        {
            NativePointer = (Interop.MemoryRequirements*)Interop.Structure.Allocate(typeof(Interop.MemoryRequirements));
        }
    }
}
