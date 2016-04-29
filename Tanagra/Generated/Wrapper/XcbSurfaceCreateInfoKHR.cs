using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class XcbSurfaceCreateInfoKHR
    {
        internal Interop.XcbSurfaceCreateInfoKHR* NativePointer;
        
        public XcbSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        xcb_connection_t _Connection;
        public xcb_connection_t Connection
        {
            get { return _Connection; }
            set { _Connection = value; NativePointer->Connection = (IntPtr)value.NativePointer; }
        }
        
        xcb_window_t _Window;
        public xcb_window_t Window
        {
            get { return _Window; }
            set { _Window = value; NativePointer->Window = (IntPtr)value.NativePointer; }
        }
        
        public XcbSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.XcbSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.XcbSurfaceCreateInfoKHR));
            //NativePointer->SType = StructureType.XcbSurfaceCreateInfoKHR;
        }
    }
}
