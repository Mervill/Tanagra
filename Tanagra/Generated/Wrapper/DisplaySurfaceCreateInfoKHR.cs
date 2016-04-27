using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplaySurfaceCreateInfoKHR
    {
        internal Interop.DisplaySurfaceCreateInfoKHR* NativeHandle;
        
        public DisplaySurfaceCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        DisplayModeKHR _DisplayMode;
        public DisplayModeKHR DisplayMode
        {
            get { return _DisplayMode; }
            set { _DisplayMode = value; NativeHandle->DisplayMode = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 PlaneIndex
        {
            get { return NativeHandle->PlaneIndex; }
            set { NativeHandle->PlaneIndex = value; }
        }
        
        public UInt32 PlaneStackIndex
        {
            get { return NativeHandle->PlaneStackIndex; }
            set { NativeHandle->PlaneStackIndex = value; }
        }
        
        public SurfaceTransformFlagBitsKHR Transform
        {
            get { return NativeHandle->Transform; }
            set { NativeHandle->Transform = value; }
        }
        
        public Single GlobalAlpha
        {
            get { return NativeHandle->GlobalAlpha; }
            set { NativeHandle->GlobalAlpha = value; }
        }
        
        public DisplayPlaneAlphaFlagBitsKHR AlphaMode
        {
            get { return NativeHandle->AlphaMode; }
            set { NativeHandle->AlphaMode = value; }
        }
        
        Extent2D _ImageExtent;
        public Extent2D ImageExtent
        {
            get { return _ImageExtent; }
            set { _ImageExtent = value; NativeHandle->ImageExtent = (IntPtr)value.NativeHandle; }
        }
        
        public DisplaySurfaceCreateInfoKHR()
        {
            NativeHandle = (Interop.DisplaySurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplaySurfaceCreateInfoKHR));
            //NativeHandle->SType = StructureType.DisplaySurfaceCreateInfoKHR;
        }
    }
}
