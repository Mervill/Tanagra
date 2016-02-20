using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayModeKHR
    {
        public readonly static DisplayModeKHR Null = new DisplayModeKHR();
        
        internal IntPtr NativeHandle;

        public override string ToString() => NativeHandle.ToString();
    }
}
