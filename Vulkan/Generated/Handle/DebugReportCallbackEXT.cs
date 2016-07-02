using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Vulkan handle. Nondispatchable. Child of <see cref="Instance"/>.
    /// </summary>
    public class DebugReportCallbackEXT
    {
        internal UInt64 NativePointer;
        
        internal DebugReportCallbackEXT()
        {
        }
        
        internal DebugReportCallbackEXT(UInt64 internalHandle)
        {
            NativePointer = internalHandle;
        }
        
        public override string ToString() => "DebugReportCallbackEXT 0x" + NativePointer.ToString("X8");
    }
}
