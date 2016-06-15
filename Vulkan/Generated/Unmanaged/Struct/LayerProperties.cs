using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LayerProperties
    {
        /// <summary>
        /// Layer name
        /// </summary>
        public unsafe fixed Byte LayerName[256];
        /// <summary>
        /// Version of the layer specification implemented
        /// </summary>
        public UInt32 SpecVersion;
        /// <summary>
        /// Build or release version of the layer's library
        /// </summary>
        public UInt32 ImplementationVersion;
        /// <summary>
        /// Free-form description of the layer
        /// </summary>
        public unsafe fixed Byte Description[256];
    }
}
