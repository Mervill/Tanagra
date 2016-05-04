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
            set { _Image = value; NativePointer->Image = (IntPtr)value.NativePointer; }
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
        
        public SparseImageOpaqueMemoryBindInfo()
        {
            NativePointer = (Interop.SparseImageOpaqueMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseImageOpaqueMemoryBindInfo));
        }
    }
}
