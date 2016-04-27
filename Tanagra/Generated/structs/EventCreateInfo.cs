using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class EventCreateInfo
    {
        internal Interop.EventCreateInfo* NativeHandle;
        
        public EventCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public EventCreateInfo()
        {
            NativeHandle = (Interop.EventCreateInfo*)Interop.Structure.Allocate(typeof(Interop.EventCreateInfo));
            //NativeHandle->SType = StructureType.EventCreateInfo;
        }
    }
}
