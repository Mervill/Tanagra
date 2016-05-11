using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class Pipeline
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "Pipeline 0x" + NativePointer.ToString("X8");
    }
}
