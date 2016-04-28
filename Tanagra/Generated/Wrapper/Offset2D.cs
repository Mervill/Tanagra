using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Offset2D
    {
        internal Interop.Offset2D* NativePointer;
        
        public Int32 X
        {
            get { return NativePointer->X; }
            set { NativePointer->X = value; }
        }
        
        public Int32 Y
        {
            get { return NativePointer->Y; }
            set { NativePointer->Y = value; }
        }
        
        public Offset2D()
        {
            NativePointer = (Interop.Offset2D*)Interop.Structure.Allocate(typeof(Interop.Offset2D));
        }
    }
}
