using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class XcbSurfaceCreateInfoKHR
    {
        internal Interop.XcbSurfaceCreateInfoKHR* NativeHandle;
        
        public XcbSurfaceCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        xcb_connection_t _Connection;
        public xcb_connection_t Connection
        {
            get { return _Connection; }
            set { _Connection = value; NativeHandle->Connection = (IntPtr)value.NativeHandle; }
        }
        
        xcb_window_t _Window;
        public xcb_window_t Window
        {
            get { return _Window; }
            set { _Window = value; NativeHandle->Window = (IntPtr)value.NativeHandle; }
        }
        
        public XcbSurfaceCreateInfoKHR()
        {
            NativeHandle = (Interop.XcbSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.XcbSurfaceCreateInfoKHR));
            //NativeHandle->SType = StructureType.XcbSurfaceCreateInfoKHR;
        }
    }
}
