using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BindSparseInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public UInt32 waitSemaphoreCount;
        public Semaphore pWaitSemaphores;
        public UInt32 bufferBindCount;
        public SparseBufferMemoryBindInfo pBufferBinds;
        public UInt32 imageOpaqueBindCount;
        public SparseImageOpaqueMemoryBindInfo pImageOpaqueBinds;
        public UInt32 imageBindCount;
        public SparseImageMemoryBindInfo pImageBinds;
        public UInt32 signalSemaphoreCount;
        public Semaphore pSignalSemaphores;
    }
}
