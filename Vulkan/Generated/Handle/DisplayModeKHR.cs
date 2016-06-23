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
        
        internal DisplayModeKHR()
        {
        }
        
        internal DisplayModeKHR(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "DisplayModeKHR 0x" + NativePointer.ToString("X8");
    }
}
