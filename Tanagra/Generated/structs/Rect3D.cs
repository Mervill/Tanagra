using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Rect3D
    {
        internal Interop.Rect3D* NativeHandle;
        
        Offset3D _Offset;
        public Offset3D Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativeHandle->Offset = (IntPtr)value.NativeHandle; }
        }
        
        Extent3D _Extent;
        public Extent3D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativeHandle->Extent = (IntPtr)value.NativeHandle; }
        }
        
        public Rect3D()
        {
            NativeHandle = (Interop.Rect3D*)Interop.Structure.Allocate(typeof(Interop.Rect3D));
        }
    }
}
