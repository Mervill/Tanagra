using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PresentInfoKHR
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_PRESENT_INFO_KHR
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Number of semaphores to wait for before presenting (Optional)
        /// </summary>
        public UInt32 WaitSemaphoreCount;
        /// <summary>
        /// Semaphores to wait for before presenting (Optional)
        /// </summary>
        public IntPtr WaitSemaphores;
        /// <summary>
        /// Number of swap chains to present in this call
        /// </summary>
        public UInt32 SwapchainCount;
        /// <summary>
        /// Swapchains to present an image from
        /// </summary>
        public IntPtr Swapchains;
        /// <summary>
        /// Indices of which swapchain images to present
        /// </summary>
        public IntPtr ImageIndices;
        /// <summary>
        /// Optional (i.e. if non-NULL) VkResult for each swapchain (Optional)
        /// </summary>
        public IntPtr Results;
    }
}
