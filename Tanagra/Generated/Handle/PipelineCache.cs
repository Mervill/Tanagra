using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class PipelineCache
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "PipelineCache 0x" + NativePointer.ToString("X8");
    }
}
