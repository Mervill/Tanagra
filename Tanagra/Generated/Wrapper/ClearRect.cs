using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearRect
    {
        internal Interop.ClearRect* NativeHandle;
        
        Rect2D _Rect;
        public Rect2D Rect
        {
            get { return _Rect; }
            set { _Rect = value; NativeHandle->Rect = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 BaseArrayLayer
        {
            get { return NativeHandle->BaseArrayLayer; }
            set { NativeHandle->BaseArrayLayer = value; }
        }
        
        public UInt32 LayerCount
        {
            get { return NativeHandle->LayerCount; }
            set { NativeHandle->LayerCount = value; }
        }
        
        public ClearRect()
        {
            NativeHandle = (Interop.ClearRect*)Interop.Structure.Allocate(typeof(Interop.ClearRect));
        }
    }
}
