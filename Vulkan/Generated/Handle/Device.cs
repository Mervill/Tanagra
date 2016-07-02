using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Dispatchable. Child of <see cref="PhysicalDevice"/>.
    /// </summary>
    public class Device
    {
        internal IntPtr NativePointer;
        
        internal Device()
        {
        }
        
        internal Device(IntPtr internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Device 0x" + NativePointer.ToString("X8");
    }
}
