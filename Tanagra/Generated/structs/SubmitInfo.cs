using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SubmitInfo
    {
        public StructureType sType;
        public IntPtr pNext;
        public UInt32 waitSemaphoreCount;
        public Semaphore pWaitSemaphores;
        public PipelineStageFlags pWaitDstStageMask;
        public UInt32 commandBufferCount;
        public CommandBuffer pCommandBuffers;
        public UInt32 signalSemaphoreCount;
        public Semaphore pSignalSemaphores;
    }
}
