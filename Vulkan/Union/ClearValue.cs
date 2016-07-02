using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct ClearValue
    {
        [FieldOffset (0)] public ClearColorValue Color;
        [FieldOffset (0)] public ClearDepthStencilValue DepthStencil;
    }
}
