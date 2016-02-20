using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DebugReportCallbackEXT
    {
        public readonly static DebugReportCallbackEXT Null = new DebugReportCallbackEXT();
        
        internal IntPtr NativeHandle;
        
    }
}
