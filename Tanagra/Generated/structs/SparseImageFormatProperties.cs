using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageFormatProperties
    {
        internal Interop.SparseImageFormatProperties* NativeHandle;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativeHandle->AspectMask; }
            set { NativeHandle->AspectMask = value; }
        }
        
        Extent3D _ImageGranularity;
        public Extent3D ImageGranularity
        {
            get { return _ImageGranularity; }
            set { _ImageGranularity = value; NativeHandle->ImageGranularity = (IntPtr)value.NativeHandle; }
        }
        
        public SparseImageFormatFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        public SparseImageFormatProperties()
        {
            NativeHandle = (Interop.SparseImageFormatProperties*)Interop.Structure.Allocate(typeof(Interop.SparseImageFormatProperties));
        }
    }
}
