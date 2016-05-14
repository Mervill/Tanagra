using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageMemoryBarrier
    {
        internal Interop.ImageMemoryBarrier* NativePointer;
        
        public AccessFlags SrcAccessMask
        {
            get { return NativePointer->SrcAccessMask; }
            set { NativePointer->SrcAccessMask = value; }
        }
        
        public AccessFlags DstAccessMask
        {
            get { return NativePointer->DstAccessMask; }
            set { NativePointer->DstAccessMask = value; }
        }
        
        public ImageLayout OldLayout
        {
            get { return NativePointer->OldLayout; }
            set { NativePointer->OldLayout = value; }
        }
        
        public ImageLayout NewLayout
        {
            get { return NativePointer->NewLayout; }
            set { NativePointer->NewLayout = value; }
        }
        
        public UInt32 SrcQueueFamilyIndex
        {
            get { return NativePointer->SrcQueueFamilyIndex; }
            set { NativePointer->SrcQueueFamilyIndex = value; }
        }
        
        public UInt32 DstQueueFamilyIndex
        {
            get { return NativePointer->DstQueueFamilyIndex; }
            set { NativePointer->DstQueueFamilyIndex = value; }
        }
        
        Image _Image;
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativePointer->Image = value.NativePointer; }
        }
        
        public ImageSubresourceRange SubresourceRange
        {
            get { return NativePointer->SubresourceRange; }
            set { NativePointer->SubresourceRange = value; }
        }
        
        public ImageMemoryBarrier()
        {
            NativePointer = (Interop.ImageMemoryBarrier*)Interop.Structure.Allocate(typeof(Interop.ImageMemoryBarrier));
            NativePointer->SType = StructureType.ImageMemoryBarrier;
        }
        
        public ImageMemoryBarrier(ImageLayout OldLayout, ImageLayout NewLayout, UInt32 SrcQueueFamilyIndex, UInt32 DstQueueFamilyIndex, Image Image, ImageSubresourceRange SubresourceRange) : this()
        {
            this.OldLayout = OldLayout;
            this.NewLayout = NewLayout;
            this.SrcQueueFamilyIndex = SrcQueueFamilyIndex;
            this.DstQueueFamilyIndex = DstQueueFamilyIndex;
            this.Image = Image;
            this.SubresourceRange = SubresourceRange;
        }
    }
}
