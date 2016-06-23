using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class PipelineCache
    {
        internal UInt64 NativePointer;
        
        internal PipelineCache()
        {
        }
        
        internal PipelineCache(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "PipelineCache 0x" + NativePointer.ToString("X8");
    }
}
