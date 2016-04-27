using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageResolve
    {
        internal Interop.ImageResolve* NativeHandle;
        
        ImageSubresourceLayers _SrcSubresource;
        public ImageSubresourceLayers SrcSubresource
        {
            get { return _SrcSubresource; }
            set { _SrcSubresource = value; NativeHandle->SrcSubresource = (IntPtr)value.NativeHandle; }
        }
        
        Offset3D _SrcOffset;
        public Offset3D SrcOffset
        {
            get { return _SrcOffset; }
            set { _SrcOffset = value; NativeHandle->SrcOffset = (IntPtr)value.NativeHandle; }
        }
        
        ImageSubresourceLayers _DstSubresource;
        public ImageSubresourceLayers DstSubresource
        {
            get { return _DstSubresource; }
            set { _DstSubresource = value; NativeHandle->DstSubresource = (IntPtr)value.NativeHandle; }
        }
        
        Offset3D _DstOffset;
        public Offset3D DstOffset
        {
            get { return _DstOffset; }
            set { _DstOffset = value; NativeHandle->DstOffset = (IntPtr)value.NativeHandle; }
        }
        
        Extent3D _Extent;
        public Extent3D Extent
        {
            get { return _Extent; }
            set { _Extent = value; NativeHandle->Extent = (IntPtr)value.NativeHandle; }
        }
        
        public ImageResolve()
        {
            NativeHandle = (Interop.ImageResolve*)Interop.Structure.Allocate(typeof(Interop.ImageResolve));
        }
    }
}
