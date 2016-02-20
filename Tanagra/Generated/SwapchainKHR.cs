using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SwapchainKHR
    {
        public readonly static SwapchainKHR Null = new SwapchainKHR();
        
        internal IntPtr NativeHandle;
        
    }
}
