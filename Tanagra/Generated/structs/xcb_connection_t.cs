using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class xcb_connection_t
    {
        internal Interop.xcb_connection_t* NativeHandle;
        
        public xcb_connection_t()
        {
            NativeHandle = (Interop.xcb_connection_t*)Interop.Structure.Allocate(typeof(Interop.xcb_connection_t));
        }
    }
}
