using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class SemaphoreCreateInfo : IDisposable
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
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~SemaphoreCreateInfo()
        {
            if(NativePointer != null)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
