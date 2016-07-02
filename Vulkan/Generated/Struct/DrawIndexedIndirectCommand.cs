using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DrawIndexedIndirectCommand
    {
        public UInt32 IndexCount;
        public UInt32 InstanceCount;
        public UInt32 FirstIndex;
        public Int32 VertexOffset;
        public UInt32 FirstInstance;
        
        public DrawIndexedIndirectCommand(UInt32 IndexCount, UInt32 InstanceCount, UInt32 FirstIndex, Int32 VertexOffset, UInt32 FirstInstance)
        {
            this.IndexCount = IndexCount;
            this.InstanceCount = InstanceCount;
            this.FirstIndex = FirstIndex;
            this.VertexOffset = VertexOffset;
            this.FirstInstance = FirstInstance;
        }
    }
}
