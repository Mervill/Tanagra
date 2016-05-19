using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class AndroidSurfaceCreateInfoKHR
    {
        internal Unmanaged.AndroidSurfaceCreateInfoKHR* NativePointer;
        
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
            NativePointer = (Unmanaged.AndroidSurfaceCreateInfoKHR*)MemoryUtils.Allocate(typeof(Unmanaged.AndroidSurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.AndroidSurfaceCreateInfoKHR;
        }
        
        public AndroidSurfaceCreateInfoKHR(IntPtr Window) : this()
        {
            this.Window = Window;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.AndroidSurfaceCreateInfoKHR*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
    }
}
