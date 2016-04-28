using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class BufferImageCopy
    {
        internal Interop.BufferImageCopy* NativePointer;
        
        public DeviceSize BufferOffset
        {
            get { return NativePointer->BufferOffset; }
            set { NativePointer->BufferOffset = value; }
        }
        
        public UInt32 BufferRowLength
        {
            get { return NativePointer->BufferRowLength; }
            set { NativePointer->BufferRowLength = value; }
        }
        
        public UInt32 BufferImageHeight
        {
            get { return NativePointer->BufferImageHeight; }
            set { NativePointer->BufferImageHeight = value; }
        }
        
        ImageSubresourceLayers _ImageSubresource;
        public ImageSubresourceLayers ImageSubresource
        {
            get { return _ImageSubresource; }
            set { _ImageSubresource = value; NativePointer->ImageSubresource = (IntPtr)value.NativePointer; }
        }
        
        Offset3D _ImageOffset;
        public Offset3D ImageOffset
        {
            get { return _ImageOffset; }
            set { _ImageOffset = value; NativePointer->ImageOffset = (IntPtr)value.NativePointer; }
        }
        
        Extent3D _ImageExtent;
        public Extent3D ImageExtent
        {
            get { return _ImageExtent; }
            set { _ImageExtent = value; NativePointer->ImageExtent = (IntPtr)value.NativePointer; }
        }
        
        public BufferImageCopy()
        {
            NativePointer = (Interop.BufferImageCopy*)Interop.Structure.Allocate(typeof(Interop.BufferImageCopy));
        }
    }
}
