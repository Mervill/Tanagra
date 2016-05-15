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
        
        public SparseMemoryBind[] Binds
        {
            get
            {
                var valueCount = NativePointer->BindCount;
                var valueArray = new SparseMemoryBind[valueCount];
                var ptr = (Interop.SparseMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseMemoryBind { NativePointer = &ptr[x] };
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->BindCount = (UInt32)valueCount;
                NativePointer->Binds = Marshal.AllocHGlobal(Marshal.SizeOf<Interop.SparseMemoryBind>() * valueCount);
                var ptr = (Interop.SparseMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = *value[x].NativePointer;
            }
        }
        
        public SparseBufferMemoryBindInfo()
        {
            NativePointer = (Interop.SparseBufferMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseBufferMemoryBindInfo));
        }
        
        public SparseBufferMemoryBindInfo(Buffer Buffer, SparseMemoryBind[] Binds) : this()
        {
            this.Buffer = Buffer;
            this.Binds = Binds;
        }
    }
}
