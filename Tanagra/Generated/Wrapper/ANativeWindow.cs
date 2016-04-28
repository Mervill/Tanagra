using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ANativeWindow
    {
        internal Interop.ANativeWindow* NativePointer;
        
        public ANativeWindow()
        {
            NativePointer = (Interop.ANativeWindow*)Interop.Structure.Allocate(typeof(Interop.ANativeWindow));
        }
    }
}
