using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Device"/>.
    /// </summary>
    public class RenderPass
    {
        internal UInt64 NativePointer;
        
        internal RenderPass()
        {
        }
        
        internal RenderPass(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "RenderPass 0x" + NativePointer.ToString("X8");
    }
}
