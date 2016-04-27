using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class wl_surface
    {
        internal Interop.wl_surface* NativeHandle;
        
        public wl_surface()
        {
            NativeHandle = (Interop.wl_surface*)Interop.Structure.Allocate(typeof(Interop.wl_surface));
        }
    }
}
