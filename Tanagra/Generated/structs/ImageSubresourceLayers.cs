using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageSubresourceLayers
    {
        internal Interop.ImageSubresourceLayers* NativeHandle;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativeHandle->AspectMask; }
            set { NativeHandle->AspectMask = value; }
        }
        
        public UInt32 MipLevel
        {
            get { return NativeHandle->MipLevel; }
            set { NativeHandle->MipLevel = value; }
        }
        
        public UInt32 BaseArrayLayer
        {
            get { return NativeHandle->BaseArrayLayer; }
            set { NativeHandle->BaseArrayLayer = value; }
        }
        
        public UInt32 LayerCount
        {
            get { return NativeHandle->LayerCount; }
            set { NativeHandle->LayerCount = value; }
        }
        
        public ImageSubresourceLayers()
        {
            NativeHandle = (Interop.ImageSubresourceLayers*)Interop.Structure.Allocate(typeof(Interop.ImageSubresourceLayers));
        }
    }
}
