using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class Buffer
    {
        internal UInt64 NativePointer;
        
        internal Buffer()
        {
        }
        
        internal Buffer(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Buffer 0x" + NativePointer.ToString("X8");
    }
}
