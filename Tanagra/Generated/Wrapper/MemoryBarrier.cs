using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryBarrier
    {
        internal Interop.MemoryBarrier* NativePointer;
        
        public AccessFlags SrcAccessMask
        {
            get { return NativePointer->SrcAccessMask; }
            set { NativePointer->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativePointer->DstAccessMask; }
            set { NativePointer->DstAccessMask = value; }
        }
        
        public MemoryBarrier()
        {
            NativePointer = (Interop.MemoryBarrier*)Interop.Structure.Allocate(typeof(Interop.MemoryBarrier));
            NativePointer->SType = StructureType.MemoryBarrier;
        }
    }
}
