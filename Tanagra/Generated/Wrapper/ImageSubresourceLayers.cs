using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageSubresourceLayers
    {
        internal Interop.ImageSubresourceLayers* NativePointer;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativePointer->AspectMask; }
            set { NativePointer->AspectMask = value; }
        }
        
        public UInt32 MipLevel
        {
            get { return NativePointer->MipLevel; }
            set { NativePointer->MipLevel = value; }
        }
        
        public UInt32 BaseArrayLayer
        {
            get { return NativePointer->BaseArrayLayer; }
            set { NativePointer->BaseArrayLayer = value; }
        }
        
        public UInt32 LayerCount
        {
            get { return NativePointer->LayerCount; }
            set { NativePointer->LayerCount = value; }
        }
        
        public ImageSubresourceLayers()
        {
            NativePointer = (Interop.ImageSubresourceLayers*)Interop.Structure.Allocate(typeof(Interop.ImageSubresourceLayers));
        }
    }
}
