using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Offset3D
    {
        internal Interop.Offset3D* NativePointer;
        
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
        
        public Int32 Z
        {
            get { return NativePointer->Z; }
            set { NativePointer->Z = value; }
        }
        
        public Offset3D()
        {
            NativePointer = (Interop.Offset3D*)Interop.Structure.Allocate(typeof(Interop.Offset3D));
        }
    }
}
