using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class xcb_window_t
    {
        internal Interop.xcb_window_t* NativePointer;
        
        public xcb_window_t()
        {
            NativePointer = (Interop.xcb_window_t*)Interop.Structure.Allocate(typeof(Interop.xcb_window_t));
        }
    }
}
