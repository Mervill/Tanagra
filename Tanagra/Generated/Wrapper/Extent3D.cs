using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Extent3D
    {
        internal Interop.Extent3D* NativePointer;
        
        public UInt32 Width
        {
            get { return NativePointer->Width; }
            set { NativePointer->Width = value; }
        }
        
        public UInt32 Height
        {
            get { return NativePointer->Height; }
            set { NativePointer->Height = value; }
        }
        
        public UInt32 Depth
        {
            get { return NativePointer->Depth; }
            set { NativePointer->Depth = value; }
        }
        
        public Extent3D()
        {
            NativePointer = (Interop.Extent3D*)Interop.Structure.Allocate(typeof(Interop.Extent3D));
        }
    }
}
