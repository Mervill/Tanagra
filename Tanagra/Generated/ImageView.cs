using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageView
    {
        public readonly static ImageView Null = new ImageView();
        
        internal IntPtr NativeHandle;
        
    }
}
