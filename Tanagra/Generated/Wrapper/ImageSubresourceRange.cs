using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageSubresourceRange
    {
        internal Interop.ImageSubresourceRange* NativePointer;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativePointer->AspectMask; }
            set { NativePointer->AspectMask = value; }
        }
        
        public UInt32 BaseMipLevel
        {
            get { return NativePointer->BaseMipLevel; }
            set { NativePointer->BaseMipLevel = value; }
        }
        
        public UInt32 LevelCount
        {
            get { return NativePointer->LevelCount; }
            set { NativePointer->LevelCount = value; }
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
        
        public ImageSubresourceRange()
        {
            NativePointer = (Interop.ImageSubresourceRange*)Interop.Structure.Allocate(typeof(Interop.ImageSubresourceRange));
        }
    }
}
