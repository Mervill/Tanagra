using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Framebuffer
    {
        public readonly static Framebuffer Null = new Framebuffer();
        
        internal IntPtr NativeHandle;

        public override string ToString() => NativeHandle.ToString();
    }
}
