using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModeCreateInfoKHR
    {
        internal Interop.DisplayModeCreateInfoKHR* NativeHandle;
        
        public DisplayModeCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        DisplayModeParametersKHR _Parameters;
        public DisplayModeParametersKHR Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; NativeHandle->Parameters = (IntPtr)value.NativeHandle; }
        }
        
        public DisplayModeCreateInfoKHR()
        {
            NativeHandle = (Interop.DisplayModeCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModeCreateInfoKHR));
            //NativeHandle->SType = StructureType.DisplayModeCreateInfoKHR;
        }
    }
}
