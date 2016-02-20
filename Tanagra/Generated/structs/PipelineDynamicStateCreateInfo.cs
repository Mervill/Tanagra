using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineDynamicStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineDynamicStateCreateFlags flags;
        public UInt32 dynamicStateCount;
        public DynamicState pDynamicStates;
    }
}
