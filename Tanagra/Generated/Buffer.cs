using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Buffer
    {
        public readonly static Buffer Null = new Buffer();
        
        internal IntPtr NativeHandle;
        
    }
}
