using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearColorValue
    {
        internal Interop.ClearColorValue* NativeHandle;
        
        public ClearColorValue()
        {
            NativeHandle = (Interop.ClearColorValue*)Interop.Structure.Allocate(typeof(Interop.ClearColorValue));
        }
    }
}
