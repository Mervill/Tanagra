using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Window
    {
        internal Interop.Window* NativeHandle;
        
        public Window()
        {
            NativeHandle = (Interop.Window*)Interop.Structure.Allocate(typeof(Interop.Window));
        }
    }
}
