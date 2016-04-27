using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearDepthStencilValue
    {
        internal Interop.ClearDepthStencilValue* NativeHandle;
        
        public Single Depth
        {
            get { return NativeHandle->Depth; }
            set { NativeHandle->Depth = value; }
        }
        
        public UInt32 Stencil
        {
            get { return NativeHandle->Stencil; }
            set { NativeHandle->Stencil = value; }
        }
        
        public ClearDepthStencilValue()
        {
            NativeHandle = (Interop.ClearDepthStencilValue*)Interop.Structure.Allocate(typeof(Interop.ClearDepthStencilValue));
        }
    }
}
