using System;
using System.Runtime.InteropServices;

namespace Vulkan.Unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageCreateInfo
    {
        /// <summary>
        /// Must be VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO
        /// </summary>
        public StructureType SType;
        /// <summary>
        /// Pointer to next structure.
        /// </summary>
        public IntPtr Next;
        /// <summary>
        /// Image creation flags (Optional)
        /// </summary>
        public ImageCreateFlags Flags;
        public ImageType ImageType;
        public Format Format;
        public Extent3D Extent;
        public UInt32 MipLevels;
        public UInt32 ArrayLayers;
        public SampleCountFlags Samples;
        public ImageTiling Tiling;
        /// <summary>
        /// Image usage flags
        /// </summary>
        public ImageUsageFlags Usage;
        /// <summary>
        /// Cross-queue-family sharing mode
        /// </summary>
        public SharingMode SharingMode;
        /// <summary>
        /// Number of queue families to share across (Optional)
        /// </summary>
        public UInt32 QueueFamilyIndexCount;
        /// <summary>
        /// Array of queue family indices to share across
        /// </summary>
        public IntPtr QueueFamilyIndices;
        /// <summary>
        /// Initial image layout for all subresources
        /// </summary>
        public ImageLayout InitialLayout;
    }
}
