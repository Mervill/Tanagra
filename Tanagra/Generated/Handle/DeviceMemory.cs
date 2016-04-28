using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class DeviceMemory
    {
        internal IntPtr NativePointer;
        
        public override string ToString() => NativePointer.ToString();
    }
}
