using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineVertexInputStateCreateInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public PipelineVertexInputStateCreateFlags flags;
        public UInt32 vertexBindingDescriptionCount;
        public VertexInputBindingDescription pVertexBindingDescriptions;
        public UInt32 vertexAttributeDescriptionCount;
        public VertexInputAttributeDescription pVertexAttributeDescriptions;
    }
}
