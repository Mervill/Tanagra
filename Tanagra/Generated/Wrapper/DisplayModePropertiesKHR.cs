using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModePropertiesKHR
    {
        internal Interop.DisplayModePropertiesKHR* NativePointer;
        
        DisplayModeKHR _DisplayMode;
        /// <summary>
        /// Handle of this display mode.
        /// </summary>
        public DisplayModeKHR DisplayMode
        {
            get { return _DisplayMode; }
            set { _DisplayMode = value; NativePointer->DisplayMode = value.NativePointer; }
        }
        
        /// <summary>
        /// The parameters this mode uses.
        /// </summary>
        public DisplayModeParametersKHR Parameters
        {
            get { return NativePointer->Parameters; }
            set { NativePointer->Parameters = value; }
        }
        
        public DisplayModePropertiesKHR()
        {
            NativePointer = (Interop.DisplayModePropertiesKHR*)MemoryUtils.Allocate(typeof(Interop.DisplayModePropertiesKHR));
        }
        
        public DisplayModePropertiesKHR(DisplayModeKHR DisplayMode, DisplayModeParametersKHR Parameters) : this()
        {
            this.DisplayMode = DisplayMode;
            this.Parameters = Parameters;
        }
    }
}
