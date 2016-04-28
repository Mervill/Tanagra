using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageFormatProperties
    {
        internal Interop.SparseImageFormatProperties* NativePointer;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativePointer->AspectMask; }
            set { NativePointer->AspectMask = value; }
        }
        
        Extent3D _ImageGranularity;
        public Extent3D ImageGranularity
        {
            get { return _ImageGranularity; }
            set { _ImageGranularity = value; NativePointer->ImageGranularity = (IntPtr)value.NativePointer; }
        }
        
        public SparseImageFormatFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        public SparseImageFormatProperties()
        {
            NativePointer = (Interop.SparseImageFormatProperties*)Interop.Structure.Allocate(typeof(Interop.SparseImageFormatProperties));
        }
    }
}
