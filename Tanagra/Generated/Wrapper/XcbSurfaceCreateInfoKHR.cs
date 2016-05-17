using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class XcbSurfaceCreateInfoKHR
    {
        internal Interop.XcbSurfaceCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public XcbSurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public IntPtr Connection
        {
            get { return NativePointer->Connection; }
            set { NativePointer->Connection = value; }
        }
        
        public IntPtr Window
        {
            get { return NativePointer->Window; }
            set { NativePointer->Window = value; }
        }
        
        public XcbSurfaceCreateInfoKHR()
        {
            NativePointer = (Interop.XcbSurfaceCreateInfoKHR*)MemoryUtils.Allocate(typeof(Interop.XcbSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.XcbSurfaceCreateInfoKHR;
        }
        
        public XcbSurfaceCreateInfoKHR(IntPtr Connection, IntPtr Window) : this()
        {
            this.Connection = Connection;
            this.Window = Window;
        }
    }
}
