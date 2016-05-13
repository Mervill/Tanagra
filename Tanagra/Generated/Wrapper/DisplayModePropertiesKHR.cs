using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModePropertiesKHR
    {
        internal Interop.DisplayModePropertiesKHR* NativePointer;
        
        DisplayModeKHR _DisplayMode;
        public DisplayModeKHR DisplayMode
        {
            get { return _DisplayMode; }
            set { _DisplayMode = value; NativePointer->DisplayMode = value.NativePointer; }
        }
        
        public DisplayModeParametersKHR Parameters
        {
            get { return NativePointer->Parameters; }
            set { NativePointer->Parameters = value; }
        }
        
        public DisplayModePropertiesKHR()
        {
            NativePointer = (Interop.DisplayModePropertiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModePropertiesKHR));
        }
    }
}
