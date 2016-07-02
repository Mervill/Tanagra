using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class Pipeline
    {
        internal UInt64 NativePointer;
        
        internal Pipeline()
        {
        }
        
        internal Pipeline(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "Pipeline 0x" + NativePointer.ToString("X8");
    }
}
