using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Display
    {
        internal Interop.Display* NativeHandle;
        
        public Display()
        {
            NativeHandle = (Interop.Display*)Interop.Structure.Allocate(typeof(Interop.Display));
        }
    }
}
