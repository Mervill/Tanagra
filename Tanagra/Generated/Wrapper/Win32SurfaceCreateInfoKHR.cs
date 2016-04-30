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
        
        public IntPtr Hinstance
        {
            get { return NativePointer->Hinstance; }
            set { NativePointer->Hinstance = value; }
        }
        
        public IntPtr Hwnd
        {
            get { return NativePointer->Hwnd; }
            set { NativePointer->Hwnd = value; }
        }
        
        public Win32SurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.Win32SurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.Win32SurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.Win32SurfaceCreateInfoKHR;
        }
    }
}
