using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Rect3D
    {
        internal Interop.Rect3D* NativePointer;
        
        Offset3D _Offset;
        public Offset3D Offset
        {
            get { return _Offset; }
            set { _Offset = value; NativePointer->Offset = (IntPtr)value.NativePointer; }
        }
        
        Extent3D _Extent;
        public Extent3D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativePointer->Extent = (IntPtr)value.NativePointer; }
        }
        
        public Rect3D()
        {
            NativePointer = (Interop.Rect3D*)Interop.Structure.Allocate(typeof(Interop.Rect3D));
        }
    }
}
