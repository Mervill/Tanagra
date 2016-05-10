using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPropertiesKHR
    {
        internal Interop.DisplayPropertiesKHR* NativePointer;
        
        DisplayKHR _Display;
        public DisplayKHR Display
        {
            get { return _Display; }
            set { _Display = value; NativePointer->Display = value.NativePointer; }
        }
        
        public string DisplayName
        {
            get { return Marshal.PtrToStringAnsi(NativePointer->DisplayName); }
            set { NativePointer->DisplayName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        public Extent2D PhysicalDimensions
        {
            get { return NativePointer->PhysicalDimensions; }
            set { NativePointer->PhysicalDimensions = value; }
        }
        
        public Extent2D PhysicalResolution
        {
            get { return NativePointer->PhysicalResolution; }
            set { NativePointer->PhysicalResolution = value; }
        }
        
        public SurfaceTransformFlagsKHR SupportedTransforms
        {
            get { return NativePointer->SupportedTransforms; }
            set { NativePointer->SupportedTransforms = value; }
        }
        
        public Bool32 PlaneReorderPossible
        {
            get { return NativePointer->PlaneReorderPossible; }
            set { NativePointer->PlaneReorderPossible = value; }
        }
        
        public Bool32 PersistentContent
        {
            get { return NativePointer->PersistentContent; }
            set { NativePointer->PersistentContent = value; }
        }
        
        public DisplayPropertiesKHR()
        {
            NativePointer = (Interop.DisplayPropertiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPropertiesKHR));
        }
    }
}
