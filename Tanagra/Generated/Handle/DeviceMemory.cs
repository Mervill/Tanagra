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
        
        public override string ToString() => "DeviceMemory 0x" + NativePointer.ToString("X8");
    }
}
