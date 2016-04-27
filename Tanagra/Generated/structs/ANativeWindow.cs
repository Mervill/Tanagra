using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ANativeWindow
    {
        internal Interop.ANativeWindow* NativeHandle;
        
        public ANativeWindow()
        {
            NativeHandle = (Interop.ANativeWindow*)Interop.Structure.Allocate(typeof(Interop.ANativeWindow));
        }
    }
}
