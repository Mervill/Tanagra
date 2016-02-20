using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpecializationMapEntry
    {
        public UInt32 constantID;
        public UInt32 offset;
        public Int64 size;
    }
}
