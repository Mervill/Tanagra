using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct ClearColorValue
    {
        [FieldOffset (0)] public unsafe fixed float Float32[4];
        [FieldOffset (0)] public unsafe fixed Int32 Int32[4];
        [FieldOffset (0)] public unsafe fixed UInt32 Uint32[4];
    }
}
