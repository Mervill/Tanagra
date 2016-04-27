using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SemaphoreCreateInfo
    {
        internal Interop.SemaphoreCreateInfo* NativeHandle;
        
        public SemaphoreCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public SemaphoreCreateInfo()
        {
            NativeHandle = (Interop.SemaphoreCreateInfo*)Interop.Structure.Allocate(typeof(Interop.SemaphoreCreateInfo));
            //NativeHandle->SType = StructureType.SemaphoreCreateInfo;
        }
    }
}
