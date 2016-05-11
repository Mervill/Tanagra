using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class DisplayModeKHR
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "DisplayModeKHR 0x" + NativePointer.ToString("X8");
    }
}
