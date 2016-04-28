using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageFormatProperties
    {
        internal Interop.ImageFormatProperties* NativePointer;
        
        Extent3D _MaxExtent;
        public Extent3D MaxExtent
        {
            get { return _MaxExtent; }
            set { _MaxExtent = value; NativePointer->MaxExtent = (IntPtr)value.NativePointer; }
        }
        
        public UInt32 MaxMipLevels
        {
            get { return NativePointer->MaxMipLevels; }
            set { NativePointer->MaxMipLevels = value; }
        }
        
        public UInt32 MaxArrayLayers
        {
            get { return NativePointer->MaxArrayLayers; }
            set { NativePointer->MaxArrayLayers = value; }
        }
        
        public SampleCountFlags SampleCounts
        {
            get { return NativePointer->SampleCounts; }
            set { NativePointer->SampleCounts = value; }
        }
        
        public DeviceSize MaxResourceSize
        {
            get { return NativePointer->MaxResourceSize; }
            set { NativePointer->MaxResourceSize = value; }
        }
        
        public ImageFormatProperties()
        {
            NativePointer = (Interop.ImageFormatProperties*)Interop.Structure.Allocate(typeof(Interop.ImageFormatProperties));
        }
    }
}
