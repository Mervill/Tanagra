using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Offset2D
    {
        internal Interop.Offset2D* NativeHandle;
        
        public Int32 X
        {
            get { return NativeHandle->X; }
            set { NativeHandle->X = value; }
        }
        
        public Int32 Y
        {
            get { return NativeHandle->Y; }
            set { NativeHandle->Y = value; }
        }
        
        public Offset2D()
        {
            NativeHandle = (Interop.Offset2D*)Interop.Structure.Allocate(typeof(Interop.Offset2D));
        }
    }
}
