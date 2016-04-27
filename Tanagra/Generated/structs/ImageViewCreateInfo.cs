using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageViewCreateInfo
    {
        internal Interop.ImageViewCreateInfo* NativeHandle;
        
        public ImageViewCreateFlags Flags
        {
            get { return NativeHandle->Flags; }
            set { NativeHandle->Flags = value; }
        }
        
        Image _Image;
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativeHandle->Image = (IntPtr)value.NativeHandle; }
        }
        
        public ImageViewType ViewType
        {
            get { return NativeHandle->ViewType; }
            set { NativeHandle->ViewType = value; }
        }
        
        public Format Format
        {
            get { return NativeHandle->Format; }
            set { NativeHandle->Format = value; }
        }
        
        ComponentMapping _Components;
        public ComponentMapping Components
        {
            get { return _Components; }
            set { _Components = value; NativeHandle->Components = (IntPtr)value.NativeHandle; }
        }
        
        ImageSubresourceRange _SubresourceRange;
        public ImageSubresourceRange SubresourceRange
        {
            get { return _SubresourceRange; }
            set { _SubresourceRange = value; NativeHandle->SubresourceRange = (IntPtr)value.NativeHandle; }
        }
        
        public ImageViewCreateInfo()
        {
            NativeHandle = (Interop.ImageViewCreateInfo*)Interop.Structure.Allocate(typeof(Interop.ImageViewCreateInfo));
            //NativeHandle->SType = StructureType.ImageViewCreateInfo;
        }
    }
}
