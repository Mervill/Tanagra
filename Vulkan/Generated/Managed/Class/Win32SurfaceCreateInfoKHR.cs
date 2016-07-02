using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class Win32SurfaceCreateInfoKHR : IDisposable
    {
        internal Unmanaged.Win32SurfaceCreateInfoKHR* NativePointer { get; private set; }
        
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
            NativePointer = (Unmanaged.Win32SurfaceCreateInfoKHR*)MemUtil.Alloc(typeof(Unmanaged.Win32SurfaceCreateInfoKHR));
            NativePointer->SType = StructureType.Win32SurfaceCreateInfoKHR;
        }
        
        internal Win32SurfaceCreateInfoKHR(Unmanaged.Win32SurfaceCreateInfoKHR* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.Win32SurfaceCreateInfoKHR));
        }
        
        public Win32SurfaceCreateInfoKHR(IntPtr Hinstance, IntPtr Hwnd) : this()
        {
            this.Hinstance = Hinstance;
            this.Hwnd = Hwnd;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~Win32SurfaceCreateInfoKHR()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
