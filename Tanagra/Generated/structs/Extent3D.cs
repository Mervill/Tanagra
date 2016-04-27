using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Extent3D
    {
        internal Interop.Extent3D* NativeHandle;
        
        public UInt32 Width
        {
            get { return NativeHandle->Width; }
            set { NativeHandle->Width = value; }
        }
        
        public UInt32 Height
        {
            get { return NativeHandle->Height; }
            set { NativeHandle->Height = value; }
        }
        
        public UInt32 Depth
        {
            get { return NativeHandle->Depth; }
            set { NativeHandle->Depth = value; }
        }
        
        public Extent3D()
        {
            NativeHandle = (Interop.Extent3D*)Interop.Structure.Allocate(typeof(Interop.Extent3D));
        }
    }
}
