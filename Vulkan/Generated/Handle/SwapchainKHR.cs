using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="SurfaceKHR"/>.
    /// </summary>
    public class SwapchainKHR
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "SwapchainKHR 0x" + NativePointer.ToString("X8");
    }
}
