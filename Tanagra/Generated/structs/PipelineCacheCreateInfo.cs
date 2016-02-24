using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineCacheCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineCacheCreateFlags flags;
        public UIntPtr initialDataSize;
        public IntPtr InitialData;
    }
}
