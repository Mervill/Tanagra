using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferCopy
    {
        internal Interop.BufferCopy* NativePointer;
        
        public DeviceSize SrcOffset
        {
            get { return NativePointer->SrcOffset; }
            set { NativePointer->SrcOffset = value; }
        }
        
        public DeviceSize DstOffset
        {
            get { return NativePointer->DstOffset; }
            set { NativePointer->DstOffset = value; }
        }
        
        public DeviceSize Size
        {
            get { return NativePointer->Size; }
            set { NativePointer->Size = value; }
        }
        
        public BufferCopy()
        {
            NativePointer = (Interop.BufferCopy*)Interop.Structure.Allocate(typeof(Interop.BufferCopy));
        }
    }
}
