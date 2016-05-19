using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class XlibSurfaceCreateInfoKHR
    {
        internal Unmanaged.XlibSurfaceCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public XlibSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public IntPtr Dpy
        {
            get { return NativePointer->Dpy; }
            set { NativePointer->Dpy = value; }
        }
        
        public IntPtr Window
        {
            get { return NativePointer->Window; }
            set { NativePointer->Window = value; }
        }
        
        public XlibSurfaceCreateInfoKHR()
        {
            NativePointer = (Unmanaged.XlibSurfaceCreateInfoKHR*)MemoryUtils.Allocate(typeof(Unmanaged.XlibSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.XlibSurfaceCreateInfoKHR;
        }
        
        public XlibSurfaceCreateInfoKHR(IntPtr Dpy, IntPtr Window) : this()
        {
            this.Dpy = Dpy;
            this.Window = Window;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.XlibSurfaceCreateInfoKHR*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
