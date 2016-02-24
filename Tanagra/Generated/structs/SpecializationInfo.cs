using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpecializationInfo
    {
        public UInt32 mapEntryCount;
        public SpecializationMapEntry[] MapEntries; // len:mapEntryCount
        public UIntPtr dataSize;
        public IntPtr Data;
    }
}
