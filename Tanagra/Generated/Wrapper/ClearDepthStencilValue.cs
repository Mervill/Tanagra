using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearDepthStencilValue
    {
        internal Interop.ClearDepthStencilValue* NativePointer;
        
        public Single Depth
        {
            get { return NativePointer->Depth; }
            set { NativePointer->Depth = value; }
        }
        
        public UInt32 Stencil
        {
            get { return NativePointer->Stencil; }
            set { NativePointer->Stencil = value; }
        }
        
        public ClearDepthStencilValue()
        {
            NativePointer = (Interop.ClearDepthStencilValue*)Interop.Structure.Allocate(typeof(Interop.ClearDepthStencilValue));
        }
    }
}
