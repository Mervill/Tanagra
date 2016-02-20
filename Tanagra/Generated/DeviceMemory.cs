using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceMemory
    {
        public readonly static DeviceMemory Null = new DeviceMemory();
        
        internal IntPtr NativeHandle;
        
    }
}
