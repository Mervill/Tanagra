using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearValue
    {
        internal Interop.ClearValue* NativeHandle;
        
        public ClearValue()
        {
            NativeHandle = (Interop.ClearValue*)Interop.Structure.Allocate(typeof(Interop.ClearValue));
        }
    }
}
