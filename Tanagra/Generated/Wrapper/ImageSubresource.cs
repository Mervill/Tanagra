using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageSubresource
    {
        internal Interop.ImageSubresource* NativeHandle;
        
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
        
        public UInt32 ArrayLayer
        {
            get { return NativeHandle->ArrayLayer; }
            set { NativeHandle->ArrayLayer = value; }
        }
        
        public ImageSubresource()
        {
            NativeHandle = (Interop.ImageSubresource*)Interop.Structure.Allocate(typeof(Interop.ImageSubresource));
        }
    }
}
