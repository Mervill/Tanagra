using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class Win32SurfaceCreateInfoKHR : IDisposable
    {
        internal Unmanaged.Win32SurfaceCreateInfoKHR* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public Win32SurfaceCreateFlagsKHR Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public IntPtr Hinstance
        {
            get { return NativePointer->Hinstance; }
            set { NativePointer->Hinstance = value; }
        }
        
        public IntPtr Hwnd
        {
            get { return NativePointer->Hwnd; }
            set { NativePointer->Hwnd = value; }
        }
        
        public Win32SurfaceCreateInfoKHR()
        {
            NativePointer = (Unmanaged.Win32SurfaceCreateInfoKHR*)MemoryUtils.Allocate(typeof(Unmanaged.Win32SurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.Win32SurfaceCreateInfoKHR;
        }
        
        public Win32SurfaceCreateInfoKHR(IntPtr Hinstance, IntPtr Hwnd) : this()
        {
            this.Hinstance = Hinstance;
            this.Hwnd = Hwnd;
        }
        
        public void Dispose()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Unmanaged.Win32SurfaceCreateInfoKHR*)IntPtr.Zero;
            GC.SuppressFinalize(this);
        }
        
        ~Win32SurfaceCreateInfoKHR()
        {
            if(NativePointer != (Unmanaged.Win32SurfaceCreateInfoKHR*)IntPtr.Zero)
            {
                MemoryUtils.Free((IntPtr)NativePointer);
                NativePointer = (Unmanaged.Win32SurfaceCreateInfoKHR*)IntPtr.Zero;
            }
        }
    }
}
