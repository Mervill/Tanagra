using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorImageInfo
    {
        internal Interop.DescriptorImageInfo* NativePointer;
        
        Sampler _Sampler;
        public Sampler Sampler
        {
            get { return _Sampler; }
            set { _Sampler = value; NativePointer->Sampler = value.NativePointer; }
        }
        
        ImageView _ImageView;
        public ImageView ImageView
        {
            get { return _ImageView; }
            set { _ImageView = value; NativePointer->ImageView = value.NativePointer; }
        }
        
        public ImageLayout ImageLayout
        {
            get { return NativePointer->ImageLayout; }
            set { NativePointer->ImageLayout = value; }
        }
        
        public DescriptorImageInfo()
        {
            NativePointer = (Interop.DescriptorImageInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorImageInfo));
        }
        
        public DescriptorImageInfo(Sampler Sampler, ImageView ImageView, ImageLayout ImageLayout) : this()
        {
            this.Sampler = Sampler;
            this.ImageView = ImageView;
            this.ImageLayout = ImageLayout;
        }
    }
}
