using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class PipelineLayout
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "PipelineLayout 0x" + NativePointer.ToString("X8");
    }
}
