using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ExtensionProperties
    {
        public Char extensionName;
        public UInt32 specVersion;
    }
}
