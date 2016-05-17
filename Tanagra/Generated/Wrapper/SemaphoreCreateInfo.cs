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
            NativePointer = (Interop.SemaphoreCreateInfo*)Interop.Structure.Allocate(typeof(Interop.SemaphoreCreateInfo));
            NativePointer->SType = StructureType.SemaphoreCreateInfo;
        }
    }
}
