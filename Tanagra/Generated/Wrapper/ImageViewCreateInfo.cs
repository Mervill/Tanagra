using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageViewCreateInfo
    {
        internal Interop.ImageViewCreateInfo* NativePointer;
        
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
            NativePointer = (Interop.ImageViewCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ImageViewCreateInfo));
            NativePointer->SType = StructureType.ImageViewCreateInfo;
        }
    }
}
