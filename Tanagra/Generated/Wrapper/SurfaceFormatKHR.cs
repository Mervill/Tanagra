using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SurfaceFormatKHR
    {
        internal Interop.SurfaceFormatKHR* NativeHandle;
        
        public Format Format
        {
            get { return NativeHandle->Format; }
            set { NativeHandle->Format = value; }
        }
        
        public ColorSpaceKHR ColorSpace
        {
            get { return NativeHandle->ColorSpace; }
            set { NativeHandle->ColorSpace = value; }
        }
        
        public SurfaceFormatKHR()
        {
            NativeHandle = (Interop.SurfaceFormatKHR*)Interop.Structure.Allocate(typeof(Interop.SurfaceFormatKHR));
        }
    }
}
