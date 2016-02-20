using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineCacheCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineCacheCreateFlags flags;
        public Int64 initialDataSize;
        public IntPtr pInitialData;
    }
}
