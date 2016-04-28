using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class VertexInputBindingDescription
    {
        internal Interop.VertexInputBindingDescription* NativePointer;
        
        public UInt32 Binding
        {
            get { return NativePointer->Binding; }
            set { NativePointer->Binding = value; }
        }
        
        public UInt32 Stride
        {
            get { return NativePointer->Stride; }
            set { NativePointer->Stride = value; }
        }
        
        public VertexInputRate InputRate
        {
            get { return NativePointer->InputRate; }
            set { NativePointer->InputRate = value; }
        }
        
        public VertexInputBindingDescription()
        {
            NativePointer = (Interop.VertexInputBindingDescription*)Interop.Structure.Allocate(typeof(Interop.VertexInputBindingDescription));
        }
    }
}
