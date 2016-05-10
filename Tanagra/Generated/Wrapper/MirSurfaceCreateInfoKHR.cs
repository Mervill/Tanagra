using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirSurfaceCreateInfoKHR
    {
        internal Interop.MirSurfaceCreateInfoKHR* NativePointer;
        
        public MirSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public IntPtr Connection
        {
            get { return NativePointer->Connection; }
            set { NativePointer->Connection = value; }
        }
        
        public IntPtr MirSurface
        {
            get { return NativePointer->MirSurface; }
            set { NativePointer->MirSurface = value; }
        }
        
        public MirSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.MirSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.MirSurfaceCreateInfoKHR));
            //NativePointer->SType = StructureType.MirSurfaceCreateInfoKHR;
        }
    }
}
