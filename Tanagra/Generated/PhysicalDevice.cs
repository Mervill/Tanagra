using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PhysicalDevice
    {
        public readonly static PhysicalDevice Null = new PhysicalDevice();
        
        internal IntPtr NativeHandle;
        
    }
}
