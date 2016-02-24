using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineTessellationStateCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineTessellationStateCreateFlags flags;
        public UInt32 patchControlPoints;
    }
}
