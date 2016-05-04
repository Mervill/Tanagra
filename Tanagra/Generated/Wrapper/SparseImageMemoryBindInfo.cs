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
            set { _Image = value; NativePointer->Image = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 BindCount
        {
            get { return NativePointer->BindCount; }
            set { NativePointer->BindCount = value; }
        }
        
        public SparseImageMemoryBind Binds
        {
            get { return NativePointer->Binds; }
            set { NativePointer->Binds = value; }
        }
        
        public SparseImageMemoryBindInfo()
        {
            NativePointer = (Interop.SparseImageMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryBindInfo));
        }
    }
}
