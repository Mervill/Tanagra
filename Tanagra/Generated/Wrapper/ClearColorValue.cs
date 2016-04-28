using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearColorValue
    {
        internal Interop.ClearColorValue* NativePointer;
        
        public ClearColorValue()
        {
            NativePointer = (Interop.ClearColorValue*)Interop.Structure.Allocate(typeof(Interop.ClearColorValue));
        }
    }
}
