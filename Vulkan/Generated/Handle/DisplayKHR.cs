using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable.
    /// </summary>
    public class DisplayKHR
    {
        internal UInt64 NativePointer;
        
        internal DisplayKHR()
        {
        }
        
        internal DisplayKHR(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "DisplayKHR 0x" + NativePointer.ToString("X8");
    }
}
