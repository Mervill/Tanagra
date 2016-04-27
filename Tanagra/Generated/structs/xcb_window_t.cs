using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class xcb_window_t
    {
        internal Interop.xcb_window_t* NativeHandle;
        
        public xcb_window_t()
        {
            NativeHandle = (Interop.xcb_window_t*)Interop.Structure.Allocate(typeof(Interop.xcb_window_t));
        }
    }
}
