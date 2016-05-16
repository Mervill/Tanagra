using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class EventCreateInfo
    {
        internal Interop.EventCreateInfo* NativePointer;
        
        /// <summary>
        /// Event creation flags
        /// </summary>
        public EventCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public EventCreateInfo()
        {
            NativePointer = (Interop.EventCreateInfo*)Interop.Structure.Allocate(typeof(Interop.EventCreateInfo));
            NativePointer->SType = StructureType.EventCreateInfo;
        }
    }
}
