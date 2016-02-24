using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineInputAssemblyStateCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineInputAssemblyStateCreateFlags flags;
        public PrimitiveTopology topology;
        public Boolean primitiveRestartEnable;
    }
}
