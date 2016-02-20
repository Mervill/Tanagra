using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StencilOpState
    {
        public StencilOp failOp;
        public StencilOp passOp;
        public StencilOp depthFailOp;
        public CompareOp compareOp;
        public UInt32 compareMask;
        public UInt32 writeMask;
        public UInt32 reference;
    }
}
