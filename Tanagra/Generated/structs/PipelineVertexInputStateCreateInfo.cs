using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineVertexInputStateCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public PipelineVertexInputStateCreateFlags flags;
        public UInt32 vertexBindingDescriptionCount;
        public VertexInputBindingDescription[] VertexBindingDescriptions; // len:vertexBindingDescriptionCount
        public UInt32 vertexAttributeDescriptionCount;
        public VertexInputAttributeDescription[] VertexAttributeDescriptions; // len:vertexAttributeDescriptionCount
    }
}
