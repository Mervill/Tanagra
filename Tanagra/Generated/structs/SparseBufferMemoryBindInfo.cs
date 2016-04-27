using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseBufferMemoryBindInfo
    {
        internal Interop.SparseBufferMemoryBindInfo* NativeHandle;
        
        Buffer _Buffer;
        public Buffer Buffer
        {
            get { return _Buffer; }
            set { _Buffer = value; NativeHandle->Buffer = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 BindCount
        {
            get { return NativeHandle->BindCount; }
            set { NativeHandle->BindCount = value; }
        }
        
        SparseMemoryBind _Binds;
        public SparseMemoryBind Binds
        {
            get { return _Binds; }
            set { _Binds = value; NativeHandle->Binds = (IntPtr)value.NativeHandle; }
        }
        
        public SparseBufferMemoryBindInfo()
        {
            NativeHandle = (Interop.SparseBufferMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseBufferMemoryBindInfo));
        }
    }
}
