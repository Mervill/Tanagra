using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseBufferMemoryBindInfo
    {
        internal Interop.SparseBufferMemoryBindInfo* NativePointer;
        
        Buffer _Buffer;
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativePointer->Buffer = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 BindCount
        {
            get { return NativePointer->BindCount; }
            set { NativePointer->BindCount = value; }
        }
        
        public SparseMemoryBind Binds
        {
            get { return NativePointer->Binds; }
            set { NativePointer->Binds = value; }
        }
        
        public SparseBufferMemoryBindInfo()
        {
            NativePointer = (Interop.SparseBufferMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseBufferMemoryBindInfo));
        }
    }
}
