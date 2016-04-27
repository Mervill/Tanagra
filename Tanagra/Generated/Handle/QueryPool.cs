using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class QueryPool
    {
        internal IntPtr NativeHandle;
        
        public override string ToString() => NativeHandle.ToString();
    }
}
