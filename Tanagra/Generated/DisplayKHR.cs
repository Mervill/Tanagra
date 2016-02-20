using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayKHR
    {
        public readonly static DisplayKHR Null = new DisplayKHR();
        
        internal IntPtr NativeHandle;

        public override string ToString() => NativeHandle.ToString();
    }
}
