using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Instance"/>.
    /// </summary>
    public class SurfaceKHR
    {
        internal UInt64 NativePointer;
        
        internal SurfaceKHR()
        {
        }
        
        internal SurfaceKHR(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "SurfaceKHR 0x" + NativePointer.ToString("X8");
    }
}
