using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPlanePropertiesKHR
    {
        internal Interop.DisplayPlanePropertiesKHR* NativeHandle;
        
        DisplayKHR _CurrentDisplay;
        public DisplayKHR CurrentDisplay
        {
            get { return _CurrentDisplay; }
            set { _CurrentDisplay = value; NativeHandle->CurrentDisplay = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 CurrentStackIndex
        {
            get { return NativeHandle->CurrentStackIndex; }
            set { NativeHandle->CurrentStackIndex = value; }
        }
        
        public DisplayPlanePropertiesKHR()
        {
            NativeHandle = (Interop.DisplayPlanePropertiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPlanePropertiesKHR));
        }
    }
}
