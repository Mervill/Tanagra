using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="DescriptorPool"/>.
    /// </summary>
    public class DescriptorSet
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "DescriptorSet 0x" + NativePointer.ToString("X8");
    }
}
