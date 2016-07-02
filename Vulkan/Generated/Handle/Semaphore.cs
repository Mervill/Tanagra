using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class Semaphore
    {
        internal UInt64 NativePointer;
        
        internal Semaphore()
        {
        }
        
        internal Semaphore(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Semaphore 0x" + NativePointer.ToString("X8");
    }
}
