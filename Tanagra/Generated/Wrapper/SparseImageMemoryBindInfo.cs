using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageMemoryBindInfo
    {
        internal Interop.SparseImageMemoryBindInfo* NativePointer;
        
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
        
        public SparseImageMemoryBind[] Binds
        {
            get
            {
                var valueCount = NativePointer->BindCount;
                var valueArray = new SparseImageMemoryBind[valueCount];
                var ptr = (SparseImageMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    valueArray[x] = ptr[x];
                return valueArray;
            }
            set
            {
                var valueCount = value.Length;
                NativePointer->BindCount = (uint)valueCount;
                NativePointer->Binds = Marshal.AllocHGlobal((int)(Marshal.SizeOf<SparseImageMemoryBind>() * valueCount));
                var ptr = (SparseImageMemoryBind*)NativePointer->Binds;
                for(var x = 0; x < valueCount; x++)
                    ptr[x] = value[x];
            }
        }
        
        public SparseImageMemoryBindInfo()
        {
            NativePointer = (Interop.SparseImageMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryBindInfo));
        }
    }
}
