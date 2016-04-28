using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageBlit
    {
        internal Interop.ImageBlit* NativePointer;
        
        ImageSubresourceLayers _SrcSubresource;
        public ImageSubresourceLayers SrcSubresource
        {
            get { return _SrcSubresource; }
            set { _SrcSubresource = value; NativePointer->SrcSubresource = (IntPtr)value.NativePointer; }
        }
        
        Offset3D _SrcOffsets;
        public Offset3D SrcOffsets
        {
            get { return _SrcOffsets; }
            set { _SrcOffsets = value; NativePointer->SrcOffsets = (IntPtr)value.NativePointer; }
        }
        
        ImageSubresourceLayers _DstSubresource;
        public ImageSubresourceLayers DstSubresource
        {
            get { return _DstSubresource; }
            set { _DstSubresource = value; NativePointer->DstSubresource = (IntPtr)value.NativePointer; }
        }
        
        Offset3D _DstOffsets;
        public Offset3D DstOffsets
        {
            get { return _DstOffsets; }
            set { _DstOffsets = value; NativePointer->DstOffsets = (IntPtr)value.NativePointer; }
        }
        
        public ImageBlit()
        {
            NativePointer = (Interop.ImageBlit*)Interop.Structure.Allocate(typeof(Interop.ImageBlit));
        }
    }
}
