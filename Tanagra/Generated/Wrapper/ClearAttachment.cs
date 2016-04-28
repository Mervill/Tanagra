using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ClearAttachment
    {
        internal Interop.ClearAttachment* NativePointer;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativePointer->AspectMask; }
            set { NativePointer->AspectMask = value; }
        }
        
        public UInt32 ColorAttachment
        {
            get { return NativePointer->ColorAttachment; }
            set { NativePointer->ColorAttachment = value; }
        }
        
        ClearValue _ClearValue;
        public ClearValue ClearValue
        {
            get { return _ClearValue; }
            set { _ClearValue = value; NativePointer->ClearValue = (IntPtr)value.NativePointer; }
        }
        
        public ClearAttachment()
        {
            NativePointer = (Interop.ClearAttachment*)Interop.Structure.Allocate(typeof(Interop.ClearAttachment));
        }
    }
}
