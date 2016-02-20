using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Semaphore
    {
        public readonly static Semaphore Null = new Semaphore();
        
        internal IntPtr NativeHandle;
        
    }
}
