using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SemaphoreCreateInfo
    {
        internal Interop.SemaphoreCreateInfo* NativePointer;
        
        /// <summary>
        /// Semaphore creation flags (Optional)
        /// </summary>
        public SemaphoreCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public SemaphoreCreateInfo()
        {
            NativePointer = (Interop.SemaphoreCreateInfo*)MemoryUtils.Allocate(typeof(Interop.SemaphoreCreateInfo));
            NativePointer->SType = StructureType.SemaphoreCreateInfo;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.SemaphoreCreateInfo*)IntPtr.Zero;
        }
    }
}
