using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FenceCreateInfo
    {
        internal Interop.FenceCreateInfo* NativePointer;
        
        /// <summary>
        /// Fence creation flags (Optional)
        /// </summary>
        public FenceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public FenceCreateInfo()
        {
            NativePointer = (Interop.FenceCreateInfo*)MemoryUtils.Allocate(typeof(Interop.FenceCreateInfo));
            NativePointer->SType = StructureType.FenceCreateInfo;
        }
    }
}
