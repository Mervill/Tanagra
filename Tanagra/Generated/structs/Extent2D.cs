using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Extent2D
    {
        internal Interop.Extent2D* NativeHandle;
        
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
        
        public Extent2D()
        {
            NativeHandle = (Interop.Extent2D*)Interop.Structure.Allocate(typeof(Interop.Extent2D));
        }
    }
}
