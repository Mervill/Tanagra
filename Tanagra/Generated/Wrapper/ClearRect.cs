using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearRect
    {
        internal Interop.ClearRect* NativePointer;
        
        Rect2D _Rect;
        public Rect2D Rect
        {
            get { return _Rect; }
            set { _Rect = value; NativePointer->Rect = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 BaseArrayLayer
        {
            get { return NativePointer->BaseArrayLayer; }
            set { NativePointer->BaseArrayLayer = value; }
        }
        
        public UInt32 LayerCount
        {
            get { return NativePointer->LayerCount; }
            set { NativePointer->LayerCount = value; }
        }
        
        public ClearRect()
        {
            NativePointer = (Interop.ClearRect*)Interop.Structure.Allocate(typeof(Interop.ClearRect));
        }
    }
}
