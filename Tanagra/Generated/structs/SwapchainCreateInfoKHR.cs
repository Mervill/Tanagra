using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SwapchainCreateInfoKHR
    {
        public StructureType sType;
        public IntPtr pNext;
        public SwapchainCreateFlagsKHR flags;
        public SurfaceKHR surface;
        public UInt32 minImageCount;
        public Format imageFormat;
        public ColorSpaceKHR imageColorSpace;
        public Extent2D imageExtent;
        public UInt32 imageArrayLayers;
        public ImageUsageFlags imageUsage;
        public SharingMode imageSharingMode;
        public UInt32 queueFamilyIndexCount;
        public UInt32 pQueueFamilyIndices;
        public SurfaceTransformFlagBitsKHR preTransform;
        public CompositeAlphaFlagBitsKHR compositeAlpha;
        public PresentModeKHR presentMode;
        public Boolean clipped;
        public SwapchainKHR oldSwapchain;
    }
}
