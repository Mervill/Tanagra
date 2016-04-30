using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public struct SwapchainKHR
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => NativePointer.ToString("X8");
    }
}
