using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class CommandPool
    {
        internal UInt64 NativePointer;
        
        internal CommandPool()
        {
        }
        
        internal CommandPool(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "CommandPool 0x" + NativePointer.ToString("X8");
    }
}
