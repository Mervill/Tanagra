using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class WaylandSurfaceCreateInfoKHR : IDisposable
    {
        internal Unmanaged.WaylandSurfaceCreateInfoKHR* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.WaylandSurfaceCreateInfoKHR*)MemUtil.Alloc(typeof(Unmanaged.WaylandSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.WaylandSurfaceCreateInfoKHR;
        }
        
        internal WaylandSurfaceCreateInfoKHR(Unmanaged.WaylandSurfaceCreateInfoKHR* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.WaylandSurfaceCreateInfoKHR));
        }
        
        public WaylandSurfaceCreateInfoKHR(IntPtr Display, IntPtr Surface) : this()
        {
            this.Display = Display;
            this.Surface = Surface;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~WaylandSurfaceCreateInfoKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
