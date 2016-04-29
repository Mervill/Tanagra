using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirSurfaceCreateInfoKHR
    {
        internal Interop.MirSurfaceCreateInfoKHR* NativePointer;
        
        public MirSurfaceCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        MirConnection _Connection;
        public MirConnection Connection
        {
            get { return _Connection; }
            set { _Connection = value; NativePointer->Connection = (IntPtr)value.NativePointer; }
        }
        
        MirSurface _MirSurface;
        public MirSurface MirSurface
        {
            get { return _MirSurface; }
            set { _MirSurface = value; NativePointer->MirSurface = (IntPtr)value.NativePointer; }
        }
        
        public MirSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.MirSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.MirSurfaceCreateInfoKHR));
            //NativePointer->SType = StructureType.MirSurfaceCreateInfoKHR;
        }
    }
}
