using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Event
    {
        public readonly static Event Null = new Event();
        
        internal IntPtr NativeHandle;
        
    }
}
