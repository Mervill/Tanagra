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
            set { _Buffer = value; NativePointer->Buffer = value.NativePointer; }
        }
        
        public UInt32 BindCount
        {
            get { return NativePointer->BindCount; }
            set { NativePointer->BindCount = value; }
        }
        
        public SparseMemoryBind[] Binds
        {
            get
            {
                var valueCount = NativePointer->BindCount;
                var valueArray = new SparseMemoryBind[valueCount];
                var ptr = (SparseMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->BindCount = (uint)valueCount;
                NativePointer->Binds = Marshal.AllocHGlobal((int)(Marshal.SizeOf<SparseMemoryBind>() * valueCount));
                var ptr = (SparseMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public SparseBufferMemoryBindInfo()
        {
            NativePointer = (Interop.SparseBufferMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseBufferMemoryBindInfo));
        }
    }
}
