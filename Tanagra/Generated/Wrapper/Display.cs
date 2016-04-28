using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Display
    {
        internal Interop.Display* NativePointer;
        
        public Display()
        {
            NativePointer = (Interop.Display*)Interop.Structure.Allocate(typeof(Interop.Display));
        }
    }
}
