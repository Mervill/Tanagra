using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class EventCreateInfo
    {
        internal Interop.EventCreateInfo* NativePointer;
        
        /// <summary>
        /// Event creation flags (Optional)
        /// </summary>
        public EventCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public EventCreateInfo()
        {
            NativePointer = (Interop.EventCreateInfo*)MemoryUtils.Allocate(typeof(Interop.EventCreateInfo));
            NativePointer->SType = StructureType.EventCreateInfo;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.EventCreateInfo*)IntPtr.Zero;
        }
    }
}
