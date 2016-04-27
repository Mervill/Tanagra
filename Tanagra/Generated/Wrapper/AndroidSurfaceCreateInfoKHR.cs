using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AndroidSurfaceCreateInfoKHR
    {
        internal Interop.AndroidSurfaceCreateInfoKHR* NativeHandle;
        
        public AndroidSurfaceCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        ANativeWindow _Window;
        public ANativeWindow Window
        {
            get { return _Window; }
            set { _Window = value; NativeHandle->Window = (IntPtr)value.NativeHandle; }
        }
        
        public AndroidSurfaceCreateInfoKHR()
        {
            NativeHandle = (Interop.AndroidSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.AndroidSurfaceCreateInfoKHR));
            //NativeHandle->SType = StructureType.AndroidSurfaceCreateInfoKHR;
        }
    }
}
