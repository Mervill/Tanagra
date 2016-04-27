using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class DescriptorImageInfo
    {
        internal Interop.DescriptorImageInfo* NativeHandle;
        
        Sampler _Sampler;
        public Sampler Sampler
        {
            get { return _Sampler; }
            set { _Sampler = value; NativeHandle->Sampler = (IntPtr)value.NativeHandle; }
        }
        
        ImageView _ImageView;
        public ImageView ImageView
        {
            get { return _ImageView; }
            set { _ImageView = value; NativeHandle->ImageView = (IntPtr)value.NativeHandle; }
        }
        
        public ImageLayout ImageLayout
        {
            get { return NativeHandle->ImageLayout; }
            set { NativeHandle->ImageLayout = value; }
        }
        
        public DescriptorImageInfo()
        {
            NativeHandle = (Interop.DescriptorImageInfo*)Interop.Structure.Allocate(typeof(Interop.DescriptorImageInfo));
        }
    }
}
