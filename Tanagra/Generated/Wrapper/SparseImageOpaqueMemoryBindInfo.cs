using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageOpaqueMemoryBindInfo
    {
        internal Interop.SparseImageOpaqueMemoryBindInfo* NativePointer;
        
        Image _Image;
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativePointer->Image = value.NativePointer; }
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
                NativePointer->Binds = Marshal.AllocHGlobal(Marshal.SizeOf<SparseMemoryBind>() * valueCount);
                var ptr = (SparseMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public SparseImageOpaqueMemoryBindInfo()
        {
            NativePointer = (Interop.SparseImageOpaqueMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseImageOpaqueMemoryBindInfo));
        }
    }
}
