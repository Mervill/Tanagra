using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class StencilOpState
    {
        internal Interop.StencilOpState* NativeHandle;
        
        public StencilOp FailOp
        {
            get { return NativeHandle->FailOp; }
            set { NativeHandle->FailOp = value; }
        }
        
        public StencilOp PassOp
        {
            get { return NativeHandle->PassOp; }
            set { NativeHandle->PassOp = value; }
        }
        
        public StencilOp DepthFailOp
        {
            get { return NativeHandle->DepthFailOp; }
            set { NativeHandle->DepthFailOp = value; }
        }
        
        public CompareOp CompareOp
        {
            get { return NativeHandle->CompareOp; }
            set { NativeHandle->CompareOp = value; }
        }
        
        public UInt32 CompareMask
        {
            get { return NativeHandle->CompareMask; }
            set { NativeHandle->CompareMask = value; }
        }
        
        public UInt32 WriteMask
        {
            get { return NativeHandle->WriteMask; }
            set { NativeHandle->WriteMask = value; }
        }
        
        public UInt32 Reference
        {
            get { return NativeHandle->Reference; }
            set { NativeHandle->Reference = value; }
        }
        
        public StencilOpState()
        {
            NativeHandle = (Interop.StencilOpState*)Interop.Structure.Allocate(typeof(Interop.StencilOpState));
        }
    }
}
