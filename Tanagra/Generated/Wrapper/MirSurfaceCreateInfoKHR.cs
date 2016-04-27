using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirSurfaceCreateInfoKHR
    {
        internal Interop.MirSurfaceCreateInfoKHR* NativeHandle;
        
        public MirSurfaceCreateFlagsKHR Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        MirConnection _Connection;
        public MirConnection Connection
        {
            get { return _Connection; }
            set { _Connection = value; NativeHandle->Connection = (IntPtr)value.NativeHandle; }
        }
        
        MirSurface _MirSurface;
        public MirSurface MirSurface
        {
            get { return _MirSurface; }
            set { _MirSurface = value; NativeHandle->MirSurface = (IntPtr)value.NativeHandle; }
        }
        
        public MirSurfaceCreateInfoKHR()
        {
            NativeHandle = (Interop.MirSurfaceCreateInfoKHR*)Interop.Structure.Allocate(typeof(Interop.MirSurfaceCreateInfoKHR));
            //NativeHandle->SType = StructureType.MirSurfaceCreateInfoKHR;
        }
    }
}
