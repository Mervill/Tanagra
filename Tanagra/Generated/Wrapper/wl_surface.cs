using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class wl_surface
    {
        internal Interop.wl_surface* NativePointer;
        
        public wl_surface()
        {
            NativePointer = (Interop.wl_surface*)Interop.Structure.Allocate(typeof(Interop.wl_surface));
        }
    }
}
