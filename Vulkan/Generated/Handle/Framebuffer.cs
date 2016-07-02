using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class Framebuffer
    {
        internal UInt64 NativePointer;
        
        internal Framebuffer()
        {
        }
        
        internal Framebuffer(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Framebuffer 0x" + NativePointer.ToString("X8");
    }
}
