using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class VertexInputAttributeDescription
    {
        internal Interop.VertexInputAttributeDescription* NativeHandle;
        
        public UInt32 Location
        {
            get { return NativeHandle->Location; }
            set { NativeHandle->Location = value; }
        }
        
        public UInt32 Binding
        {
            get { return NativeHandle->Binding; }
            set { NativeHandle->Binding = value; }
        }
        
        public Format Format
        {
            get { return NativeHandle->Format; }
            set { NativeHandle->Format = value; }
        }
        
        public UInt32 Offset
        {
            get { return NativeHandle->Offset; }
            set { NativeHandle->Offset = value; }
        }
        
        public VertexInputAttributeDescription()
        {
            NativeHandle = (Interop.VertexInputAttributeDescription*)Interop.Structure.Allocate(typeof(Interop.VertexInputAttributeDescription));
        }
    }
}
