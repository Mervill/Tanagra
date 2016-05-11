using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class DescriptorSet
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "DescriptorSet 0x" + NativePointer.ToString("X8");
    }
}
