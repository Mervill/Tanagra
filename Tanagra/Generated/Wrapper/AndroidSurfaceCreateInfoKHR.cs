using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AndroidSurfaceCreateInfoKHR
    {
        internal Interop.AndroidSurfaceCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
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
            NativePointer = (Interop.AndroidSurfaceCreateInfoKHR*)MemoryUtils.Allocate(typeof(Interop.AndroidSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.AndroidSurfaceCreateInfoKHR;
        }
        
        public AndroidSurfaceCreateInfoKHR(IntPtr Window) : this()
        {
            this.Window = Window;
        }
    }
}
