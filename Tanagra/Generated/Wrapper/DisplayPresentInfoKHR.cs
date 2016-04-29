using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPresentInfoKHR
    {
        internal Interop.DisplayPresentInfoKHR* NativePointer;
        
        Rect2D _SrcRect;
        public Rect2D SrcRect
        {
            get { return _SrcRect; }
            set { _SrcRect = value; NativePointer->SrcRect = (IntPtr)value.NativePointer; }
        }
        
        Rect2D _DstRect;
        public Rect2D DstRect
        {
            get { return _DstRect; }
            set { _DstRect = value; NativePointer->DstRect = (IntPtr)value.NativePointer; }
        }
        
        public Boolean Persistent
        {
            get { return NativePointer->Persistent; }
            set { NativePointer->Persistent = value; }
        }
        
        public DisplayPresentInfoKHR()
        {
            NativePointer = (Interop.DisplayPresentInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPresentInfoKHR));
            NativePointer->SType = StructureType.DisplayPresentInfoKHR;
        }
    }
}
