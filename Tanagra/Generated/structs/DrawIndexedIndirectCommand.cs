using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DrawIndexedIndirectCommand
    {
        internal Interop.DrawIndexedIndirectCommand* NativeHandle;
        
        public UInt32 IndexCount
        {
            get { return NativeHandle->IndexCount; }
            set { NativeHandle->IndexCount = value; }
        }
        
        public UInt32 InstanceCount
        {
            get { return NativeHandle->InstanceCount; }
            set { NativeHandle->InstanceCount = value; }
        }
        
        public UInt32 FirstIndex
        {
            get { return NativeHandle->FirstIndex; }
            set { NativeHandle->FirstIndex = value; }
        }
        
        public Int32 VertexOffset
        {
            get { return NativeHandle->VertexOffset; }
            set { NativeHandle->VertexOffset = value; }
        }
        
        public UInt32 FirstInstance
        {
            get { return NativeHandle->FirstInstance; }
            set { NativeHandle->FirstInstance = value; }
        }
        
        public DrawIndexedIndirectCommand()
        {
            NativeHandle = (Interop.DrawIndexedIndirectCommand*)Interop.Structure.Allocate(typeof(Interop.DrawIndexedIndirectCommand));
        }
    }
}
