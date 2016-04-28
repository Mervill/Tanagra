using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class SparseImageMemoryRequirements
    {
        internal Interop.SparseImageMemoryRequirements* NativePointer;
        
        SparseImageFormatProperties _FormatProperties;
        public SparseImageFormatProperties FormatProperties
        {
            get { return _FormatProperties; }
            set { _FormatProperties = value; NativePointer->FormatProperties = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 ImageMipTailFirstLod
        {
            get { return NativePointer->ImageMipTailFirstLod; }
            set { NativePointer->ImageMipTailFirstLod = value; }
        }
        
        public DeviceSize ImageMipTailSize
        {
            get { return NativePointer->ImageMipTailSize; }
            set { NativePointer->ImageMipTailSize = value; }
        }
        
        public DeviceSize ImageMipTailOffset
        {
            get { return NativePointer->ImageMipTailOffset; }
            set { NativePointer->ImageMipTailOffset = value; }
        }
        
        public DeviceSize ImageMipTailStride
        {
            get { return NativePointer->ImageMipTailStride; }
            set { NativePointer->ImageMipTailStride = value; }
        }
        
        public SparseImageMemoryRequirements()
        {
            NativePointer = (Interop.SparseImageMemoryRequirements*)Interop.Structure.Allocate(typeof(Interop.SparseImageMemoryRequirements));
        }
    }
}
