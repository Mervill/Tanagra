using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class XlibSurfaceCreateInfoKHR
    {
        internal Interop.XlibSurfaceCreateInfoKHR* NativeHandle;
        
        public XlibSurfaceCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        Display _Dpy;
        public Display Dpy
        {
            get { return _Dpy; }
            set { _Dpy = value; NativeHandle->Dpy = (IntPtr)value.NativeHandle; }
        }
        
        Window _Window;
        public Window Window
        {
            get { return _Window; }
            set { _Window = value; NativeHandle->Window = (IntPtr)value.NativeHandle; }
        }
        
        public XlibSurfaceCreateInfoKHR()
        {
            NativeHandle = (Interop.XlibSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.XlibSurfaceCreateInfoKHR));
            //NativeHandle->SType = StructureType.XlibSurfaceCreateInfoKHR;
        }
    }
}
