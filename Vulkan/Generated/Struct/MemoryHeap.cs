using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    /// <summary>
    /// Returned Only - This object is never given as input to a Vulkan function
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryHeap
    {
        /// <summary>
        /// Available memory in the heap
        /// </summary>
        public DeviceSize Size;
        /// <summary>
        /// Flags for the heap (Optional)
        /// </summary>
        public MemoryHeapFlags Flags;
    }
}
