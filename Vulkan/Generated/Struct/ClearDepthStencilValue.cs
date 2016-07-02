using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClearDepthStencilValue
    {
        public Single Depth;
        public UInt32 Stencil;
        
        public ClearDepthStencilValue(Single Depth, UInt32 Stencil)
        {
            this.Depth = Depth;
            this.Stencil = Stencil;
        }
    }
}
