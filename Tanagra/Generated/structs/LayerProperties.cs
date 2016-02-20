using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LayerProperties
    {
        public Char layerName;
        public UInt32 specVersion;
        public UInt32 implementationVersion;
        public Char description;
    }
}
