using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubmitInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public UInt32 waitSemaphoreCount;
        public Semaphore[] WaitSemaphores; // len:waitSemaphoreCount
        public PipelineStageFlags[] WaitDstStageMask; // len:waitSemaphoreCount
        public UInt32 commandBufferCount;
        public CommandBuffer[] CommandBuffers; // len:commandBufferCount
        public UInt32 signalSemaphoreCount;
        public Semaphore[] SignalSemaphores; // len:signalSemaphoreCount
    }
}
