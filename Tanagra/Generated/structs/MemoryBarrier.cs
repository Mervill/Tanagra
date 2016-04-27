using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryBarrier
    {
        internal Interop.MemoryBarrier* NativeHandle;
        
        public AccessFlags SrcAccessMask
        {
            get { return NativeHandle->SrcAccessMask; }
            set { NativeHandle->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativeHandle->DstAccessMask; }
            set { NativeHandle->DstAccessMask = value; }
        }
        
        public MemoryBarrier()
        {
            NativeHandle = (Interop.MemoryBarrier*)Interop.Structure.Allocate(typeof(Interop.MemoryBarrier));
            //NativeHandle->SType = StructureType.MemoryBarrier;
        }
    }
}
