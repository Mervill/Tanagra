using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ClearDepthStencilValue
    {
        public Single depth;
        public UInt32 stencil;
    }
}
