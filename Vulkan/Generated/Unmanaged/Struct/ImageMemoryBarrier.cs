using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageMemoryBarrier
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask;
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask;
        /// <summary>
        /// Current layout of the image
        /// </summary>
        public ImageLayout OldLayout;
        /// <summary>
        /// New layout to transition the image to
        /// </summary>
        public ImageLayout NewLayout;
        /// <summary>
        /// Queue family to transition ownership from
        /// </summary>
        public UInt32 SrcQueueFamilyIndex;
        /// <summary>
        /// Queue family to transition ownership to
        /// </summary>
        public UInt32 DstQueueFamilyIndex;
        /// <summary>
        /// Image to sync
        /// </summary>
        public UInt64 Image;
        /// <summary>
        /// Subresource range to sync
        /// </summary>
        public ImageSubresourceRange SubresourceRange;
    }
}
