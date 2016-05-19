using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class WaylandSurfaceCreateInfoKHR
    {
        internal Unmanaged.WaylandSurfaceCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
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
            NativePointer = (Unmanaged.WaylandSurfaceCreateInfoKHR*)MemoryUtils.Allocate(typeof(Unmanaged.WaylandSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.WaylandSurfaceCreateInfoKHR;
        }
        
        public WaylandSurfaceCreateInfoKHR(IntPtr Display, IntPtr Surface) : this()
        {
            this.Display = Display;
            this.Surface = Surface;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.WaylandSurfaceCreateInfoKHR*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
