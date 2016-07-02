using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StencilOpState
    {
        public StencilOp FailOp;
        public StencilOp PassOp;
        public StencilOp DepthFailOp;
        public CompareOp CompareOp;
        public UInt32 CompareMask;
        public UInt32 WriteMask;
        public UInt32 Reference;
        
        public StencilOpState(StencilOp FailOp, StencilOp PassOp, StencilOp DepthFailOp, CompareOp CompareOp, UInt32 CompareMask, UInt32 WriteMask, UInt32 Reference)
        {
            this.FailOp = FailOp;
            this.PassOp = PassOp;
            this.DepthFailOp = DepthFailOp;
            this.CompareOp = CompareOp;
            this.CompareMask = CompareMask;
            this.WriteMask = WriteMask;
            this.Reference = Reference;
        }
    }
}
