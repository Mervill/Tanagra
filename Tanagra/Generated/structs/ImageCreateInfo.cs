using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ImageCreateInfo
    {
        public StructureType sType;
        public IntPtr Next;
        public ImageCreateFlags flags;
        public ImageType imageType;
        public Format format;
        public Extent3D extent;
        public UInt32 mipLevels;
        public UInt32 arrayLayers;
        public SampleCountFlags samples;
        public ImageTiling tiling;
        public ImageUsageFlags usage;
        public SharingMode sharingMode;
        public UInt32 queueFamilyIndexCount;
        public UInt32[] QueueFamilyIndices; // len:queueFamilyIndexCount
        public ImageLayout initialLayout;
    }
}
