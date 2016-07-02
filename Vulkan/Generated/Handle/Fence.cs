using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class Fence
    {
        internal UInt64 NativePointer;
        
        internal Fence()
        {
        }
        
        internal Fence(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Fence 0x" + NativePointer.ToString("X8");
    }
}
