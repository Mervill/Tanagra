using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DrawIndexedIndirectCommand
    {
        internal Interop.DrawIndexedIndirectCommand* NativePointer;
        
        public UInt32 IndexCount
        {
            get { return NativePointer->IndexCount; }
            set { NativePointer->IndexCount = value; }
        }
        
        public UInt32 InstanceCount
        {
            get { return NativePointer->InstanceCount; }
            set { NativePointer->InstanceCount = value; }
        }
        
        public UInt32 FirstIndex
        {
            get { return NativePointer->FirstIndex; }
            set { NativePointer->FirstIndex = value; }
        }
        
        public Int32 VertexOffset
        {
            get { return NativePointer->VertexOffset; }
            set { NativePointer->VertexOffset = value; }
        }
        
        public UInt32 FirstInstance
        {
            get { return NativePointer->FirstInstance; }
            set { NativePointer->FirstInstance = value; }
        }
        
        public DrawIndexedIndirectCommand()
        {
            NativePointer = (Interop.DrawIndexedIndirectCommand*)Interop.Structure.Allocate(typeof(Interop.DrawIndexedIndirectCommand));
        }
    }
}
