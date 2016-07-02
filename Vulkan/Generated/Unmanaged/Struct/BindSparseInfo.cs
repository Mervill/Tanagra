using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BindSparseInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_BIND_SPARSE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        public UInt32 WaitSemaphoreCount;
        public IntPtr WaitSemaphores;
        public UInt32 BufferBindCount;
        public IntPtr BufferBinds;
        public UInt32 ImageOpaqueBindCount;
        public IntPtr ImageOpaqueBinds;
        public UInt32 ImageBindCount;
        public IntPtr ImageBinds;
        public UInt32 SignalSemaphoreCount;
        public IntPtr SignalSemaphores;
    }
}
