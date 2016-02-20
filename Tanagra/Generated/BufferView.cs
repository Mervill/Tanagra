using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BufferView
    {
        public readonly static BufferView Null = new BufferView();
        
        internal IntPtr NativeHandle;
        
    }
}
