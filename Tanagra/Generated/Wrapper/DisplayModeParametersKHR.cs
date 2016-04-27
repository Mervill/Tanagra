using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayModeParametersKHR
    {
        internal Interop.DisplayModeParametersKHR* NativeHandle;
        
        Extent2D _VisibleRegion;
        public Extent2D VisibleRegion
        {
            get { return _VisibleRegion; }
            set { _VisibleRegion = value; NativeHandle->VisibleRegion = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 RefreshRate
        {
            get { return NativeHandle->RefreshRate; }
            set { NativeHandle->RefreshRate = value; }
        }
        
        public DisplayModeParametersKHR()
        {
            NativeHandle = (Interop.DisplayModeParametersKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayModeParametersKHR));
        }
    }
}
