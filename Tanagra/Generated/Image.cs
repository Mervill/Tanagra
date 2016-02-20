using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Image
    {
        public readonly static Image Null = new Image();
        
        internal IntPtr NativeHandle;
        
    }
}
