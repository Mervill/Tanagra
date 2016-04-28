using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class StencilOpState
    {
        internal Interop.StencilOpState* NativePointer;
        
        public StencilOp FailOp
        {
            get { return NativePointer->FailOp; }
            set { NativePointer->FailOp = value; }
        }
        
        public StencilOp PassOp
        {
            get { return NativePointer->PassOp; }
            set { NativePointer->PassOp = value; }
        }
        
        public StencilOp DepthFailOp
        {
            get { return NativePointer->DepthFailOp; }
            set { NativePointer->DepthFailOp = value; }
        }
        
        public CompareOp CompareOp
        {
            get { return NativePointer->CompareOp; }
            set { NativePointer->CompareOp = value; }
        }
        
        public UInt32 CompareMask
        {
            get { return NativePointer->CompareMask; }
            set { NativePointer->CompareMask = value; }
        }
        
        public UInt32 WriteMask
        {
            get { return NativePointer->WriteMask; }
            set { NativePointer->WriteMask = value; }
        }
        
        public UInt32 Reference
        {
            get { return NativePointer->Reference; }
            set { NativePointer->Reference = value; }
        }
        
        public StencilOpState()
        {
            NativePointer = (Interop.StencilOpState*)Interop.Structure.Allocate(typeof(Interop.StencilOpState));
        }
    }
}
