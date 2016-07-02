using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DrawIndirectCommand
    {
        public UInt32 VertexCount;
        public UInt32 InstanceCount;
        public UInt32 FirstVertex;
        public UInt32 FirstInstance;
        
        public DrawIndirectCommand(UInt32 VertexCount, UInt32 InstanceCount, UInt32 FirstVertex, UInt32 FirstInstance)
        {
            this.VertexCount = VertexCount;
            this.InstanceCount = InstanceCount;
            this.FirstVertex = FirstVertex;
            this.FirstInstance = FirstInstance;
        }
    }
}
