using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class DescriptorSetLayout
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "DescriptorSetLayout 0x" + NativePointer.ToString("X8");
    }
}
