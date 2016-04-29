using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Win32SurfaceCreateInfoKHR
    {
        internal Interop.Win32SurfaceCreateInfoKHR* NativePointer;
        
        public Win32SurfaceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        HINSTANCE _Hinstance;
        public HINSTANCE Hinstance
        {
            get { return _Hinstance; }
            set { _Hinstance = value; NativePointer->Hinstance = (IntPtr)value.NativePointer; }
        }
        
        HWND _Hwnd;
        public HWND Hwnd
        {
            get { return _Hwnd; }
            set { _Hwnd = value; NativePointer->Hwnd = (IntPtr)value.NativePointer; }
        }
        
        public Win32SurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.Win32SurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.Win32SurfaceCreateInfoKHR));
            //NativePointer->SType = StructureType.Win32SurfaceCreateInfoKHR;
        }
    }
}
