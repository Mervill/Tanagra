using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class Offset3D
    {
        internal Interop.Offset3D* NativeHandle;
        
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
        
        public Int32 Z
        {
            get { return NativeHandle->Z; }
            set { NativeHandle->Z = value; }
        }
        
        public Offset3D()
        {
            NativeHandle = (Interop.Offset3D*)Interop.Structure.Allocate(typeof(Interop.Offset3D));
        }
    }
}
