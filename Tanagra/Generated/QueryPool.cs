using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct QueryPool
    {
        public readonly static QueryPool Null = new QueryPool();
        
        internal IntPtr NativeHandle;
        
    }
}
