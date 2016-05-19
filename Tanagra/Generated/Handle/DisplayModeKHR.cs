using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="PhysicalDevice,VkDisplayKHR"/>.
    /// </summary>
    public class DisplayModeKHR
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "DisplayModeKHR 0x" + NativePointer.ToString("X8");
    }
}
