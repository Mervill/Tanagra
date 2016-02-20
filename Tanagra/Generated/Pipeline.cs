using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Pipeline
    {
        public readonly static Pipeline Null = new Pipeline();
        
        internal IntPtr NativeHandle;
        
    }
}
