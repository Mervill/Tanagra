using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Dispatchable. Child of <see cref="Instance"/>.
    /// </summary>
    public class PhysicalDevice
    {
        internal IntPtr NativePointer;
        
        internal PhysicalDevice()
        {
        }
        
        internal PhysicalDevice(IntPtr internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "PhysicalDevice 0x" + NativePointer.ToString("X8");
    }
}
