using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class WaylandSurfaceCreateInfoKHR
    {
        internal Interop.WaylandSurfaceCreateInfoKHR* NativePointer;
        
        public WaylandSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        wl_display _Display;
        public wl_display Display
        {
            get { return _Display; }
            set { _Display = value; NativePointer->Display = (IntPtr)value.NativePointer; }
        }
        
        wl_surface _Surface;
        public wl_surface Surface
        {
            get { return _Surface; }
            set { _Surface = value; NativePointer->Surface = (IntPtr)value.NativePointer; }
        }
        
        public WaylandSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.WaylandSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.WaylandSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.WaylandSurfaceCreateInfoKHR;
        }
    }
}
