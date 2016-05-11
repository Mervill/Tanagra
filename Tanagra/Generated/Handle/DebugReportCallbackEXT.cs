using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    public class DebugReportCallbackEXT
    {
        internal UInt64 NativePointer;
        
        public override string ToString() => "DebugReportCallbackEXT 0x" + NativePointer.ToString("X8");
    }
}
