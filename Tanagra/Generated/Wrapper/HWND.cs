using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class HWND
    {
        internal Interop.HWND* NativePointer;
        
        public HWND()
        {
            NativePointer = (Interop.HWND*)Interop.Structure.Allocate(typeof(Interop.HWND));
        }
    }
}
