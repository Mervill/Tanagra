using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class DescriptorImageInfo : IDisposable
    {
        internal Unmanaged.DescriptorImageInfo* NativePointer { get; private set; }
        
        Sampler _Sampler;
        /// <summary>
        /// Sampler to write to the descriptor in case it's a SAMPLER or COMBINED_IMAGE_SAMPLER descriptor. Ignored otherwise.
        /// </summary>
        public Sampler Sampler
        {
            get { return _Sampler; }
            set { _Sampler = value; NativePointer->Sampler = value.NativePointer; }
        }
        
        ImageView _ImageView;
        /// <summary>
        /// Image view to write to the descriptor in case it's a SAMPLED_IMAGE, STORAGE_IMAGE, COMBINED_IMAGE_SAMPLER, or INPUT_ATTACHMENT descriptor. Ignored otherwise.
        /// </summary>
        public ImageView ImageView
        {
            get { return _ImageView; }
            set { _ImageView = value; NativePointer->ImageView = value.NativePointer; }
        }
        
        /// <summary>
        /// Layout the image is expected to be in when accessed using this descriptor (only used if imageView is not VK_NULL_HANDLE).
        /// </summary>
        public ImageLayout ImageLayout
        {
            get { return NativePointer->ImageLayout; }
            set { NativePointer->ImageLayout = value; }
        }
        
        public DescriptorImageInfo()
        {
            NativePointer = (Unmanaged.DescriptorImageInfo*)MemUtil.Alloc(typeof(Unmanaged.DescriptorImageInfo));
        }
        
        internal DescriptorImageInfo(Unmanaged.DescriptorImageInfo* ptr)
        {
            NativePointer = ptr;
            MemUtil.Register(NativePointer, typeof(Unmanaged.DescriptorImageInfo));
        }
        
        /// <param name="Sampler">Sampler to write to the descriptor in case it's a SAMPLER or COMBINED_IMAGE_SAMPLER descriptor. Ignored otherwise.</param>
        /// <param name="ImageView">Image view to write to the descriptor in case it's a SAMPLED_IMAGE, STORAGE_IMAGE, COMBINED_IMAGE_SAMPLER, or INPUT_ATTACHMENT descriptor. Ignored otherwise.</param>
        /// <param name="ImageLayout">Layout the image is expected to be in when accessed using this descriptor (only used if imageView is not VK_NULL_HANDLE).</param>
        public DescriptorImageInfo(Sampler Sampler, ImageView ImageView, ImageLayout ImageLayout) : this()
        {
            this.Sampler = Sampler;
            this.ImageView = ImageView;
            this.ImageLayout = ImageLayout;
        }
        
        public void Dispose()
        {
            MemUtil.Free(NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~DescriptorImageInfo()
        {
            if(NativePointer != null)
            {
                MemUtil.Free(NativePointer);
                NativePointer = null;
            }
        }
    }
}
