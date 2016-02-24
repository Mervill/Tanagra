using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PresentInfoKHR
    {
        public StructureType sType;
        public IntPtr Next;
        public UInt32 waitSemaphoreCount;
        public Semaphore[] WaitSemaphores; // len:waitSemaphoreCount
        public UInt32 swapchainCount;
        public SwapchainKHR[] Swapchains; // len:swapchainCount
        public UInt32[] ImageIndices; // len:swapchainCount
        public Result[] Results; // len:swapchainCount
    }
}
