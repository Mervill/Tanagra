using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class WaylandSurfaceCreateInfoKHR
    {
        internal Interop.WaylandSurfaceCreateInfoKHR* NativeHandle;
        
        public WaylandSurfaceCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        wl_display _Display;
        public wl_display Display
        {
            get { return _Display; }
            set { _Display = value; NativeHandle->Display = (IntPtr)value.NativeHandle; }
        }
        
        wl_surface _Surface;
        public wl_surface Surface
        {
            get { return _Surface; }
            set { _Surface = value; NativeHandle->Surface = (IntPtr)value.NativeHandle; }
        }
        
        public WaylandSurfaceCreateInfoKHR()
        {
            NativeHandle = (Interop.WaylandSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.WaylandSurfaceCreateInfoKHR));
            //NativeHandle->SType = StructureType.WaylandSurfaceCreateInfoKHR;
        }
    }
}
