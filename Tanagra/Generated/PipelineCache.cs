using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineCache
    {
        public readonly static PipelineCache Null = new PipelineCache();
        
        internal IntPtr NativeHandle;
        
    }
}
