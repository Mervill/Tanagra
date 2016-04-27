using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class Fence
    {
        internal IntPtr NativeHandle;
        
        public override string ToString() => NativeHandle.ToString();
    }
}
