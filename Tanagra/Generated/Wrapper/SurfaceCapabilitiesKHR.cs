using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SurfaceCapabilitiesKHR
    {
        internal Interop.SurfaceCapabilitiesKHR* NativeHandle;
        
        public UInt32 MinImageCount
        {
            get { return NativeHandle->MinImageCount; }
            set { NativeHandle->MinImageCount = value; }
        }
        
        public UInt32 MaxImageCount
        {
            get { return NativeHandle->MaxImageCount; }
            set { NativeHandle->MaxImageCount = value; }
        }
        
        Extent2D _CurrentExtent;
        public Extent2D CurrentExtent
        {
            get { return _CurrentExtent; }
            set { _CurrentExtent = value; NativeHandle->CurrentExtent = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _MinImageExtent;
        public Extent2D MinImageExtent
        {
            get { return _MinImageExtent; }
            set { _MinImageExtent = value; NativeHandle->MinImageExtent = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _MaxImageExtent;
        public Extent2D MaxImageExtent
        {
            get { return _MaxImageExtent; }
            set { _MaxImageExtent = value; NativeHandle->MaxImageExtent = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MaxImageArrayLayers
        {
            get { return NativeHandle->MaxImageArrayLayers; }
            set { NativeHandle->MaxImageArrayLayers = value; }
        }
        
        VkSurfaceTransformFlagsKHR _SupportedTransforms;
        public VkSurfaceTransformFlagsKHR SupportedTransforms
        {
            get { return _SupportedTransforms; }
            set { _SupportedTransforms = value; NativeHandle->SupportedTransforms = (IntPtr)value.NativeHandle; }
        }
        
        public SurfaceTransformFlagBitsKHR CurrentTransform
        {
            get { return NativeHandle->CurrentTransform; }
            set { NativeHandle->CurrentTransform = value; }
        }
        
        VkCompositeAlphaFlagsKHR _SupportedCompositeAlpha;
        public VkCompositeAlphaFlagsKHR SupportedCompositeAlpha
        {
            get { return _SupportedCompositeAlpha; }
            set { _SupportedCompositeAlpha = value; NativeHandle->SupportedCompositeAlpha = (IntPtr)value.NativeHandle; }
        }
        
        public ImageUsageFlags SupportedUsageFlags
        {
            get { return NativeHandle->SupportedUsageFlags; }
            set { NativeHandle->SupportedUsageFlags = value; }
        }
        
        public SurfaceCapabilitiesKHR()
        {
            NativeHandle = (Interop.SurfaceCapabilitiesKHR*)Interop.Structure.Allocate(typeof(Interop.SurfaceCapabilitiesKHR));
        }
    }
}
