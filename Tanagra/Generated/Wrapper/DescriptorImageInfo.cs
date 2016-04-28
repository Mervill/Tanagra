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
            set { _Sampler = value; NativePointer->Sampler = (IntPtr)value.NativePointer; }
        }
        
        ImageView _ImageView;
        public ImageView ImageView
        {
            get { return _ImageView; }
            set { _ImageView = value; NativePointer->ImageView = (IntPtr)value.NativePointer; }
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
    }
}
