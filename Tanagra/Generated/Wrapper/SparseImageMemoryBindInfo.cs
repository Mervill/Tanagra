using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageMemoryBindInfo
    {
        internal Interop.SparseImageMemoryBindInfo* NativeHandle;
        
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
        
        SparseImageMemoryBind _Binds;
        public SparseImageMemoryBind Binds
        {
            get { return _Binds; }
            set { _Binds = value; NativeHandle->Binds = (IntPtr)value.NativeHandle; }
        }
        
        public SparseImageMemoryBindInfo()
        {
            NativeHandle = (Interop.SparseImageMemoryBindInfo*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryBindInfo));
        }
    }
}
