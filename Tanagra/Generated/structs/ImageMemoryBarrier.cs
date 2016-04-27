using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageMemoryBarrier
    {
        internal Interop.ImageMemoryBarrier* NativeHandle;
        
        public AccessFlags SrcAccessMask
        {
            get { return NativeHandle->SrcAccessMask; }
            set { NativeHandle->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativeHandle->DstAccessMask; }
            set { NativeHandle->DstAccessMask = value; }
        }
        
        public ImageLayout OldLayout
        {
            get { return NativeHandle->OldLayout; }
            set { NativeHandle->OldLayout = value; }
        }
        
        public ImageLayout NewLayout
        {
            get { return NativeHandle->NewLayout; }
            set { NativeHandle->NewLayout = value; }
        }
        
        public UInt32 SrcQueueFamilyIndex
        {
            get { return NativeHandle->SrcQueueFamilyIndex; }
            set { NativeHandle->SrcQueueFamilyIndex = value; }
        }
        
        public UInt32 DstQueueFamilyIndex
        {
            get { return NativeHandle->DstQueueFamilyIndex; }
            set { NativeHandle->DstQueueFamilyIndex = value; }
        }
        
        Image _Image;
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativeHandle->Image = (IntPtr)value.NativeHandle; }
        }
        
        ImageSubresourceRange _SubresourceRange;
        public ImageSubresourceRange SubresourceRange
        {
            get { return _SubresourceRange; }
            set { _SubresourceRange = value; NativeHandle->SubresourceRange = (IntPtr)value.NativeHandle; }
        }
        
        public ImageMemoryBarrier()
        {
            NativeHandle = (Interop.ImageMemoryBarrier*)Interop.Structure.Allocate(typeof(Interop.ImageMemoryBarrier));
            //NativeHandle->SType = StructureType.ImageMemoryBarrier;
        }
    }
}
