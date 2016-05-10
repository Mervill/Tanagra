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
        
        public DisplayModeParametersKHR Parameters
        {
            get { return NativePointer->Parameters; }
            set { NativePointer->Parameters = value; }
        }
        
        public DisplayModeCreateInfoKHR()
        {
            NativePointer = (Interop.DisplayModeCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModeCreateInfoKHR));
            NativePointer->SType = StructureType.DisplayModeCreateInfoKHR;
        }
    }
}
