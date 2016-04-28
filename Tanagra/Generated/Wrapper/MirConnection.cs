using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirConnection
    {
        internal Interop.MirConnection* NativePointer;
        
        public MirConnection()
        {
            NativePointer = (Interop.MirConnection*)Interop.Structure.Allocate(typeof(Interop.MirConnection));
        }
    }
}
