using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SwapchainCreateInfoKHR
    {
        internal Interop.SwapchainCreateInfoKHR* NativeHandle;
        
        public SwapchainCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        SurfaceKHR _Surface;
        public SurfaceKHR Surface
        {
            get { return _Surface; }
            set { _Surface = value; NativeHandle->Surface = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MinImageCount
        {
            get { return NativeHandle->MinImageCount; }
            set { NativeHandle->MinImageCount = value; }
        }
        
        public Format ImageFormat
        {
            get { return NativeHandle->ImageFormat; }
            set { NativeHandle->ImageFormat = value; }
        }
        
        public ColorSpaceKHR ImageColorSpace
        {
            get { return NativeHandle->ImageColorSpace; }
            set { NativeHandle->ImageColorSpace = value; }
        }
        
        Extent2D _ImageExtent;
        public Extent2D ImageExtent
        {
            get { return _ImageExtent; }
            set { _ImageExtent = value; NativeHandle->ImageExtent = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ImageArrayLayers
        {
            get { return NativeHandle->ImageArrayLayers; }
            set { NativeHandle->ImageArrayLayers = value; }
        }
        
        public ImageUsageFlags ImageUsage
        {
            get { return NativeHandle->ImageUsage; }
            set { NativeHandle->ImageUsage = value; }
        }
        
        public SharingMode ImageSharingMode
        {
            get { return NativeHandle->ImageSharingMode; }
            set { NativeHandle->ImageSharingMode = value; }
        }
        
        public UInt32 QueueFamilyIndexCount
        {
            get { return NativeHandle->QueueFamilyIndexCount; }
            set { NativeHandle->QueueFamilyIndexCount = value; }
        }
        
        public UInt32 QueueFamilyIndices
        {
            get { return NativeHandle->QueueFamilyIndices; }
            set { NativeHandle->QueueFamilyIndices = value; }
        }
        
        public SurfaceTransformFlagBitsKHR PreTransform
        {
            get { return NativeHandle->PreTransform; }
            set { NativeHandle->PreTransform = value; }
        }
        
        public CompositeAlphaFlagBitsKHR CompositeAlpha
        {
            get { return NativeHandle->CompositeAlpha; }
            set { NativeHandle->CompositeAlpha = value; }
        }
        
        public PresentModeKHR PresentMode
        {
            get { return NativeHandle->PresentMode; }
            set { NativeHandle->PresentMode = value; }
        }
        
        public Boolean Clipped
        {
            get { return NativeHandle->Clipped; }
            set { NativeHandle->Clipped = value; }
        }
        
        SwapchainKHR _OldSwapchain;
        public SwapchainKHR OldSwapchain
        {
            get { return _OldSwapchain; }
            set { _OldSwapchain = value; NativeHandle->OldSwapchain = (IntPtr)value.NativeHandle; }
        }
        
        public SwapchainCreateInfoKHR()
        {
            NativeHandle = (Interop.SwapchainCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.SwapchainCreateInfoKHR));
            //NativeHandle->SType = StructureType.SwapchainCreateInfoKHR;
        }
    }
}
