using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageMemoryRequirements
    {
        internal Interop.SparseImageMemoryRequirements* NativeHandle;
        
        SparseImageFormatProperties _FormatProperties;
        public SparseImageFormatProperties FormatProperties
        {
            get { return _FormatProperties; }
            set { _FormatProperties = value; NativeHandle->FormatProperties = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 ImageMipTailFirstLod
        {
            get { return NativeHandle->ImageMipTailFirstLod; }
            set { NativeHandle->ImageMipTailFirstLod = value; }
        }
        
        DeviceSize _ImageMipTailSize;
        public DeviceSize ImageMipTailSize
        {
            get { return _ImageMipTailSize; }
            set { _ImageMipTailSize = value; NativeHandle->ImageMipTailSize = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _ImageMipTailOffset;
        public DeviceSize ImageMipTailOffset
        {
            get { return _ImageMipTailOffset; }
            set { _ImageMipTailOffset = value; NativeHandle->ImageMipTailOffset = (IntPtr)value.NativeHandle; }
        }
        
        DeviceSize _ImageMipTailStride;
        public DeviceSize ImageMipTailStride
        {
            get { return _ImageMipTailStride; }
            set { _ImageMipTailStride = value; NativeHandle->ImageMipTailStride = (IntPtr)value.NativeHandle; }
        }
        
        public SparseImageMemoryRequirements()
        {
            NativeHandle = (Interop.SparseImageMemoryRequirements*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryRequirements));
        }
    }
}
