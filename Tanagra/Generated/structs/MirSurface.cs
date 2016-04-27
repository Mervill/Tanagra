using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirSurface
    {
        internal Interop.MirSurface* NativeHandle;
        
        public MirSurface()
        {
            NativeHandle = (Interop.MirSurface*)Interop.Structure.Allocate(typeof(Interop.MirSurface));
        }
    }
}
