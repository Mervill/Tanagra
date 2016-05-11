using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class QueryPool
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "QueryPool 0x" + NativePointer.ToString("X8");
    }
}
