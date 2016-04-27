using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearAttachment
    {
        internal Interop.ClearAttachment* NativeHandle;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativeHandle->AspectMask; }
            set { NativeHandle->AspectMask = value; }
        }
        
        public UInt32 ColorAttachment
        {
            get { return NativeHandle->ColorAttachment; }
            set { NativeHandle->ColorAttachment = value; }
        }
        
        ClearValue _ClearValue;
        public ClearValue ClearValue
        {
            get { return _ClearValue; }
            set { _ClearValue = value; NativeHandle->ClearValue = (IntPtr)value.NativeHandle; }
        }
        
        public ClearAttachment()
        {
            NativeHandle = (Interop.ClearAttachment*)Interop.Structure.Allocate(typeof(Interop.ClearAttachment));
        }
    }
}
