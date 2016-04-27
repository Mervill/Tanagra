using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DrawIndirectCommand
    {
        internal Interop.DrawIndirectCommand* NativeHandle;
        
        public UInt32 VertexCount
        {
            get { return NativeHandle->VertexCount; }
            set { NativeHandle->VertexCount = value; }
        }
        
        public UInt32 InstanceCount
        {
            get { return NativeHandle->InstanceCount; }
            set { NativeHandle->InstanceCount = value; }
        }
        
        public UInt32 FirstVertex
        {
            get { return NativeHandle->FirstVertex; }
            set { NativeHandle->FirstVertex = value; }
        }
        
        public UInt32 FirstInstance
        {
            get { return NativeHandle->FirstInstance; }
            set { NativeHandle->FirstInstance = value; }
        }
        
        public DrawIndirectCommand()
        {
            NativeHandle = (Interop.DrawIndirectCommand*)Interop.Structure.Allocate(typeof(Interop.DrawIndirectCommand));
        }
    }
}
