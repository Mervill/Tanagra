using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageOpaqueMemoryBindInfo
    {
        internal Interop.SparseImageOpaqueMemoryBindInfo* NativeHandle;
        
        Image _Image;
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativeHandle->Image = (IntPtr)value.NativeHandle; }
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
        
        public SparseImageOpaqueMemoryBindInfo()
        {
            NativeHandle = (Interop.SparseImageOpaqueMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseImageOpaqueMemoryBindInfo));
        }
    }
}
