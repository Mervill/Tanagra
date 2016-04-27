using System;
using System.Runtime.InteropServices;

namespace Vulkan
{
    unsafe public class ImageFormatProperties
    {
        internal Interop.ImageFormatProperties* NativeHandle;
        
        Extent3D _MaxExtent;
        public Extent3D MaxExtent
        {
            get { return _MaxExtent; }
            set { _MaxExtent = value; NativeHandle->MaxExtent = (IntPtr)value.NativeHandle; }
        }
        
        public UInt32 MaxMipLevels
        {
            get { return NativeHandle->MaxMipLevels; }
            set { NativeHandle->MaxMipLevels = value; }
        }
        
        public UInt32 MaxArrayLayers
        {
            get { return NativeHandle->MaxArrayLayers; }
            set { NativeHandle->MaxArrayLayers = value; }
        }
        
        public SampleCountFlags SampleCounts
        {
            get { return NativeHandle->SampleCounts; }
            set { NativeHandle->SampleCounts = value; }
        }
        
        DeviceSize _MaxResourceSize;
        public DeviceSize MaxResourceSize
        {
            get { return _MaxResourceSize; }
            set { _MaxResourceSize = value; NativeHandle->MaxResourceSize = (IntPtr)value.NativeHandle; }
        }
        
        public ImageFormatProperties()
        {
            NativeHandle = (Interop.ImageFormatProperties*)Interop.Structure.Allocate(typeof(Interop.ImageFormatProperties));
        }
    }
}
