using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SwapchainCreateInfoKHR
    {
        internal Interop.SwapchainCreateInfoKHR* NativePointer;
        
        public SwapchainCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        SurfaceKHR _Surface;
        public SurfaceKHR Surface
        {
            get { return _Surface; }
            set { _Surface = value; NativePointer->Surface = value.NativePointer; }
        }
        
        public UInt32 MinImageCount
        {
            get { return NativePointer->MinImageCount; }
            set { NativePointer->MinImageCount = value; }
        }
        
        public Format ImageFormat
        {
            get { return NativePointer->ImageFormat; }
            set { NativePointer->ImageFormat = value; }
        }
        
        public ColorSpaceKHR ImageColorSpace
        {
            get { return NativePointer->ImageColorSpace; }
            set { NativePointer->ImageColorSpace = value; }
        }
        
        public Extent2D ImageExtent
        {
            get { return NativePointer->ImageExtent; }
            set { NativePointer->ImageExtent = value; }
        }
        
        public UInt32 ImageArrayLayers
        {
            get { return NativePointer->ImageArrayLayers; }
            set { NativePointer->ImageArrayLayers = value; }
        }
        
        public ImageUsageFlags ImageUsage
        {
            get { return NativePointer->ImageUsage; }
            set { NativePointer->ImageUsage = value; }
        }
        
        public SharingMode ImageSharingMode
        {
            get { return NativePointer->ImageSharingMode; }
            set { NativePointer->ImageSharingMode = value; }
        }
        
        public UInt32 QueueFamilyIndexCount
        {
            get { return NativePointer->QueueFamilyIndexCount; }
            set { NativePointer->QueueFamilyIndexCount = value; }
        }
        
        public UInt32[] QueueFamilyIndices
        {
            get
            {
                var valueCount = NativePointer->QueueFamilyIndexCount;
                var valueArray = new UInt32[valueCount];
                var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->QueueFamilyIndexCount = (uint)valueCount;
                NativePointer->QueueFamilyIndices = Marshal.AllocHGlobal(Marshal.SizeOf<UInt32>() * valueCount);
                var ptr = (UInt32*)NativePointer->QueueFamilyIndices;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public SurfaceTransformFlagsKHR PreTransform
        {
            get { return NativePointer->PreTransform; }
            set { NativePointer->PreTransform = value; }
        }
        
        public CompositeAlphaFlagsKHR CompositeAlpha
        {
            get { return NativePointer->CompositeAlpha; }
            set { NativePointer->CompositeAlpha = value; }
        }
        
        public PresentModeKHR PresentMode
        {
            get { return NativePointer->PresentMode; }
            set { NativePointer->PresentMode = value; }
        }
        
        public Bool32 Clipped
        {
            get { return NativePointer->Clipped; }
            set { NativePointer->Clipped = value; }
        }
        
        SwapchainKHR _OldSwapchain;
        public SwapchainKHR OldSwapchain
        {
            get { return _OldSwapchain; }
            set { _OldSwapchain = value; NativePointer->OldSwapchain = value.NativePointer; }
        }
        
        public SwapchainCreateInfoKHR()
        {
            NativePointer = (Interop.SwapchainCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.SwapchainCreateInfoKHR));
            NativePointer->SType = StructureType.SwapchainCreateInfoKHR;
        }
    }
}
