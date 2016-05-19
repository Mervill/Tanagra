using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SemaphoreCreateInfo
    {
        internal Unmanaged.SemaphoreCreateInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.SemaphoreCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.SemaphoreCreateInfo));
            NativePointer->SType = StructureType.SemaphoreCreateInfo;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.SemaphoreCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
