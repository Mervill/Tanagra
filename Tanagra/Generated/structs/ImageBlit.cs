using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageBlit
    {
        internal Interop.ImageBlit* NativeHandle;
        
        ImageSubresourceLayers _SrcSubresource;
        public ImageSubresourceLayers SrcSubresource
        {
            get { return _SrcSubresource; }
            set { _SrcSubresource = value; NativeHandle->SrcSubresource = (IntPtr)value.NativeHandle; }
        }
        
        Offset3D _SrcOffsets;
        public Offset3D SrcOffsets
        {
            get { return _SrcOffsets; }
            set { _SrcOffsets = value; NativeHandle->SrcOffsets = (IntPtr)value.NativeHandle; }
        }
        
        ImageSubresourceLayers _DstSubresource;
        public ImageSubresourceLayers DstSubresource
        {
            get { return _DstSubresource; }
            set { _DstSubresource = value; NativeHandle->DstSubresource = (IntPtr)value.NativeHandle; }
        }
        
        Offset3D _DstOffsets;
        public Offset3D DstOffsets
        {
            get { return _DstOffsets; }
            set { _DstOffsets = value; NativeHandle->DstOffsets = (IntPtr)value.NativeHandle; }
        }
        
        public ImageBlit()
        {
            NativeHandle = (Interop.ImageBlit*)Interop.Structure.Allocate(typeof(Interop.ImageBlit));
        }
    }
}
