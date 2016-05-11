using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class DescriptorPool
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "DescriptorPool 0x" + NativePointer.ToString("X8");
    }
}
