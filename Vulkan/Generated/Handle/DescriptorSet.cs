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
        
        internal DescriptorSet()
        {
        }
        
        internal DescriptorSet(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "DescriptorSet 0x" + NativePointer.ToString("X8");
    }
}
