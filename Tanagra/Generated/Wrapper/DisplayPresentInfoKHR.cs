using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DisplayPresentInfoKHR
    {
        internal Interop.DisplayPresentInfoKHR* NativePointer;
        
        public Rect2D SrcRect
        {
            get { return NativePointer->SrcRect; }
            set { NativePointer->SrcRect = value; }
        }
        
        public Rect2D DstRect
        {
            get { return NativePointer->DstRect; }
            set { NativePointer->DstRect = value; }
        }
        
        public Bool32 Persistent
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
