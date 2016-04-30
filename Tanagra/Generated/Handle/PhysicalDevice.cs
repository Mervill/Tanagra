using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class PhysicalDevice
    {
        internal IntPtr NativePointer;
        
        public override string ToString() => NativePointer.ToString("X8");
    }
}
