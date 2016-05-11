using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class RenderPass
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "RenderPass 0x" + NativePointer.ToString("X8");
    }
}
