using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class Device
    {
        internal IntPtr NativePointer;
        
        public override string ToString() => "Device 0x" + NativePointer.ToString("X8");
    }
}
