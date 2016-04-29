using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplaySurfaceCreateInfoKHR
    {
        internal Interop.DisplaySurfaceCreateInfoKHR* NativePointer;
        
        public DisplaySurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        DisplayModeKHR _DisplayMode;
        public DisplayModeKHR DisplayMode
        {
            get { return _DisplayMode; }
            set { _DisplayMode = value; NativePointer->DisplayMode = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 PlaneIndex
        {
            get { return NativePointer->PlaneIndex; }
            set { NativePointer->PlaneIndex = value; }
        }
        
        public UInt32 PlaneStackIndex
        {
            get { return NativePointer->PlaneStackIndex; }
            set { NativePointer->PlaneStackIndex = value; }
        }
        
        public SurfaceTransformFlagBitsKHR Transform
        {
            get { return NativePointer->Transform; }
            set { NativePointer->Transform = value; }
        }
        
        public Single GlobalAlpha
        {
            get { return NativePointer->GlobalAlpha; }
            set { NativePointer->GlobalAlpha = value; }
        }
        
        public DisplayPlaneAlphaFlagBitsKHR AlphaMode
        {
            get { return NativePointer->AlphaMode; }
            set { NativePointer->AlphaMode = value; }
        }
        
        Extent2D _ImageExtent;
        public Extent2D ImageExtent
        {
            get { return _ImageExtent; }
            set { _ImageExtent = value; NativePointer->ImageExtent = (IntPtr)value.NativePointer; }
        }
        
        public DisplaySurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.DisplaySurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplaySurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.DisplaySurfaceCreateInfoKHR;
        }
    }
}
