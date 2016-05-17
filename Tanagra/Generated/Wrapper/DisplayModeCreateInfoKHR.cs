using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModeCreateInfoKHR
    {
        internal Interop.DisplayModeCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public DisplayModeCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters
        {
            get { return NativePointer->Parameters; }
            set { NativePointer->Parameters = value; }
        }
        
        public DisplayModeCreateInfoKHR()
        {
            NativePointer = (Interop.DisplayModeCreateInfoKHR*)MemoryUtils.Allocate(typeof(Interop.DisplayModeCreateInfoKHR));
            NativePointer->SType = StructureType.DisplayModeCreateInfoKHR;
        }
        
        public DisplayModeCreateInfoKHR(DisplayModeParametersKHR Parameters) : this()
        {
            this.Parameters = Parameters;
        }
    }
}
