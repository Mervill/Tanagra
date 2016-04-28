using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DrawIndirectCommand
    {
        internal Interop.DrawIndirectCommand* NativePointer;
        
        public UInt32 VertexCount
        {
            get { return NativePointer->VertexCount; }
            set { NativePointer->VertexCount = value; }
        }
        
        public UInt32 InstanceCount
        {
            get { return NativePointer->InstanceCount; }
            set { NativePointer->InstanceCount = value; }
        }
        
        public UInt32 FirstVertex
        {
            get { return NativePointer->FirstVertex; }
            set { NativePointer->FirstVertex = value; }
        }
        
        public UInt32 FirstInstance
        {
            get { return NativePointer->FirstInstance; }
            set { NativePointer->FirstInstance = value; }
        }
        
        public DrawIndirectCommand()
        {
            NativePointer = (Interop.DrawIndirectCommand*)Interop.Structure.Allocate(typeof(Interop.DrawIndirectCommand));
        }
    }
}
