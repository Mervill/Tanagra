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
        
        public IntPtr Window
        {
            get { return NativePointer->Window; }
            set { NativePointer->Window = value; }
        }
        
        public AndroidSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.AndroidSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.AndroidSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.AndroidSurfaceCreateInfoKHR;
        }
    }
}
