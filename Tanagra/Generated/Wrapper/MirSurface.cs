using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirSurface
    {
        internal Interop.MirSurface* NativePointer;
        
        public MirSurface()
        {
            NativePointer = (Interop.MirSurface*)Interop.Structure.Allocate(typeof(Interop.MirSurface));
        }
    }
}
