using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPropertiesKHR
    {
        internal Interop.DisplayPropertiesKHR* NativeHandle;
        
        DisplayKHR _Display;
        public DisplayKHR Display
        {
            get { return _Display; }
            set { _Display = value; NativeHandle->Display = (IntPtr)value.NativeHandle; }
        }
        
        public string DisplayName
        {
            get { return Marshal.PtrToStringAnsi(NativeHandle->DisplayName); }
            set { NativeHandle->DisplayName = Marshal.StringToHGlobalAnsi(value); }
        }
        
        Extent2D _PhysicalDimensions;
        public Extent2D PhysicalDimensions
        {
            get { return _PhysicalDimensions; }
            set { _PhysicalDimensions = value; NativeHandle->PhysicalDimensions = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _PhysicalResolution;
        public Extent2D PhysicalResolution
        {
            get { return _PhysicalResolution; }
            set { _PhysicalResolution = value; NativeHandle->PhysicalResolution = (IntPtr)value.NativeHandle; }
        }
        
        VkSurfaceTransformFlagsKHR _SupportedTransforms;
        public VkSurfaceTransformFlagsKHR SupportedTransforms
        {
            get { return _SupportedTransforms; }
            set { _SupportedTransforms = value; NativeHandle->SupportedTransforms = (IntPtr)value.NativeHandle; }
        }
        
        public Boolean PlaneReorderPossible
        {
            get { return NativeHandle->PlaneReorderPossible; }
            set { NativeHandle->PlaneReorderPossible = value; }
        }
        
        public Boolean PersistentContent
        {
            get { return NativeHandle->PersistentContent; }
            set { NativeHandle->PersistentContent = value; }
        }
        
        public DisplayPropertiesKHR()
        {
            NativeHandle = (Interop.DisplayPropertiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPropertiesKHR));
        }
    }
}
