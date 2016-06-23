using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Dispatchable.
    /// </summary>
    public class Instance
    {
        internal IntPtr NativePointer;
        
        internal Instance()
        {
        }
        
        internal Instance(IntPtr internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Instance 0x" + NativePointer.ToString("X8");
    }
}
