using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class CommandPool
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "CommandPool 0x" + NativePointer.ToString("X8");
    }
}
