using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class DeviceMemory
    {
        internal UInt64 NativePointer;
        
        internal DeviceMemory()
        {
        }
        
        internal DeviceMemory(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "DeviceMemory 0x" + NativePointer.ToString("X8");
    }
}
