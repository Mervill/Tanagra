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
                if(NativePointer->Binds == IntPtr.Zero)
                    return null;
                var valueCount = NativePointer->BindCount;
                var valueArray = new SparseMemoryBind[valueCount];
                var ptr = (Interop.SparseMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = new SparseMemoryBind { NativePointer = &ptr[x] };
                
                return valueArray;
            }
            set
            {
                if(value != null)
                {
                    var valueCount = value.Length;
                    var typeSize = Marshal.SizeOf<Interop.SparseMemoryBind>() * valueCount;
                    if(NativePointer->Binds != IntPtr.Zero)
                        Marshal.ReAllocHGlobal(NativePointer->Binds, (IntPtr)typeSize);
                    
                    if(NativePointer->Binds == IntPtr.Zero)
                        NativePointer->Binds = Marshal.AllocHGlobal(typeSize);
                    
                    NativePointer->BindCount = (UInt32)valueCount;
                    var ptr = (Interop.SparseMemoryBind*)NativePointer->Binds;
                    for(var x = 0; x < valueCount; x++)
                        ptr[x] = *value[x].NativePointer;
                }
                else
                {
                    if(NativePointer->Binds != IntPtr.Zero)
                        Marshal.FreeHGlobal(NativePointer->Binds);
                    
                    NativePointer->Binds = IntPtr.Zero;
                    NativePointer->BindCount = 0;
                }
            }
        }
        
        public SparseBufferMemoryBindInfo()
        {
            NativePointer = (Interop.SparseBufferMemoryBindInfo*)MemoryUtils.Allocate(typeof(Interop.SparseBufferMemoryBindInfo));
        }
        
        public SparseBufferMemoryBindInfo(Buffer Buffer, SparseMemoryBind[] Binds) : this()
        {
            this.Buffer = Buffer;
            this.Binds = Binds;
        }
    }
}
