using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SampleMask
    {
        public UInt32 value;
    }
}
