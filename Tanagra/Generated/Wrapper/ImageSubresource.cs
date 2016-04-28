using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageSubresource
    {
        internal Interop.ImageSubresource* NativePointer;
        
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
        
        public UInt32 ArrayLayer
        {
            get { return NativePointer->ArrayLayer; }
            set { NativePointer->ArrayLayer = value; }
        }
        
        public ImageSubresource()
        {
            NativePointer = (Interop.ImageSubresource*)Interop.Structure.Allocate(typeof(Interop.ImageSubresource));
        }
    }
}
