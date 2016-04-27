using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class HWND
    {
        internal Interop.HWND* NativeHandle;
        
        public HWND()
        {
            NativeHandle = (Interop.HWND*)Interop.Structure.Allocate(typeof(Interop.HWND));
        }
    }
}
