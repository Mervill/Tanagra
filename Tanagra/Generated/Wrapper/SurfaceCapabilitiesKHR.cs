using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SurfaceCapabilitiesKHR
    {
        internal Interop.SurfaceCapabilitiesKHR* NativePointer;
        
        public UInt32 MinImageCount
        {
            get { return NativePointer->MinImageCount; }
            set { NativePointer->MinImageCount = value; }
        }
        
        public UInt32 MaxImageCount
        {
            get { return NativePointer->MaxImageCount; }
            set { NativePointer->MaxImageCount = value; }
        }
        
        Extent2D _CurrentExtent;
        public Extent2D CurrentExtent
        {
            get { return _CurrentExtent; }
            set { _CurrentExtent = value; NativePointer->CurrentExtent = (IntPtr)value.NativePointer; }
        }
        
        Extent2D _MinImageExtent;
        public Extent2D MinImageExtent
        {
            get { return _MinImageExtent; }
            set { _MinImageExtent = value; NativePointer->MinImageExtent = (IntPtr)value.NativePointer; }
        }
        
        Extent2D _MaxImageExtent;
        public Extent2D MaxImageExtent
        {
            get { return _MaxImageExtent; }
            set { _MaxImageExtent = value; NativePointer->MaxImageExtent = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 MaxImageArrayLayers
        {
            get { return NativePointer->MaxImageArrayLayers; }
            set { NativePointer->MaxImageArrayLayers = value; }
        }
        
        VkSurfaceTransformFlagsKHR _SupportedTransforms;
        public VkSurfaceTransformFlagsKHR SupportedTransforms
        {
            get { return _SupportedTransforms; }
            set { _SupportedTransforms = value; NativePointer->SupportedTransforms = (IntPtr)value.NativePointer; }
        }
        
        public SurfaceTransformFlagBitsKHR CurrentTransform
        {
            get { return NativePointer->CurrentTransform; }
            set { NativePointer->CurrentTransform = value; }
        }
        
        VkCompositeAlphaFlagsKHR _SupportedCompositeAlpha;
        public VkCompositeAlphaFlagsKHR SupportedCompositeAlpha
        {
            get { return _SupportedCompositeAlpha; }
            set { _SupportedCompositeAlpha = value; NativePointer->SupportedCompositeAlpha = (IntPtr)value.NativePointer; }
        }
        
        public ImageUsageFlags SupportedUsageFlags
        {
            get { return NativePointer->SupportedUsageFlags; }
            set { NativePointer->SupportedUsageFlags = value; }
        }
        
        public SurfaceCapabilitiesKHR()
        {
            NativePointer = (Interop.SurfaceCapabilitiesKHR*)Interop.Structure.Allocate(typeof(Interop.SurfaceCapabilitiesKHR));
        }
    }
}
