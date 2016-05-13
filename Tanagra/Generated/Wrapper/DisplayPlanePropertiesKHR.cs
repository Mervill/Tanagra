using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPlanePropertiesKHR
    {
        internal Interop.DisplayPlanePropertiesKHR* NativePointer;
        
        DisplayKHR _CurrentDisplay;
        public DisplayKHR CurrentDisplay
        {
            get { return _CurrentDisplay; }
            set { _CurrentDisplay = value; NativePointer->CurrentDisplay = value.NativePointer; }
        }
        
        public UInt32 CurrentStackIndex
        {
            get { return NativePointer->CurrentStackIndex; }
            set { NativePointer->CurrentStackIndex = value; }
        }
        
        public DisplayPlanePropertiesKHR()
        {
            NativePointer = (Interop.DisplayPlanePropertiesKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPlanePropertiesKHR));
        }
    }
}
