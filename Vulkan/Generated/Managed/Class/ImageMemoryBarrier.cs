using System;
using System.Runtime.InteropServices;

namespace Vulkan.Managed
{
    unsafe public class ImageMemoryBarrier : IDisposable
    {
        internal Unmanaged.ImageMemoryBarrier* NativePointer;
        
        /// <summary>
        /// Memory accesses from the source of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags SrcAccessMask
        {
            get { return NativePointer->SrcAccessMask; }
            set { NativePointer->SrcAccessMask = value; }
        }
        
        /// <summary>
        /// Memory accesses from the destination of the dependency to synchronize (Optional)
        /// </summary>
        public AccessFlags DstAccessMask
        {
            get { return NativePointer->DstAccessMask; }
            set { NativePointer->DstAccessMask = value; }
        }
        
        /// <summary>
        /// Current layout of the image
        /// </summary>
        public ImageLayout OldLayout
        {
            get { return NativePointer->OldLayout; }
            set { NativePointer->OldLayout = value; }
        }
        
        /// <summary>
        /// New layout to transition the image to
        /// </summary>
        public ImageLayout NewLayout
        {
            get { return NativePointer->NewLayout; }
            set { NativePointer->NewLayout = value; }
        }
        
        /// <summary>
        /// Queue family to transition ownership from
        /// </summary>
        public UInt32 SrcQueueFamilyIndex
        {
            get { return NativePointer->SrcQueueFamilyIndex; }
            set { NativePointer->SrcQueueFamilyIndex = value; }
        }
        
        /// <summary>
        /// Queue family to transition ownership to
        /// </summary>
        public UInt32 DstQueueFamilyIndex
        {
            get { return NativePointer->DstQueueFamilyIndex; }
            set { NativePointer->DstQueueFamilyIndex = value; }
        }
        
        Image _Image;
        /// <summary>
        /// Image to sync
        /// </summary>
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; NativePointer->Image = value.NativePointer; }
        }
        
        /// <summary>
        /// Subresource range to sync
        /// </summary>
        public ImageSubresourceRange SubresourceRange
        {
            get { return NativePointer->SubresourceRange; }
            set { NativePointer->SubresourceRange = value; }
        }
        
        public ImageMemoryBarrier()
        {
            NativePointer = (Unmanaged.ImageMemoryBarrier*)MemUtil.Alloc(typeof(Unmanaged.ImageMemoryBarrier));
            NativePointer->SType = StructureType.ImageMemoryBarrier;
        }
        
        /// <param name="OldLayout">Current layout of the image</param>
        /// <param name="NewLayout">New layout to transition the image to</param>
        /// <param name="SrcQueueFamilyIndex">Queue family to transition ownership from</param>
        /// <param name="DstQueueFamilyIndex">Queue family to transition ownership to</param>
        /// <param name="Image">Image to sync</param>
        /// <param name="SubresourceRange">Subresource range to sync</param>
        public ImageMemoryBarrier(ImageLayout OldLayout, ImageLayout NewLayout, UInt32 SrcQueueFamilyIndex, UInt32 DstQueueFamilyIndex, Image Image, ImageSubresourceRange SubresourceRange) : this()
        {
            this.OldLayout = OldLayout;
            this.NewLayout = NewLayout;
            this.SrcQueueFamilyIndex = SrcQueueFamilyIndex;
            this.DstQueueFamilyIndex = DstQueueFamilyIndex;
            this.Image = Image;
            this.SubresourceRange = SubresourceRange;
        }
        
        public void Dispose()
        {
            MemUtil.Free((IntPtr)NativePointer);
            NativePointer = null;
            GC.SuppressFinalize(this);
        }
        
        ~ImageMemoryBarrier()
        {
            if(NativePointer != null)
            {
                MemUtil.Free((IntPtr)NativePointer);
                NativePointer = null;
            }
        }
    }
}
