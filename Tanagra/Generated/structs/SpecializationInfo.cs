using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpecializationInfo
    {
        public UInt32 mapEntryCount;
        public SpecializationMapEntry pMapEntries;
        public Int64 dataSize;
        public IntPtr pData;
    }
}
