using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class EventCreateInfo : IDisposable
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
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~EventCreateInfo()
        {
            if(NativePointer != null)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
