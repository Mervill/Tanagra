using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModePropertiesKHR
    {
        internal Interop.DisplayModePropertiesKHR* NativeHandle;
        
        DisplayModeKHR _DisplayMode;
        public DisplayModeKHR DisplayMode
        {
            get { return _DisplayMode; }
            set { _DisplayMode = value; NativeHandle->DisplayMode = (IntPtr)value.NativeHandle; }
        }
        
        DisplayModeParametersKHR _Parameters;
        public DisplayModeParametersKHR Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; NativeHandle->Parameters = (IntPtr)value.NativeHandle; }
        }
        
        public DisplayModePropertiesKHR()
        {
            NativeHandle = (Interop.DisplayModePropertiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModePropertiesKHR));
        }
    }
}
