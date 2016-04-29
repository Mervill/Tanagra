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
            set { _Image = value; NativePointer->Image = (IntPtr)value.NativePointer; }
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
        
        ComponentMapping _Components;
        public ComponentMapping Components
        {
            get { return _Components; }
            set { _Components = value; NativePointer->Components = (IntPtr)value.NativePointer; }
        }
        
        ImageSubresourceRange _SubresourceRange;
        public ImageSubresourceRange SubresourceRange
        {
            get { return _SubresourceRange; }
            set { _SubresourceRange = value; NativePointer->SubresourceRange = (IntPtr)value.NativePointer; }
        }
        
        public ImageViewCreateInfo()
        {
            NativePointer = (Interop.ImageViewCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ImageViewCreateInfo));
            NativePointer->SType = StructureType.ImageViewCreateInfo;
        }
    }
}
