using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Device
    {
        public readonly static Device Null = new Device();
        
        internal IntPtr NativeHandle;
        
    }
}
