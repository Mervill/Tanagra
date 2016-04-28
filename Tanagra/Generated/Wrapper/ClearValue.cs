using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearValue
    {
        internal Interop.ClearValue* NativePointer;
        
        public ClearValue()
        {
            NativePointer = (Interop.ClearValue*)Interop.Structure.Allocate(typeof(Interop.ClearValue));
        }
    }
}
