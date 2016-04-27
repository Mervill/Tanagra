using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Rect2D
    {
        internal Interop.Rect2D* NativeHandle;
        
        Offset2D _Offset;
        public Offset2D Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativeHandle->Offset = (IntPtr)value.NativeHandle; }
        }
        
        Extent2D _Extent;
        public Extent2D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativeHandle->Extent = (IntPtr)value.NativeHandle; }
        }
        
        public Rect2D()
        {
            NativeHandle = (Interop.Rect2D*)Interop.Structure.Allocate(typeof(Interop.Rect2D));
        }
    }
}
