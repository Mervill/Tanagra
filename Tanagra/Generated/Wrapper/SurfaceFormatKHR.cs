using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SurfaceFormatKHR
    {
        internal Interop.SurfaceFormatKHR* NativePointer;
        
        public Format Format
        {
            get { return NativePointer->Format; }
            set { NativePointer->Format = value; }
        }
        
        public ColorSpaceKHR ColorSpace
        {
            get { return NativePointer->ColorSpace; }
            set { NativePointer->ColorSpace = value; }
        }
        
        public SurfaceFormatKHR()
        {
            NativePointer = (Interop.SurfaceFormatKHR*)Interop.Structure.Allocate(typeof(Interop.SurfaceFormatKHR));
        }
    }
}
