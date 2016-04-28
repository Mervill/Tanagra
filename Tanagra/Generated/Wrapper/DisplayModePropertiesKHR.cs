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
            set { _DisplayMode = value; NativePointer->DisplayMode = (IntPtr)value.NativePointer; }
        }
        
        DisplayModeParametersKHR _Parameters;
        public DisplayModeParametersKHR Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; NativePointer->Parameters = (IntPtr)value.NativePointer; }
        }
        
        public DisplayModePropertiesKHR()
        {
            NativePointer = (Interop.DisplayModePropertiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModePropertiesKHR));
        }
    }
}
