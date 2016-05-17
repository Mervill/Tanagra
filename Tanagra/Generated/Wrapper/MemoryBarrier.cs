using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MemoryBarrier
    {
        internal Interop.MemoryBarrier* NativePointer;
        
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask
        {
            get { return NativePointer->SrcAccessMask; }
            set { NativePointer->SrcAccessMask = value; }
        }
        
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
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
