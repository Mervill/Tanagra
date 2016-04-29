using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPlaneCapabilitiesKHR
    {
        internal Interop.DisplayPlaneCapabilitiesKHR* NativePointer;
        
        public DisplayPlaneAlphaFlags SupportedAlpha
        {
            get { return NativePointer->SupportedAlpha; }
            set { NativePointer->SupportedAlpha = value; }
        }
        
        Offset2D _MinSrcPosition;
        public Offset2D MinSrcPosition
        {
            get { return _MinSrcPosition; }
            set { _MinSrcPosition = value; NativePointer->MinSrcPosition = (IntPtr)value.NativePointer; }
        }
        
        Offset2D _MaxSrcPosition;
        public Offset2D MaxSrcPosition
        {
            get { return _MaxSrcPosition; }
            set { _MaxSrcPosition = value; NativePointer->MaxSrcPosition = (IntPtr)value.NativePointer; }
        }
        
        Extent2D _MinSrcExtent;
        public Extent2D MinSrcExtent
        {
            get { return _MinSrcExtent; }
            set { _MinSrcExtent = value; NativePointer->MinSrcExtent = (IntPtr)value.NativePointer; }
        }
        
        Extent2D _MaxSrcExtent;
        public Extent2D MaxSrcExtent
        {
            get { return _MaxSrcExtent; }
            set { _MaxSrcExtent = value; NativePointer->MaxSrcExtent = (IntPtr)value.NativePointer; }
        }
        
        Offset2D _MinDstPosition;
        public Offset2D MinDstPosition
        {
            get { return _MinDstPosition; }
            set { _MinDstPosition = value; NativePointer->MinDstPosition = (IntPtr)value.NativePointer; }
        }
        
        Offset2D _MaxDstPosition;
        public Offset2D MaxDstPosition
        {
            get { return _MaxDstPosition; }
            set { _MaxDstPosition = value; NativePointer->MaxDstPosition = (IntPtr)value.NativePointer; }
        }
        
        Extent2D _MinDstExtent;
        public Extent2D MinDstExtent
        {
            get { return _MinDstExtent; }
            set { _MinDstExtent = value; NativePointer->MinDstExtent = (IntPtr)value.NativePointer; }
        }
        
        Extent2D _MaxDstExtent;
        public Extent2D MaxDstExtent
        {
            get { return _MaxDstExtent; }
            set { _MaxDstExtent = value; NativePointer->MaxDstExtent = (IntPtr)value.NativePointer; }
        }
        
        public DisplayPlaneCapabilitiesKHR()
        {
            NativePointer = (Interop.DisplayPlaneCapabilitiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPlaneCapabilitiesKHR));
        }
    }
}
