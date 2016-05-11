using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class Framebuffer
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "Framebuffer 0x" + NativePointer.ToString("X8");
    }
}
