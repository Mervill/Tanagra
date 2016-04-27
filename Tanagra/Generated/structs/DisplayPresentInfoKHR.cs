using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPresentInfoKHR
    {
        internal Interop.DisplayPresentInfoKHR* NativeHandle;
        
        Rect2D _SrcRect;
        public Rect2D SrcRect
        {
            get { return _SrcRect; }
            set { _SrcRect = value; NativeHandle->SrcRect = (IntPtr)value.NativeHandle; }
        }
        
        Rect2D _DstRect;
        public Rect2D DstRect
        {
            get { return _DstRect; }
            set { _DstRect = value; NativeHandle->DstRect = (IntPtr)value.NativeHandle; }
        }
        
        public Boolean Persistent
        {
            get { return NativeHandle->Persistent; }
            set { NativeHandle->Persistent = value; }
        }
        
        public DisplayPresentInfoKHR()
        {
            NativeHandle = (Interop.DisplayPresentInfoKHR*)Interop.Structure.Allocate(typeof(Interop.DisplayPresentInfoKHR));
            //NativeHandle->SType = StructureType.DisplayPresentInfoKHR;
        }
    }
}
