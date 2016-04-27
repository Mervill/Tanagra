using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class HINSTANCE
    {
        internal Interop.HINSTANCE* NativeHandle;
        
        public HINSTANCE()
        {
            NativeHandle = (Interop.HINSTANCE*)Interop.Structure.Allocate(typeof(Interop.HINSTANCE));
        }
    }
}
