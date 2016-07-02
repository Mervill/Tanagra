using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Dispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class Queue
    {
        internal IntPtr NativePointer;
        
        internal Queue()
        {
        }
        
        internal Queue(IntPtr internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Queue 0x" + NativePointer.ToString("X8");
    }
}
