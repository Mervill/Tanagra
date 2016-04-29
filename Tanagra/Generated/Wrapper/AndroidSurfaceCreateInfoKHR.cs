using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AndroidSurfaceCreateInfoKHR
    {
        internal Interop.AndroidSurfaceCreateInfoKHR* NativePointer;
        
        public AndroidSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        ANativeWindow _Window;
        public ANativeWindow Window
        {
            get { return _Window; }
            set { _Window = value; NativePointer->Window = (IntPtr)value.NativePointer; }
        }
        
        public AndroidSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.AndroidSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.AndroidSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.AndroidSurfaceCreateInfoKHR;
        }
    }
}
