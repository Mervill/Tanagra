using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class ImageViewCreateInfo : IDisposable
    {
        internal Unmanaged.ImageViewCreateInfo* NativePointer;
        
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
            NativePointer = (Unmanaged.ImageViewCreateInfo*)MemUtil.Alloc(typeof(Unmanaged.ImageViewCreateInfo));
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
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~ImageViewCreateInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
