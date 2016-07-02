using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubmitInfo
    {
        /// <summary>
        /// Type of structure. Should be VK_STRUCTURE_TYPE_SUBMIT_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        public UInt32 WaitSemaphoreCount;
        public IntPtr WaitSemaphores;
        public IntPtr WaitDstStageMask;
        public UInt32 CommandBufferCount;
        public IntPtr CommandBuffers;
        public UInt32 SignalSemaphoreCount;
        public IntPtr SignalSemaphores;
    }
}
