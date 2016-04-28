using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModeCreateInfoKHR
    {
        internal Interop.DisplayModeCreateInfoKHR* NativePointer;
        
        public DisplayModeCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        DisplayModeParametersKHR _Parameters;
        public DisplayModeParametersKHR Parameters
        {
            get { return _Parameters; }
            set { _Parameters = value; NativePointer->Parameters = (IntPtr)value.NativePointer; }
        }
        
        public DisplayModeCreateInfoKHR()
        {
            NativePointer = (Interop.DisplayModeCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModeCreateInfoKHR));
            //NativePointer->SType = StructureType.DisplayModeCreateInfoKHR;
        }
    }
}
