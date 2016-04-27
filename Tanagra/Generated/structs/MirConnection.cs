using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirConnection
    {
        internal Interop.MirConnection* NativeHandle;
        
        public MirConnection()
        {
            NativeHandle = (Interop.MirConnection*)Interop.Structure.Allocate(typeof(Interop.MirConnection));
        }
    }
}
