using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class FenceCreateInfo
    {
        internal Unmanaged.FenceCreateInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.FenceCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.FenceCreateInfo));
            NativePointer->SType = StructureType.FenceCreateInfo;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.FenceCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
