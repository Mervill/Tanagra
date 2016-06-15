using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ExtensionProperties
    {
        /// <summary>
        /// Extension name
        /// </summary>
        public unsafe fixed Byte ExtensionName[256];
        /// <summary>
        /// Version of the extension specification implemented
        /// </summary>
        public UInt32 SpecVersion;
    }
}
