using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class xcb_visualid_t
    {
        internal Interop.xcb_visualid_t* NativeHandle;
        
        public xcb_visualid_t()
        {
            NativeHandle = (Interop.xcb_visualid_t*)Interop.Structure.Allocate(typeof(Interop.xcb_visualid_t));
        }
    }
}
