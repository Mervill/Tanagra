using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class wl_display
    {
        internal Interop.wl_display* NativePointer;
        
        public wl_display()
        {
            NativePointer = (Interop.wl_display*)Interop.Structure.Allocate(typeof(Interop.wl_display));
        }
    }
}
