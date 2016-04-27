using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Win32SurfaceCreateInfoKHR
    {
        internal Interop.Win32SurfaceCreateInfoKHR* NativeHandle;
        
        public Win32SurfaceCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        HINSTANCE _Hinstance;
        public HINSTANCE Hinstance
        {
            get { return _Hinstance; }
            set { _Hinstance = value; NativeHandle->Hinstance = (IntPtr)value.NativeHandle; }
        }
        
        HWND _Hwnd;
        public HWND Hwnd
        {
            get { return _Hwnd; }
            set { _Hwnd = value; NativeHandle->Hwnd = (IntPtr)value.NativeHandle; }
        }
        
        public Win32SurfaceCreateInfoKHR()
        {
            NativeHandle = (Interop.Win32SurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.Win32SurfaceCreateInfoKHR));
            //NativeHandle->SType = StructureType.Win32SurfaceCreateInfoKHR;
        }
    }
}
