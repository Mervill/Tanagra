using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class DisplayModeKHR
    {
        internal IntPtr NativePointer;
        
        public override string ToString() => NativePointer.ToString();
    }
}
