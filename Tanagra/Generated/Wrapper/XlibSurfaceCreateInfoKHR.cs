using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class XlibSurfaceCreateInfoKHR
    {
        internal Interop.XlibSurfaceCreateInfoKHR* NativePointer;
        
        public XlibSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        Display _Dpy;
        public Display Dpy
        {
            get { return _Dpy; }
            set { _Dpy = value; NativePointer->Dpy = (IntPtr)value.NativePointer; }
        }
        
        Window _Window;
        public Window Window
        {
            get { return _Window; }
            set { _Window = value; NativePointer->Window = (IntPtr)value.NativePointer; }
        }
        
        public XlibSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.XlibSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.XlibSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.XlibSurfaceCreateInfoKHR;
        }
    }
}
