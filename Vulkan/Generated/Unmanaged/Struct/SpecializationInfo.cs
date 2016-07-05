using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpecializationInfo
    {
        /// <summary>
        /// Number of entries in the map (Optional)
        /// </summary>
        public UInt32 MapEntryCount;
        /// <summary>
        /// Array of map entries
        /// </summary>
        public IntPtr MapEntries;
        /// <summary>
        /// Size in bytes of pData (Optional)
        /// </summary>
        public IntPtr DataSize;
        /// <summary>
        /// Pointer to SpecConstant data
        /// </summary>
        public IntPtr Data;
    }
}
