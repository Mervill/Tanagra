using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class SurfaceKHR
    {
        internal IntPtr NativeHandle;
        
        public override string ToString() => NativeHandle.ToString();
    }
}
