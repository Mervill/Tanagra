using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class XlibSurfaceCreateInfoKHR
    {
        internal Interop.XlibSurfaceCreateInfoKHR* NativePointer;
        
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
            NativePointer = (Interop.XlibSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.XlibSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.XlibSurfaceCreateInfoKHR;
        }
        
        public XlibSurfaceCreateInfoKHR(IntPtr Dpy, IntPtr Window) : this()
        {
            this.Dpy = Dpy;
            this.Window = Window;
        }
    }
}
