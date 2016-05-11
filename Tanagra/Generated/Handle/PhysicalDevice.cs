using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class PhysicalDevice
    {
        internal IntPtr NativePointer;
        
        public override string ToString() => "PhysicalDevice 0x" + NativePointer.ToString("X8");
    }
}
