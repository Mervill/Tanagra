using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Fence
    {
        public readonly static Fence Null = new Fence();
        
        internal IntPtr NativeHandle;
        
    }
}
