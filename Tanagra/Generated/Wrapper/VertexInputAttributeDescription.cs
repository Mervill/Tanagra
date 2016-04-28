using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class VertexInputAttributeDescription
    {
        internal Interop.VertexInputAttributeDescription* NativePointer;
        
        public UInt32 Location
        {
            get { return NativePointer->Location; }
            set { NativePointer->Location = value; }
        }
        
        public UInt32 Binding
        {
            get { return NativePointer->Binding; }
            set { NativePointer->Binding = value; }
        }
        
        public Format Format
        {
            get { return NativePointer->Format; }
            set { NativePointer->Format = value; }
        }
        
        public UInt32 Offset
        {
            get { return NativePointer->Offset; }
            set { NativePointer->Offset = value; }
        }
        
        public VertexInputAttributeDescription()
        {
            NativePointer = (Interop.VertexInputAttributeDescription*)Interop.Structure.Allocate(typeof(Interop.VertexInputAttributeDescription));
        }
    }
}
