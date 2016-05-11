using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class Queue
    {
        internal IntPtr NativePointer;
        
        public override string ToString() => "Queue 0x" + NativePointer.ToString("X8");
    }
}
