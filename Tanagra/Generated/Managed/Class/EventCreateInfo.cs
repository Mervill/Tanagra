using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class EventCreateInfo
    {
        internal Unmanaged.EventCreateInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.EventCreateInfo*)MemoryUtils.Allocate(typeof(Unmanaged.EventCreateInfo));
            NativePointer->SType = StructureType.EventCreateInfo;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.EventCreateInfo*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
