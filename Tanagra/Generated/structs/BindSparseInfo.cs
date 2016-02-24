using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BindSparseInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public UInt32 waitSemaphoreCount;
        public Semaphore[] WaitSemaphores; // len:waitSemaphoreCount
        public UInt32 bufferBindCount;
        public SparseBufferMemoryBindInfo[] BufferBinds; // len:bufferBindCount
        public UInt32 imageOpaqueBindCount;
        public SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds; // len:imageOpaqueBindCount
        public UInt32 imageBindCount;
        public SparseImageMemoryBindInfo[] ImageBinds; // len:imageBindCount
        public UInt32 signalSemaphoreCount;
        public Semaphore[] SignalSemaphores; // len:signalSemaphoreCount
    }
}
