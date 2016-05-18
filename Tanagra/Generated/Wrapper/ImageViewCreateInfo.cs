using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageViewCreateInfo
    {
        internal Interop.ImageViewCreateInfo* NativePointer;
        
        /// <summary>
        /// Reserved (Optional)
        /// </summary>
        public ImageViewCreateFlags Flags
        {
            get { return NativePointer->Flags; }
            set { NativePointer->Flags = value; }
        }
        
        Image _Image;
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativePointer->Image = value.NativePointer; }
        }
        
        public ImageViewType ViewType
        {
            get { return NativePointer->ViewType; }
            set { NativePointer->ViewType = value; }
        }
        
        public Format Format
        {
            get { return NativePointer->Format; }
            set { NativePointer->Format = value; }
        }
        
        public ComponentMapping Components
        {
            get { return NativePointer->Components; }
            set { NativePointer->Components = value; }
        }
        
        public ImageSubresourceRange SubresourceRange
        {
            get { return NativePointer->SubresourceRange; }
            set { NativePointer->SubresourceRange = value; }
        }
        
        public ImageViewCreateInfo()
        {
            NativePointer = (Interop.ImageViewCreateInfo*)MemoryUtils.Allocate(typeof(Interop.ImageViewCreateInfo));
            NativePointer->SType = StructureType.ImageViewCreateInfo;
        }
        
        public ImageViewCreateInfo(Image Image, ImageViewType ViewType, Format Format, ComponentMapping Components, ImageSubresourceRange SubresourceRange) : this()
        {
            this.Image = Image;
            this.ViewType = ViewType;
            this.Format = Format;
            this.Components = Components;
            this.SubresourceRange = SubresourceRange;
        }
        
        public void Free()
        {
            MemoryUtils.Free((IntPtr)NativePointer);
            NativePointer = (Interop.ImageViewCreateInfo*)IntPtr.Zero;
        }
    }
}
