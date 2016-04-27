using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPlaneCapabilitiesKHR
    {
        internal Interop.DisplayPlaneCapabilitiesKHR* NativeHandle;
        
        VkDisplayPlaneAlphaFlagsKHR _SupportedAlpha;
        public VkDisplayPlaneAlphaFlagsKHR SupportedAlpha
        {
            get { return _SupportedAlpha; }
            set { _SupportedAlpha = value; NativeHandle->SupportedAlpha = (IntPtr)value.NativeHandle; }
        }
        
        Offset2D _MinSrcPosition;
        public Offset2D MinSrcPosition
        {
            get { return _MinSrcPosition; }
            set { _MinSrcPosition = value; NativeHandle->MinSrcPosition = (IntPtr)value.NativeHandle; }
        }
        
        Offset2D _MaxSrcPosition;
        public Offset2D MaxSrcPosition
        {
            get { return _MaxSrcPosition; }
            set { _MaxSrcPosition = value; NativeHandle->MaxSrcPosition = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _MinSrcExtent;
        public Extent2D MinSrcExtent
        {
            get { return _MinSrcExtent; }
            set { _MinSrcExtent = value; NativeHandle->MinSrcExtent = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _MaxSrcExtent;
        public Extent2D MaxSrcExtent
        {
            get { return _MaxSrcExtent; }
            set { _MaxSrcExtent = value; NativeHandle->MaxSrcExtent = (IntPtr)value.NativeHandle; }
        }
        
        Offset2D _MinDstPosition;
        public Offset2D MinDstPosition
        {
            get { return _MinDstPosition; }
            set { _MinDstPosition = value; NativeHandle->MinDstPosition = (IntPtr)value.NativeHandle; }
        }
        
        Offset2D _MaxDstPosition;
        public Offset2D MaxDstPosition
        {
            get { return _MaxDstPosition; }
            set { _MaxDstPosition = value; NativeHandle->MaxDstPosition = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _MinDstExtent;
        public Extent2D MinDstExtent
        {
            get { return _MinDstExtent; }
            set { _MinDstExtent = value; NativeHandle->MinDstExtent = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _MaxDstExtent;
        public Extent2D MaxDstExtent
        {
            get { return _MaxDstExtent; }
            set { _MaxDstExtent = value; NativeHandle->MaxDstExtent = (IntPtr)value.NativeHandle; }
        }
        
        public DisplayPlaneCapabilitiesKHR()
        {
            NativeHandle = (Interop.DisplayPlaneCapabilitiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPlaneCapabilitiesKHR));
        }
    }
}
