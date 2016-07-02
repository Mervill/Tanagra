using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryType
    {
        /// <summary>
        /// Memory properties of this memory type (Optional)
        /// </summary>
        public MemoryPropertyFlags PropertyFlags;
        /// <summary>
        /// Index of the memory heap allocations of this memory type are taken from
        /// </summary>
        public UInt32 HeapIndex;
    }
}
