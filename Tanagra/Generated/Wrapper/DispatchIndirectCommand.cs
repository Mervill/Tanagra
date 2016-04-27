using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DispatchIndirectCommand
    {
        internal Interop.DispatchIndirectCommand* NativeHandle;
        
        public UInt32 X
        {
            get { return NativeHandle->X; }
            set { NativeHandle->X = value; }
        }
        
        public UInt32 Y
        {
            get { return NativeHandle->Y; }
            set { NativeHandle->Y = value; }
        }
        
        public UInt32 Z
        {
            get { return NativeHandle->Z; }
            set { NativeHandle->Z = value; }
        }
        
        public DispatchIndirectCommand()
        {
            NativeHandle = (Interop.DispatchIndirectCommand*)Interop.Structure.Allocate(typeof(Interop.DispatchIndirectCommand));
        }
    }
}
