using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Window
    {
        internal Interop.Window* NativePointer;
        
        public Window()
        {
            NativePointer = (Interop.Window*)Interop.Structure.Allocate(typeof(Interop.Window));
        }
    }
}
