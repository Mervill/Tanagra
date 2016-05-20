using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct ClearValue
    {
        [FieldOffset (0)] internal ClearColorValue Color;
        [FieldOffset (0)] internal ClearDepthStencilValue DepthStencil;
    }
}
