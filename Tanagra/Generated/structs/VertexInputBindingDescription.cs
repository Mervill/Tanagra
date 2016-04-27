using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class VertexInputBindingDescription
    {
        internal Interop.VertexInputBindingDescription* NativeHandle;
        
        public UInt32 Binding
        {
            get { return NativeHandle->Binding; }
            set { NativeHandle->Binding = value; }
        }
        
        public UInt32 Stride
        {
            get { return NativeHandle->Stride; }
            set { NativeHandle->Stride = value; }
        }
        
        public VertexInputRate InputRate
        {
            get { return NativeHandle->InputRate; }
            set { NativeHandle->InputRate = value; }
        }
        
        public VertexInputBindingDescription()
        {
            NativeHandle = (Interop.VertexInputBindingDescription*)Interop.Structure.Allocate(typeof(Interop.VertexInputBindingDescription));
        }
    }
}
