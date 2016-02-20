using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PresentInfoKHR
    {
        public StructureType sType;
        public IntPtr pNext;
        public UInt32 waitSemaphoreCount;
        public Semaphore pWaitSemaphores;
        public UInt32 swapchainCount;
        public SwapchainKHR pSwapchains;
        public UInt32 pImageIndices;
        public Result pResults;
    }
}
