using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class wl_display
    {
        internal Interop.wl_display* NativeHandle;
        
        public wl_display()
        {
            NativeHandle = (Interop.wl_display*)Interop.Structure.Allocate(typeof(Interop.wl_display));
        }
    }
}
