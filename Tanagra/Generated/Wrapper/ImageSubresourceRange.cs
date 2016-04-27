using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageSubresourceRange
    {
        internal Interop.ImageSubresourceRange* NativeHandle;
        
        public ImageAspectFlags AspectMask
        {
            get { return NativeHandle->AspectMask; }
            set { NativeHandle->AspectMask = value; }
        }
        
        public UInt32 BaseMipLevel
        {
            get { return NativeHandle->BaseMipLevel; }
            set { NativeHandle->BaseMipLevel = value; }
        }
        
        public UInt32 LevelCount
        {
            get { return NativeHandle->LevelCount; }
            set { NativeHandle->LevelCount = value; }
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
        
        public ImageSubresourceRange()
        {
            NativeHandle = (Interop.ImageSubresourceRange*)Interop.Structure.Allocate(typeof(Interop.ImageSubresourceRange));
        }
    }
}
