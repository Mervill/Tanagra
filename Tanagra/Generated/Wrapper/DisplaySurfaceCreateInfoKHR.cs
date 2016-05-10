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
            set { _DisplayMode = value; NativePointer->DisplayMode = value.NativePointer; }
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
        
        public SurfaceTransformFlagsKHR Transform
        {
            get { return NativePointer->Transform; }
            set { NativePointer->Transform = value; }
        }
        
        public Single GlobalAlpha
        {
            get { return NativePointer->GlobalAlpha; }
            set { NativePointer->GlobalAlpha = value; }
        }
        
        public DisplayPlaneAlphaFlagsKHR AlphaMode
        {
            get { return NativePointer->AlphaMode; }
            set { NativePointer->AlphaMode = value; }
        }
        
        public Extent2D ImageExtent
        {
            get { return NativePointer->ImageExtent; }
            set { NativePointer->ImageExtent = value; }
        }
        
        public DisplaySurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.DisplaySurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplaySurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.DisplaySurfaceCreateInfoKHR;
        }
    }
}
