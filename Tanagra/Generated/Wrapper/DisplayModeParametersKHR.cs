using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModeParametersKHR
    {
        internal Interop.DisplayModeParametersKHR* NativePointer;
        
        Extent2D _VisibleRegion;
        public Extent2D VisibleRegion
        {
            get { return _VisibleRegion; }
            set { _VisibleRegion = value; NativePointer->VisibleRegion = value; }
        }
        
        public UInt32 RefreshRate
        {
            get { return NativePointer->RefreshRate; }
            set { NativePointer->RefreshRate = value; }
        }
        
        public DisplayModeParametersKHR()
        {
            NativePointer = (Interop.DisplayModeParametersKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModeParametersKHR));
        }
    }
}
