using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class MirSurfaceCreateInfoKHR
    {
        internal Interop.MirSurfaceCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
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
            NativePointer = (Interop.MirSurfaceCreateInfoKHR*)MemoryUtils.Allocate(typeof(Interop.MirSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.MirSurfaceCreateInfoKHR;
        }
        
        public MirSurfaceCreateInfoKHR(IntPtr Connection, IntPtr MirSurface) : this()
        {
            this.Connection = Connection;
            this.MirSurface = MirSurface;
        }
    }
}
