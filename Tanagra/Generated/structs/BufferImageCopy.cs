using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferImageCopy
    {
        internal Interop.BufferImageCopy* NativeHandle;
        
        DeviceSize _BufferOffset;
        public DeviceSize BufferOffset
        {
            get { return _BufferOffset; }
            set { _BufferOffset = value; NativeHandle->BufferOffset = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 BufferRowLength
        {
            get { return NativeHandle->BufferRowLength; }
            set { NativeHandle->BufferRowLength = value; }
        }
        
        public UInt32 BufferImageHeight
        {
            get { return NativeHandle->BufferImageHeight; }
            set { NativeHandle->BufferImageHeight = value; }
        }
        
        ImageSubresourceLayers _ImageSubresource;
        public ImageSubresourceLayers ImageSubresource
        {
            get { return _ImageSubresource; }
            set { _ImageSubresource = value; NativeHandle->ImageSubresource = (IntPtr)value.NativeHandle; }
        }
        
        Offset3D _ImageOffset;
        public Offset3D ImageOffset
        {
            get { return _ImageOffset; }
            set { _ImageOffset = value; NativeHandle->ImageOffset = (IntPtr)value.NativeHandle; }
        }
        
        Extent3D _ImageExtent;
        public Extent3D ImageExtent
        {
            get { return _ImageExtent; }
            set { _ImageExtent = value; NativeHandle->ImageExtent = (IntPtr)value.NativeHandle; }
        }
        
        public BufferImageCopy()
        {
            NativeHandle = (Interop.BufferImageCopy*)Interop.Structure.Allocate(typeof(Interop.BufferImageCopy));
        }
    }
}
