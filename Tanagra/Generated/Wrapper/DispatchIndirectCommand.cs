using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DispatchIndirectCommand
    {
        internal Interop.DispatchIndirectCommand* NativePointer;
        
        public UInt32 X
        {
            get { return NativePointer->X; }
            set { NativePointer->X = value; }
        }
        
        public UInt32 Y
        {
            get { return NativePointer->Y; }
            set { NativePointer->Y = value; }
        }
        
        public UInt32 Z
        {
            get { return NativePointer->Z; }
            set { NativePointer->Z = value; }
        }
        
        public DispatchIndirectCommand()
        {
            NativePointer = (Interop.DispatchIndirectCommand*)Interop.Structure.Allocate(typeof(Interop.DispatchIndirectCommand));
        }
    }
}
