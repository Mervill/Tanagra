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
        
        public IntPtr Display
        {
            get { return NativePointer->Display; }
            set { NativePointer->Display = value; }
        }
        
        public IntPtr Surface
        {
            get { return NativePointer->Surface; }
            set { NativePointer->Surface = value; }
        }
        
        public WaylandSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.WaylandSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.WaylandSurfaceCreateInfoKHR));
            //NativePointer->SType = StructureType.WaylandSurfaceCreateInfoKHR;
        }
    }
}
