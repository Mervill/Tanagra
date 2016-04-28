using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageResolve
    {
        internal Interop.ImageResolve* NativePointer;
        
        ImageSubresourceLayers _SrcSubresource;
        public ImageSubresourceLayers SrcSubresource
        {
            get { return _SrcSubresource; }
            set { _SrcSubresource = value; NativePointer->SrcSubresource = (IntPtr)value.NativePointer; }
        }
        
        Offset3D _SrcOffset;
        public Offset3D SrcOffset
        {
            get { return _SrcOffset; }
            set { _SrcOffset = value; NativePointer->SrcOffset = (IntPtr)value.NativePointer; }
        }
        
        ImageSubresourceLayers _DstSubresource;
        public ImageSubresourceLayers DstSubresource
        {
            get { return _DstSubresource; }
            set { _DstSubresource = value; NativePointer->DstSubresource = (IntPtr)value.NativePointer; }
        }
        
        Offset3D _DstOffset;
        public Offset3D DstOffset
        {
            get { return _DstOffset; }
            set { _DstOffset = value; NativePointer->DstOffset = (IntPtr)value.NativePointer; }
        }
        
        Extent3D _Extent;
        public Extent3D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativePointer->Extent = (IntPtr)value.NativePointer; }
        }
        
        public ImageResolve()
        {
            NativePointer = (Interop.ImageResolve*)Interop.Structure.Allocate(typeof(Interop.ImageResolve));
        }
    }
}
